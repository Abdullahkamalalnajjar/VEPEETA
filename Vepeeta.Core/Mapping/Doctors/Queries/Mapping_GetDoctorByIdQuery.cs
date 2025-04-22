using Vepeeta.Core.Features.Doctors.Queries.Results;
using Vepeeta.Data.Entity.Identity.Doctor;

namespace Vepeeta.Core.Mapping.Doctors
{
    public partial class DoctorProfile
    {
        public void Mapping_GetDoctorByIdQuery()
        {
            CreateMap<Doctor, GetDoctorByIdResponse>();

        }
    }
}