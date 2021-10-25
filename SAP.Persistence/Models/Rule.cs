using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class Rule
    {
        public Rule()
        {
            RuleQueries = new HashSet<RuleQuery>();
            Sections = new HashSet<Section>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ScopeId { get; set; }
        public int Limit { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual Scope Scope { get; set; }
        public virtual ICollection<RuleQuery> RuleQueries { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
    }
}
