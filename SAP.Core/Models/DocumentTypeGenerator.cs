using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Core.Models
{
    public class DocumentTypeGenerator
    {
        public bool HasDeferredRevenueInThisInterval { get; set; }
        public bool HasPreviousDeferredRevenue { get; set; }
        public bool OnlyActualRevenue { get; set; }
    }
}
