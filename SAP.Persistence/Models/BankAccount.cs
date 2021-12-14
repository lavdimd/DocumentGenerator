using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class BankAccount
    {
        public int Id { get; set; }
        public int PaymentTableId { get; set; }
        public string Prefix { get; set; }
        public string AccountNumber { get; set; }
        public string BankCode { get; set; }
        public string Iban { get; set; }
        public string Bic { get; set; }
        public string AccountName { get; set; }
        public int? CountryId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
