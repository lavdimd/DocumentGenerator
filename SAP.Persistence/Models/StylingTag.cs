using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class StylingTag
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public string HtmlTag { get; set; }
        public string HtmlValue { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual Section Section { get; set; }
    }
}
