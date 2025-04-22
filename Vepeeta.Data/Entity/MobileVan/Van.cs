using Vepeeta.Data.Entity.Identity;
using Vepeeta.Data.Entity.MobileVan.MobileVanService;

namespace Vepeeta.Data.Entity.MobileVan
{
    public class Van : User
    {
        public bool IsVeterinarian { get; set; }
        public bool IsGroomer { get; set; }

        // Provider documents
        public string? VeterinaryLicensePath { get; set; }
        public string? CommercialRegistrationLicensePath { get; set; }

        // Profile information
        public string? ProfilePhotoPath { get; set; }
        public string? FullName { get; set; }
        public ICollection<VanWorkingHour>? WorkingHours { get; set; }
        public ICollection<VanServices>? VanServices { get; set; }

    }
}
