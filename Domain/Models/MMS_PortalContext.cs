using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Domain.Models
{
    public partial class MMS_PortalContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public MMS_PortalContext()
        {
        }

        public MMS_PortalContext(DbContextOptions<MMS_PortalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alphabitic> Alphabitics { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerEditInfoRequest> CustomerEditInfoRequests { get; set; }
        public virtual DbSet<CustomersIban> CustomersIbans { get; set; }
        public virtual DbSet<Degree> Degrees { get; set; }
        public virtual DbSet<DocType> DocTypes { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<EditGuildRequest> EditGuildRequests { get; set; }
        public virtual DbSet<EditIbanRequest> EditIbanRequests { get; set; }
        public virtual DbSet<EditPostalCodeRequest> EditPostalCodeRequests { get; set; }
        public virtual DbSet<GuildCategory> GuildCategories { get; set; }
        public virtual DbSet<GuildSubCategory> GuildSubCategories { get; set; }
        public virtual DbSet<InputRegaccPsp> InputRegaccPsps { get; set; }
        public virtual DbSet<InputRegaccPspVw> InputRegaccPspVws { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<MarketerContract> MarketerContracts { get; set; }
        public virtual DbSet<Merchant> Merchants { get; set; }
        public virtual DbSet<MerchantState> MerchantStates { get; set; }
        public virtual DbSet<MerchantSyncTable> MerchantSyncTables { get; set; }
        public virtual DbSet<Nationality> Nationalities { get; set; }
        public virtual DbSet<NewGuildAndPostalCodeRequest> NewGuildAndPostalCodeRequests { get; set; }
        public virtual DbSet<NewIbanRequest> NewIbanRequests { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PersonEditInfoRequest> PersonEditInfoRequests { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Psp> Psps { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<RequestDetail> RequestDetails { get; set; }
        public virtual DbSet<RequestHistory> RequestHistories { get; set; }
        public virtual DbSet<RequestState> RequestStates { get; set; }
        public virtual DbSet<RequestType> RequestTypes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RolePermission> RolePermissions { get; set; }
        public virtual DbSet<SharedType> SharedTypes { get; set; }
        public virtual DbSet<ShpAcceptorInfoVw> ShpAcceptorInfoVws { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<TerminalType> TerminalTypes { get; set; }
        public virtual DbSet<Token> Tokens { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UsersPermission> UsersPermissions { get; set; }
        public virtual DbSet<WebServiceUser> WebServiceUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=.;database=MMS_Portal;uid=sa;pwd=123456;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Alphabitic>(entity =>
            {
                entity.ToTable("Alphabitic");

                entity.Property(e => e.AlphabiticChar)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(200);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Bank>(entity =>
            {
                entity.ToTable("Bank");

                entity.Property(e => e.BankName)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasDefaultValueSql("(N'-')");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("City");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("City_Name");

                entity.Property(e => e.Createdate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdate");

                entity.Property(e => e.EnglishCityName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("English_City_Name");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.OldCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("oldCode");

                entity.Property(e => e.ProvinceId).HasColumnName("ProvinceID");

                entity.Property(e => e.TosanCityCodeNew)
                    .HasMaxLength(50)
                    .HasColumnName("TosanCity_Code_New");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.ToTable("Contract");

                entity.Property(e => e.ContractDate)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.ContractNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ExpireDate).HasColumnType("datetime");

                entity.Property(e => e.IntroducedSharedType).HasMaxLength(20);

                entity.Property(e => e.ServiceStartDate).HasColumnType("datetime");

                entity.Property(e => e.ShareType).HasMaxLength(20);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Contract_Customer");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_Contract_Project");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Country");

                entity.Property(e => e.Abbrivation)
                    .HasMaxLength(50)
                    .HasColumnName("abbrivation");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.Property(e => e.FarsiName)
                    .HasMaxLength(50)
                    .HasColumnName("farsi_name");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.AddressEn)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.AddressFa).HasMaxLength(500);

                entity.Property(e => e.BusinesslicenseImg).IsUnicode(false);

                entity.Property(e => e.CountryAbbreviation)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerKey).HasMaxLength(50);

                entity.Property(e => e.CustomerValue).HasMaxLength(200);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNumber).HasMaxLength(50);

                entity.Property(e => e.ProvinceAbbreviation)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.RedirectUrl).IsUnicode(false);

                entity.Property(e => e.ShopAddress).HasMaxLength(300);

                entity.Property(e => e.ShopBusinessLicenseExpireDate).HasMaxLength(10);

                entity.Property(e => e.ShopBusinessLicenseIssueDate).HasMaxLength(10);

                entity.Property(e => e.ShopBusinessLicenseNumber).HasMaxLength(50);

                entity.Property(e => e.ShopCityPreCode).HasMaxLength(50);

                entity.Property(e => e.ShopEmail).HasMaxLength(50);

                entity.Property(e => e.ShopFaxNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShopLogo).IsUnicode(false);

                entity.Property(e => e.ShopNameEn)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShopNameFa).HasMaxLength(50);

                entity.Property(e => e.ShopPostalCode).HasMaxLength(50);

                entity.Property(e => e.ShopTelephoneNumber).HasMaxLength(50);

                entity.Property(e => e.TaxPayerCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("taxPayerCode")
                    .IsFixedLength(true);

                entity.Property(e => e.Telephone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.WebSiteAddress).HasMaxLength(50);

                entity.HasOne(d => d.Guild)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.GuildId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_GuildCategory");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK_Customer_Person");
            });

            modelBuilder.Entity<CustomerEditInfoRequest>(entity =>
            {
                entity.ToTable("CustomerEditInfoRequest");

                entity.Property(e => e.AddressEn)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.AddressFa).HasMaxLength(500);

                entity.Property(e => e.BusinesslicenseImg).IsUnicode(false);

                entity.Property(e => e.CountryAbbreviation)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerKey).HasMaxLength(50);

                entity.Property(e => e.CustomerValue).HasMaxLength(200);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNumber).HasMaxLength(50);

                entity.Property(e => e.ProvinceAbbreviation)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.RedirectUrl).IsUnicode(false);

                entity.Property(e => e.ShopAddress).HasMaxLength(300);

                entity.Property(e => e.ShopBusinessLicenseExpireDate).HasMaxLength(10);

                entity.Property(e => e.ShopBusinessLicenseIssueDate).HasMaxLength(10);

                entity.Property(e => e.ShopBusinessLicenseNumber).HasMaxLength(50);

                entity.Property(e => e.ShopCityPreCode).HasMaxLength(50);

                entity.Property(e => e.ShopEmail).HasMaxLength(50);

                entity.Property(e => e.ShopFaxNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShopLogo).IsUnicode(false);

                entity.Property(e => e.ShopNameEn)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShopNameFa).HasMaxLength(50);

                entity.Property(e => e.ShopPostalCode).HasMaxLength(50);

                entity.Property(e => e.ShopTelephoneNumber).HasMaxLength(50);

                entity.Property(e => e.Telephone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.WebSiteAddress).HasMaxLength(50);
            });

            modelBuilder.Entity<CustomersIban>(entity =>
            {
                entity.Property(e => e.AccountNumber).HasMaxLength(30);

                entity.Property(e => e.Iban).HasMaxLength(30);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomersIbans)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_CustomersIbans_Customer");
            });

            modelBuilder.Entity<Degree>(entity =>
            {
                entity.ToTable("Degree");

                entity.Property(e => e.DegreeName)
                    .HasMaxLength(300)
                    .HasDefaultValueSql("(N'-')");
            });

            modelBuilder.Entity<DocType>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.TypeName).HasMaxLength(100);
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ContentType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.InsertTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<EditGuildRequest>(entity =>
            {
                entity.ToTable("EditGuildRequest");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.EditGuildRequests)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EditGuildRequest_EditGuildRequest");
            });

            modelBuilder.Entity<EditIbanRequest>(entity =>
            {
                entity.ToTable("EditIbanRequest");

                entity.Property(e => e.AccountNumber).HasMaxLength(30);

                entity.Property(e => e.Iban)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.EditIbanRequests)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EditIbanRequest_Request");
            });

            modelBuilder.Entity<EditPostalCodeRequest>(entity =>
            {
                entity.ToTable("EditPostalCodeRequest");

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.EditPostalCodeRequests)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EditPostalCodeRequest_Request");
            });

            modelBuilder.Entity<GuildCategory>(entity =>
            {
                entity.ToTable("GuildCategory");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CategoryCode).HasColumnName("Category_Code");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(100)
                    .HasColumnName("Category_Name");

                entity.Property(e => e.Createdate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdate");

                entity.Property(e => e.Isactive).HasColumnName("isactive");
            });

            modelBuilder.Entity<GuildSubCategory>(entity =>
            {
                entity.ToTable("GuildSubCategory");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CategoryId).HasColumnName("Category_ID");

                entity.Property(e => e.Createdate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdate");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.SubCategoryCode)
                    .HasMaxLength(10)
                    .HasColumnName("SubCategory_Code");

                entity.Property(e => e.SubCategoryTitle)
                    .HasMaxLength(150)
                    .HasColumnName("SubCategory_Title");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.GuildSubCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_GuildSubCategory_GuildCategory");
            });

            modelBuilder.Entity<InputRegaccPsp>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("input_regacc_psp");

                entity.Property(e => e.AddressEn)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.AddressFa).HasMaxLength(500);

                entity.Property(e => e.AnnounceLatestChangesImg).IsUnicode(false);

                entity.Property(e => e.BirthCertificateImg).IsUnicode(false);

                entity.Property(e => e.BirthCertificatePlaceOfIssue).HasMaxLength(100);

                entity.Property(e => e.BirthDate).HasMaxLength(10);

                entity.Property(e => e.BirthLocation).HasMaxLength(100);

                entity.Property(e => e.BusinesslicenseImg).IsUnicode(false);

                entity.Property(e => e.CategoryCode).HasColumnName("Category_Code");

                entity.Property(e => e.CompanyStatuteImg).IsUnicode(false);

                entity.Property(e => e.CountryAbbreviation)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerKey).HasMaxLength(50);

                entity.Property(e => e.CustomerValue).HasMaxLength(200);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FatherNameEn).HasMaxLength(100);

                entity.Property(e => e.FatherNameFa).HasMaxLength(100);

                entity.Property(e => e.FirstNameEn).HasMaxLength(100);

                entity.Property(e => e.FirstNameFa)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.InstallationDate).HasMaxLength(10);

                entity.Property(e => e.LastCallTime).HasColumnType("datetime");

                entity.Property(e => e.LastNameEn).HasMaxLength(200);

                entity.Property(e => e.LastNameFa)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.MobileNumber).HasMaxLength(50);

                entity.Property(e => e.NationalCardImgBack).IsUnicode(false);

                entity.Property(e => e.NationalCardImgFront).IsUnicode(false);

                entity.Property(e => e.NationalNumber)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ProvinceAbbreviation)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.RedirectUrl).IsUnicode(false);

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.ShaparakState).HasColumnName("shaparakState");

                entity.Property(e => e.ShaparakTrackingNumber).HasMaxLength(50);

                entity.Property(e => e.ShopAddress).HasMaxLength(300);

                entity.Property(e => e.ShopBusinessLicenseExpireDate).HasMaxLength(10);

                entity.Property(e => e.ShopBusinessLicenseIssueDate).HasMaxLength(10);

                entity.Property(e => e.ShopBusinessLicenseNumber).HasMaxLength(50);

                entity.Property(e => e.ShopCityPreCode).HasMaxLength(50);

                entity.Property(e => e.ShopEmail).HasMaxLength(50);

                entity.Property(e => e.ShopFaxNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShopLogo).IsUnicode(false);

                entity.Property(e => e.ShopNameEn)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShopNameFa).HasMaxLength(50);

                entity.Property(e => e.ShopPostalCode).HasMaxLength(50);

                entity.Property(e => e.ShopTelephoneNumber).HasMaxLength(50);

                entity.Property(e => e.Telephone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.WebSiteAddress).HasMaxLength(50);

                entity.Property(e => e.WorkPermitImg).IsUnicode(false);
            });

            modelBuilder.Entity<InputRegaccPspVw>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("input_regacc_psp_vw");

                entity.Property(e => e.AddressEn)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.AddressFa).HasMaxLength(500);

                entity.Property(e => e.AnnounceLatestChangesImg).IsUnicode(false);

                entity.Property(e => e.BirthCertificateImg).IsUnicode(false);

                entity.Property(e => e.BirthCertificatePlaceOfIssue).HasMaxLength(100);

                entity.Property(e => e.BirthDate).HasMaxLength(10);

                entity.Property(e => e.BirthLocation).HasMaxLength(100);

                entity.Property(e => e.BusinesslicenseImg).IsUnicode(false);

                entity.Property(e => e.CategoryCode).HasColumnName("Category_Code");

                entity.Property(e => e.ComNameEn)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ComNameFa).HasMaxLength(30);

                entity.Property(e => e.CommercialCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyStatuteImg).IsUnicode(false);

                entity.Property(e => e.CountryAbbreviation)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerKey).HasMaxLength(50);

                entity.Property(e => e.CustomerValue).HasMaxLength(200);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Expr3).HasColumnType("datetime");

                entity.Property(e => e.FatherNameEn).HasMaxLength(100);

                entity.Property(e => e.FatherNameFa).HasMaxLength(100);

                entity.Property(e => e.FirstNameEn).HasMaxLength(100);

                entity.Property(e => e.FirstNameFa)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ForeignPervasiveCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InsertDateTime).HasColumnType("datetime");

                entity.Property(e => e.InstallationDate).HasMaxLength(10);

                entity.Property(e => e.LastCallTime).HasColumnType("datetime");

                entity.Property(e => e.LastNameEn).HasMaxLength(200);

                entity.Property(e => e.LastNameFa)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.MobileNumber).HasMaxLength(50);

                entity.Property(e => e.NationalCardImgBack).IsUnicode(false);

                entity.Property(e => e.NationalCardImgFront).IsUnicode(false);

                entity.Property(e => e.NationalLegalCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.NationalNumber)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.PassportExpireDate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PassportNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ProvinceAbbreviation)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.RedirectUrl).IsUnicode(false);

                entity.Property(e => e.RegisterDate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RegisterNo)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RequestData)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Requestid).HasColumnName("requestid");

                entity.Property(e => e.ShaparakState).HasColumnName("shaparakState");

                entity.Property(e => e.ShaparakTrackingNumber).HasMaxLength(50);

                entity.Property(e => e.ShopAddress).HasMaxLength(300);

                entity.Property(e => e.ShopBusinessLicenseExpireDate).HasMaxLength(10);

                entity.Property(e => e.ShopBusinessLicenseIssueDate).HasMaxLength(10);

                entity.Property(e => e.ShopBusinessLicenseNumber).HasMaxLength(50);

                entity.Property(e => e.ShopCityPreCode).HasMaxLength(50);

                entity.Property(e => e.ShopEmail).HasMaxLength(50);

                entity.Property(e => e.ShopFaxNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShopLogo).IsUnicode(false);

                entity.Property(e => e.ShopNameEn)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShopNameFa).HasMaxLength(50);

                entity.Property(e => e.ShopPostalCode).HasMaxLength(50);

                entity.Property(e => e.ShopTelephoneNumber).HasMaxLength(50);

                entity.Property(e => e.TaxPayerCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("taxPayerCode")
                    .IsFixedLength(true);

                entity.Property(e => e.Telephone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.WebSiteAddress).HasMaxLength(50);

                entity.Property(e => e.WorkPermitImg).IsUnicode(false);
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("Log");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.FunctionName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.InsertDateTime).HasColumnType("datetime");

                entity.Property(e => e.MerchantId).HasColumnName("MerchantID");

                entity.Property(e => e.ResponseCode).HasMaxLength(50);

                entity.Property(e => e.Rrn).HasColumnName("RRN");

                entity.Property(e => e.TerminalDateTime).HasMaxLength(50);

                entity.Property(e => e.TerminalId).HasColumnName("TerminalID");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MarketerContract>(entity =>
            {
                entity.ToTable("MarketerContract");

                entity.Property(e => e.ContractDate)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Iban)
                    .HasMaxLength(30)
                    .IsFixedLength(true);

                entity.Property(e => e.ShareType).HasMaxLength(20);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.MarketerContractCustomers)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_MarketerContract_Customer2");

                entity.HasOne(d => d.Marketer)
                    .WithMany(p => p.MarketerContractMarketers)
                    .HasForeignKey(d => d.MarketerId)
                    .HasConstraintName("FK_MarketerContract_Customer1");
            });

            modelBuilder.Entity<Merchant>(entity =>
            {
                entity.Property(e => e.AcceptorCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.TerminalNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Merchants)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Merchants_Customer");

                entity.HasOne(d => d.Psp)
                    .WithMany(p => p.Merchants)
                    .HasForeignKey(d => d.PspId)
                    .HasConstraintName("FK_Merchants_CustomersPSP");

                entity.HasOne(d => d.TerminalTypeNavigation)
                    .WithMany(p => p.Merchants)
                    .HasForeignKey(d => d.TerminalType)
                    .HasConstraintName("FK_Merchants_TerminalTypes");
            });

            modelBuilder.Entity<MerchantState>(entity =>
            {
                entity.ToTable("MerchantState");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<MerchantSyncTable>(entity =>
            {
                entity.ToTable("MerchantSyncTable");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdate");

                entity.Property(e => e.Issynced).HasColumnName("issynced");

                entity.Property(e => e.Merchantid).HasColumnName("merchantid");

                entity.Property(e => e.Syncdate)
                    .HasColumnType("datetime")
                    .HasColumnName("syncdate");
            });

            modelBuilder.Entity<Nationality>(entity =>
            {
                entity.ToTable("Nationality");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.NationalName)
                    .HasMaxLength(300)
                    .HasDefaultValueSql("(N'-')");
            });

            modelBuilder.Entity<NewGuildAndPostalCodeRequest>(entity =>
            {
                entity.ToTable("NewGuildAndPostalCodeRequest");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.NewGuildAndPostalCodeRequests)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK_NewGuildAndPostalCodeRequest_Request");
            });

            modelBuilder.Entity<NewIbanRequest>(entity =>
            {
                entity.ToTable("NewIbanRequest");

                entity.Property(e => e.AccountNumber).HasMaxLength(30);

                entity.Property(e => e.Iban).HasMaxLength(30);

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.NewIbanRequests)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK_NewIbanRequest_Request");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("Permission");

                entity.Property(e => e.Permission1)
                    .IsRequired()
                    .HasColumnName("Permission");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");

                entity.Property(e => e.AnnounceLatestChangesImg).IsUnicode(false);

                entity.Property(e => e.BirthCertificateImg).IsUnicode(false);

                entity.Property(e => e.BirthCertificatePlaceOfIssue).HasMaxLength(100);

                entity.Property(e => e.BirthDate).HasMaxLength(10);

                entity.Property(e => e.BirthLocation).HasMaxLength(100);

                entity.Property(e => e.ComNameEn)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ComNameFa).HasMaxLength(100);

                entity.Property(e => e.CommercialCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyStatuteImg).IsUnicode(false);

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.FatherNameEn).HasMaxLength(100);

                entity.Property(e => e.FatherNameFa).HasMaxLength(100);

                entity.Property(e => e.FirstNameEn).HasMaxLength(100);

                entity.Property(e => e.FirstNameFa)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ForeignPervasiveCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InsertDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastNameEn).HasMaxLength(200);

                entity.Property(e => e.LastNameFa)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.NationalCardImgBack).IsUnicode(false);

                entity.Property(e => e.NationalCardImgFront).IsUnicode(false);

                entity.Property(e => e.NationalLegalCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.NationalNumber)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.PassportExpireDate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PassportNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RegisterDate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RegisterNo)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.WorkPermitImg).IsUnicode(false);

                entity.HasOne(d => d.BirthCertificateAlphabiticNo)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.BirthCertificateAlphabiticNoId)
                    .HasConstraintName("FK_Person_Alphabitic");

                entity.HasOne(d => d.Degree)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.DegreeId)
                    .HasConstraintName("FK_Person_Degree");

                entity.HasOne(d => d.Nationality)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.NationalityId)
                    .HasConstraintName("FK_Person_Nationality");
            });

            modelBuilder.Entity<PersonEditInfoRequest>(entity =>
            {
                entity.ToTable("PersonEditInfoRequest");

                entity.Property(e => e.AnnounceLatestChangesImg).IsUnicode(false);

                entity.Property(e => e.BirthCertificateImg).IsUnicode(false);

                entity.Property(e => e.BirthCertificatePlaceOfIssue).HasMaxLength(100);

                entity.Property(e => e.BirthDate).HasMaxLength(10);

                entity.Property(e => e.BirthLocation).HasMaxLength(100);

                entity.Property(e => e.CompanyStatuteImg).IsUnicode(false);

                entity.Property(e => e.FatherNameEn).HasMaxLength(100);

                entity.Property(e => e.FatherNameFa).HasMaxLength(100);

                entity.Property(e => e.FirstNameEn).HasMaxLength(100);

                entity.Property(e => e.FirstNameFa)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.InsertDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastNameEn).HasMaxLength(200);

                entity.Property(e => e.LastNameFa)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.NationalCardImgBack).IsUnicode(false);

                entity.Property(e => e.NationalCardImgFront).IsUnicode(false);

                entity.Property(e => e.NationalNumber)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.WorkPermitImg).IsUnicode(false);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project");

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.ShareType).HasMaxLength(20);
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Province");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.ProvinceAbbreviation)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("Province_Abbreviation")
                    .IsFixedLength(true);

                entity.Property(e => e.ProvinceCode).HasColumnName("Province_Code");

                entity.Property(e => e.ProvinceId).HasColumnName("ProvinceID");

                entity.Property(e => e.ProvinceName)
                    .HasMaxLength(50)
                    .HasColumnName("Province_Name");

                entity.Property(e => e.TellCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Psp>(entity =>
            {
                entity.ToTable("PSP");

                entity.Property(e => e.AcceptorCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Alias).HasMaxLength(150);

                entity.Property(e => e.Enabled).HasDefaultValueSql("((1))");

                entity.Property(e => e.Iin)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IIN");

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.PasswordShaparak).HasMaxLength(50);

                entity.Property(e => e.PspMmsPassword).HasMaxLength(50);

                entity.Property(e => e.PspMmsUsername).HasMaxLength(50);

                entity.Property(e => e.ShaparakFtpPassword).HasMaxLength(50);

                entity.Property(e => e.ShaparakFtpUsername).HasMaxLength(50);

                entity.Property(e => e.TerminalNo)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.UserShaparak).HasMaxLength(50);
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.ToTable("Request");

                entity.Property(e => e.EditedBy).HasMaxLength(75);

                entity.Property(e => e.InsertDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InstallationDate).HasMaxLength(10);

                entity.Property(e => e.LastCallTime).HasColumnType("datetime");

                entity.Property(e => e.RequestData)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShaparakState).HasColumnName("shaparakState");

                entity.Property(e => e.ShaparakTrackingNumber).HasMaxLength(50);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Request_Customer");

                entity.HasOne(d => d.Psp)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.PspId)
                    .HasConstraintName("FK_Request_CustomersPSP");

                entity.HasOne(d => d.RequestState)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.RequestStateId)
                    .HasConstraintName("FK_Request_RequestState");

                entity.HasOne(d => d.RequestType)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.RequestTypeId)
                    .HasConstraintName("FK_Request_RequestType");
            });

            modelBuilder.Entity<RequestDetail>(entity =>
            {
                entity.ToTable("RequestDetail");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.RequestDetails)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RequestDetail_Request");
            });

            modelBuilder.Entity<RequestHistory>(entity =>
            {
                entity.ToTable("RequestHistory");

                entity.Property(e => e.InsertDateTime).HasColumnType("datetime");

                entity.Property(e => e.ShaparakState).HasColumnName("shaparakState");

                entity.Property(e => e.ShaparakTrackingNumber).HasMaxLength(50);

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.RequestHistories)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK_WorkFlowHistory_Request");
            });

            modelBuilder.Entity<RequestState>(entity =>
            {
                entity.ToTable("RequestState");

                entity.Property(e => e.Name).HasMaxLength(500);
            });

            modelBuilder.Entity<RequestType>(entity =>
            {
                entity.ToTable("RequestType");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.PspRequestTitle).HasMaxLength(150);

                entity.Property(e => e.Request).HasMaxLength(150);

                entity.Property(e => e.ShaparakSatetTitle).HasMaxLength(150);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleName).IsRequired();
            });

            modelBuilder.Entity<RolePermission>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.PermissionId });
            });

            modelBuilder.Entity<SharedType>(entity =>
            {
                entity.ToTable("SharedType");

                entity.Property(e => e.SahredType)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ShpAcceptorInfoVw>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Shp_AcceptorInfo_vw");

                entity.Property(e => e.AcceptorCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.AddressEn)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.AddressFa).HasMaxLength(500);

                entity.Property(e => e.AnnounceLatestChangesImg).IsUnicode(false);

                entity.Property(e => e.BirthCertificateImg).IsUnicode(false);

                entity.Property(e => e.BirthCertificatePlaceOfIssue).HasMaxLength(100);

                entity.Property(e => e.BirthDate).HasMaxLength(10);

                entity.Property(e => e.BirthLocation).HasMaxLength(100);

                entity.Property(e => e.BusinesslicenseImg).IsUnicode(false);

                entity.Property(e => e.CategoryCode).HasColumnName("Category_Code");

                entity.Property(e => e.ComNameEn)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ComNameFa).HasMaxLength(30);

                entity.Property(e => e.CommercialCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyStatuteImg).IsUnicode(false);

                entity.Property(e => e.CountryAbbreviation)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerKey).HasMaxLength(50);

                entity.Property(e => e.CustomerValue).HasMaxLength(200);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Expr3).HasColumnType("datetime");

                entity.Property(e => e.FatherNameEn).HasMaxLength(100);

                entity.Property(e => e.FatherNameFa).HasMaxLength(100);

                entity.Property(e => e.FirstNameEn).HasMaxLength(100);

                entity.Property(e => e.FirstNameFa)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ForeignPervasiveCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InsertDateTime).HasColumnType("datetime");

                entity.Property(e => e.InstallationDate).HasMaxLength(10);

                entity.Property(e => e.LastCallTime).HasColumnType("datetime");

                entity.Property(e => e.LastNameEn).HasMaxLength(200);

                entity.Property(e => e.LastNameFa)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Marketeriban)
                    .HasMaxLength(30)
                    .HasColumnName("marketeriban")
                    .IsFixedLength(true);

                entity.Property(e => e.MobileNumber).HasMaxLength(50);

                entity.Property(e => e.NationalCardImgBack).IsUnicode(false);

                entity.Property(e => e.NationalCardImgFront).IsUnicode(false);

                entity.Property(e => e.NationalLegalCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.NationalNumber)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.PassportExpireDate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PassportNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ProvinceAbbreviation)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.RedirectUrl).IsUnicode(false);

                entity.Property(e => e.RegisterDate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RegisterNo)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RequestData)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Requestid).HasColumnName("requestid");

                entity.Property(e => e.ShaparakState).HasColumnName("shaparakState");

                entity.Property(e => e.ShaparakTrackingNumber).HasMaxLength(50);

                entity.Property(e => e.ShopAddress).HasMaxLength(300);

                entity.Property(e => e.ShopBusinessLicenseExpireDate).HasMaxLength(10);

                entity.Property(e => e.ShopBusinessLicenseIssueDate).HasMaxLength(10);

                entity.Property(e => e.ShopBusinessLicenseNumber).HasMaxLength(50);

                entity.Property(e => e.ShopCityPreCode).HasMaxLength(50);

                entity.Property(e => e.ShopEmail).HasMaxLength(50);

                entity.Property(e => e.ShopFaxNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShopLogo).IsUnicode(false);

                entity.Property(e => e.ShopNameEn)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShopNameFa).HasMaxLength(50);

                entity.Property(e => e.ShopPostalCode).HasMaxLength(50);

                entity.Property(e => e.ShopTelephoneNumber).HasMaxLength(50);

                entity.Property(e => e.TaxPayerCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("taxPayerCode")
                    .IsFixedLength(true);

                entity.Property(e => e.Telephone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TerminalNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WebSiteAddress).HasMaxLength(50);

                entity.Property(e => e.WorkPermitImg).IsUnicode(false);
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("State");
            });

            modelBuilder.Entity<TerminalType>(entity =>
            {
                entity.HasKey(e => e.TerminalTypeCode);

                entity.Property(e => e.TerminalTypeCode).ValueGeneratedNever();

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.TerminalTypeName).IsRequired();
            });

            modelBuilder.Entity<Token>(entity =>
            {
                entity.ToTable("Token");

                entity.Property(e => e.Token1)
                    .IsRequired()
                    .HasColumnName("Token");

                entity.Property(e => e.TokenIssueDate).HasColumnType("datetime");

                entity.Property(e => e.TokenVerifiedDate).HasColumnType("datetime");

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastLoginDate).HasColumnType("datetime");

                entity.Property(e => e.LastName).IsRequired();

                entity.Property(e => e.Mobile).HasMaxLength(16);

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.UserName).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role");
            });

            modelBuilder.Entity<UsersPermission>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.PermissionId })
                    .HasName("PK_UsersPermissions");

                entity.ToTable("UsersPermission");
            });

            modelBuilder.Entity<WebServiceUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("WebServiceUser");

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.UserName).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
