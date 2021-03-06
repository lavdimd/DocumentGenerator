using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class EntityNotification
    {
        public EntityNotification()
        {
            Notifications = new HashSet<Notification>();
        }

        public int Id { get; set; }
        public string Message { get; set; }
        public int EntityId { get; set; }
        public string EntityName { get; set; }
        public string ImageUrl { get; set; }
        public string RedirectUrl { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
