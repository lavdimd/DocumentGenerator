using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class SpecificationAttribute
    {
        public SpecificationAttribute()
        {
            CategorySpecificationAttributeMappings = new HashSet<CategorySpecificationAttributeMapping>();
            InverseParentSpecificationAttribute = new HashSet<SpecificationAttribute>();
            SpecificationAttributeOptions = new HashSet<SpecificationAttributeOption>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public int ControlTypeId { get; set; }
        public int? ParentSpecificationAttributeId { get; set; }
        public bool Required { get; set; }
        public int? MaximumLength { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public int? SecondaryId { get; set; }

        public virtual SpecificationAttribute ParentSpecificationAttribute { get; set; }
        public virtual ICollection<CategorySpecificationAttributeMapping> CategorySpecificationAttributeMappings { get; set; }
        public virtual ICollection<SpecificationAttribute> InverseParentSpecificationAttribute { get; set; }
        public virtual ICollection<SpecificationAttributeOption> SpecificationAttributeOptions { get; set; }
    }
}
