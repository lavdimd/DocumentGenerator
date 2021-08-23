using SapDocumentGeneratorApi.Enum;
using System;

namespace SapDocumentGeneratorApi.Models.PlanBoosting
{
    public class BoostingPlan
    {
        #region Properties

        public string Name { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public int DurationInDays { get; set; }
        public decimal Amount { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public bool AvailableToMultiStores { get; set; }
        public int CurrencyId { get; set; }

        public bool Active { get; set; }


        public PriorityEnum Priority { get; set; }
        public BoostingPlanStatusEnum Status { get; set; }

        #endregion Properties
    }
}
