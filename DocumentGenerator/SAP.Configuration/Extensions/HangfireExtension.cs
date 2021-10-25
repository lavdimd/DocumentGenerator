using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using SAP.Core.Configuration;

namespace SAP.Configuration.Extensions
{
    public static class HangfireExtension
    {
        public static IServiceCollection RegisterHangfire(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddHangfire(config =>
                config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseDefaultTypeSerializer()
                .UseSqlServerStorage(appSettings.ConnectionStrings.DatabaseConnection));

            return services;
        }
    }
}
