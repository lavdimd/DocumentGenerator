using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class Category
    {
        public Category()
        {
            BoostingPlans = new HashSet<BoostingPlan>();
            CategorySpecificationAttributeMappings = new HashSet<CategorySpecificationAttributeMapping>();
            ClassifiedAdCategoryMappings = new HashSet<ClassifiedAdCategoryMapping>();
            CustomerSearches = new HashSet<CustomerSearch>();
            InverseParentCategory = new HashSet<Category>();
            Stores = new HashSet<Store>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MetaKeywords { get; set; }
        public bool Published { get; set; }
        public int? ParentCategoryId { get; set; }
        public bool ShowOnHomepage { get; set; }
        public bool IncludeInTopMenu { get; set; }
        public int DisplayOrder { get; set; }
        public bool AvailableToMultiStores { get; set; }
        public bool? EnableSelect { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public int? SecondaryId { get; set; }
        public string ImageUrl { get; set; }

        public virtual Category ParentCategory { get; set; }
        public virtual ICollection<BoostingPlan> BoostingPlans { get; set; }
        public virtual ICollection<CategorySpecificationAttributeMapping> CategorySpecificationAttributeMappings { get; set; }
        public virtual ICollection<ClassifiedAdCategoryMapping> ClassifiedAdCategoryMappings { get; set; }
        public virtual ICollection<CustomerSearch> CustomerSearches { get; set; }
        public virtual ICollection<Category> InverseParentCategory { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
    }
}
