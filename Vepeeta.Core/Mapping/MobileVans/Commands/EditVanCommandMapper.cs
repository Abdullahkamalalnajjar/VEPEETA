using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vepeeta.Core.Features.MobileVans.Commands.Models;
using Vepeeta.Data.Entity.MobileVan;
using Vepeeta.Data.Helpers;

namespace Vepeeta.Core.Mapping.MobileVans
{
    public partial class MobileVanProfile
    {
        public void EditVanCommandMapper()
        {
            CreateMap<EditVanCommand, Van>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
            .ForMember(dest => dest.IsVeterinarian, opt => opt.MapFrom(src => src.IsVeterinarian))
            .ForMember(dest => dest.IsGroomer, opt => opt.MapFrom(src => src.IsGroomer))

            // التعامل مع الصور بشروط
            .ForMember(dest => dest.VeterinaryLicensePath,
                opt => opt.MapFrom(src => src.VeterinaryLicensePath != null
                    ? FileHelper.SaveFile(src.VeterinaryLicensePath, "VanLicenses")
                    : null))

            .ForMember(dest => dest.CommercialRegistrationLicensePath,
                opt => opt.MapFrom(src => src.CommercialRegistrationLicensePath != null
                    ? FileHelper.SaveFile(src.CommercialRegistrationLicensePath, "VanLicenses")
                    : null))

            .ForMember(dest => dest.ProfilePhotoPath,
                opt => opt.MapFrom(src => src.ProfilePhotoPath != null
                    ? FileHelper.SaveFile(src.ProfilePhotoPath, "VanPhotos")
                    : null))

            // تجاهل الخصائص اللي هنحدثها يدويًا
            .ForMember(dest => dest.VanServices, opt => opt.Ignore())
            .ForMember(dest => dest.WorkingHours, opt => opt.Ignore());
        }
    }
}