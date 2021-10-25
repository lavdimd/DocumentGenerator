using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class Notification
    {
        public int Id { get; set; }
        public int NotificationTypeId { get; set; }
        public int NotificationId { get; set; }
        public int ReceiverId { get; set; }
        public Guid ReceiverGuid { get; set; }
        public DateTime EventDateTime { get; set; }
        public bool IsSeen { get; set; }
        public bool IsSent { get; set; }
        public bool IsEmailSent { get; set; }
        public byte Group { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual EntityNotification NotificationNavigation { get; set; }
    }
}
