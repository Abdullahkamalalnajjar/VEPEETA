using Vepeeta.Core.Features.MobileVans.Commands.Models;
using Vepeeta.Data.Entity.MobileVan;
using Vepeeta.Data.Entity.MobileVan.MobileVanService;
using Vepeeta.Data.Helpers;

namespace Vepeeta.Core.Mapping.MobileVans
{
    public partial class MobileVanProfile
    {
        public void CreateVanCommandMapper()
        {
            CreateMap<CreateVanCommand, Van>()
             .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
             .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
             .ForMember(dest => dest.CommercialRegistrationLicensePath, opt => opt.MapFrom(src => FileHelper.SaveFile(src.CommercialRegistrationLicensePath, "CommercialRegistrationLicensePath")))
             .ForMember(dest => dest.VeterinaryLicensePath, opt => opt.MapFrom(src => FileHelper.SaveFile(src.VeterinaryLicensePath, "VeterinaryLicensePath")))
             .ForMember(dest => dest.ProfilePhotoPath, opt => opt.MapFrom(src => FileHelper.SaveFile(src.ProfilePhotoPath, "ProfilePhotoPath")))
             .ForMember(dest => dest.VanServices, opt => opt.Ignore()) // أهم حاجة
             .ForMember(dest => dest.WorkingHours, opt => opt.Ignore()); // برضو هتتبني يدوي

            // تحويل DTO لساعات العمل
           

        }
    }
}
