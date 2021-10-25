using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class Setting
    {
        public Setting()
        {
            LocaleStringResourceSettings = new HashSet<LocaleStringResourceSetting>();
        }

        public int Id { get; set; }
        public int DataAnnotationTypeId { get; set; }
        public int ControlSettingId { get; set; }
        public string Value { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual ControlSetting ControlSetting { get; set; }
        public virtual DataAnnotationType DataAnnotationType { get; set; }
        public virtual ICollection<LocaleStringResourceSetting> LocaleStringResourceSettings { get; set; }
    }
}
