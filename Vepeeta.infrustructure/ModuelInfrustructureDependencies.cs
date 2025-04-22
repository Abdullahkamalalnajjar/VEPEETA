using Microsoft.Extensions.DependencyInjection;
using Vepeeta.infrustructure.Abstracts;
using Vepeeta.infrustructure.InfrustructureBase;
using Vepeeta.infrustructure.Repositories;

namespace Vepeeta.infrustructure
{
    public static class ModuelInfrustructureDependencies
    {
        public static IServiceCollection AddInfrustructureDependencies(this IServiceCollection services)
        {

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IRateRepository, RateRepository>();
            return services;
        }
    }
}
