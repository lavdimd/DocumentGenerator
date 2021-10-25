using SAP.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Models.DTOs.Request.Transactions
{
    public class CustomTransactionSummaryModel
    {
        public decimal TotalAmount { get; set; }
        public int NoOfRecords { get; set; }
        public string Currency { get; set; }
        public string CountryCode { get; set; }
        public int VATrate { get; set; }
        public string ExternalCodeForSAP { get; set; }
        public decimal TaxAmountInLocalCurrency { get; set; }
        public string StoreOrderNumber { get; set; }
        public SapInterfaceObjects SapInterfaceType { get; set; }
    }
}
