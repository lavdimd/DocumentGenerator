using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class PermissionRecord
    {
        public PermissionRecord()
        {
            PermissionRecordCustomerRoleMappings = new HashSet<PermissionRecordCustomerRoleMapping>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Scope { get; set; }
        public string SystemName { get; set; }
        public string Category { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual ICollection<PermissionRecordCustomerRoleMapping> PermissionRecordCustomerRoleMappings { get; set; }
    }
}
