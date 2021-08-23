using SapDocumentGeneratorApi.Models.Customer;
using SapDocumentGeneratorApi.Models.Payment;
using SapDocumentGeneratorApi.Models.PlanBoosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapDocumentGeneratorApi.Models.TransactionHistory
{
    public class TransactionHistoryDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int PaymentTableId { get; set; }
        public int BoostingPlanId { get; set; }

        public CustomerDto Customer { get; set; }
        public PaymentDto PaymentTable { get; set; }
        public BoostingPlan BoostingPlan { get; set; }
    }
}
