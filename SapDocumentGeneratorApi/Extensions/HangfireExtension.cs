using Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SapDocumentGeneratorApi.Configuration;

namespace SapDocumentGeneratorApi.Extensions
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
