using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class Report
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int FromCustomerId { get; set; }
        public int ReportTypeId { get; set; }
        public int EntityId { get; set; }
        public int RowId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual Entity Entity { get; set; }
        public virtual Customer FromCustomer { get; set; }
        public virtual ReportType ReportType { get; set; }
    }
}
