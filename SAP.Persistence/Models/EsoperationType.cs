using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class EsoperationType
    {
        public EsoperationType()
        {
            EsoperationClassifiedAds = new HashSet<EsoperationClassifiedAd>();
        }

        public int Id { get; set; }
        public string OperationName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual ICollection<EsoperationClassifiedAd> EsoperationClassifiedAds { get; set; }
    }
}
