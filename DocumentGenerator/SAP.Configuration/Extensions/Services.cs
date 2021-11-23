using Microsoft.Extensions.DependencyInjection;
using SAP.Services.Helpers;
using SAP.Services.Helpers.Interfaces;
using SAP.Services.Interfaces;
using SAP.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Configuration.Extensions
{
    public static class Services
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IDocumentGeneratorService, DocumentGeneratorService>();
            services.AddScoped<ITransactionHistoryService, TransactionHistoryService>();
            services.AddScoped<IDocumentGeneratorHelper, DocumentGeneratorHelper>();
            services.AddScoped<ISapInterfaceTransactionService, SapInterfaceTransactionService>();
            services.AddScoped<ILogService, LogService>();
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<IStaticSettingService, StaticSettingService>();
        }

        public static void RegisterPlatformJobServices(this IServiceCollection services)
        {
            services.AddScoped<IDocumentGeneratorJob, DocumentGeneratorJob>();
        }
    }
}
