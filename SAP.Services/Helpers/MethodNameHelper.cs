using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Services.Helpers
{
    public class MethodNameHelper
    {
        public static string GetMethodName([CallerMemberName] string name = null) => name;
    }
}
