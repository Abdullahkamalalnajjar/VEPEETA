using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Localization;
using Vepeeta.Api.Helpers;
using Vepeeta.Core.Bases;
using Vepeeta.Core.Features.AppUser.Command.Models;
using Vepeeta.Core.Resources;
using Vepeeta.Data.Entity.Identity;

namespace Vepeeta.Core.Features.AppUser.Command.Handler
{
    public class UserCommandHandler : ResponseHandler,
    IRequestHandler<CreateUserCommand, Response<string>>,
       IRequestHandler<EditUserCommand, Response<string>>,
       IRequestHandler<DeleteUserCommand, Response<string>>
    {
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IMemoryCache _memoryCache;
        private readonly EmailHelper _emailHelper;
        private readonly UserManager<User> _userManager;
        private readonly ResponseHandler _responseHandler;

        public UserCommandHandler(IMapper mapper, IStringLocalizer<SharedResources> localizer, IMemoryCache memoryCache, EmailHelper emailHelper, UserManager<User> userManager, ResponseHandler responseHandler) : base(localizer)
        {
            _mapper = mapper;
            _localizer = localizer;
            _memoryCache = memoryCache;
            _emailHelper = emailHelper;
            _userManager = userManager;
            _responseHandler = responseHandler;
        }
        public async Task<Response<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var checkEmailUser = await _userManager.FindByEmailAsync(request.Email);
            if (checkEmailUser != null)
                return BadRequest<string>(_localizer[SharedResourcesKeys.Email] + ":" + _localizer[SharedResourcesKeys.IsExist]);

            if (!string.IsNullOrEmpty(request.PhoneNumber))
            {
                var checkPhoneNumber = await _userManager.Users
                    .Where(x => x.PhoneNumber.Equals(request.PhoneNumber))
                    .FirstOrDefaultAsync();
                if (checkPhoneNumber != null)
                    return BadRequest<string>(_localizer[SharedResourcesKeys.PhoneNumber] + ":" + _localizer[SharedResourcesKeys.IsExist]);
            }

            // التحقق مما إذا كان هناك OTP مُخزن
            if (_memoryCache.TryGetValue(request.Email, out string cachedOtp))
            {
                if (string.IsNullOrEmpty(request.Otp) || request.Otp != cachedOtp)
                    return BadRequest<string>("Invalid OTP or OTP expired.");

                // حذف الـ OTP بعد التحقق الناجح
                _memoryCache.Remove(request.Email);
            }
            else
            {
                // في حالة عدم وجود OTP سابق، يتم إرساله الآن
                var otp = new Random().Next(100000, 999999).ToString();
                _memoryCache.Set(request.Email, otp, TimeSpan.FromMinutes(10)); // حفظ الـ OTP لمدة 10 دقائق

                var subject = "Your OTP Code";
                var body = $"<p>Your OTP code is: <strong>{otp}</strong> to verify your email for registration</p>";

                try
                {
                    await _emailHelper.SendEmailAsync(request.Email, subject, body);
                    return Success("OTP has been sent to your email. Please enter it to complete the registration.");
                }
                catch (Exception ex)
                {
                    return BadRequest<string>($"Error sending OTP: {ex.Message}");
                }
            }

            // بعد التحقق من OTP، يتم إنشاء المستخدم
            var user = _mapper.Map<PetOwner>(request);
            await _userManager.SetPhoneNumberAsync(user, request.PhoneNumber);
            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                var localizedErrors = result.Errors
                    .Select(error => _localizer[$"{error.Code}"] ?? error.Description)
                    .ToList();
                return BadRequest<string>(localizedErrors.FirstOrDefault()!);
            }
            await _emailHelper.SendEmailAsync(request.Email, "Thank You,", "Account has been Created Succssfully");
            return Created(_localizer[SharedResourcesKeys.SignUpSuccess].Value);
        }


        public async Task<Response<string>> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            // تحقق من وجود المستخدم
            var checkIdUser = await _userManager.Users.OfType<PetOwner>().FirstOrDefaultAsync(x => x.Id == request.Id);
            if (checkIdUser == null) return NotFound<string>();

            // تحديث الحقول المطلوبة فقط
            _mapper.Map(request, checkIdUser);
            // تحديث رقم الهاتف باستخدام SetPhoneNumberAsync
            if (!string.IsNullOrEmpty(request.PhoneNumber) && request.PhoneNumber != checkIdUser.PhoneNumber)
            {
                var phoneUpdateResult = await _userManager.SetPhoneNumberAsync(checkIdUser, request.PhoneNumber);

            }
            // تحديث المستخدم في قاعدة البيانات
            var result = await _userManager.UpdateAsync(checkIdUser);

            if (result.Succeeded)
                return Updated(_localizer[SharedResourcesKeys.Updated].Value);
            return BadRequest<string>(result.Errors.FirstOrDefault()?.Description!);

        }

        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            // التحقق مما إذا كان المستخدم موجودًا أم لا
            var checkUser = await _userManager.Users
                .FirstOrDefaultAsync(i => i.Id == request.Id, cancellationToken);

            if (checkUser == null)
                return _responseHandler.Fail<string>(_localizer[SharedResourcesKeys.UserNotFound]);

            // محاولة حذف المستخدم
            var result = await _userManager.DeleteAsync(checkUser);
            if (!result.Succeeded)
                return _responseHandler.Fail<string>(
                    _localizer[SharedResourcesKeys.FaildDeleteUser] + " " +
                    string.Join(", ", result.Errors.Select(e => _localizer[e.Code] ?? e.Description))
                );

            return _responseHandler.Success<string>(_localizer[SharedResourcesKeys.DeleteUser]);
        }

    }
}


