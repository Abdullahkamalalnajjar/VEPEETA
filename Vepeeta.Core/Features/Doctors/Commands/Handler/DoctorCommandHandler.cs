using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Localization;
using TechTalk.SpecFlow.Analytics.UserId;
using Vepeeta.Api.Helpers;
using Vepeeta.Core.Bases;
using Vepeeta.Core.Features.Doctors.Commands.Models;
using Vepeeta.Core.Resources;
using Vepeeta.Data.Entity.Identity;
using Vepeeta.Data.Entity.Identity.Doctor;
using Vepeeta.Data.Helpers;

namespace Vepeeta.Core.Features.Doctors.Commands.Handler
{
    public class DoctorCommandHandler : ResponseHandler,
        IRequestHandler<CreateDoctorCommand, Response<string>>,
        IRequestHandler<EditDoctorCommand, Response<string>>,
        IRequestHandler<DeleteDoctorCommand, Response<string>>
    {
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IMemoryCache _memoryCache;
        private readonly EmailHelper _emailHelper;
        private readonly ResponseHandler _responseHandler;
        private readonly UserManager<User> _userManager;

        public DoctorCommandHandler(IMapper mapper, IFileService fileService, IStringLocalizer<SharedResources> localizer, IMemoryCache memoryCache, EmailHelper emailHelper, ResponseHandler responseHandler, UserManager<User> userManager) : base(localizer)
        {
            _mapper = mapper;
            _fileService = fileService;
            _localizer = localizer;
            _memoryCache = memoryCache;
            _emailHelper = emailHelper;
            _responseHandler = responseHandler;
            _userManager = userManager;
        }
        #region CreateDoctorCommand


        public async Task<Response<string>> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
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
            var user = _mapper.Map<Doctor>(request);
            user.Certificates = request.Certificates?.ConvertAll(c => new DoctorCertificate { CertificateName = c });
            user.WorkHours = request.WorkHours?.ConvertAll(c => new WorkingHours { Day = c.Day, From = c.From, To = c.To });
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

        #endregion

        #region DeleteDoctorCommand

        public async Task<Response<string>> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
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
        #endregion

        #region EditDoctorCommand

        public async Task<Response<string>> Handle(EditDoctorCommand request, CancellationToken cancellationToken)
        {
            // تحقق من وجود المستخدم
            var checkIdUser = await _userManager.Users.OfType<Doctor>()
                .Include(x => x.WorkHours)
                .Include(x => x.Certificates)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (checkIdUser == null)
                return NotFound<string>();

            // تحديث الحقول التي تم تعديلها فقط
            if (!string.IsNullOrEmpty(request.FullName) && request.FullName != checkIdUser.FullName)
                checkIdUser.FullName = request.FullName;

            if (!string.IsNullOrEmpty(request.Email) && request.Email != checkIdUser.Email)
                checkIdUser.Email = request.Email;

            if (!string.IsNullOrEmpty(request.PhoneNumber) && request.PhoneNumber != checkIdUser.PhoneNumber)
                checkIdUser.PhoneNumber = request.PhoneNumber;

            if (!string.IsNullOrEmpty(request.Specialization) && request.Specialization != checkIdUser.Specialization)
                checkIdUser.Specialization = request.Specialization;

            if (!string.IsNullOrEmpty(request.MedicalLicenseNumber) && request.MedicalLicenseNumber != checkIdUser.MedicalLicenseNumber)
                checkIdUser.MedicalLicenseNumber = request.MedicalLicenseNumber;

            if (!string.IsNullOrEmpty(request.MedicalCollege) && request.MedicalCollege != checkIdUser.MedicalCollege)
                checkIdUser.MedicalCollege = request.MedicalCollege;

            if (!string.IsNullOrEmpty(request.NameOfClinicOrHospital) && request.NameOfClinicOrHospital != checkIdUser.NameOfClinicOrHospital)
                checkIdUser.NameOfClinicOrHospital = request.NameOfClinicOrHospital;

            if (!string.IsNullOrEmpty(request.MedicalPracticeAddress) && request.MedicalPracticeAddress != checkIdUser.MedicalPracticeAddress)
                checkIdUser.MedicalPracticeAddress = request.MedicalPracticeAddress;

            if (!string.IsNullOrEmpty(request.ConsultationFees) && request.ConsultationFees != checkIdUser.ConsultationFees)
                checkIdUser.ConsultationFees = request.ConsultationFees;

            // التحقق من صور الترخيص
            if (request.PhotosOfMedicalLicense != null)
            {
                checkIdUser.PhotosOfMedicalLicense = FileHelper.SaveFile(request.PhotosOfMedicalLicense, "PhotosOfMedicalLicenses");
            }

            // التحقق من الصورة الشخصية
            if (request.ProfilePicture != null)
            {
                checkIdUser.ProfilePicture = FileHelper.SaveFile(request.ProfilePicture, "ProfileImageOFDoctor");
            }

            // تحديث الشهادات فقط إذا كانت موجودة
            if (request.Certificates != null)
            {
                foreach (var certificateDto in request.Certificates)
                {
                    var certificate = checkIdUser.Certificates.FirstOrDefault(x => x.Id == certificateDto.Id);
                    if (certificate != null)
                    {
                        certificate.CertificateName = certificateDto.CertificateName;
                    }
                    else
                    {
                        checkIdUser.Certificates.Add(new DoctorCertificate
                        {
                            CertificateName = certificateDto.CertificateName
                        });
                    }
                }
            }

            // تحديث ساعات العمل فقط إذا كانت موجودة
            if (request.WorkHours != null)
            {
                foreach (var workHourDto in request.WorkHours)
                {
                    if (workHourDto.Id != 0) // تحديث البيانات إذا كان لها ID
                    {
                        var existingWorkHour = checkIdUser.WorkHours.FirstOrDefault(x => x.Id == workHourDto.Id);
                        if (existingWorkHour != null)
                        {
                            existingWorkHour.Day = workHourDto.Day;
                            existingWorkHour.From = workHourDto.From;
                            existingWorkHour.To = workHourDto.To;
                        }
                    }
                    else // إضافة بيانات جديدة إذا لم يكن هناك ID
                    {
                        checkIdUser.WorkHours.Add(new WorkingHours
                        {
                            Day = workHourDto.Day,
                            From = workHourDto.From,
                            To = workHourDto.To
                        });
                    }
                }
            }

            // تحديث المستخدم في قاعدة البيانات
            var result = await _userManager.UpdateAsync(checkIdUser);

            if (result.Succeeded)
                return Updated(_localizer[SharedResourcesKeys.Updated].Value);

            return BadRequest<string>(result.Errors.FirstOrDefault()?.Description!);
        }

        #endregion

    }
}
