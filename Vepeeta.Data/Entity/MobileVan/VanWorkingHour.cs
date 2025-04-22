namespace Vepeeta.Data.Entity.MobileVan
{
    public class VanWorkingHour
    {
        public int Id { get; set; }
        public string Day { get; set; } = string.Empty;
        public TimeSpan From { get; set; }
        public TimeSpan To { get; set; }
        public string VanId { get; set; }
        public Van Van { get; set; }
    }
}
