using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Core.Common.Constants
{
    public class SapInterfaceConstants
    {
        public const string BUKRS = "CZ01";
        public const string GJAHR = "2021";
        public const string MONAT = "Fiscal Period";
        public const string BUZEI = "Number of Line Item Within Accounting Document";
        public const string BLART = "C4";
        public const string BUDAT = "Document date (dd.mm.yyyy)";
        public const string BLDAT = "Document date (dd.mm.yyyy)";
        public const string WAERS = "Document currency";
        public const string XBLNR = "123";
        public const string BKTXT = "Document header text";
        public const string BSCHL = "01";
        public const string SHKZG = "D";
        public const string HKONT = "51001340"; //G/L account number
        public const string UMSKZ = "Special G/L indicator";
        public const string ALTKT = "Group Account Number";
        public const string XNEGP = "Negative posting";
        public const string SGTXT = "Flea Market";
        public const string ZUONR = "100";
        public const string DMBTR = "Amount in local currency";
        public const string WRBTR = "Amount in document currency";
        public const string DMBTR_BRUTTO = "Amount in local currency";
        public const string WRBTR_BRUTTO = "Amount in document currency";
        public const string MWSKZ = "EM"; // CZK VAT CODE for SAP
        public const string MWSTS = "Tax Amount in Local Currency";
        public const string WMWST = "Tax amount in document currency";
        public const string KOSTL = "Cost Center";
        public const string AUFNR = "Order Number";
        public const string MENGE = "Quantity";
        public const string MEINS = "Base Unit of Measure";
        public const string PERNR = "Personal number";
        public const string GSBER = "Business Area";
        public const string PRCTR = "Profit center";
        public const string VBUND = "Trading partner";
        public const string BEWAR = "Transaction type";
        public const string FKBER = "Functional Area";
        public const string XREF1 = "Reference 1";
        public const string XREF2 = "Reference 2";
        public const string XREF3 = "Reference 3";
        public const string ZFBDT = "Baseline date for due date calculation (dd.mm.yyyy)";
        public const string BVTYP = "Partner bank type";
        public const string ZLSCH = "Payment Method";
        public const string ZTERM = "Terms of payment key";
        public const string ZLSPR = "Payment Block Key";
        public const string PROJK = "WBS element";
        public const string BARCD = "Bar code (for Livelink archive)";
    }
}
