namespace Vepeeta.Data.Entity.Identity.Clinics
{
    public class Clinics_WorkingHours
    {
        public int Id { get; set; }
        public string Day { get; set; } = string.Empty; // السبت، الأحد، ...
        public TimeSpan From { get; set; }
        public TimeSpan To { get; set; }

        public string ClinicId { get; set; }
        public Clinic Clinic { get; set; }
    }
}

