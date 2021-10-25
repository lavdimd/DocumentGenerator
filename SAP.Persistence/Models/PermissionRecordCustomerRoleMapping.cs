using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class PermissionRecordCustomerRoleMapping
    {
        public int Id { get; set; }
        public int PermissionRecordId { get; set; }
        public int CustomerRoleId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual CustomerRole CustomerRole { get; set; }
        public virtual PermissionRecord PermissionRecord { get; set; }
    }
}
