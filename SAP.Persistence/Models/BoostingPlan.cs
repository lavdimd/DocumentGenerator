using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class BoostingPlan
    {
        public BoostingPlan()
        {
            BoostingPlanClassifiedAdMappings = new HashSet<BoostingPlanClassifiedAdMapping>();
            PaymentInfos = new HashSet<PaymentInfo>();
            TransactionHistories = new HashSet<TransactionHistory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public int DurationInDays { get; set; }
        public decimal Amount { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public bool AvailableToMultiStores { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public int CurrencyId { get; set; }
        public bool? Published { get; set; }

        public virtual Category Category { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual ICollection<BoostingPlanClassifiedAdMapping> BoostingPlanClassifiedAdMappings { get; set; }
        public virtual ICollection<PaymentInfo> PaymentInfos { get; set; }
        public virtual ICollection<TransactionHistory> TransactionHistories { get; set; }
    }
}
