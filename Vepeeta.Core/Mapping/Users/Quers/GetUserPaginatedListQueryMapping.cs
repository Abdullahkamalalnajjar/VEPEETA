using Vepeeta.Core.Features.AppUser.Quers.Response;
using Vepeeta.Data.Entity.Identity;

namespace Vepeeta.Core.Mapping.Users
{
    public partial class UserProfile
    {
        public void GetUserPaginatedListQueryMapping()
        {
            
            CreateMap<PetOwner, GetUserPaginatedListResponse>()
               .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FristName} {src.LastName}"))
               .ForMember(dest => dest.Animalname, opt => opt.MapFrom(src => src.Animalname))
               .ForMember(dest => dest.AnimalGender, opt => opt.MapFrom(src => src.AnimalGender))
               .ForMember(dest => dest.AnimalType, opt => opt.MapFrom(src => src.AnimalType))
               .ForMember(dest => dest.AnimalCategory, opt => opt.MapFrom(src => src.AnimalCategory))
               .ForMember(dest => dest.AnimalBornDate, opt => opt.MapFrom(src => src.AnimalBornDate))
               .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Weight))
               .ForMember(dest => dest.ReproductiveStatus, opt => opt.MapFrom(src => src.ReproductiveStatus))
               .ForMember(dest => dest.sensitivity, opt => opt.MapFrom(src => src.sensitivity))
               .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image));
                CreateMap<User, GetUserPaginatedListResponse>();
        }

    }
}

