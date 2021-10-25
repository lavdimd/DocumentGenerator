using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class Conversation
    {
        public Conversation()
        {
            Messages = new HashSet<Message>();
        }

        public int Id { get; set; }
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
        public int ClassifiedAdId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public int NewMessagesCount { get; set; }
        public DateTime? LastMessageSend { get; set; }
        public int LastMessageSendBy { get; set; }
        public bool? Seen { get; set; }
        public Guid ConversationGuid { get; set; }
        public DateTime? LastMessageRead { get; set; }
        public Guid FromUserGuid { get; set; }
        public Guid ToUserGuid { get; set; }
        public bool NewMessageNotificationEmailSent { get; set; }
        public bool? FromUserIdDeleted { get; set; }
        public bool? ToUserIdDeleted { get; set; }

        public virtual ClassifiedAd ClassifiedAd { get; set; }
        public virtual Customer FromUser { get; set; }
        public virtual Customer ToUser { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
