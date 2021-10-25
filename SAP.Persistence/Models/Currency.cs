using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class Currency
    {
        public Currency()
        {
            BoostingPlanClassifiedAdMappings = new HashSet<BoostingPlanClassifiedAdMapping>();
            BoostingPlans = new HashSet<BoostingPlan>();
            DeferredRevenues = new HashSet<DeferredRevenue>();
            Languages = new HashSet<Language>();
            PaymentInfos = new HashSet<PaymentInfo>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string CurrencyCode { get; set; }
        public decimal Rate { get; set; }
        public string DisplayLocale { get; set; }
        public string CustomFormatting { get; set; }
        public bool LimitedToStores { get; set; }
        public bool Published { get; set; }
        public int DisplayOrder { get; set; }
        public string DomainEndings { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual ICollection<BoostingPlanClassifiedAdMapping> BoostingPlanClassifiedAdMappings { get; set; }
        public virtual ICollection<BoostingPlan> BoostingPlans { get; set; }
        public virtual ICollection<DeferredRevenue> DeferredRevenues { get; set; }
        public virtual ICollection<Language> Languages { get; set; }
        public virtual ICollection<PaymentInfo> PaymentInfos { get; set; }
    }
}
