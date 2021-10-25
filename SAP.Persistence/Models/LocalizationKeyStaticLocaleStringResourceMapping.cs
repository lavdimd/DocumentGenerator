using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class LocalizationKeyStaticLocaleStringResourceMapping
    {
        public int Id { get; set; }
        public string LocalizationKey { get; set; }
        public int StaticLocaleStringResourceId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual StaticLocaleStringResource StaticLocaleStringResource { get; set; }
    }
}
