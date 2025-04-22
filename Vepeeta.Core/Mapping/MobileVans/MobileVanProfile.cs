using AutoMapper;

namespace Vepeeta.Core.Mapping.MobileVans
{
    public partial class MobileVanProfile : Profile
    {
        public MobileVanProfile()
        {
            CreateVanCommandMapper();
            GetPaginatedVanMappingProfile();
            EditVanCommandMapper();
        }
    }
}
