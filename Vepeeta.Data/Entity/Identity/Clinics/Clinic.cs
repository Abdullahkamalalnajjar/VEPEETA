using Vepeeta.Data.Entity.Identity.Clinics.Clinic_Services;

namespace Vepeeta.Data.Entity.Identity.Clinics
{
    public class Clinic : User
    {
        public string? ProfileImage { get; set; } = string.Empty;
        public string? Name { get; set; } = string.Empty;
        public string? Specialty { get; set; } = string.Empty;
        public string? LicenseNumber { get; set; } = string.Empty;
        public override string PhoneNumber { get; set; } = null;
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public ICollection<ClincsImage>? ImageUrls { get; set; } = new List<ClincsImage>();

        // إضافة أوقات العمل
        public List<Clinics_WorkingHours>? WorkingHours { get; set; } = new List<Clinics_WorkingHours>();

        //
        public ICollection<ClinicServices>? ClinicServices { get; set; } = new List<ClinicServices>();

    }
}
