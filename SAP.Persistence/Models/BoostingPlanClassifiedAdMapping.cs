using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class BoostingPlanClassifiedAdMapping
    {
        public BoostingPlanClassifiedAdMapping()
        {
            PaymentInfos = new HashSet<PaymentInfo>();
        }

        public int Id { get; set; }
        public int BoostingPlanId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public bool AutomaticUpdate { get; set; }
        public DateTime? NextDateForAutomaticUpdate { get; set; }
        public int ClassifiedAdId { get; set; }
        public string Description { get; set; }
        public bool AvailableToMultiStores { get; set; }
        public int CurrencyId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? Active { get; set; }
        public DateTime? UserNotificationTime { get; set; }
        public bool? UserNotified { get; set; }

        public virtual BoostingPlan BoostingPlan { get; set; }
        public virtual ClassifiedAd ClassifiedAd { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual ICollection<PaymentInfo> PaymentInfos { get; set; }
    }
}
