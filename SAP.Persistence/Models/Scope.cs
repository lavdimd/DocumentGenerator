using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class Scope
    {
        public Scope()
        {
            Rules = new HashSet<Rule>();
            ScopeProperties = new HashSet<ScopeProperty>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ScopeType { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual ICollection<Rule> Rules { get; set; }
        public virtual ICollection<ScopeProperty> ScopeProperties { get; set; }
    }
}
