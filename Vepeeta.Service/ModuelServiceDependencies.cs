using Microsoft.Extensions.DependencyInjection;
using Vepeeta.Service.Abstract;
using Vepeeta.Service.Implementation;
using Vepeeta.Service.Implemention;

namespace Vepeeta.Service
{
    public static class ModuelServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {


            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IOTPService, OTPService>();
            services.AddScoped<IRateService, RateService>();


            return services;
        }
    }


}
