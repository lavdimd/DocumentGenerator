using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class DeferredRevenue
    {
        public int Id { get; set; }
        public int PaymentTableId { get; set; }
        public decimal Amount { get; set; }
        public DateTime DeferredRevenueDate { get; set; }
        public int ClassifiedAdId { get; set; }
        public int CurrencyId { get; set; }
        public int CountryId { get; set; }
        public bool? Reported { get; set; }
        public DateTime? ReportedDate { get; set; }
        public int? PaymentId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public int StoreId { get; set; }

        public virtual ClassifiedAd ClassifiedAd { get; set; }
        public virtual Country Country { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual Payment PaymentTable { get; set; }
        public virtual Store Store { get; set; }
    }
}
