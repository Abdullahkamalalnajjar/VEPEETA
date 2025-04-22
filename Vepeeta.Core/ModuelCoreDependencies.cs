using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Vepeeta.Core.Behavior;
using Vepeeta.Core.Dtos.Auth;
using Vepeeta.Service.Handler.Auth;

namespace Vepeeta.Core
{
    public static class ModuelCoreDependencies
    {

        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            // Get Validators
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddScoped<ForgotPasswordHandler>();
            services.AddScoped<ResetPasswordHandler>();
            services.AddScoped<VerifyOTPHandler>();

            return services;
        }
    }
}
