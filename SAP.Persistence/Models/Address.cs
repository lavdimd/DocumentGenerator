using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class Address
    {
        public Address()
        {
            ClassifiedAds = new HashSet<ClassifiedAd>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public int? CountryId { get; set; }
        public int? StateProvinceId { get; set; }
        public string County { get; set; }
        public int? CityId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ZipPostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string CustomAttributes { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public int Status { get; set; }

        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual StateProvince StateProvince { get; set; }
        public virtual CustomerAddressMapping CustomerAddressMapping { get; set; }
        public virtual ICollection<ClassifiedAd> ClassifiedAds { get; set; }
    }
}
