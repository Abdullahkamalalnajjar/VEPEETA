using MediatR;
using Microsoft.AspNetCore.Http;
using Vepeeta.Core.Bases;

namespace Vepeeta.Core.Features.Clinics.Commands.Models
{
    public class CreateClinicCommand : IRequest<Response<string>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public IFormFile? ProfileImage { get; set; }
        public string? Name { get; set; }
        public string? Specialty { get; set; }
        public string? LicenseNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public List<IFormFile>? ImageUrls { get; set; }
        public List<int>? Services { get; set; }
        public List<CreateWorkingHoursOfClinicDto>? WorkHours { get; set; }

        public string? Otp { get; set; }

    }
    public class CreateWorkingHoursOfClinicDto
    {
        public string Day { get; set; }
        public TimeSpan From { get; set; }
        public TimeSpan To { get; set; }
    }
}
