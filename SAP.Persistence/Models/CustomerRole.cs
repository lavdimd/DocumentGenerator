using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class CustomerRole
    {
        public CustomerRole()
        {
            CustomerCustomerRoleMappings = new HashSet<CustomerCustomerRoleMapping>();
            PermissionRecordCustomerRoleMappings = new HashSet<PermissionRecordCustomerRoleMapping>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool FreeShipping { get; set; }
        public bool TaxExempt { get; set; }
        public bool Active { get; set; }
        public bool IsSystemRole { get; set; }
        public string SystemName { get; set; }
        public bool EnablePasswordLifetime { get; set; }
        public bool OverrideTaxDisplayType { get; set; }
        public int DefaultTaxDisplayTypeId { get; set; }
        public int PurchasedWithProductId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual ICollection<CustomerCustomerRoleMapping> CustomerCustomerRoleMappings { get; set; }
        public virtual ICollection<PermissionRecordCustomerRoleMapping> PermissionRecordCustomerRoleMappings { get; set; }
    }
}
