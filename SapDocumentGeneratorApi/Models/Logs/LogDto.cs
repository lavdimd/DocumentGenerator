using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapDocumentGeneratorApi.Models.Logs
{
    public class LogDto
    {
        public int LogLevel { get; set; }
        public string shortMessage { get; set; }
        public string fullMessage { get; set; }
    }
}
