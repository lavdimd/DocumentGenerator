using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapDocumentGeneratorApi.Enum
{
    public enum PaymentStateEnum
    {
        CREATED = 0,
        PAYMENT_METHOD_CHOSEN = 1,
        PAID = 2,
        AUTHORIZED = 3,
        CANCELED = 4,
        TIMEOUTED = 5,
        REFUNDED = 6,
        PARTIALLY_REFUNDED = 7
    }
}
