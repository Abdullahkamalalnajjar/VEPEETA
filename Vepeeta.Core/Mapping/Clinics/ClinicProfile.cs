using AutoMapper;

namespace Vepeeta.Core.Mapping.Clinics
{
    public partial class ClinicProfile : Profile
    {
        public ClinicProfile()
        {
            CreateClinicCommandMapper();
            GetPaginatedClinicMappingProfile();
            EditClinicCommandMapping();
        }

    }
}
