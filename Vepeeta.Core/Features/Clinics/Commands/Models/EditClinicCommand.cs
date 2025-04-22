using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vepeeta.Core.Bases;

namespace Vepeeta.Core.Features.Clinics.Commands.Models
{
    public class EditClinicCommand : IRequest<Response<string>>
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IFormFile? ProfileImage { get; set; }
        public string? Name { get; set; }
        public string? Specialty { get; set; }
        public string? LicenseNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public List<IFormFile>? ImageUrls { get; set; }
        public List<int>? Services { get; set; }
        public List<EditWorkingHoursOfClinicDto>? WorkHours { get; set; }

    }
    public class EditWorkingHoursOfClinicDto
    {
        public string Day { get; set; }
        public TimeSpan From { get; set; }
        public TimeSpan To { get; set; }
    }
}
