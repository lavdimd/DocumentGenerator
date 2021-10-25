using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Core.Configuration
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; } = new ConnectionStrings();
        public FtpServerConfig FtpServerConfig { get; set; } = new FtpServerConfig();
        public HttpUrls HttpUrls { get; set; } = new HttpUrls();
    }
}
