using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class Section
    {
        public Section()
        {
            StylingTags = new HashSet<StylingTag>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? RuleId { get; set; }
        public int PageId { get; set; }
        public bool AllStores { get; set; }
        public int DisplayOrder { get; set; }
        public int StoreId { get; set; }
        public int ScopeType { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public int StyleFormat { get; set; }
        public string SectionName { get; set; }

        public virtual ConfigurablePage Page { get; set; }
        public virtual Rule Rule { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<StylingTag> StylingTags { get; set; }
    }
}
