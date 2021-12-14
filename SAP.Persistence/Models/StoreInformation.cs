using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class StoreInformation
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public string StoreOrderNumber { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public string SmartEmailingEmail { get; set; }
        public string AddressName { get; set; }
        public string BusinessId { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public string Logo { get; set; }
        public string RegisteredOffice { get; set; }
        public string TaxId { get; set; }
        public decimal TaxRate { get; set; }

        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual Store Store { get; set; }
    }
}
