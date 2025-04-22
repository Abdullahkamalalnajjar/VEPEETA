namespace Vepeeta.Data.Entity.Identity.Clinics.Clinic_Services
{
    public class ClinicServices
    {
        public int Id { get; set; }
        public int BaseServicesId { get; set; }
        public BaseServices BaseServices { get; set; }
        public string ClinicId { get; set; }
        public Clinic Clinic { get; set; }
    }
}
