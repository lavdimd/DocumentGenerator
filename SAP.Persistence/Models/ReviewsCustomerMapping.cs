using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class ReviewsCustomerMapping
    {
        public int Id { get; set; }
        public int ReviewId { get; set; }
        public int FromCustomerId { get; set; }
        public int ToCustomerId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual Customer FromCustomer { get; set; }
        public virtual Review Review { get; set; }
        public virtual Customer ToCustomer { get; set; }
    }
}
