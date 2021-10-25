using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Core.Enum
{
    public enum SapInterfaceObjects
    {
        CustomerInvoice = 1,
        GeneralLedgerPosting = 2,
        VendorInvoice = 3
    }

    public enum PostingKey
    {
        CustomerInvoiceDebit = 1,
        GeneralLedgerDebit = 40,
        GeneralLedgerCredit = 50
    }
}
