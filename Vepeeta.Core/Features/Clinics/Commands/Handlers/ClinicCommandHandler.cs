using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Localization;
using Vepeeta.Api.Helpers;
using Vepeeta.Core.Bases;
using Vepeeta.Core.Features.Clinics.Commands.Models;
using Vepeeta.Core.Resources;
using Vepeeta.Data.Entity.Identity;
using Vepeeta.Data.Entity.Identity.Clinics;
using Vepeeta.Data.Entity.Identity.Clinics.Clinic_Services;
using Vepeeta.Data.Helpers;

namespace Vepeeta.Core.Features.Clinics.Commands.Handlers
{
    public class ClinicCommandHandler : ResponseHandler,
        IRequestHandler<CreateClinicCommand, Response<string>>,
          IRequestHandler<DeleteClinicCommand, Response<string>>,
        IRequestHandler<EditClinicCommand, Response<string>>
    {
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IMemoryCache _memoryCache;
        private readonly EmailHelper _emailHelper;
        private readonly UserManager<User> _userManager;
        private readonly ResponseHandler _responseHandler;

        public ClinicCommandHandler(IMapper mapper, IStringLocalizer<SharedResources> localizer, IMemoryCache memoryCache, EmailHelper emailHelper, UserManager<User> userManager, ResponseHandler responseHandler) : base(localizer)
        {
            _mapper = mapper;
            _localizer = localizer;
            _memoryCache = memoryCache;
            _emailHelper = emailHelper;
            _userManager = userManager;
            _responseHandler = responseHandler;
        }


        public async Task<Response<string>> Handle(CreateClinicCommand request, CancellationToken cancellationToken)
        {
            // التحقق من وجود بريد إلكتروني مسجل مسبقًا
            var checkEmailUser = await _userManager.FindByEmailAsync(request.Email);
            if (checkEmailUser != null)
                return BadRequest<string>("Email already exists.");

            // التحقق من وجود رقم الهاتف مسجل مسبقًا
            if (!string.IsNullOrEmpty(request.PhoneNumber))
            {
                var checkPhoneNumber = await _userManager.Users
                    .Where(x => x.PhoneNumber.Equals(request.PhoneNumber))
                    .FirstOrDefaultAsync();
                if (checkPhoneNumber != null)
                    return BadRequest<string>("Phone number already exists.");
            }

            // التحقق من وجود OTP مُخزن في الـ Cache
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

            // تحويل البيانات من CreateClinicCommand إلى Clinic و ClinicServices و Clinics_WorkingHours
            var clinic = _mapper.Map<Clinic>(request);
            // تأكد من أن request.Services ليست null قبل التعيين
            clinic.ClinicServices = request.Services?.Select(serviceId => new ClinicServices { BaseServicesId = serviceId }).ToList() ?? new List<ClinicServices>();

            // تأكد من أن request.WorkHours ليست null قبل التعيين
            clinic.WorkingHours = request.WorkHours?.Select(wh => new Clinics_WorkingHours
            {
                Day = wh.Day,
                From = wh.From,
                To = wh.To
            }).ToList() ?? new List<Clinics_WorkingHours>();


            // إنشاء العيادة
            var result = await _userManager.CreateAsync(clinic, request.Password);

            if (!result.Succeeded)
            {
                var localizedErrors = result.Errors
                    .Select(error => error.Description)
                    .ToList();
                return BadRequest<string>(localizedErrors.FirstOrDefault());
            }

            await _emailHelper.SendEmailAsync(request.Email, "Thank You,", "Account has been Created Successfully");
            return Created("Clinic created successfully.");
        }

        public async Task<Response<string>> Handle(DeleteClinicCommand request, CancellationToken cancellationToken)
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
        //last v 8/4
        public async Task<Response<string>> Handle(EditClinicCommand request, CancellationToken cancellationToken)
        {
            // تحقق من وجود العيادة باستخدام ID
            var checkClinic = await _userManager.Users.OfType<Clinic>()
                .Include(x => x.ClinicServices)
                .Include(x => x.WorkingHours)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (checkClinic == null)
                return NotFound<string>("Clinic not found.");

            // تحديث الحقول التي تم تعديلها فقط
            if (!string.IsNullOrEmpty(request.Name) && request.Name != checkClinic.Name)
                checkClinic.Name = request.Name;

            if (!string.IsNullOrEmpty(request.Email) && request.Email != checkClinic.Email)
                checkClinic.Email = request.Email;

            if (!string.IsNullOrEmpty(request.PhoneNumber) && request.PhoneNumber != checkClinic.PhoneNumber)
                checkClinic.PhoneNumber = request.PhoneNumber;

            if (!string.IsNullOrEmpty(request.Specialty) && request.Specialty != checkClinic.Specialty)
                checkClinic.Specialty = request.Specialty;

            if (!string.IsNullOrEmpty(request.LicenseNumber) && request.LicenseNumber != checkClinic.LicenseNumber)
                checkClinic.LicenseNumber = request.LicenseNumber;

            // تحديث صور العيادة المتعددة إذا كانت موجودة
            if (request.ImageUrls != null && request.ImageUrls.Count > 0)
            {
                try
                {
                    var images = FileHelper.SaveFilesOfClincImageAsImages(request.ImageUrls, "Clinics");
                    checkClinic.ImageUrls = images;
                }
                catch (Exception ex)
                {
                    return BadRequest<string>($"Error saving images: {ex.Message}");
                }
            }

            // تحديث الخدمات المرتبطة بالعيادة إذا كانت موجودة
            if (request.Services != null && request.Services.Count > 0)
            {
                // مسح الخدمات القديمة
                checkClinic.ClinicServices.Clear();

                // إضافة الخدمات الجديدة
                foreach (var serviceId in request.Services)
                {
                    checkClinic.ClinicServices.Add(new ClinicServices { BaseServicesId = serviceId });
                }
            }

            // تحديث ساعات العمل إذا كانت موجودة
            if (request.WorkHours != null && request.WorkHours.Count > 0)
            {
                checkClinic.WorkingHours.Clear();
                foreach (var workHour in request.WorkHours)
                {
                    checkClinic.WorkingHours.Add(new Clinics_WorkingHours
                    {
                        Day = workHour.Day,
                        From = workHour.From,
                        To = workHour.To
                    });
                }
            }

            // حفظ التعديلات
            var result = await _userManager.UpdateAsync(checkClinic);

            if (result.Succeeded)
                return Success("Clinic updated successfully.");

            return BadRequest<string>(result.Errors.FirstOrDefault()?.Description ?? "An error occurred while updating the clinic.");
        }

    }
}

