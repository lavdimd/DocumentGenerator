using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class ControlSetting
    {
        public ControlSetting()
        {
            LocaleStringResourceControls = new HashSet<LocaleStringResourceControl>();
            Settings = new HashSet<Setting>();
        }

        public int Id { get; set; }
        public int EntityId { get; set; }
        public string Name { get; set; }
        public string DefaultValue { get; set; }
        public int StoreId { get; set; }
        public bool IsEntityName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual Entity Entity { get; set; }
        public virtual ICollection<LocaleStringResourceControl> LocaleStringResourceControls { get; set; }
        public virtual ICollection<Setting> Settings { get; set; }
    }
}
