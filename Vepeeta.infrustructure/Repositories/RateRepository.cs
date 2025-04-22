using Vepeeta.Data.Entity;
using Vepeeta.infrustructure.Abstracts;
using Vepeeta.infrustructure.DbContext;
using Vepeeta.infrustructure.InfrustructureBase;

namespace Vepeeta.infrustructure.Repositories
{
    public class RateRepository : GenericRepository<Rateing>, IRateRepository
    {
        public RateRepository(ApplicationDbContext context) : base(context)
        {
        }

    }
}
