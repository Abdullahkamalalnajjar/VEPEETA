using Vepeeta.Core.Features.AppUser.Command.Models;
using Vepeeta.Data.Entity.Identity;
using Vepeeta.Data.Helpers;

namespace Vepeeta.Core.Mapping.Users
{
    public partial class UserProfile
    {
        public void Mapping_CreateUserCommandMapping()
        {

            CreateMap<CreateUserCommand, User>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email ?? string.Empty))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber ?? string.Empty));

            CreateMap<CreateUserCommand, PetOwner>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email ?? string.Empty))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber ?? string.Empty))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => FileHelper.SaveFile(src.Image, "ProfileImageOFUser")));
        }

    }
}

