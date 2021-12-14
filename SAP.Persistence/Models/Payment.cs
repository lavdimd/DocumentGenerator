using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class Payment
    {
        public Payment()
        {
            DeferredRevenuePaymentTables = new HashSet<DeferredRevenue>();
            DeferredRevenuePayments = new HashSet<DeferredRevenue>();
            InverseParentTablePayment = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public long PaymentId { get; set; }
        public int PaymentStatus { get; set; }
        public decimal Amount { get; set; }
        public string AdditionalParams { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public int CustomerId { get; set; }
        public DateTime? UserNotificationTime { get; set; }
        public bool? UserNotified { get; set; }
        public int? ParentTablePaymentId { get; set; }
        public bool? IsDeferredRevenue { get; set; }
        public int PaymentInstrument { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Payment ParentTablePayment { get; set; }
        public virtual PaymentInfo PaymentInfo { get; set; }
        public virtual TransactionHistory TransactionHistory { get; set; }
        public virtual ICollection<DeferredRevenue> DeferredRevenuePaymentTables { get; set; }
        public virtual ICollection<DeferredRevenue> DeferredRevenuePayments { get; set; }
        public virtual ICollection<Payment> InverseParentTablePayment { get; set; }
    }
}
