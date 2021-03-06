using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class ActionNotification
    {
        public int Id { get; set; }
        public int ActionNotificationType { get; set; }
        public int ActorId { get; set; }
        public int EntityId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
