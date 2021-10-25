using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapDocumentGeneratorApi.Models.SAPInterfaceFields
{
    public class SapInterfaceFields
    {
        public string BUKRS { get; set; } = "CZ08 = Gjirafa";
        public string GJAHR { get; set; } = "Fiscal Year";
        public string MONAT { get; set; } = "Fiscal Period";
        public string BUZEI { get; set; } = "Number of Line Item Within Accounting Document";
        public string BLART { get; set; } = "Document type";
        public string BUDAT { get; set; } = "Document date (dd.mm.yyyy)";
        public string BLDAT { get; set; } = "Document date (dd.mm.yyyy)";
        public string WAERS { get; set; } = "Document currency";
        public string XBLNR { get; set; } = "Document reference";
        public string BKTXT { get; set; } = "Document header text";
        public string BSCHL { get; set; } = "Posting key";
        public string SHKZG { get; set; } = "Debit/Credit Indicator";
        public string HKONT { get; set; } = "G/L account number";
        public string UMSKZ { get; set; } = "Special G/L indicator";
        public string ALTKT { get; set; } = "Group Account Number";
        public string XNEGP { get; set; } = "Negative posting";
        public string SGTXT { get; set; } = "Item Text";
        public string ZUONR { get; set; } = "Assignment Number";
        public string DMBTR { get; set; } = "Amount in local currency";
        public string WRBTR { get; set; } = "Amount in document currency";
        public string DMBTR_BRUTTO { get; set; } = "Amount in local currency";
        public string WRBTR_BRUTTO { get; set; } = "Amount in document currency";
        public string MWSKZ { get; set; } = "VAT code";
        public string MWSTS { get; set; } = "Tax Amount in Local Currency";
        public string WMWST { get; set; } = "Tax amount in document currency";
        public string KOSTL { get; set; } = "Cost Center";
        public string AUFNR { get; set; } = "Order Number";
        public string MENGE { get; set; } = "Quantity";
        public string MEINS { get; set; } = "Base Unit of Measure";
        public string PERNR { get; set; } = "Personal number";
        public string GSBER { get; set; } = "Business Area";
        public string PRCTR { get; set; } = "Profit center";
        public string VBUND { get; set; } = "Trading partner";
        public string BEWAR { get; set; } = "Transaction type";
        public string FKBER { get; set; } = "Functional Area";
        public string XREF1 { get; set; } = "Reference 1";
        public string XREF2 { get; set; } = "Reference 2";
        public string XREF3 { get; set; } = "Reference 3";
        public string ZFBDT { get; set; } = "Baseline date for due date calculation (dd.mm.yyyy)";
        public string BVTYP { get; set; } = "Partner bank type";
        public string ZLSCH { get; set; } = "Payment Method";
        public string ZTERM { get; set; } = "Terms of payment key";
        public string ZLSPR { get; set; } = "Payment Block Key";
        public string PROJK { get; set; } = "WBS element";
        public string BARCD { get; set; } = "Bar code (for Livelink archive)";

    }
}
