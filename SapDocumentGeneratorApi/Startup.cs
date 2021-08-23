using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SapDocumentGeneratorApi.Configuration;
using SapDocumentGeneratorApi.Extensions;
using SapDocumentGeneratorApi.JobServices.Interfaces;

namespace SapDocumentGeneratorApi
{
    public class Startup
    {
        private static AppSettings appSettings;
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.RegisterAppSettings(_configuration);
            appSettings = services.GetAppSettings();
            services.AddSingleton<AppSettings>();

            services.RegisterAppSettings(_configuration);

            services.AddHttpClient();
            services.RegisterServices();
            services.RegisterPlatformJobServices();
            services.RegisterHangfire(appSettings);
            services.AddHangfireServer();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SapDocumentGeneratorApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IRecurringJobManager recurringJobManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SapDocumentGeneratorApi v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

//#if !DEBUG
//            app.UseHangfireDashboard(string.Empty, new DashboardOptions
//            {
//                Authorization = new[] { new AuthFilter() },
//                IgnoreAntiforgeryToken = true,
//                AppPath = ""
//            });
//#else
            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = new[] { new AuthFilter() },
                IgnoreAntiforgeryToken = true
            });
//#endif

            recurringJobManager.AddOrUpdate<ITransactionHistoryJob>("Prepare reports from transaction history", x => x.PrepareReportsFromTrasactionHistory(default), Cron.Daily);
        }
    }
}
