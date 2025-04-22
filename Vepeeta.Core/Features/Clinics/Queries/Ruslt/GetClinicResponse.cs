using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vepeeta.Core.Features.Clinics.Queries.Ruslt
{
    public class GetClinicResponse
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? ProfileImage { get; set; }
        public string? Name { get; set; }
        public string? Specialty { get; set; }
        public string? LicenseNumber { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public ICollection<ClincsImageDto>? ImageUrls { get; set; }

        // إضافة أوقات العمل
        public List<Clinics_WorkingHoursDto>? WorkingHours { get; set; }
        public List<ClinicServiceDto>? ClinicServices { get; set; }

    }
    public class Clinics_WorkingHoursDto
    {
        public int Id { get; set; }
        public string Day { get; set; } = string.Empty;
        public TimeSpan From { get; set; }
        public TimeSpan To { get; set; }
    }
    public class ClincsImageDto
    {
        public int? Id { get; set; }
        public string ImageUrl { get; set; }

    }
    public class ClinicServiceDto
    {
        public int Id { get; set; }
        // public int BaseServicesId { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
    }

}
