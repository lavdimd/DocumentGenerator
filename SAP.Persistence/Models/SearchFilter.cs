using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class SearchFilter
    {
        public int Id { get; set; }
        public int SearchId { get; set; }
        public int SpecificationOptionId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual CustomerSearch Search { get; set; }
        public virtual SpecificationAttributeOption SpecificationOption { get; set; }
    }
}
