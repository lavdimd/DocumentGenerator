using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class City
    {
        public City()
        {
            Addresses = new HashSet<Address>();
            CustomerSearches = new HashSet<CustomerSearch>();
            StoreInformations = new HashSet<StoreInformation>();
        }

        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public bool Published { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public string ZipCode { get; set; }
        public string NormalizedName { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<CustomerSearch> CustomerSearches { get; set; }
        public virtual ICollection<StoreInformation> StoreInformations { get; set; }
    }
}
