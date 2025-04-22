using Vepeeta.Data.Entity.Identity.Doctor;

namespace Vepeeta.Data.Entity
{
    public class Rateing
    {
        public int Id { get; set; }
        public double Rate { get; set; } = 0.0;
        public string? Comments { get; set; }
        public string DoctorId { get; set; }
        public Doctor Doctor { get; set; }

    }
}
