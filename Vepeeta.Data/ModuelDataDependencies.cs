using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vepeeta.Api.Helpers;
using Vepeeta.Data.Helpers;
namespace Vepeeta.Data
{

    public static class ModuelDataDependencies
    {
        public static IServiceCollection AddDataDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            #region Register MailSettings
            services.Configure<MailSettings>(configuration.GetSection("EmailSettings")); // ✅ الطريقة الصحيحة
            services.AddTransient<EmailHelper>(); // ✅ تسجيل EmailHelper بشكل صحيح
            #endregion

            services.AddMemoryCache();
            return services;
        }
    }



}
