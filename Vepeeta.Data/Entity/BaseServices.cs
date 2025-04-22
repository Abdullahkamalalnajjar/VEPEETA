using Vepeeta.Data.Entity.Identity.Clinics.Clinic_Services;
using Vepeeta.Data.Entity.MobileVan.MobileVanService;

namespace Vepeeta.Data.Entity
{
    public class BaseServices
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public ICollection<ClinicServices> ClinicServices { get; set; } = new List<ClinicServices>();
        public ICollection<VanServices> VanServices { get; set; } = new List<VanServices>();
    }
}
