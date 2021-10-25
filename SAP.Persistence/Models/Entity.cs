using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class Entity
    {
        public Entity()
        {
            ControlSettings = new HashSet<ControlSetting>();
            Reports = new HashSet<Report>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual ICollection<ControlSetting> ControlSettings { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
