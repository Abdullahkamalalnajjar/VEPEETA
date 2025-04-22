using MediatR;
using Microsoft.AspNetCore.Http;
using Vepeeta.Core.Bases;

namespace Vepeeta.Core.Features.MobileVans.Commands.Models
{
    public class CreateVanCommand : IRequest<Response<string>>
    {
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string? FullName { get; set; }
        public bool? IsVeterinarian { get; set; }
        public bool?IsGroomer { get; set; }
        public IFormFile? VeterinaryLicensePath { get; set; }
        public IFormFile? CommercialRegistrationLicensePath { get; set; }
        public IFormFile? ProfilePhotoPath { get; set; }

        public List<CreateVanWorkingHoursDto>? WorkingHours { get; set; } 
        public List<int>? VanServices { get; set; } 
        public string? Otp { get; set; }
    }
    public class CreateVanWorkingHoursDto
    {
        public string Day { get; set; }
        public TimeSpan From { get; set; }
        public TimeSpan To { get; set; }
    }
}
