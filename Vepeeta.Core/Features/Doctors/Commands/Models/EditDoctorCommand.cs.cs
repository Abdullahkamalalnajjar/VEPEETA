using MediatR;
using Microsoft.AspNetCore.Http;
using Vepeeta.Core.Bases;

namespace Vepeeta.Core.Features.Doctors.Commands.Models
{
    public class EditDoctorCommand : IRequest<Response<string>>
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? Specialization { get; set; }
        public string? MedicalLicenseNumber { get; set; }
        public IFormFile? PhotosOfMedicalLicense { get; set; }
        public string? MedicalCollege { get; set; }
        public List<EditDoctorCertificateDto>? Certificates { get; set; }
        public string? NameOfClinicOrHospital { get; set; }
        public string? MedicalPracticeAddress { get; set; }
        public string? ConsultationFees { get; set; }
        public IFormFile? ProfilePicture { get; set; }
        public bool? isVideoCallAvailable { get; set; } = false;
        public bool? isVisitHomeAvailable { get; set; } = false;
        public bool? isAudioCallAvailable { get; set; } = false;
        public List<EditDoctorServiceDto>? Services { get; set; }
        public List<EditWorkingHoursDto>? WorkHours { get; set; }
    }

    public class EditDoctorCertificateDto
    {
        public int Id { get; set; }
        public string CertificateName { get; set; }
    }

    public class EditDoctorServiceDto
    {
        public int Id { get; set; } 
        
    }

    public class EditWorkingHoursDto
    {
        public int Id { get; set; }
        public string Day { get; set; }
        public TimeSpan From { get; set; }
        public TimeSpan To { get; set; }
    }
}
