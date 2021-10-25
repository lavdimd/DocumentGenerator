using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class BoostPosition
    {
        public int Id { get; set; }
        public int BoostDisplayId { get; set; }
        public int Position { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual BoostedDisplayOrder BoostDisplay { get; set; }
    }
}
