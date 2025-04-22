using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vepeeta.Core.Bases;

namespace Vepeeta.Core.Features.MobileVans.Commands.Models
{
    public class EditVanCommand : IRequest<Response<string>>
    {

        public string Id { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? FullName { get; set; }
        public bool? IsVeterinarian { get; set; }
        public bool? IsGroomer { get; set; }

        // الحقول الخاصة بالملفات (رخصة البيطرة، الترخيص التجاري، والصورة الشخصية)
        public IFormFile? VeterinaryLicensePath { get; set; }
        public IFormFile? CommercialRegistrationLicensePath { get; set; }
        public IFormFile? ProfilePhotoPath { get; set; }

        public List<EditVanWorkingHoursDto>? WorkingHours { get; set; }


        public List<int>? VanServices { get; set; }
    }


    public class EditVanWorkingHoursDto
    {
        public int Id { get; set; }
        public string Day { get; set; }
        public TimeSpan From { get; set; }
        public TimeSpan To { get; set; }
    }

    public class EditVanServicesDto
    {
        public int Id { set; get; }

    }

}
