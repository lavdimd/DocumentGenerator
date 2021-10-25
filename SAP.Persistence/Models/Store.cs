using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class Store
    {
        public Store()
        {
            CustomerSearches = new HashSet<CustomerSearch>();
            DeferredRevenues = new HashSet<DeferredRevenue>();
            PaymentInfos = new HashSet<PaymentInfo>();
            Sections = new HashSet<Section>();
            TransactionHistories = new HashSet<TransactionHistory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public int DisplayOrder { get; set; }
        public bool Published { get; set; }
        public bool IsMainStore { get; set; }
        public int DefaultLanguageId { get; set; }
        public int? StoreCategoryId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual Language DefaultLanguage { get; set; }
        public virtual Category StoreCategory { get; set; }
        public virtual StoreInformation StoreInformation { get; set; }
        public virtual ICollection<CustomerSearch> CustomerSearches { get; set; }
        public virtual ICollection<DeferredRevenue> DeferredRevenues { get; set; }
        public virtual ICollection<PaymentInfo> PaymentInfos { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
        public virtual ICollection<TransactionHistory> TransactionHistories { get; set; }
    }
}
