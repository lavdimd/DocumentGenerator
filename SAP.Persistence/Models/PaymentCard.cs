using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class PaymentCard
    {
        public int Id { get; set; }
        public int PaymentTableId { get; set; }
        public string CardIssuerBank { get; set; }
        public string CardBrand { get; set; }
        public string CardNumber { get; set; }
        public string CardExpiration { get; set; }
        public string AccountNumber { get; set; }
        public string CardToken { get; set; }
        public string ThreeDresult { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
