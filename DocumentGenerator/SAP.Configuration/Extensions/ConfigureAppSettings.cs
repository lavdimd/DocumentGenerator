

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SAP.Core.Configuration;
using SAP.Core.Infrastructure;

namespace SAP.Configuration.Extensions
{
    public static class ConfigureAppSettings
    {
        public static void RegisterAppSettings(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<AppSettings>(config);
            Singleton<AppSettings>.Instance = services.GetAppSettings();
        }
        
        public static AppSettings GetAppSettings(this IServiceCollection services)
        {
            return services.BuildServiceProvider().GetRequiredService<IOptions<AppSettings>>().Value;
        }
    }
}
