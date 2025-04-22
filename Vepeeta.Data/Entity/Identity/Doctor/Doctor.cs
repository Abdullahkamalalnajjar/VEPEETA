namespace Vepeeta.Data.Entity.Identity.Doctor
{
    public class Doctor : User
    {
        public string? ProfilePicture { get; set; } //الصورة الشخصية
        public string? FullName { get; set; }
        public string? Specialization { get; set; }
        public string? MedicalLicenseNumber { get; set; }
        public string? PhotosOfMedicalLicense { get; set; }//الصور
        public string? MedicalCollege { get; set; }
        public List<DoctorCertificate>? Certificates { get; set; } = new(); //الصور 
        public string? NameOfClinicOrHospital { get; set; }
        public string? MedicalPracticeAddress { get; set; }
        public string? ConsultationFees { get; set; }
        public bool? isVideoCallAvailable { get; set; } = false;
        public bool? isVisitHomeAvailable { get; set; } = false;
        public bool? isAudioCallAvailable { get; set; } = false;
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string? Address { get; set; }
        public List<WorkingHours>? WorkHours { get; set; } = new();
        public List<Rateing>? Rateing { get; set; } = new();
        public ICollection<DoctorService>? DoctorServices { get; set; }

    }
}
