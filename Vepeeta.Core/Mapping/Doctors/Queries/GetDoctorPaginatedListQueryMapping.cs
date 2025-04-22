using Vepeeta.Core.Features.Doctors.Queries.Results;
using Vepeeta.Data.Entity.Identity;
using Vepeeta.Data.Entity.Identity.Doctor;

namespace Vepeeta.Core.Mapping.Doctors
{
    public partial class DoctorProfile
    {

        public void GetDoctorPaginatedListQueryMapping()
        {
            CreateMap<Doctor, GetDoctorPaginatedListResponse>();
            CreateMap<User, GetDoctorPaginatedListResponse>();
            CreateMap<DoctorCertificate, DoctorCertificateDto>();
            CreateMap<WorkingHours, WorkingHoursDto>();
        }
    }
}
