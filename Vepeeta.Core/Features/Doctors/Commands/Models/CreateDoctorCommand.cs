using MediatR;
using Microsoft.AspNetCore.Http;
using Vepeeta.Core.Bases;

namespace Vepeeta.Core.Features.Doctors.Commands.Models
{
    public class CreateDoctorCommand : IRequest<Response<string>>
    {
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string? FullName { get; set; }
        public string? Specialization { get; set; }
        public string? MedicalLicenseNumber { get; set; }
        public IFormFile? ProfilePicture { get; set; }
        public IFormFile? PhotosOfMedicalLicense { get; set; }
        public string? MedicalCollege { get; set; }
        public List<string>? Certificates { get; set; }
        public string? NameOfClinicOrHospital { get; set; }
        public string? MedicalPracticeAddress { get; set; }
        public string? ConsultationFees { get; set; }
        public bool? isVideoCallAvailable { get; set; }
        public bool? isVisitHomeAvailable { get; set; }
        public bool? isAudioCallAvailable { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string? Address { get; set; }
        public List<int>? Services { get; set; } = new();
        public List<CreateWorkingHoursDto>? WorkHours { get; set; }
        public string? Otp { get; set; }
    }

    public class CreateWorkingHoursDto
    {
        public string Day { get; set; }
        public TimeSpan From { get; set; }
        public TimeSpan To { get; set; }
    }
}
