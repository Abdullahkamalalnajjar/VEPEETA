namespace Vepeeta.Data.Entity.Identity.Clinics
{
    public class ClincsImage
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }

        public string ClinicId { get; set; }
        public Clinic Clinics { get; set; }
    }
}
