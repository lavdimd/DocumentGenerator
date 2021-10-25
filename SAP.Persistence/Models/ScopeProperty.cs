using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class ScopeProperty
    {
        public ScopeProperty()
        {
            RuleQueries = new HashSet<RuleQuery>();
            ScopePropertyOperatorMappings = new HashSet<ScopePropertyOperatorMapping>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ScopeId { get; set; }
        public bool IsActive { get; set; }
        public int PropertyType { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual Scope Scope { get; set; }
        public virtual ICollection<RuleQuery> RuleQueries { get; set; }
        public virtual ICollection<ScopePropertyOperatorMapping> ScopePropertyOperatorMappings { get; set; }
    }
}
