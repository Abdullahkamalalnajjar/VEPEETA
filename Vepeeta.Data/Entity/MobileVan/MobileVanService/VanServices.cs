namespace Vepeeta.Data.Entity.MobileVan.MobileVanService
{
    public class VanServices
    {
        public int Id { get; set; }
        public int BaseServicesId { get; set; }
        public BaseServices BaseServices { get; set; }
        public string VanId { get; set; }
        public Van Van { get; set; }
    }
}
