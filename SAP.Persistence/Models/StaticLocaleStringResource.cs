using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class StaticLocaleStringResource
    {
        public StaticLocaleStringResource()
        {
            LocalizationKeyStaticLocaleStringResourceMappings = new HashSet<LocalizationKeyStaticLocaleStringResourceMapping>();
        }

        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string ResourceName { get; set; }
        public string ResourceValue { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual Language Language { get; set; }
        public virtual ICollection<LocalizationKeyStaticLocaleStringResourceMapping> LocalizationKeyStaticLocaleStringResourceMappings { get; set; }
    }
}
