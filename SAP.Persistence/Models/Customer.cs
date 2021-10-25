using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class Customer
    {
        public Customer()
        {
            BlockCustomerFromCustomers = new HashSet<BlockCustomer>();
            BlockCustomerToCustomers = new HashSet<BlockCustomer>();
            BoostingPlanClassifiedAdMappings = new HashSet<BoostingPlanClassifiedAdMapping>();
            ClassifiedAds = new HashSet<ClassifiedAd>();
            ConversationFromUsers = new HashSet<Conversation>();
            ConversationToUsers = new HashSet<Conversation>();
            CustomerAddressMappings = new HashSet<CustomerAddressMapping>();
            CustomerCustomerRoleMappings = new HashSet<CustomerCustomerRoleMapping>();
            CustomerFavorites = new HashSet<CustomerFavorite>();
            CustomerSearches = new HashSet<CustomerSearch>();
            FollowFromCustomers = new HashSet<Follow>();
            FollowToCustomers = new HashSet<Follow>();
            Invoices = new HashSet<Invoice>();
            PaymentInfos = new HashSet<PaymentInfo>();
            Payments = new HashSet<Payment>();
            Reports = new HashSet<Report>();
            ReviewsCustomerMappingFromCustomers = new HashSet<ReviewsCustomerMapping>();
            ReviewsCustomerMappingToCustomers = new HashSet<ReviewsCustomerMapping>();
            TransactionHistories = new HashSet<TransactionHistory>();
        }

        public int Id { get; set; }
        public Guid CustomerGuid { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string EmailToRevalidate { get; set; }
        public string AdminComment { get; set; }
        public bool IsTaxExempt { get; set; }
        public int AffiliateId { get; set; }
        public int VendorId { get; set; }
        public bool RequireReLogin { get; set; }
        public DateTime? CannotLoginUntilDateUtc { get; set; }
        public bool Active { get; set; }
        public bool IsSystemAccount { get; set; }
        public string SystemName { get; set; }
        public string LastIpAddress { get; set; }
        public DateTime? LastLoginDateUtc { get; set; }
        public DateTime LastActivityDateUtc { get; set; }
        public int RegisteredInStoreId { get; set; }
        public int DefaultCustomerLanguageId { get; set; }
        public string DefaultCustomerCurrencyCode { get; set; }
        public string IamId { get; set; }
        public string ProfilePictureUrl { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public int? UserResponseTimeInMinutes { get; set; }
        public decimal? UserResponseRate { get; set; }

        public virtual ICollection<BlockCustomer> BlockCustomerFromCustomers { get; set; }
        public virtual ICollection<BlockCustomer> BlockCustomerToCustomers { get; set; }
        public virtual ICollection<BoostingPlanClassifiedAdMapping> BoostingPlanClassifiedAdMappings { get; set; }
        public virtual ICollection<ClassifiedAd> ClassifiedAds { get; set; }
        public virtual ICollection<Conversation> ConversationFromUsers { get; set; }
        public virtual ICollection<Conversation> ConversationToUsers { get; set; }
        public virtual ICollection<CustomerAddressMapping> CustomerAddressMappings { get; set; }
        public virtual ICollection<CustomerCustomerRoleMapping> CustomerCustomerRoleMappings { get; set; }
        public virtual ICollection<CustomerFavorite> CustomerFavorites { get; set; }
        public virtual ICollection<CustomerSearch> CustomerSearches { get; set; }
        public virtual ICollection<Follow> FollowFromCustomers { get; set; }
        public virtual ICollection<Follow> FollowToCustomers { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<PaymentInfo> PaymentInfos { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<ReviewsCustomerMapping> ReviewsCustomerMappingFromCustomers { get; set; }
        public virtual ICollection<ReviewsCustomerMapping> ReviewsCustomerMappingToCustomers { get; set; }
        public virtual ICollection<TransactionHistory> TransactionHistories { get; set; }
    }
}
