using System;
using System.Collections.Generic;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class Language
    {
        public Language()
        {
            CustomerSearches = new HashSet<CustomerSearch>();
            EsAliasIndexLanguageMappings = new HashSet<EsAliasIndexLanguageMapping>();
            LocaleStringResourceControls = new HashSet<LocaleStringResourceControl>();
            LocaleStringResourceSettings = new HashSet<LocaleStringResourceSetting>();
            PaymentInfos = new HashSet<PaymentInfo>();
            StaticLocaleStringResources = new HashSet<StaticLocaleStringResource>();
            Stores = new HashSet<Store>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LanguageCulture { get; set; }
        public string UniqueSeoCode { get; set; }
        public string FlagImageFileName { get; set; }
        public bool Rtl { get; set; }
        public bool LimitedToStores { get; set; }
        public int DefaultCurrencyId { get; set; }
        public bool Published { get; set; }
        public int DisplayOrder { get; set; }
        public bool DefaultLanguage { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual Currency DefaultCurrency { get; set; }
        public virtual ICollection<CustomerSearch> CustomerSearches { get; set; }
        public virtual ICollection<EsAliasIndexLanguageMapping> EsAliasIndexLanguageMappings { get; set; }
        public virtual ICollection<LocaleStringResourceControl> LocaleStringResourceControls { get; set; }
        public virtual ICollection<LocaleStringResourceSetting> LocaleStringResourceSettings { get; set; }
        public virtual ICollection<PaymentInfo> PaymentInfos { get; set; }
        public virtual ICollection<StaticLocaleStringResource> StaticLocaleStringResources { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
    }
}
