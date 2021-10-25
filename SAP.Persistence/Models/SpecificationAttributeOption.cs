using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class SpecificationAttributeOption
    {
        public SpecificationAttributeOption()
        {
            ClassifiedAdSpecificationAttributeOptionMappings = new HashSet<ClassifiedAdSpecificationAttributeOptionMapping>();
            InverseParentSpecificationAttributeOption = new HashSet<SpecificationAttributeOption>();
            SearchFilters = new HashSet<SearchFilter>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int SpecificationAttributeId { get; set; }
        public int DisplayOrder { get; set; }
        public int? ParentSpecificationAttributeOptionId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public string ChainedAncestorString { get; set; }
        public int? SecondaryId { get; set; }

        public virtual SpecificationAttributeOption ParentSpecificationAttributeOption { get; set; }
        public virtual SpecificationAttribute SpecificationAttribute { get; set; }
        public virtual ICollection<ClassifiedAdSpecificationAttributeOptionMapping> ClassifiedAdSpecificationAttributeOptionMappings { get; set; }
        public virtual ICollection<SpecificationAttributeOption> InverseParentSpecificationAttributeOption { get; set; }
        public virtual ICollection<SearchFilter> SearchFilters { get; set; }
    }
}
