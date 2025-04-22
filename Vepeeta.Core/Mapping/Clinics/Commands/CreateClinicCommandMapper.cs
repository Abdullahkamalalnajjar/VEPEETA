using Vepeeta.Core.Features.Clinics.Commands.Models;
using Vepeeta.Data.Entity.Identity.Clinics;
using Vepeeta.Data.Entity.Identity.Clinics.Clinic_Services;
using Vepeeta.Data.Helpers;

namespace Vepeeta.Core.Mapping.Clinics
{
    public partial class ClinicProfile
    {
        public void CreateClinicCommandMapper()
        {
            // تحويل الـ CreateClinicCommand إلى Clinic
            CreateMap<CreateClinicCommand, Clinic>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Specialty, opt => opt.MapFrom(src => src.Specialty))
                .ForMember(dest => dest.LicenseNumber, opt => opt.MapFrom(src => src.LicenseNumber))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                 .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Latitude))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Longitude))
                .ForMember(dest => dest.ProfileImage, opt => opt.MapFrom(src => FileHelper.SaveFile(src.ProfileImage, "ClinicImages")))
                .ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => FileHelper.SaveFilesOfClincImageAsImages(src.ImageUrls, "ClinicImages")));

            // تحويل الـ CreateClinicCommand إلى ClinicServices
            CreateMap<CreateClinicCommand, ClinicServices>()
                .ForMember(dest => dest.BaseServicesId, opt => opt.MapFrom(src => src.Services))
                .ForMember(dest => dest.ClinicId, opt => opt.Ignore())  // ClinicId سيتم تعيينه لاحقًا
                .ForMember(dest => dest.BaseServices, opt => opt.Ignore());  // سيتم تعيين BaseServices لاحقًا عبر الـ ID

            // تحويل الـ CreateClinicCommand إلى Clinics_WorkingHours
            CreateMap<CreateClinicCommand, Clinics_WorkingHours>()
                .ForMember(dest => dest.Day, opt => opt.MapFrom(src => src.WorkHours.Select(w => w.Day)))
                .ForMember(dest => dest.From, opt => opt.MapFrom(src => src.WorkHours.Select(w => w.From)))
                .ForMember(dest => dest.To, opt => opt.MapFrom(src => src.WorkHours.Select(w => w.To)));
        }
    }
}
