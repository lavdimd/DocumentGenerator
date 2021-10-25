using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class CustomerSearch
    {
        public CustomerSearch()
        {
            SearchFilters = new HashSet<SearchFilter>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string FullTextSearch { get; set; }
        public int? CategoryId { get; set; }
        public bool EnableNotifications { get; set; }
        public int LanguageId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? EnableEmailNotifications { get; set; }
        public int? CityId { get; set; }
        public int StoreId { get; set; }

        public virtual Category Category { get; set; }
        public virtual City City { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Language Language { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<SearchFilter> SearchFilters { get; set; }
    }
}
