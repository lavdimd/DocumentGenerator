using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class Country
    {
        public Country()
        {
            Addresses = new HashSet<Address>();
            Cities = new HashSet<City>();
            DeferredRevenues = new HashSet<DeferredRevenue>();
            PaymentInfos = new HashSet<PaymentInfo>();
            StateProvinces = new HashSet<StateProvince>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool AllowsBilling { get; set; }
        public bool AllowsShipping { get; set; }
        public string TwoLetterIsoCode { get; set; }
        public string ThreeLetterIsoCode { get; set; }
        public int NumericIsoCode { get; set; }
        public bool SubjectToVat { get; set; }
        public bool Published { get; set; }
        public int DisplayOrder { get; set; }
        public bool LimitedToStores { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public string ExternalCodeForSap { get; set; }
        public int Vatrate { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<DeferredRevenue> DeferredRevenues { get; set; }
        public virtual ICollection<PaymentInfo> PaymentInfos { get; set; }
        public virtual ICollection<StateProvince> StateProvinces { get; set; }
    }
}
