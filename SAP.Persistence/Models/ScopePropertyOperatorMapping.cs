using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class ScopePropertyOperatorMapping
    {
        public int Id { get; set; }
        public int ScopePropertyId { get; set; }
        public int OperatorId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual Operator Operator { get; set; }
        public virtual ScopeProperty ScopeProperty { get; set; }
    }
}
