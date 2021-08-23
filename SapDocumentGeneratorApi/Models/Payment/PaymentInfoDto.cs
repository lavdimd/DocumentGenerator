using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapDocumentGeneratorApi.Models.Payment
{
    public class PaymentInfoDto
    {
        public int CurrencyId { get; set; }
        public int LanguageId { get; set; }
        public string CustomFormatting { get; set; }
        public int StoreId { get; set; }
        public int BoostingPlanId { get; set; }
        public int ClassifiedAdId { get; set; }
        public bool AutomaticUpdate { get; set; }
        public int CustomerId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public DateTime? EndDateForAutomaticUpdate { get; set; }
    }
}
