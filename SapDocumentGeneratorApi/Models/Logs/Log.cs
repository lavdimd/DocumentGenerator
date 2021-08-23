using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapDocumentGeneratorApi.Models.Logs
{
    public class Log
    {
        public int LogLevelId { get; set; }
        public string ShortMessage { get; set; }
        public string FullMessage { get; set; }
        public string IpAddress { get; set; }
        public int? CustomerId { get; set; }
        public string PageUrl { get; set; }
        public string ReferrerUrl { get; set; }
        public LogLevel LogLevel { get; set; }
    }
}
