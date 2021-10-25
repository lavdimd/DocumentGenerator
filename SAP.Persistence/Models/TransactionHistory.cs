using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class TransactionHistory
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int PaymentTableId { get; set; }
        public int BoostingPlanId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IncludedInSapDocument { get; set; }
        public decimal Amount { get; set; }
        public int StoreId { get; set; }

        public virtual BoostingPlan BoostingPlan { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Payment PaymentTable { get; set; }
        public virtual Store Store { get; set; }
    }
}
