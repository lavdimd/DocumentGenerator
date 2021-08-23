using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapDocumentGeneratorApi.Models.Logs
{
    public class LogLevel
    {
        public string Name { get; set; }

        public List<Log> Logs { get; set; }
    }
}
