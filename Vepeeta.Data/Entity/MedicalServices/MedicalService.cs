using Vepeeta.Data.Entity.Identity.Doctor;

namespace Vepeeta.Data.Entity.MedicalServices
{
    public class MedicalService
    {
        public int Id { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string Type { get; set; }
        // public ICollection<ClientService> ClientServices { get; set; }
        public ICollection<DoctorService> DoctorServices { get; set; }
        //  public ICollection<VanService> VanServices { get; set; }
    }
}
