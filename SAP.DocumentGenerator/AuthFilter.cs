using Hangfire.Dashboard;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace SAP.DocumentGenerator
{
    public class AuthFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext dashboardContext)
        {
            if (dashboardContext == null)
            {
                return false;
            }

            var configurationAllowedIps = dashboardContext.GetHttpContext().RequestServices.GetService<IConfiguration>().GetSection("AllowedIps").Get<string[]>();
            List<string> _allowedIps = new(configurationAllowedIps);

            var dashboardCurrentContext = dashboardContext.GetHttpContext();
            var ipAddress = dashboardCurrentContext.Connection.RemoteIpAddress.ToString();

            if (dashboardCurrentContext.Request.Headers.ContainsKey("CF-Connecting-IP"))
                ipAddress = dashboardCurrentContext.Request.Headers["CF-Connecting-IP"];

            else if (dashboardCurrentContext.Request.Headers.ContainsKey("x-forwarded-for"))
                ipAddress = dashboardCurrentContext.Request.Headers["x-forwarded-for"];

            if (!_allowedIps.Contains(ipAddress))
            {
                return false;
            }

            return true;
        }
    }
}
