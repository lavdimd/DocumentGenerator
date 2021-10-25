using SAP.Core.Enum;

namespace SapDocumentGeneratorApi.Models.TransactionHistory
{
    public class CustomTransactionModel
    {
        public decimal TotalAmount { get; set; }
        public int NoOfRecords { get; set; }
        public string Currency { get; set; }
        public string CountryCode { get; set; }
        public int VATrate { get; set; }
        public string ExternalCodeForSAP { get; set; }
        public decimal TaxAmountInLocalCurrency { get; set; }
        public SapInterfaceObjects SapInterfaceType { get; set; }
    }
}
