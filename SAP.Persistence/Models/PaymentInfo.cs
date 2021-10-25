using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class PaymentInfo
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public int CurrencyId { get; set; }
        public int CustomerId { get; set; }
        public int BoostingPlanId { get; set; }
        public int ClassifiedAdId { get; set; }
        public int StoreId { get; set; }
        public bool AutomaticUpdate { get; set; }
        public int PaymentTableId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? NextDateForAutomaticUpdate { get; set; }
        public int? BoostingPlanClassifiedAdMappingId { get; set; }
        public int CountryId { get; set; }

        public virtual BoostingPlan BoostingPlan { get; set; }
        public virtual BoostingPlanClassifiedAdMapping BoostingPlanClassifiedAdMapping { get; set; }
        public virtual ClassifiedAd ClassifiedAd { get; set; }
        public virtual Country Country { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Language Language { get; set; }
        public virtual Payment PaymentTable { get; set; }
        public virtual Store Store { get; set; }
    }
}
