using AutoMapper;

namespace Vepeeta.Core.Mapping.Doctors
{
    public partial class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateDoctorCommand_Mapping();
            Mapping_EditDoctorCommandMapping();
            GetDoctorPaginatedListQueryMapping();
            Mapping_GetDoctorByIdQuery();
            GetNearestDoctorMapping();
        }
    }
}
