using Vepeeta.Data.Entity.Identity.Doctor;
using Vepeeta.infrustructure.Abstracts;
using Vepeeta.infrustructure.DbContext;
using Vepeeta.infrustructure.InfrustructureBase;

namespace Vepeeta.infrustructure.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
