using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class CategorySpecificationAttributeMapping
    {
        public int Id { get; set; }
        public int SpecificationAttributeId { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual Category Category { get; set; }
        public virtual SpecificationAttribute SpecificationAttribute { get; set; }
    }
}
