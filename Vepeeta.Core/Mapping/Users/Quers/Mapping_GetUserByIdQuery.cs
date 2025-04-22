using Vepeeta.Core.Features.AppUser.Quers.Response;
using Vepeeta.Data.Entity.Identity;

namespace Vepeeta.Core.Mapping.Users
{
    public partial class UserProfile
    {
        public void Mapping_GetUserByIdQuery()
        {
            CreateMap<PetOwner, GetUserByIdResponse>().ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FristName} {src.LastName}"));
           
        }
    }
}
