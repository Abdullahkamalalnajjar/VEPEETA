using AutoMapper;

namespace Vepeeta.Core.Mapping.Users
{
    public partial class UserProfile : Profile
    {
        public UserProfile()
        {
            Mapping_CreateUserCommandMapping();
            Mapping_EditUserCommandMapping();
            GetUserPaginatedListQueryMapping();
            Mapping_GetUserByIdQuery();
        }

    }
}