using Vepeeta.Data.Entity.MedicalServices;

namespace Vepeeta.Data.Entity.Identity.Doctor
{
    public class DoctorService
    {
        public int Id { get; set; }
        public string DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int MedicalServiceId { get; set; }
        public MedicalService MedicalService { get; set; }

    }
}

