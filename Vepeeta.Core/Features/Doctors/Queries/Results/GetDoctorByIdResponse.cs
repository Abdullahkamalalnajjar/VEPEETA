namespace Vepeeta.Core.Features.Doctors.Queries.Results
{
    public class GetDoctorByIdResponse
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? FullName { get; set; }
        public string? Specialization { get; set; }
        public string? MedicalLicenseNumber { get; set; }
        public string? PhotosOfMedicalLicense { get; set; }
        public string? ProfilePicture { get; set; }
        public string? MedicalCollege { get; set; }
        public List<DoctorCertificateDto>? Certificates { get; set; } = new();
        public string? NameOfClinicOrHospital { get; set; }
        public string? MedicalPracticeAddress { get; set; }
        public string? ConsultationFees { get; set; }
        public string? Address { get; set; }
        public bool? isVideoCallAvailable { get; set; }
        public bool? isVisitHomeAvailable { get; set; }
        public bool? isAudioCallAvailable { get; set; }
        public List<WorkingHoursDto>? WorkHours { get; set; }

    }

}
