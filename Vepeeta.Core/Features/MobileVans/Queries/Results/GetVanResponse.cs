using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vepeeta.Core.Features.MobileVans.Queries.Results
{
    public class GetVanResponse
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public bool IsVeterinarian { get; set; }
        public bool IsGroomer { get; set; }
        public string VeterinaryLicensePath { get; set; }
        public string CommercialRegistrationLicensePath { get; set; }
        public string ProfilePhotoPath { get; set; }

        public List<Van_WorkingHoursDto>? WorkingHours { get; set; }
        public List<VanServiceDto>? VanServices { get; set; }

    }
    public class Van_WorkingHoursDto
    {
        public int Id { get; set; }
        public string Day { get; set; } 
        public TimeSpan From { get; set; }
        public TimeSpan To { get; set; }
    }
   
    public class VanServiceDto
    {
        public int Id { get; set; }
        // public int BaseServicesId { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
    }
}

