using Microsoft.Extensions.DependencyInjection;
using SapDocumentGeneratorApi.HttpServices.Interfaces;
using SapDocumentGeneratorApi.HttpServices.Services;
using SapDocumentGeneratorApi.JobServices.Interfaces;
using SapDocumentGeneratorApi.JobServices.Services;

namespace SapDocumentGeneratorApi.Extensions
{
    public static class Services
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IHttpTransactionHistoryService, HttpTransactionHistoryService>();
            services.AddScoped<IHttpLogService, HttpLogService>();
        }

        public static void RegisterPlatformJobServices(this IServiceCollection services)
        {
            services.AddScoped<ITransactionHistoryJob, TransactionHistoryJob>();
        }
    }
}
