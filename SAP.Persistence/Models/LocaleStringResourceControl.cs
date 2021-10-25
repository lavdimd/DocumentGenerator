using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class LocaleStringResourceControl
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string Value { get; set; }
        public int ControlSettingId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual ControlSetting ControlSetting { get; set; }
        public virtual Language Language { get; set; }
    }
}
