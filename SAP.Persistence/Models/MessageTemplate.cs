using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class MessageTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BccEmailAddresses { get; set; }
        public string Subject { get; set; }
        public int EmailAccountId { get; set; }
        public string Body { get; set; }
        public bool? IsActive { get; set; }
        public bool DelayBeforeSend { get; set; }
        public int DelayPeriodId { get; set; }
        public bool AttachedDownloadId { get; set; }
        public bool LimitedToStores { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual EmailAccount EmailAccount { get; set; }
    }
}
