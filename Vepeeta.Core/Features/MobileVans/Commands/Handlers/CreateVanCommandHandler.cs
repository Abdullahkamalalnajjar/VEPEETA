using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Localization;
using TechTalk.SpecFlow.Analytics.UserId;
using Vepeeta.Api.Helpers;
using Vepeeta.Core.Bases;
using Vepeeta.Core.Features.MobileVans.Commands.Models;
using Vepeeta.Core.Resources;
using Vepeeta.Data.Entity.Identity;
using Vepeeta.Data.Entity.MobileVan;
using Vepeeta.Data.Entity.MobileVan.MobileVanService;
using Vepeeta.Data.Helpers;

namespace Vepeeta.Core.Features.MobileVans.Commands.Handlers
{
    public class CreateVanCommandHandler : ResponseHandler,
        IRequestHandler<CreateVanCommand, Response<string>>,
        IRequestHandler<DeleteVanCommand, Response<string>>,
        IRequestHandler<EditVanCommand, Response<string>>
    {
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IMemoryCache _memoryCache;
        private readonly EmailHelper _emailHelper;
        private readonly UserManager<User> _userManager;
        private readonly ResponseHandler _responseHandler;

        public CreateVanCommandHandler(IMapper mapper, IFileService fileService, IStringLocalizer<SharedResources> localizer, IMemoryCache memoryCache, EmailHelper emailHelper, UserManager<User> userManager, ResponseHandler responseHandler) : base(localizer)
        {
            _mapper = mapper;
            _fileService = fileService;
            _localizer = localizer;
            _memoryCache = memoryCache;
            _emailHelper = emailHelper;
            _userManager = userManager;
            _responseHandler = responseHandler;
        }

        public async Task<Response<string>> Handle(CreateVanCommand request, CancellationToken cancellationToken)
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
            var user = _mapper.Map<Van>(request);
            user.WorkingHours = request.WorkingHours?.ConvertAll(c => new VanWorkingHour { Day = c.Day, From = c.From, To = c.To });
            user.VanServices = request.VanServices?.Select(serviceId => new VanServices { BaseServicesId = serviceId }).ToList() ?? new List<VanServices>();

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

        public async Task<Response<string>> Handle(DeleteVanCommand request, CancellationToken cancellationToken)
        {
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

        public async Task<Response<string>> Handle(EditVanCommand request, CancellationToken cancellationToken)
        {
            var checkVan = await _userManager.Users.OfType<Van>()
                .Include(x => x.VanServices)
                .Include(x => x.WorkingHours)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (checkVan == null)
                return NotFound<string>("Van not found.");

            // تحديث الحقول الأساسية
            if (!string.IsNullOrEmpty(request.FullName) && request.FullName != checkVan.FullName)
                checkVan.FullName = request.FullName;

            if (!string.IsNullOrEmpty(request.Email) && request.Email != checkVan.Email)
                checkVan.Email = request.Email;

            if (!string.IsNullOrEmpty(request.PhoneNumber) && request.PhoneNumber != checkVan.PhoneNumber)
                checkVan.PhoneNumber = request.PhoneNumber;

            if (request.IsVeterinarian.HasValue && request.IsVeterinarian != checkVan.IsVeterinarian)
                checkVan.IsVeterinarian = request.IsVeterinarian.Value;

            if (request.IsGroomer.HasValue && request.IsGroomer != checkVan.IsGroomer)
                checkVan.IsGroomer = request.IsGroomer.Value;

            // ملفات الصور
            if (request.VeterinaryLicensePath != null)
                checkVan.VeterinaryLicensePath = FileHelper.SaveFile(request.VeterinaryLicensePath, "VanLicenses");

            if (request.CommercialRegistrationLicensePath != null)
                checkVan.CommercialRegistrationLicensePath = FileHelper.SaveFile(request.CommercialRegistrationLicensePath, "VanLicenses");

            if (request.ProfilePhotoPath != null)
                checkVan.ProfilePhotoPath = FileHelper.SaveFile(request.ProfilePhotoPath, "VanPhotos");

            // تعديل ساعات العمل
            if (request.WorkingHours != null)
            {
                // حذف الساعات اللي مش موجودة في الطلب
                checkVan.WorkingHours = checkVan.WorkingHours
                    .Where(existing => request.WorkingHours.Any(r => r.Id == existing.Id))
                    .ToList();

                // تعديل أو إضافة الساعات
                foreach (var item in request.WorkingHours)
                {
                    var existing = checkVan.WorkingHours.FirstOrDefault(x => x.Id == item.Id);
                    if (existing != null)
                    {
                        existing.Day = item.Day;
                        existing.From = item.From;
                        existing.To = item.To;
                    }
                    else
                    {
                        checkVan.WorkingHours.Add(new VanWorkingHour
                        {
                            Day = item.Day,
                            From = item.From,
                            To = item.To,
                            VanId = checkVan.Id
                        });
                    }
                }
            }

            // تعديل الخدمات
            if (request.VanServices != null)
            {
                var newServiceIds = request.VanServices;

                // حذف الخدمات اللي مش موجودة في الطلب
                checkVan.VanServices = checkVan.VanServices
                    .Where(s => newServiceIds.Contains(s.BaseServicesId))
                    .ToList();

                // إضافة الخدمات الجديدة
                foreach (var id in newServiceIds)
                {
                    if (!checkVan.VanServices.Any(s => s.BaseServicesId == id))
                    {
                        checkVan.VanServices.Add(new VanServices
                        {
                            BaseServicesId = id,
                            VanId = checkVan.Id
                        });
                    }
                }
            }

            // حفظ التعديلات
            var result = await _userManager.UpdateAsync(checkVan);
            if (result.Succeeded)
                return Success("Van updated successfully.");

            return BadRequest<string>(result.Errors.FirstOrDefault()?.Description ?? "An error occurred while updating the van.");
        }


    }
}



