using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class ClassifiedAdCategoryMapping
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int ClassifiedAdId { get; set; }
        public bool IsFeaturedProduct { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual Category Category { get; set; }
        public virtual ClassifiedAd ClassifiedAd { get; set; }
    }
}
