using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vepeeta.Core.Features.Clinics.Commands.Models;
using Vepeeta.Data.Entity.Identity.Clinics;
using Vepeeta.Data.Helpers;

namespace Vepeeta.Core.Mapping.Clinics
{
    public partial class ClinicProfile
    {


        public void EditClinicCommandMapping()
        {
            CreateMap<EditClinicCommand, Clinic>()
              .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
              .ForMember(dest => dest.Specialty, opt => opt.MapFrom(src => src.Specialty))
              .ForMember(dest => dest.LicenseNumber, opt => opt.MapFrom(src => src.LicenseNumber))
              .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
              .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Latitude))
              .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Longitude))
             .ForMember(dest => dest.ProfileImage, opt => opt.MapFrom(src => FileHelper.SaveFile(src.ProfileImage, "ClinicImages")))
             .ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => FileHelper.SaveFilesOfClincImageAsImages(src.ImageUrls, "ClinicImages")))
             .ForMember(dest => dest.ClinicServices, opt => opt.MapFrom(src => src.Services)) // Assuming we need to map Services to ClinicServices
             .ForMember(dest => dest.WorkingHours, opt => opt.MapFrom(src => src.WorkHours));

        }
    }
}
