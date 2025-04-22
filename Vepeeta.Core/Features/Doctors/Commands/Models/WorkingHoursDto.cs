namespace Vepeeta.Core.Features.Doctors.Commands.Models
{
    public class WorkingHoursDto
    {
        public int Id { get; set; }
        public string Day { get; set; }
        public TimeSpan From { get; set; }
        public TimeSpan To { get; set; }
    }
}
