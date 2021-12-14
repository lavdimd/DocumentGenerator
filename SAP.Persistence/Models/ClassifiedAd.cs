using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class ClassifiedAd
    {
        public ClassifiedAd()
        {
            BoostingPlanClassifiedAdMappings = new HashSet<BoostingPlanClassifiedAdMapping>();
            ClassifiedAdCategoryMappings = new HashSet<ClassifiedAdCategoryMapping>();
            ClassifiedAdPictureMappings = new HashSet<ClassifiedAdPictureMapping>();
            ClassifiedAdSpecificationAttributeOptionMappings = new HashSet<ClassifiedAdSpecificationAttributeOptionMapping>();
            Conversations = new HashSet<Conversation>();
            CustomerFavorites = new HashSet<CustomerFavorite>();
            DeferredRevenues = new HashSet<DeferredRevenue>();
            PaymentInfos = new HashSet<PaymentInfo>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaTitle { get; set; }
        public string FullDescription { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public bool Free { get; set; }
        public bool CallForPrice { get; set; }
        public bool EnableOffer { get; set; }
        public bool ShowPhoneNumber { get; set; }
        public int Status { get; set; }
        public bool Published { get; set; }
        public DateTime PublishedDate { get; set; }
        public int PublisherId { get; set; }
        public int AddressId { get; set; }
        public int CustomerId { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool ClassifiedAdBoosted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public int StoreId { get; set; }
        public int? SecondaryId { get; set; }

        public virtual Address Address { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual EsoperationClassifiedAd EsoperationClassifiedAd { get; set; }
        public virtual ICollection<BoostingPlanClassifiedAdMapping> BoostingPlanClassifiedAdMappings { get; set; }
        public virtual ICollection<ClassifiedAdCategoryMapping> ClassifiedAdCategoryMappings { get; set; }
        public virtual ICollection<ClassifiedAdPictureMapping> ClassifiedAdPictureMappings { get; set; }
        public virtual ICollection<ClassifiedAdSpecificationAttributeOptionMapping> ClassifiedAdSpecificationAttributeOptionMappings { get; set; }
        public virtual ICollection<Conversation> Conversations { get; set; }
        public virtual ICollection<CustomerFavorite> CustomerFavorites { get; set; }
        public virtual ICollection<DeferredRevenue> DeferredRevenues { get; set; }
        public virtual ICollection<PaymentInfo> PaymentInfos { get; set; }
    }
}
