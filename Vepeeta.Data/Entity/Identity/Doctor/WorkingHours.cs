namespace Vepeeta.Data.Entity.Identity.Doctor
{
    public class WorkingHours
    {
        public int Id { get; set; }
        public string Day { get; set; } = string.Empty;
        public TimeSpan From { get; set; }
        public TimeSpan To { get; set; }
        public string DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
