using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SAP.Persistence.Models
{
    public partial class EcommerceClientContext : DbContext
    {
        public EcommerceClientContext()
        {
        }

        public EcommerceClientContext(DbContextOptions<EcommerceClientContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActionNotification> ActionNotifications { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<AggregatedCounter> AggregatedCounters { get; set; }
        public virtual DbSet<Banner> Banners { get; set; }
        public virtual DbSet<BlockCustomer> BlockCustomers { get; set; }
        public virtual DbSet<BoostPosition> BoostPositions { get; set; }
        public virtual DbSet<BoostedDisplayOrder> BoostedDisplayOrders { get; set; }
        public virtual DbSet<BoostingPlan> BoostingPlans { get; set; }
        public virtual DbSet<BoostingPlanClassifiedAdMapping> BoostingPlanClassifiedAdMappings { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategorySpecificationAttributeMapping> CategorySpecificationAttributeMappings { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<ClassifiedAd> ClassifiedAds { get; set; }
        public virtual DbSet<ClassifiedAdCategoryMapping> ClassifiedAdCategoryMappings { get; set; }
        public virtual DbSet<ClassifiedAdPictureMapping> ClassifiedAdPictureMappings { get; set; }
        public virtual DbSet<ClassifiedAdSpecificationAttributeOptionMapping> ClassifiedAdSpecificationAttributeOptionMappings { get; set; }
        public virtual DbSet<ConfigurablePage> ConfigurablePages { get; set; }
        public virtual DbSet<ControlSetting> ControlSettings { get; set; }
        public virtual DbSet<Conversation> Conversations { get; set; }
        public virtual DbSet<Counter> Counters { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<CustomNotification> CustomNotifications { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerAddressMapping> CustomerAddressMappings { get; set; }
        public virtual DbSet<CustomerCustomerRoleMapping> CustomerCustomerRoleMappings { get; set; }
        public virtual DbSet<CustomerFavorite> CustomerFavorites { get; set; }
        public virtual DbSet<CustomerRole> CustomerRoles { get; set; }
        public virtual DbSet<CustomerSearch> CustomerSearches { get; set; }
        public virtual DbSet<DataAnnotationType> DataAnnotationTypes { get; set; }
        public virtual DbSet<DefaultSapObjectInterface> DefaultSapObjectInterfaces { get; set; }
        public virtual DbSet<DeferredRevenue> DeferredRevenues { get; set; }
        public virtual DbSet<EmailAccount> EmailAccounts { get; set; }
        public virtual DbSet<Entity> Entities { get; set; }
        public virtual DbSet<EntityNotification> EntityNotifications { get; set; }
        public virtual DbSet<EsAliasIndexLanguageMapping> EsAliasIndexLanguageMappings { get; set; }
        public virtual DbSet<EsIndexType> EsIndexTypes { get; set; }
        public virtual DbSet<EsoperationClassifiedAd> EsoperationClassifiedAds { get; set; }
        public virtual DbSet<EsoperationType> EsoperationTypes { get; set; }
        public virtual DbSet<Follow> Follows { get; set; }
        public virtual DbSet<GenericAttribute> GenericAttributes { get; set; }
        public virtual DbSet<Hash> Hashes { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<JobParameter> JobParameters { get; set; }
        public virtual DbSet<JobQueue> JobQueues { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<List> Lists { get; set; }
        public virtual DbSet<LocaleStringResourceControl> LocaleStringResourceControls { get; set; }
        public virtual DbSet<LocaleStringResourceSetting> LocaleStringResourceSettings { get; set; }
        public virtual DbSet<LocalizationKeyStaticLocaleStringResourceMapping> LocalizationKeyStaticLocaleStringResourceMappings { get; set; }
        public virtual DbSet<LocalizedProperty> LocalizedProperties { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<LogLevel> LogLevels { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<MessageTemplate> MessageTemplates { get; set; }
        public virtual DbSet<NewsLetterSubscription> NewsLetterSubscriptions { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Operator> Operators { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentInfo> PaymentInfos { get; set; }
        public virtual DbSet<PermissionRecord> PermissionRecords { get; set; }
        public virtual DbSet<PermissionRecordCustomerRoleMapping> PermissionRecordCustomerRoleMappings { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<QueuedEmail> QueuedEmails { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<ReportType> ReportTypes { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<ReviewsCustomerMapping> ReviewsCustomerMappings { get; set; }
        public virtual DbSet<Rule> Rules { get; set; }
        public virtual DbSet<RuleQuery> RuleQueries { get; set; }
        public virtual DbSet<SapInterfaceTransaction> SapInterfaceTransactions { get; set; }
        public virtual DbSet<Schema> Schemas { get; set; }
        public virtual DbSet<Scope> Scopes { get; set; }
        public virtual DbSet<ScopeProperty> ScopeProperties { get; set; }
        public virtual DbSet<ScopePropertyOperatorMapping> ScopePropertyOperatorMappings { get; set; }
        public virtual DbSet<SearchFilter> SearchFilters { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<Server> Servers { get; set; }
        public virtual DbSet<Set> Sets { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<SpecificationAttribute> SpecificationAttributes { get; set; }
        public virtual DbSet<SpecificationAttributeOption> SpecificationAttributeOptions { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<StateProvince> StateProvinces { get; set; }
        public virtual DbSet<StaticLocaleStringResource> StaticLocaleStringResources { get; set; }
        public virtual DbSet<StaticSetting> StaticSettings { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<StoreInformation> StoreInformations { get; set; }
        public virtual DbSet<StoreMapping> StoreMappings { get; set; }
        public virtual DbSet<StylingTag> StylingTags { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<TransactionHistory> TransactionHistories { get; set; }
        public virtual DbSet<UrlRecord> UrlRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-0SEBGP48;Database=EcommerceClient;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ActionNotification>(entity =>
            {
                entity.ToTable("ActionNotification");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.Address1).HasMaxLength(100);

                entity.Property(e => e.Address2).HasMaxLength(100);

                entity.Property(e => e.Company).HasMaxLength(100);

                entity.Property(e => e.County).HasMaxLength(100);

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CustomAttributes).HasMaxLength(150);

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FaxNumber).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.Latitude).HasMaxLength(150);

                entity.Property(e => e.Longitude).HasMaxLength(150);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.ZipPostalCode).HasMaxLength(50);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CityId);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CountryId);

                entity.HasOne(d => d.StateProvince)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.StateProvinceId);
            });

            modelBuilder.Entity<AggregatedCounter>(entity =>
            {
                entity.HasKey(e => e.Key)
                    .HasName("PK_HangFire_CounterAggregated");

                entity.ToTable("AggregatedCounter", "HangFire");

                entity.HasIndex(e => e.ExpireAt, "IX_HangFire_AggregatedCounter_ExpireAt")
                    .HasFilter("([ExpireAt] IS NOT NULL)");

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Banner>(entity =>
            {
                entity.ToTable("Banner");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.RedirectUrl).HasMaxLength(2048);

                entity.Property(e => e.Title).HasMaxLength(100);
            });

            modelBuilder.Entity<BlockCustomer>(entity =>
            {
                entity.ToTable("BlockCustomer");

                entity.HasIndex(e => e.Deleted, "IX_BlockCustomer_Deleted");

                entity.HasIndex(e => new { e.FromCustomerId, e.ToCustomerId, e.Deleted }, "IX_BlockCustomer_FromCustomerId_ToCustomerId_Deleted");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.HasOne(d => d.FromCustomer)
                    .WithMany(p => p.BlockCustomerFromCustomers)
                    .HasForeignKey(d => d.FromCustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ToCustomer)
                    .WithMany(p => p.BlockCustomerToCustomers)
                    .HasForeignKey(d => d.ToCustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<BoostPosition>(entity =>
            {
                entity.ToTable("BoostPosition");

                entity.HasIndex(e => new { e.BoostDisplayId, e.Deleted }, "IX_BoostPosition_BoostDisplayId_Deleted");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.HasOne(d => d.BoostDisplay)
                    .WithMany(p => p.BoostPositions)
                    .HasForeignKey(d => d.BoostDisplayId);
            });

            modelBuilder.Entity<BoostedDisplayOrder>(entity =>
            {
                entity.ToTable("BoostedDisplayOrder");

                entity.HasIndex(e => e.Deleted, "IX_BoostedDisplayOrder_Deleted");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");
            });

            modelBuilder.Entity<BoostingPlan>(entity =>
            {
                entity.ToTable("BoostingPlan");

                entity.HasIndex(e => new { e.CategoryId, e.Status, e.Published, e.Name, e.Deleted }, "IX_BoostingPlan_CategoryId_Status_Published_Name_Deleted");

                entity.HasIndex(e => new { e.Deleted, e.Published }, "IX_BoostingPlan_Deleted_Published");

                entity.HasIndex(e => new { e.Published, e.Deleted }, "IX_BoostingPlan_Published_Deleted");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Description).HasMaxLength(2048);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Priority).HasComment("Low = 1, Medium = 2, High = 3");

                entity.Property(e => e.Published)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Status).HasComment("Active = 1, Passive = 2, Expired = 3, All = 4");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.BoostingPlans)
                    .HasForeignKey(d => d.CategoryId);

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.BoostingPlans)
                    .HasForeignKey(d => d.CurrencyId);
            });

            modelBuilder.Entity<BoostingPlanClassifiedAdMapping>(entity =>
            {
                entity.ToTable("BoostingPlan_ClassifiedAd_Mapping");

                entity.HasIndex(e => new { e.Active, e.DateTo, e.Deleted }, "IX_BoostingPlan_ClassifiedAd_Mapping_Active_DateTo_Deleted");

                entity.HasIndex(e => new { e.AutomaticUpdate, e.NextDateForAutomaticUpdate, e.Deleted }, "IX_BoostingPlan_ClassifiedAd_Mapping_AutomaticUpdate_NextDateForAutomaticUpdate_Deleted");

                entity.HasIndex(e => e.BoostingPlanId, "IX_BoostingPlan_ClassifiedAd_Mapping_BoostingPlanId");

                entity.HasIndex(e => new { e.ClassifiedAdId, e.Active, e.Deleted }, "IX_BoostingPlan_ClassifiedAd_Mapping_ClassifiedAdId_Active_Deleted");

                entity.HasIndex(e => new { e.DateTo, e.Deleted }, "IX_BoostingPlan_ClassifiedAd_Mapping_DateTo_Deleted");

                entity.HasIndex(e => e.Deleted, "IX_BoostingPlan_ClassifiedAd_Mapping_Deleted");

                entity.HasIndex(e => new { e.UserNotificationTime, e.UserNotified, e.Deleted }, "IX_BoostingPlan_ClassifiedAd_Mapping_UserNotificationTime_UserNotified_Deleted");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Description).HasMaxLength(2048);

                entity.Property(e => e.UserNotified)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.HasOne(d => d.BoostingPlan)
                    .WithMany(p => p.BoostingPlanClassifiedAdMappings)
                    .HasForeignKey(d => d.BoostingPlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ClassifiedAd)
                    .WithMany(p => p.BoostingPlanClassifiedAdMappings)
                    .HasForeignKey(d => d.ClassifiedAdId);

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.BoostingPlanClassifiedAdMappings)
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.BoostingPlanClassifiedAdMappings)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.HasIndex(e => e.Deleted, "IX_Category_Deleted");

                entity.HasIndex(e => new { e.Deleted, e.ParentCategoryId }, "IX_Category_Deleted_ParentCategoryId");

                entity.HasIndex(e => new { e.IncludeInTopMenu, e.Deleted }, "IX_Category_IncludeInTopMenu_Deleted");

                entity.HasIndex(e => new { e.IncludeInTopMenu, e.Deleted, e.ParentCategoryId }, "IX_Category_IncludeInTopMenu_Deleted_ParentCategoryId");

                entity.HasIndex(e => new { e.ParentCategoryId, e.ShowOnHomepage, e.IncludeInTopMenu, e.Deleted, e.DisplayOrder }, "IX_Category_ParentCategoryId_ShowOnHomepage_IncludeInTopMenu_Deleted_DisplayOrder");

                entity.HasIndex(e => e.SecondaryId, "IX_Category_SecondaryId")
                    .IsUnique()
                    .HasFilter("([SecondaryId] IS NOT NULL)");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Description).HasMaxLength(2048);

                entity.Property(e => e.EnableSelect)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(2048)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.MetaKeywords).HasMaxLength(150);

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.HasOne(d => d.ParentCategory)
                    .WithMany(p => p.InverseParentCategory)
                    .HasForeignKey(d => d.ParentCategoryId);
            });

            modelBuilder.Entity<CategorySpecificationAttributeMapping>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.SpecificationAttributeId, e.CategoryId });

                entity.ToTable("Category_SpecificationAttribute_Mapping");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.CategorySpecificationAttributeMappings)
                    .HasForeignKey(d => d.CategoryId);

                entity.HasOne(d => d.SpecificationAttribute)
                    .WithMany(p => p.CategorySpecificationAttributeMappings)
                    .HasForeignKey(d => d.SpecificationAttributeId);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.HasIndex(e => new { e.CountryId, e.Deleted, e.DisplayOrder }, "IX_City_CountryId_Deleted_DisplayOrder");

                entity.HasIndex(e => new { e.Deleted, e.DisplayOrder }, "IX_City_Deleted_DisplayOrder");

                entity.HasIndex(e => new { e.Deleted, e.Name, e.DisplayOrder }, "IX_City_Deleted_Name_DisplayOrder");

                entity.Property(e => e.Abbreviation).HasMaxLength(100);

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(N'')");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId);
            });

            modelBuilder.Entity<ClassifiedAd>(entity =>
            {
                entity.ToTable("ClassifiedAd");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.FullDescription).HasMaxLength(4000);

                entity.Property(e => e.MetaKeywords).HasMaxLength(400);

                entity.Property(e => e.MetaTitle).HasMaxLength(400);

                entity.Property(e => e.Name).HasMaxLength(400);

                entity.Property(e => e.OldPrice).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Status).HasComment("AllStatuses = 0, Active = 1, Edit = 2, Expired = 3, Sold = 4");

                entity.Property(e => e.StoreId).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.ClassifiedAds)
                    .HasForeignKey(d => d.AddressId);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ClassifiedAds)
                    .HasForeignKey(d => d.CustomerId);
            });

            modelBuilder.Entity<ClassifiedAdCategoryMapping>(entity =>
            {
                entity.HasKey(e => new { e.CategoryId, e.ClassifiedAdId, e.Id });

                entity.ToTable("ClassifiedAd_Category_Mapping");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ClassifiedAdCategoryMappings)
                    .HasForeignKey(d => d.CategoryId);

                entity.HasOne(d => d.ClassifiedAd)
                    .WithMany(p => p.ClassifiedAdCategoryMappings)
                    .HasForeignKey(d => d.ClassifiedAdId);
            });

            modelBuilder.Entity<ClassifiedAdPictureMapping>(entity =>
            {
                entity.HasKey(e => new { e.ClassifiedAdId, e.PictureId, e.Id });

                entity.ToTable("ClassifiedAd_Picture_Mapping");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.HasOne(d => d.ClassifiedAd)
                    .WithMany(p => p.ClassifiedAdPictureMappings)
                    .HasForeignKey(d => d.ClassifiedAdId);

                entity.HasOne(d => d.Picture)
                    .WithMany(p => p.ClassifiedAdPictureMappings)
                    .HasForeignKey(d => d.PictureId);
            });

            modelBuilder.Entity<ClassifiedAdSpecificationAttributeOptionMapping>(entity =>
            {
                entity.HasKey(e => new { e.ClassifiedAdId, e.SpecificationAttributeOptionId, e.Id });

                entity.ToTable("ClassifiedAd_SpecificationAttributeOption_Mapping");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Value).HasMaxLength(4000);

                entity.HasOne(d => d.ClassifiedAd)
                    .WithMany(p => p.ClassifiedAdSpecificationAttributeOptionMappings)
                    .HasForeignKey(d => d.ClassifiedAdId);

                entity.HasOne(d => d.SpecificationAttributeOption)
                    .WithMany(p => p.ClassifiedAdSpecificationAttributeOptionMappings)
                    .HasForeignKey(d => d.SpecificationAttributeOptionId);
            });

            modelBuilder.Entity<ConfigurablePage>(entity =>
            {
                entity.ToTable("ConfigurablePage");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasMaxLength(400)
                    .HasDefaultValueSql("(N'')");
            });

            modelBuilder.Entity<ControlSetting>(entity =>
            {
                entity.ToTable("ControlSetting");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DefaultValue).HasMaxLength(150);

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.HasOne(d => d.Entity)
                    .WithMany(p => p.ControlSettings)
                    .HasForeignKey(d => d.EntityId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Conversation>(entity =>
            {
                entity.ToTable("Conversation");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.FromUserIdDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Seen)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.ToUserIdDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.HasOne(d => d.ClassifiedAd)
                    .WithMany(p => p.Conversations)
                    .HasForeignKey(d => d.ClassifiedAdId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.FromUser)
                    .WithMany(p => p.ConversationFromUsers)
                    .HasForeignKey(d => d.FromUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ToUser)
                    .WithMany(p => p.ConversationToUsers)
                    .HasForeignKey(d => d.ToUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Counter>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Counter", "HangFire");

                entity.HasIndex(e => e.Key, "CX_HangFire_Counter")
                    .IsClustered();

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.HasIndex(e => new { e.Deleted, e.DisplayOrder }, "IX_Country_Deleted_DisplayOrder");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.ExternalCodeForSap)
                    .HasMaxLength(3)
                    .HasColumnName("ExternalCodeForSAP");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ThreeLetterIsoCode).HasMaxLength(3);

                entity.Property(e => e.TwoLetterIsoCode).HasMaxLength(2);

                entity.Property(e => e.Vatrate).HasColumnName("VATRate");
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.ToTable("Currency");

                entity.HasIndex(e => new { e.CurrencyCode, e.Deleted }, "IX_Currency_CurrencyCode_Deleted");

                entity.HasIndex(e => new { e.Deleted, e.DisplayOrder }, "IX_Currency_Deleted_DisplayOrder");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.CustomFormatting).HasMaxLength(50);

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.DisplayLocale).HasMaxLength(50);

                entity.Property(e => e.DomainEndings).HasMaxLength(2048);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Rate).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<CustomNotification>(entity =>
            {
                entity.ToTable("CustomNotification");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.ImageUrl).HasMaxLength(4000);

                entity.Property(e => e.Message).HasMaxLength(4000);

                entity.Property(e => e.RedirectUrl).HasMaxLength(4000);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.HasIndex(e => new { e.CustomerGuid, e.Deleted }, "IX_Customer_CustomerGuid_Deleted");

                entity.Property(e => e.AdminComment).HasMaxLength(150);

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DefaultCustomerCurrencyCode).HasMaxLength(96);

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.EmailToRevalidate).HasMaxLength(150);

                entity.Property(e => e.FirstName).HasMaxLength(150);

                entity.Property(e => e.IamId).HasMaxLength(1024);

                entity.Property(e => e.LastIpAddress).HasMaxLength(150);

                entity.Property(e => e.LastName).HasMaxLength(150);

                entity.Property(e => e.ProfilePictureUrl).HasMaxLength(2048);

                entity.Property(e => e.SystemName).HasMaxLength(150);

                entity.Property(e => e.UserResponseRate).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Username).HasMaxLength(100);
            });

            modelBuilder.Entity<CustomerAddressMapping>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.AddressId, e.Id });

                entity.ToTable("Customer_Address_Mapping");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.CustomerAddressMappings)
                    .HasForeignKey(d => d.AddressId);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerAddressMappings)
                    .HasForeignKey(d => d.CustomerId);
            });

            modelBuilder.Entity<CustomerCustomerRoleMapping>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.CustomerRoleId, e.Id });

                entity.ToTable("Customer_CustomerRole_Mapping");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerCustomerRoleMappings)
                    .HasForeignKey(d => d.CustomerId);

                entity.HasOne(d => d.CustomerRole)
                    .WithMany(p => p.CustomerCustomerRoleMappings)
                    .HasForeignKey(d => d.CustomerRoleId);
            });

            modelBuilder.Entity<CustomerFavorite>(entity =>
            {
                entity.ToTable("CustomerFavorite");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.HasOne(d => d.ClassifiedAd)
                    .WithMany(p => p.CustomerFavorites)
                    .HasForeignKey(d => d.ClassifiedAdId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerFavorites)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<CustomerRole>(entity =>
            {
                entity.ToTable("CustomerRole");

                entity.HasIndex(e => e.SystemName, "IX_CustomerRole_SystemName")
                    .IsUnique()
                    .HasFilter("([SystemName] IS NOT NULL)");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.SystemName).HasMaxLength(150);
            });

            modelBuilder.Entity<CustomerSearch>(entity =>
            {
                entity.ToTable("CustomerSearch");

                entity.HasIndex(e => e.CityId, "IX_CustomerSearch_CityId");

                entity.HasIndex(e => e.StoreId, "IX_CustomerSearch_StoreId");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.EnableEmailNotifications)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.FullTextSearch).HasMaxLength(400);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.CustomerSearches)
                    .HasForeignKey(d => d.CategoryId);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.CustomerSearches)
                    .HasForeignKey(d => d.CityId);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerSearches)
                    .HasForeignKey(d => d.CustomerId);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.CustomerSearches)
                    .HasForeignKey(d => d.LanguageId);

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.CustomerSearches)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<DataAnnotationType>(entity =>
            {
                entity.ToTable("DataAnnotationType");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Name).HasMaxLength(150);
            });

            modelBuilder.Entity<DefaultSapObjectInterface>(entity =>
            {
                entity.ToTable("DefaultSapObjectInterface");

                entity.Property(e => e.Altkt)
                    .HasMaxLength(50)
                    .HasColumnName("ALTKT");

                entity.Property(e => e.Aufnr)
                    .HasMaxLength(20)
                    .HasColumnName("AUFNR");

                entity.Property(e => e.Barcd)
                    .HasMaxLength(20)
                    .HasColumnName("BARCD");

                entity.Property(e => e.Bewar)
                    .HasMaxLength(20)
                    .HasColumnName("BEWAR");

                entity.Property(e => e.Bktxt)
                    .HasMaxLength(100)
                    .HasColumnName("BKTXT");

                entity.Property(e => e.Blart)
                    .HasMaxLength(10)
                    .HasColumnName("BLART");

                entity.Property(e => e.Bldat)
                    .HasMaxLength(20)
                    .HasColumnName("BLDAT");

                entity.Property(e => e.Bschl)
                    .HasMaxLength(20)
                    .HasColumnName("BSCHL");

                entity.Property(e => e.Budat)
                    .HasMaxLength(20)
                    .HasColumnName("BUDAT");

                entity.Property(e => e.Bukrs)
                    .HasMaxLength(150)
                    .HasColumnName("BUKRS");

                entity.Property(e => e.Buzei)
                    .HasMaxLength(15)
                    .HasColumnName("BUZEI");

                entity.Property(e => e.Bvtyp)
                    .HasMaxLength(20)
                    .HasColumnName("BVTYP");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Dmbtr)
                    .HasMaxLength(20)
                    .HasColumnName("DMBTR");

                entity.Property(e => e.DmbtrBrutto)
                    .HasMaxLength(20)
                    .HasColumnName("DMBTR_BRUTTO");

                entity.Property(e => e.Fkber)
                    .HasMaxLength(20)
                    .HasColumnName("FKBER");

                entity.Property(e => e.Gjahr)
                    .HasMaxLength(15)
                    .HasColumnName("GJAHR");

                entity.Property(e => e.Gsber)
                    .HasMaxLength(20)
                    .HasColumnName("GSBER");

                entity.Property(e => e.Hkont)
                    .HasMaxLength(50)
                    .HasColumnName("HKONT");

                entity.Property(e => e.Kostl)
                    .HasMaxLength(20)
                    .HasColumnName("KOSTL");

                entity.Property(e => e.Meins)
                    .HasMaxLength(20)
                    .HasColumnName("MEINS");

                entity.Property(e => e.Menge)
                    .HasMaxLength(20)
                    .HasColumnName("MENGE");

                entity.Property(e => e.Monat)
                    .HasMaxLength(10)
                    .HasColumnName("MONAT");

                entity.Property(e => e.Mwskz)
                    .HasMaxLength(20)
                    .HasColumnName("MWSKZ");

                entity.Property(e => e.Mwsts)
                    .HasMaxLength(20)
                    .HasColumnName("MWSTS");

                entity.Property(e => e.Pernr)
                    .HasMaxLength(20)
                    .HasColumnName("PERNR");

                entity.Property(e => e.Prctr)
                    .HasMaxLength(20)
                    .HasColumnName("PRCTR");

                entity.Property(e => e.Projk)
                    .HasMaxLength(20)
                    .HasColumnName("PROJK");

                entity.Property(e => e.Sgtxt)
                    .HasMaxLength(150)
                    .HasColumnName("SGTXT");

                entity.Property(e => e.Shkzg)
                    .HasMaxLength(20)
                    .HasColumnName("SHKZG");

                entity.Property(e => e.Umskz)
                    .HasMaxLength(50)
                    .HasColumnName("UMSKZ");

                entity.Property(e => e.Vbund)
                    .HasMaxLength(20)
                    .HasColumnName("VBUND");

                entity.Property(e => e.Waers)
                    .HasMaxLength(20)
                    .HasColumnName("WAERS");

                entity.Property(e => e.Wmwst)
                    .HasMaxLength(20)
                    .HasColumnName("WMWST");

                entity.Property(e => e.Wrbtr)
                    .HasMaxLength(20)
                    .HasColumnName("WRBTR");

                entity.Property(e => e.WrbtrBrutto)
                    .HasMaxLength(20)
                    .HasColumnName("WRBTR_BRUTTO");

                entity.Property(e => e.Xblnr)
                    .HasMaxLength(20)
                    .HasColumnName("XBLNR");

                entity.Property(e => e.Xnegp)
                    .HasMaxLength(50)
                    .HasColumnName("XNEGP");

                entity.Property(e => e.Xref1)
                    .HasMaxLength(20)
                    .HasColumnName("XREF1");

                entity.Property(e => e.Xref2)
                    .HasMaxLength(20)
                    .HasColumnName("XREF2");

                entity.Property(e => e.Xref3)
                    .HasMaxLength(20)
                    .HasColumnName("XREF3");

                entity.Property(e => e.Zfbdt)
                    .HasMaxLength(20)
                    .HasColumnName("ZFBDT");

                entity.Property(e => e.Zlsch)
                    .HasMaxLength(20)
                    .HasColumnName("ZLSCH");

                entity.Property(e => e.Zlspr)
                    .HasMaxLength(20)
                    .HasColumnName("ZLSPR");

                entity.Property(e => e.Zterm)
                    .HasMaxLength(20)
                    .HasColumnName("ZTERM");

                entity.Property(e => e.Zuonr)
                    .HasMaxLength(20)
                    .HasColumnName("ZUONR");
            });

            modelBuilder.Entity<DeferredRevenue>(entity =>
            {
                entity.ToTable("DeferredRevenue");

                entity.HasIndex(e => e.ClassifiedAdId, "IX_DeferredRevenue_ClassifiedAdId");

                entity.HasIndex(e => e.CountryId, "IX_DeferredRevenue_CountryId");

                entity.HasIndex(e => e.CurrencyId, "IX_DeferredRevenue_CurrencyId");

                entity.HasIndex(e => e.PaymentId, "IX_DeferredRevenue_PaymentId");

                entity.HasIndex(e => e.PaymentTableId, "IX_DeferredRevenue_PaymentTableId");

                entity.HasIndex(e => e.StoreId, "IX_DeferredRevenue_StoreId");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.StoreId).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.ClassifiedAd)
                    .WithMany(p => p.DeferredRevenues)
                    .HasForeignKey(d => d.ClassifiedAdId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.DeferredRevenues)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.DeferredRevenues)
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.DeferredRevenuePayments)
                    .HasForeignKey(d => d.PaymentId);

                entity.HasOne(d => d.PaymentTable)
                    .WithMany(p => p.DeferredRevenuePaymentTables)
                    .HasForeignKey(d => d.PaymentTableId);

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.DeferredRevenues)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<EmailAccount>(entity =>
            {
                entity.ToTable("EmailAccount");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.DisplayName).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Host).HasMaxLength(150);

                entity.Property(e => e.Password).HasMaxLength(1500);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<Entity>(entity =>
            {
                entity.ToTable("Entity");
            });

            modelBuilder.Entity<EntityNotification>(entity =>
            {
                entity.ToTable("EntityNotification");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.EntityName).HasMaxLength(200);

                entity.Property(e => e.ImageUrl).HasMaxLength(4000);

                entity.Property(e => e.Message).HasMaxLength(4000);

                entity.Property(e => e.RedirectUrl).HasMaxLength(4000);
            });

            modelBuilder.Entity<EsAliasIndexLanguageMapping>(entity =>
            {
                entity.ToTable("ES_Alias_Index_Language_Mapping");

                entity.Property(e => e.Alias)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.BaseIndexName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.HasOne(d => d.IndexType)
                    .WithMany(p => p.EsAliasIndexLanguageMappings)
                    .HasForeignKey(d => d.IndexTypeId);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.EsAliasIndexLanguageMappings)
                    .HasForeignKey(d => d.LanguageId);
            });

            modelBuilder.Entity<EsIndexType>(entity =>
            {
                entity.ToTable("ES_Index_Type");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(450);
            });

            modelBuilder.Entity<EsoperationClassifiedAd>(entity =>
            {
                entity.ToTable("ESOperationClassifiedAd");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.HasOne(d => d.ClassifiedAd)
                    .WithMany(p => p.EsoperationClassifiedAds)
                    .HasForeignKey(d => d.ClassifiedAdId);

                entity.HasOne(d => d.OperationType)
                    .WithMany(p => p.EsoperationClassifiedAds)
                    .HasForeignKey(d => d.OperationTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<EsoperationType>(entity =>
            {
                entity.ToTable("ESOperationType");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.OperationName).HasMaxLength(256);
            });

            modelBuilder.Entity<Follow>(entity =>
            {
                entity.ToTable("Follow");

                entity.HasIndex(e => new { e.ToCustomerId, e.FromCustomerId, e.Deleted }, "IX_Follow_ToCustomerId_FromCustomerId_Deleted");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.HasOne(d => d.FromCustomer)
                    .WithMany(p => p.FollowFromCustomers)
                    .HasForeignKey(d => d.FromCustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ToCustomer)
                    .WithMany(p => p.FollowToCustomers)
                    .HasForeignKey(d => d.ToCustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<GenericAttribute>(entity =>
            {
                entity.ToTable("GenericAttribute");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.EntityName)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(4000);
            });

            modelBuilder.Entity<Hash>(entity =>
            {
                entity.HasKey(e => new { e.Key, e.Field })
                    .HasName("PK_HangFire_Hash");

                entity.ToTable("Hash", "HangFire");

                entity.HasIndex(e => e.ExpireAt, "IX_HangFire_Hash_ExpireAt")
                    .HasFilter("([ExpireAt] IS NOT NULL)");

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.Field).HasMaxLength(100);
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoice");

                entity.HasIndex(e => e.BoostingClassifiedAdMappingId, "IX_Invoice_Boosting_ClassifiedAd_MappingId")
                    .IsUnique();

                entity.HasIndex(e => e.CustomerId, "IX_Invoice_CustomerId");

                entity.Property(e => e.BoostingClassifiedAdMappingId).HasColumnName("Boosting_ClassifiedAd_MappingId");

                entity.Property(e => e.CdnUrl).HasMaxLength(2100);

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.InvoiceNumber)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasDefaultValueSql("(N'')");

                entity.HasOne(d => d.BoostingClassifiedAdMapping)
                    .WithOne(p => p.Invoice)
                    .HasForeignKey<Invoice>(d => d.BoostingClassifiedAdMappingId);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("Job", "HangFire");

                entity.HasIndex(e => e.ExpireAt, "IX_HangFire_Job_ExpireAt")
                    .HasFilter("([ExpireAt] IS NOT NULL)");

                entity.HasIndex(e => e.StateName, "IX_HangFire_Job_StateName")
                    .HasFilter("([StateName] IS NOT NULL)");

                entity.Property(e => e.Arguments).IsRequired();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");

                entity.Property(e => e.InvocationData).IsRequired();

                entity.Property(e => e.StateName).HasMaxLength(20);
            });

            modelBuilder.Entity<JobParameter>(entity =>
            {
                entity.HasKey(e => new { e.JobId, e.Name })
                    .HasName("PK_HangFire_JobParameter");

                entity.ToTable("JobParameter", "HangFire");

                entity.Property(e => e.Name).HasMaxLength(40);

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.JobParameters)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_HangFire_JobParameter_Job");
            });

            modelBuilder.Entity<JobQueue>(entity =>
            {
                entity.HasKey(e => new { e.Queue, e.Id })
                    .HasName("PK_HangFire_JobQueue");

                entity.ToTable("JobQueue", "HangFire");

                entity.Property(e => e.Queue).HasMaxLength(50);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.FetchedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("Language");

                entity.HasIndex(e => e.Deleted, "IX_Language_Deleted");

                entity.HasIndex(e => new { e.Deleted, e.DisplayOrder }, "IX_Language_Deleted_DisplayOrder");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.FlagImageFileName).HasMaxLength(150);

                entity.Property(e => e.LanguageCulture).HasMaxLength(150);

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.UniqueSeoCode).HasMaxLength(50);

                entity.HasOne(d => d.DefaultCurrency)
                    .WithMany(p => p.Languages)
                    .HasForeignKey(d => d.DefaultCurrencyId);
            });

            modelBuilder.Entity<List>(entity =>
            {
                entity.HasKey(e => new { e.Key, e.Id })
                    .HasName("PK_HangFire_List");

                entity.ToTable("List", "HangFire");

                entity.HasIndex(e => e.ExpireAt, "IX_HangFire_List_ExpireAt")
                    .HasFilter("([ExpireAt] IS NOT NULL)");

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<LocaleStringResourceControl>(entity =>
            {
                entity.ToTable("LocaleStringResourceControl");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Value).HasMaxLength(150);

                entity.HasOne(d => d.ControlSetting)
                    .WithMany(p => p.LocaleStringResourceControls)
                    .HasForeignKey(d => d.ControlSettingId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.LocaleStringResourceControls)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<LocaleStringResourceSetting>(entity =>
            {
                entity.ToTable("LocaleStringResourceSetting");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Value).HasMaxLength(150);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.LocaleStringResourceSettings)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Setting)
                    .WithMany(p => p.LocaleStringResourceSettings)
                    .HasForeignKey(d => d.SettingId);
            });

            modelBuilder.Entity<LocalizationKeyStaticLocaleStringResourceMapping>(entity =>
            {
                entity.ToTable("LocalizationKey_StaticLocaleStringResource_Mapping");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.LocalizationKey)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.StaticLocaleStringResource)
                    .WithMany(p => p.LocalizationKeyStaticLocaleStringResourceMappings)
                    .HasForeignKey(d => d.StaticLocaleStringResourceId);
            });

            modelBuilder.Entity<LocalizedProperty>(entity =>
            {
                entity.ToTable("LocalizedProperty");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.LocaleKey)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.LocaleKeyGroup).HasMaxLength(400);

                entity.Property(e => e.LocaleValue).HasMaxLength(2000);
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IpAddress).HasMaxLength(96);

                entity.Property(e => e.PageUrl)
                    .IsRequired()
                    .HasMaxLength(2048);

                entity.Property(e => e.ReferrerUrl).HasMaxLength(2048);

                entity.Property(e => e.ShortMessage)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.HasOne(d => d.LogLevel)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.LogLevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<LogLevel>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(96);
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.FromUserIdDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.ToUserIdDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Type).HasComment("Chat = 1, Offer = 2, Attach = 3, AcceptOffer = 4, DeclineOffer = 5, UpdateOffer = 6");

                entity.Property(e => e.Value).HasMaxLength(2048);

                entity.HasOne(d => d.Conversation)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.ConversationId);
            });

            modelBuilder.Entity<MessageTemplate>(entity =>
            {
                entity.ToTable("MessageTemplate");

                entity.Property(e => e.BccEmailAddresses).HasMaxLength(2048);

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.Subject).HasMaxLength(1000);

                entity.HasOne(d => d.EmailAccount)
                    .WithMany(p => p.MessageTemplates)
                    .HasForeignKey(d => d.EmailAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<NewsLetterSubscription>(entity =>
            {
                entity.ToTable("NewsLetterSubscription");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasDefaultValueSql("(N'')");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.NotificationTypeId).HasComment("Entity = 1, Custom = 2, EntityAll = 3, CustomAll = 4");

                entity.HasOne(d => d.NotificationNavigation)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.NotificationId);
            });

            modelBuilder.Entity<Operator>(entity =>
            {
                entity.ToTable("Operator");

                entity.HasIndex(e => e.OperatorType, "AK_Operator_OperatorType")
                    .IsUnique();

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400)
                    .HasDefaultValueSql("(N'')");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.HasIndex(e => e.PaymentId, "IX_Payment_PaymentId");

                entity.Property(e => e.AccountNumber).HasMaxLength(150);

                entity.Property(e => e.AdditionalParams).HasMaxLength(1000);

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.CardBrand).HasMaxLength(150);

                entity.Property(e => e.CardExpiration).HasMaxLength(50);

                entity.Property(e => e.CardIssuerBank).HasMaxLength(150);

                entity.Property(e => e.CardNumber).HasMaxLength(100);

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsDeferredRevenue)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.UserNotified)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ParentTablePayment)
                    .WithMany(p => p.InverseParentTablePayment)
                    .HasForeignKey(d => d.ParentTablePaymentId);
            });

            modelBuilder.Entity<PaymentInfo>(entity =>
            {
                entity.ToTable("PaymentInfo");

                entity.HasIndex(e => e.BoostingPlanClassifiedAdMappingId, "IX_PaymentInfo_BoostingPlan_ClassifiedAd_MappingId");

                entity.HasIndex(e => e.CountryId, "IX_PaymentInfo_CountryId");

                entity.HasIndex(e => e.PaymentTableId, "IX_PaymentInfo_PaymentTableId")
                    .IsUnique();

                entity.Property(e => e.BoostingPlanClassifiedAdMappingId).HasColumnName("BoostingPlan_ClassifiedAd_MappingId");

                entity.Property(e => e.CountryId).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.HasOne(d => d.BoostingPlanClassifiedAdMapping)
                    .WithMany(p => p.PaymentInfos)
                    .HasForeignKey(d => d.BoostingPlanClassifiedAdMappingId);

                entity.HasOne(d => d.BoostingPlan)
                    .WithMany(p => p.PaymentInfos)
                    .HasForeignKey(d => d.BoostingPlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ClassifiedAd)
                    .WithMany(p => p.PaymentInfos)
                    .HasForeignKey(d => d.ClassifiedAdId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.PaymentInfos)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.PaymentInfos)
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.PaymentInfos)
                    .HasForeignKey(d => d.CustomerId);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.PaymentInfos)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.PaymentTable)
                    .WithOne(p => p.PaymentInfo)
                    .HasForeignKey<PaymentInfo>(d => d.PaymentTableId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.PaymentInfos)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<PermissionRecord>(entity =>
            {
                entity.ToTable("PermissionRecord");

                entity.Property(e => e.Category).HasMaxLength(150);

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.Scope).HasMaxLength(150);

                entity.Property(e => e.SystemName).HasMaxLength(150);
            });

            modelBuilder.Entity<PermissionRecordCustomerRoleMapping>(entity =>
            {
                entity.HasKey(e => new { e.PermissionRecordId, e.CustomerRoleId, e.Id });

                entity.ToTable("PermissionRecord_CustomerRole_Mapping");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.HasOne(d => d.CustomerRole)
                    .WithMany(p => p.PermissionRecordCustomerRoleMappings)
                    .HasForeignKey(d => d.CustomerRoleId);

                entity.HasOne(d => d.PermissionRecord)
                    .WithMany(p => p.PermissionRecordCustomerRoleMappings)
                    .HasForeignKey(d => d.PermissionRecordId);
            });

            modelBuilder.Entity<Picture>(entity =>
            {
                entity.ToTable("Picture");

                entity.Property(e => e.AltAttribute).HasMaxLength(1024);

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.MimeType).HasMaxLength(40);

                entity.Property(e => e.SeoFilename).HasMaxLength(300);

                entity.Property(e => e.TitleAttribute).HasMaxLength(1024);
            });

            modelBuilder.Entity<QueuedEmail>(entity =>
            {
                entity.ToTable("QueuedEmail");

                entity.Property(e => e.Bcc).HasMaxLength(150);

                entity.Property(e => e.Cc)
                    .HasMaxLength(50)
                    .HasColumnName("CC");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.From).HasMaxLength(1024);

                entity.Property(e => e.FromName).HasMaxLength(1024);

                entity.Property(e => e.Subject).HasMaxLength(1024);

                entity.Property(e => e.To).HasMaxLength(1024);

                entity.Property(e => e.ToName).HasMaxLength(1024);
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("Report");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.HasOne(d => d.Entity)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.EntityId);

                entity.HasOne(d => d.FromCustomer)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.FromCustomerId);

                entity.HasOne(d => d.ReportType)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.ReportTypeId);
            });

            modelBuilder.Entity<ReportType>(entity =>
            {
                entity.ToTable("ReportType");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Title).HasMaxLength(100);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("Review");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.Title).HasMaxLength(150);
            });

            modelBuilder.Entity<ReviewsCustomerMapping>(entity =>
            {
                entity.ToTable("Reviews_Customer_Mapping");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.HasOne(d => d.FromCustomer)
                    .WithMany(p => p.ReviewsCustomerMappingFromCustomers)
                    .HasForeignKey(d => d.FromCustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Review)
                    .WithMany(p => p.ReviewsCustomerMappings)
                    .HasForeignKey(d => d.ReviewId);

                entity.HasOne(d => d.ToCustomer)
                    .WithMany(p => p.ReviewsCustomerMappingToCustomers)
                    .HasForeignKey(d => d.ToCustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Rule>(entity =>
            {
                entity.ToTable("Rule");

                entity.HasIndex(e => e.ScopeId, "IX_Rule_ScopeId");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400)
                    .HasDefaultValueSql("(N'')");

                entity.HasOne(d => d.Scope)
                    .WithMany(p => p.Rules)
                    .HasForeignKey(d => d.ScopeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<RuleQuery>(entity =>
            {
                entity.ToTable("RuleQuery");

                entity.HasIndex(e => e.OperatorId, "IX_RuleQuery_OperatorId");

                entity.HasIndex(e => e.RuleId, "IX_RuleQuery_RuleId");

                entity.HasIndex(e => e.ScopePropertyId, "IX_RuleQuery_ScopePropertyId");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Value).HasMaxLength(100);

                entity.HasOne(d => d.OperatorNavigation)
                    .WithMany(p => p.RuleQueries)
                    .HasForeignKey(d => d.OperatorId);

                entity.HasOne(d => d.Rule)
                    .WithMany(p => p.RuleQueries)
                    .HasForeignKey(d => d.RuleId);

                entity.HasOne(d => d.ScopeProperty)
                    .WithMany(p => p.RuleQueries)
                    .HasForeignKey(d => d.ScopePropertyId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<SapInterfaceTransaction>(entity =>
            {
                entity.ToTable("SapInterfaceTransaction");

                entity.Property(e => e.Altkt)
                    .HasMaxLength(50)
                    .HasColumnName("ALTKT");

                entity.Property(e => e.Aufnr)
                    .HasMaxLength(20)
                    .HasColumnName("AUFNR");

                entity.Property(e => e.Barcd)
                    .HasMaxLength(20)
                    .HasColumnName("BARCD");

                entity.Property(e => e.Bewar)
                    .HasMaxLength(20)
                    .HasColumnName("BEWAR");

                entity.Property(e => e.Bktxt)
                    .HasMaxLength(100)
                    .HasColumnName("BKTXT");

                entity.Property(e => e.Blart)
                    .HasMaxLength(10)
                    .HasColumnName("BLART");

                entity.Property(e => e.Bldat)
                    .HasMaxLength(20)
                    .HasColumnName("BLDAT");

                entity.Property(e => e.Bschl)
                    .HasMaxLength(20)
                    .HasColumnName("BSCHL");

                entity.Property(e => e.Budat)
                    .HasMaxLength(20)
                    .HasColumnName("BUDAT");

                entity.Property(e => e.Bukrs)
                    .HasMaxLength(150)
                    .HasColumnName("BUKRS");

                entity.Property(e => e.Buzei)
                    .HasMaxLength(15)
                    .HasColumnName("BUZEI");

                entity.Property(e => e.Bvtyp)
                    .HasMaxLength(20)
                    .HasColumnName("BVTYP");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Dmbtr)
                    .HasMaxLength(20)
                    .HasColumnName("DMBTR");

                entity.Property(e => e.DmbtrBrutto)
                    .HasMaxLength(20)
                    .HasColumnName("DMBTR_BRUTTO");

                entity.Property(e => e.Fkber)
                    .HasMaxLength(20)
                    .HasColumnName("FKBER");

                entity.Property(e => e.Gjahr)
                    .HasMaxLength(15)
                    .HasColumnName("GJAHR");

                entity.Property(e => e.Gsber)
                    .HasMaxLength(20)
                    .HasColumnName("GSBER");

                entity.Property(e => e.Hkont)
                    .HasMaxLength(50)
                    .HasColumnName("HKONT");

                entity.Property(e => e.Kostl)
                    .HasMaxLength(20)
                    .HasColumnName("KOSTL");

                entity.Property(e => e.Meins)
                    .HasMaxLength(20)
                    .HasColumnName("MEINS");

                entity.Property(e => e.Menge)
                    .HasMaxLength(20)
                    .HasColumnName("MENGE");

                entity.Property(e => e.Monat)
                    .HasMaxLength(10)
                    .HasColumnName("MONAT");

                entity.Property(e => e.Mwskz)
                    .HasMaxLength(20)
                    .HasColumnName("MWSKZ");

                entity.Property(e => e.Mwsts)
                    .HasMaxLength(20)
                    .HasColumnName("MWSTS");

                entity.Property(e => e.Pernr)
                    .HasMaxLength(20)
                    .HasColumnName("PERNR");

                entity.Property(e => e.Prctr)
                    .HasMaxLength(20)
                    .HasColumnName("PRCTR");

                entity.Property(e => e.Projk)
                    .HasMaxLength(20)
                    .HasColumnName("PROJK");

                entity.Property(e => e.Sgtxt)
                    .HasMaxLength(150)
                    .HasColumnName("SGTXT");

                entity.Property(e => e.Shkzg)
                    .HasMaxLength(20)
                    .HasColumnName("SHKZG");

                entity.Property(e => e.Umskz)
                    .HasMaxLength(50)
                    .HasColumnName("UMSKZ");

                entity.Property(e => e.Vbund)
                    .HasMaxLength(20)
                    .HasColumnName("VBUND");

                entity.Property(e => e.Waers)
                    .HasMaxLength(20)
                    .HasColumnName("WAERS");

                entity.Property(e => e.Wmwst)
                    .HasMaxLength(20)
                    .HasColumnName("WMWST");

                entity.Property(e => e.Wrbtr)
                    .HasMaxLength(20)
                    .HasColumnName("WRBTR");

                entity.Property(e => e.WrbtrBrutto)
                    .HasMaxLength(20)
                    .HasColumnName("WRBTR_BRUTTO");

                entity.Property(e => e.Xblnr)
                    .HasMaxLength(20)
                    .HasColumnName("XBLNR");

                entity.Property(e => e.Xnegp)
                    .HasMaxLength(50)
                    .HasColumnName("XNEGP");

                entity.Property(e => e.Xref1)
                    .HasMaxLength(20)
                    .HasColumnName("XREF1");

                entity.Property(e => e.Xref2)
                    .HasMaxLength(20)
                    .HasColumnName("XREF2");

                entity.Property(e => e.Xref3)
                    .HasMaxLength(20)
                    .HasColumnName("XREF3");

                entity.Property(e => e.Zfbdt)
                    .HasMaxLength(20)
                    .HasColumnName("ZFBDT");

                entity.Property(e => e.Zlsch)
                    .HasMaxLength(20)
                    .HasColumnName("ZLSCH");

                entity.Property(e => e.Zlspr)
                    .HasMaxLength(20)
                    .HasColumnName("ZLSPR");

                entity.Property(e => e.Zterm)
                    .HasMaxLength(20)
                    .HasColumnName("ZTERM");

                entity.Property(e => e.Zuonr)
                    .HasMaxLength(20)
                    .HasColumnName("ZUONR");
            });

            modelBuilder.Entity<Schema>(entity =>
            {
                entity.HasKey(e => e.Version)
                    .HasName("PK_HangFire_Schema");

                entity.ToTable("Schema", "HangFire");

                entity.Property(e => e.Version).ValueGeneratedNever();
            });

            modelBuilder.Entity<Scope>(entity =>
            {
                entity.ToTable("Scope");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400)
                    .HasDefaultValueSql("(N'')");
            });

            modelBuilder.Entity<ScopeProperty>(entity =>
            {
                entity.ToTable("ScopeProperty");

                entity.HasIndex(e => e.ScopeId, "IX_ScopeProperty_ScopeId");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400)
                    .HasDefaultValueSql("(N'')");

                entity.HasOne(d => d.Scope)
                    .WithMany(p => p.ScopeProperties)
                    .HasForeignKey(d => d.ScopeId);
            });

            modelBuilder.Entity<ScopePropertyOperatorMapping>(entity =>
            {
                entity.ToTable("ScopeProperty_Operator_Mapping");

                entity.HasIndex(e => e.OperatorId, "IX_ScopeProperty_Operator_Mapping_OperatorId");

                entity.HasIndex(e => e.ScopePropertyId, "IX_ScopeProperty_Operator_Mapping_ScopePropertyId");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.HasOne(d => d.Operator)
                    .WithMany(p => p.ScopePropertyOperatorMappings)
                    .HasForeignKey(d => d.OperatorId);

                entity.HasOne(d => d.ScopeProperty)
                    .WithMany(p => p.ScopePropertyOperatorMappings)
                    .HasForeignKey(d => d.ScopePropertyId);
            });

            modelBuilder.Entity<SearchFilter>(entity =>
            {
                entity.ToTable("SearchFilter");

                entity.HasOne(d => d.Search)
                    .WithMany(p => p.SearchFilters)
                    .HasForeignKey(d => d.SearchId);

                entity.HasOne(d => d.SpecificationOption)
                    .WithMany(p => p.SearchFilters)
                    .HasForeignKey(d => d.SpecificationOptionId);
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.ToTable("Section");

                entity.HasIndex(e => e.PageId, "IX_Section_PageId");

                entity.HasIndex(e => e.RuleId, "IX_Section_RuleId");

                entity.HasIndex(e => e.StoreId, "IX_Section_StoreId");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.SectionName)
                    .IsRequired()
                    .HasMaxLength(400)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(400)
                    .HasDefaultValueSql("(N'')");

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.Sections)
                    .HasForeignKey(d => d.PageId);

                entity.HasOne(d => d.Rule)
                    .WithMany(p => p.Sections)
                    .HasForeignKey(d => d.RuleId);

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Sections)
                    .HasForeignKey(d => d.StoreId);
            });

            modelBuilder.Entity<Server>(entity =>
            {
                entity.ToTable("Server", "HangFire");

                entity.HasIndex(e => e.LastHeartbeat, "IX_HangFire_Server_LastHeartbeat");

                entity.Property(e => e.Id).HasMaxLength(200);

                entity.Property(e => e.LastHeartbeat).HasColumnType("datetime");
            });

            modelBuilder.Entity<Set>(entity =>
            {
                entity.HasKey(e => new { e.Key, e.Value })
                    .HasName("PK_HangFire_Set");

                entity.ToTable("Set", "HangFire");

                entity.HasIndex(e => e.ExpireAt, "IX_HangFire_Set_ExpireAt")
                    .HasFilter("([ExpireAt] IS NOT NULL)");

                entity.HasIndex(e => new { e.Key, e.Score }, "IX_HangFire_Set_Score");

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.Value).HasMaxLength(256);

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Setting>(entity =>
            {
                entity.ToTable("Setting");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Value).HasMaxLength(250);

                entity.HasOne(d => d.ControlSetting)
                    .WithMany(p => p.Settings)
                    .HasForeignKey(d => d.ControlSettingId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.DataAnnotationType)
                    .WithMany(p => p.Settings)
                    .HasForeignKey(d => d.DataAnnotationTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<SpecificationAttribute>(entity =>
            {
                entity.ToTable("SpecificationAttribute");

                entity.HasIndex(e => e.SecondaryId, "IX_SpecificationAttribute_SecondaryId")
                    .IsUnique()
                    .HasFilter("([SecondaryId] IS NOT NULL)");

                entity.Property(e => e.ControlTypeId).HasComment("DropdownList = 1, CheckBox = 2, RadioButton = 3, TextBox = 4");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Name).HasMaxLength(512);

                entity.HasOne(d => d.ParentSpecificationAttribute)
                    .WithMany(p => p.InverseParentSpecificationAttribute)
                    .HasForeignKey(d => d.ParentSpecificationAttributeId);
            });

            modelBuilder.Entity<SpecificationAttributeOption>(entity =>
            {
                entity.ToTable("SpecificationAttributeOption");

                entity.HasIndex(e => e.SecondaryId, "IX_SpecificationAttributeOption_SecondaryId")
                    .IsUnique()
                    .HasFilter("([SecondaryId] IS NOT NULL)");

                entity.Property(e => e.ChainedAncestorString)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Name).HasMaxLength(512);

                entity.Property(e => e.ParentSpecificationAttributeOptionId).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.ParentSpecificationAttributeOption)
                    .WithMany(p => p.InverseParentSpecificationAttributeOption)
                    .HasForeignKey(d => d.ParentSpecificationAttributeOptionId);

                entity.HasOne(d => d.SpecificationAttribute)
                    .WithMany(p => p.SpecificationAttributeOptions)
                    .HasForeignKey(d => d.SpecificationAttributeId);
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasKey(e => new { e.JobId, e.Id })
                    .HasName("PK_HangFire_State");

                entity.ToTable("State", "HangFire");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Reason).HasMaxLength(100);

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.States)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_HangFire_State_Job");
            });

            modelBuilder.Entity<StateProvince>(entity =>
            {
                entity.ToTable("StateProvince");

                entity.HasIndex(e => new { e.CountryId, e.Deleted, e.DisplayOrder }, "IX_StateProvince_CountryId_Deleted_DisplayOrder");

                entity.HasIndex(e => new { e.Deleted, e.DisplayOrder }, "IX_StateProvince_Deleted_DisplayOrder");

                entity.Property(e => e.Abbreviation).HasMaxLength(2);

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.StateProvinces)
                    .HasForeignKey(d => d.CountryId);
            });

            modelBuilder.Entity<StaticLocaleStringResource>(entity =>
            {
                entity.ToTable("StaticLocaleStringResource");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.ResourceName).HasMaxLength(150);

                entity.Property(e => e.ResourceValue).HasMaxLength(4000);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.StaticLocaleStringResources)
                    .HasForeignKey(d => d.LanguageId);
            });

            modelBuilder.Entity<StaticSetting>(entity =>
            {
                entity.ToTable("StaticSetting");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.Value).HasMaxLength(150);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store");

                entity.HasIndex(e => e.Deleted, "IX_Store_Deleted");

                entity.HasIndex(e => new { e.Deleted, e.DisplayOrder }, "IX_Store_Deleted_DisplayOrder");

                entity.HasIndex(e => new { e.IsMainStore, e.Deleted }, "IX_Store_IsMainStore_Deleted");

                entity.HasIndex(e => e.StoreCategoryId, "IX_Store_StoreCategoryId");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.Url).HasMaxLength(1000);

                entity.HasOne(d => d.DefaultLanguage)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.DefaultLanguageId);

                entity.HasOne(d => d.StoreCategory)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.StoreCategoryId);
            });

            modelBuilder.Entity<StoreInformation>(entity =>
            {
                entity.ToTable("StoreInformation");

                entity.HasIndex(e => e.StoreId, "IX_StoreInformation_StoreId")
                    .IsUnique();

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.StoreOrderNumber).HasMaxLength(10);

                entity.HasOne(d => d.Store)
                    .WithOne(p => p.StoreInformation)
                    .HasForeignKey<StoreInformation>(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<StoreMapping>(entity =>
            {
                entity.ToTable("StoreMapping");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.EntityName).HasMaxLength(400);
            });

            modelBuilder.Entity<StylingTag>(entity =>
            {
                entity.ToTable("StylingTag");

                entity.HasIndex(e => e.SectionId, "IX_StylingTag_SectionId");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.StylingTags)
                    .HasForeignKey(d => d.SectionId);
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.ToTable("Topic");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IncludeInFooterColumn4)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.MetaDescription).HasMaxLength(4000);

                entity.Property(e => e.MetaKeywords).HasMaxLength(500);

                entity.Property(e => e.MetaTitle).HasMaxLength(500);

                entity.Property(e => e.Password).HasMaxLength(4000);

                entity.Property(e => e.SystemName).HasMaxLength(500);

                entity.Property(e => e.Title).HasMaxLength(4000);
            });

            modelBuilder.Entity<TransactionHistory>(entity =>
            {
                entity.ToTable("TransactionHistory");

                entity.HasIndex(e => new { e.CreatedOn, e.Deleted }, "IX_TransactionHistory_CreatedOn_Deleted");

                entity.HasIndex(e => e.CustomerId, "IX_TransactionHistory_CustomerId");

                entity.HasIndex(e => e.StoreId, "IX_TransactionHistory_StoreId");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.StoreId).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.BoostingPlan)
                    .WithMany(p => p.TransactionHistories)
                    .HasForeignKey(d => d.BoostingPlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TransactionHistories)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.PaymentTable)
                    .WithMany(p => p.TransactionHistories)
                    .HasForeignKey(d => d.PaymentTableId);

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.TransactionHistories)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<UrlRecord>(entity =>
            {
                entity.ToTable("UrlRecord");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.EntityName)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasMaxLength(400);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
