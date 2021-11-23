
namespace SAP.Core.Models
{
    public class SapPostingInterfaceSettings
    {
        public string CompanyCode { get; set; }
        public string DocumentType { get; set; }
        public string CustomerInvoiceDebit { get; set; }
        public string GeneralLedgerDebit { get; set; }
        public string GeneralLedgerCredit { get; set; }
        public string DebitIndicator { get; set; }
        public string CreditIndicator { get; set; }
        public string DeferredRevenuesAccountNumber { get; set; }
        public string RevenuesAccountNumber { get; set; }
        public string AccountsReceivableAccountNumber { get; set; }
        public string ItemText { get; set; }
    }
}
