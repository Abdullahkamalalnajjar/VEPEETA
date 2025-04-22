namespace Vepeeta.Data.Entity.Identity.Doctor
{
    public class DoctorCertificate
    {
        public int Id { get; set; }
        public string CertificateName { get; set; } = string.Empty;


        public string DoctorId { get; set; }
        public Doctor Doctor { get; set; } = null!;
    }
}
