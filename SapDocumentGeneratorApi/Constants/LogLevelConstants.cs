using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapDocumentGeneratorApi.Constants
{
    public static class LogLevelConstants
    {
        public const int Debug = 1;
        public const int Information = 2;
        public const int Warning = 3;
        public const int Error = 4;
        public const int Critical = 5;
        public const int None = 6;
        public const int Trace = 7; //Trace = 0 @ loglevel enum https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.loglevel?view=dotnet-plat-ext-5.0 
        public const int GoPay = 8;
    }
}
