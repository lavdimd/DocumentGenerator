using Microsoft.Extensions.DependencyInjection;
using SapDocumentGeneratorApi.Configuration;
using SapDocumentGeneratorApi.HttpServices.Interfaces;
using SapDocumentGeneratorApi.HttpServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SapDocumentGeneratorApi.Extensions
{
    public static class HttpClientExtension
    {
        public static void RegisterHttpTransactionHistoryService(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddHttpClient<IHttpTransactionHistoryService, HttpTransactionHistoryService>(client =>
            {
                client.BaseAddress = new Uri(appSettings.HttpUrls.EcommerceClientUrl);
                client.DefaultRequestHeaders
                        .Accept
                        .Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.Timeout = TimeSpan.FromMinutes(20);
            })
        .SetHandlerLifetime(TimeSpan.FromMinutes(5));
        }
    }
}
