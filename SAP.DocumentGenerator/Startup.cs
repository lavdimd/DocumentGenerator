using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SAP.Configuration.Extensions;
using SAP.Configuration.Filters;
using SAP.Configuration.Middlewares;
using SAP.Core.Configuration;
using SAP.Models.Mapping;
using SAP.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAP.DocumentGenerator
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        private static AppSettings appSettings;

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

            services.RegisterServices();
            services.RegisterPlatformJobServices();

            services.RegisterHangfire(appSettings);
            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddHangfireServer();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SAP.DocumentGenerator", Version = "v1" });
                c.OperationFilter<ApiAuthorizationHeaderParameter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IRecurringJobManager recurringJobManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SAP.DocumentGenerator v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseMiddleware<ApiKeyAuthorizationMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });



#if !DEBUG
            app.UseHangfireDashboard(string.Empty, new DashboardOptions
            {
                Authorization = new[] { new AuthFilter() },
                IgnoreAntiforgeryToken = true,
                AppPath = ""
            });
#else
            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = new[] { new AuthFilter() },
                IgnoreAntiforgeryToken = true
            });
#endif
            recurringJobManager.AddOrUpdate<IDocumentGeneratorJob>("Upload reports from transaction history", x => x.GenerateCSV(default), Cron.Daily);
        }
    }
}
