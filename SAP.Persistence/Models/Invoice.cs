using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class Invoice
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public int CustomerId { get; set; }
        public string CdnUrl { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public int BoostingClassifiedAdMappingId { get; set; }

        public virtual BoostingPlanClassifiedAdMapping BoostingClassifiedAdMapping { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
