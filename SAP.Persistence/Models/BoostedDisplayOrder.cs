using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class BoostedDisplayOrder
    {
        public BoostedDisplayOrder()
        {
            BoostPositions = new HashSet<BoostPosition>();
        }

        public int Id { get; set; }
        public int PageSize { get; set; }
        public bool IsDefault { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual ICollection<BoostPosition> BoostPositions { get; set; }
    }
}
