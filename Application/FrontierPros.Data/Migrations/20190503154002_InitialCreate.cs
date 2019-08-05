using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontierPros.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        //    migrationBuilder.CreateTable(
        //        name: "ActivityLogType",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            SystemKeyword = table.Column<string>(maxLength: 100, nullable: false),
        //            Name = table.Column<string>(maxLength: 200, nullable: false),
        //            Enabled = table.Column<bool>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ActivityLogType", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "AddressAttribute",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Name = table.Column<string>(maxLength: 400, nullable: false),
        //            IsRequired = table.Column<bool>(nullable: false),
        //            AttributeControlTypeId = table.Column<int>(nullable: false),
        //            DisplayOrder = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_AddressAttribute", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Campaign",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Name = table.Column<string>(nullable: false),
        //            Subject = table.Column<string>(nullable: false),
        //            Body = table.Column<string>(nullable: false),
        //            StoreId = table.Column<int>(nullable: false),
        //            CustomerRoleId = table.Column<int>(nullable: false),
        //            CreatedOnUtc = table.Column<DateTime>(nullable: false),
        //            DontSendBeforeDateUtc = table.Column<DateTime>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Campaign", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Category",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Name = table.Column<string>(maxLength: 400, nullable: false),
        //            Description = table.Column<string>(nullable: true),
        //            CategoryTemplateId = table.Column<int>(nullable: false),
        //            MetaKeywords = table.Column<string>(maxLength: 400, nullable: true),
        //            MetaDescription = table.Column<string>(nullable: true),
        //            MetaTitle = table.Column<string>(maxLength: 400, nullable: true),
        //            ParentCategoryId = table.Column<int>(nullable: false),
        //            PictureId = table.Column<int>(nullable: false),
        //            PageSize = table.Column<int>(nullable: false),
        //            AllowCustomersToSelectPageSize = table.Column<bool>(nullable: false),
        //            PageSizeOptions = table.Column<string>(maxLength: 200, nullable: true),
        //            PriceRanges = table.Column<string>(maxLength: 400, nullable: true),
        //            ShowOnHomePage = table.Column<bool>(nullable: false),
        //            IncludeInTopMenu = table.Column<bool>(nullable: false),
        //            SubjectToAcl = table.Column<bool>(nullable: false),
        //            LimitedToStores = table.Column<bool>(nullable: false),
        //            Published = table.Column<bool>(nullable: false),
        //            Deleted = table.Column<bool>(nullable: false),
        //            DisplayOrder = table.Column<int>(nullable: false),
        //            CreatedOnUtc = table.Column<DateTime>(nullable: false),
        //            UpdatedOnUtc = table.Column<DateTime>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Category", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "CategoryTemplate",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Name = table.Column<string>(maxLength: 400, nullable: false),
        //            ViewPath = table.Column<string>(maxLength: 400, nullable: false),
        //            DisplayOrder = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_CategoryTemplate", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "CheckoutAttribute",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Name = table.Column<string>(maxLength: 400, nullable: false),
        //            TextPrompt = table.Column<string>(nullable: true),
        //            IsRequired = table.Column<bool>(nullable: false),
        //            ShippableProductRequired = table.Column<bool>(nullable: false),
        //            IsTaxExempt = table.Column<bool>(nullable: false),
        //            TaxCategoryId = table.Column<int>(nullable: false),
        //            AttributeControlTypeId = table.Column<int>(nullable: false),
        //            DisplayOrder = table.Column<int>(nullable: false),
        //            LimitedToStores = table.Column<bool>(nullable: false),
        //            ValidationMinLength = table.Column<int>(nullable: true),
        //            ValidationMaxLength = table.Column<int>(nullable: true),
        //            ValidationFileAllowedExtensions = table.Column<string>(nullable: true),
        //            ValidationFileMaximumSize = table.Column<int>(nullable: true),
        //            DefaultValue = table.Column<string>(nullable: true),
        //            ConditionAttributeXml = table.Column<string>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_CheckoutAttribute", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Country",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Name = table.Column<string>(maxLength: 100, nullable: false),
        //            AllowsBilling = table.Column<bool>(nullable: false),
        //            AllowsShipping = table.Column<bool>(nullable: false),
        //            TwoLetterIsoCode = table.Column<string>(maxLength: 2, nullable: true),
        //            ThreeLetterIsoCode = table.Column<string>(maxLength: 3, nullable: true),
        //            NumericIsoCode = table.Column<int>(nullable: false),
        //            SubjectToVat = table.Column<bool>(nullable: false),
        //            Published = table.Column<bool>(nullable: false),
        //            DisplayOrder = table.Column<int>(nullable: false),
        //            LimitedToStores = table.Column<bool>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Country", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "CrossSellProduct",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            ProductId1 = table.Column<int>(nullable: false),
        //            ProductId2 = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_CrossSellProduct", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Currency",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Name = table.Column<string>(maxLength: 50, nullable: false),
        //            CurrencyCode = table.Column<string>(maxLength: 5, nullable: false),
        //            Rate = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            DisplayLocale = table.Column<string>(maxLength: 50, nullable: true),
        //            CustomFormatting = table.Column<string>(maxLength: 50, nullable: true),
        //            LimitedToStores = table.Column<bool>(nullable: false),
        //            Published = table.Column<bool>(nullable: false),
        //            DisplayOrder = table.Column<int>(nullable: false),
        //            CreatedOnUtc = table.Column<DateTime>(nullable: false),
        //            UpdatedOnUtc = table.Column<DateTime>(nullable: false),
        //            RoundingTypeId = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Currency", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "CustomerAttribute",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Name = table.Column<string>(maxLength: 400, nullable: false),
        //            IsRequired = table.Column<bool>(nullable: false),
        //            AttributeControlTypeId = table.Column<int>(nullable: false),
        //            DisplayOrder = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_CustomerAttribute", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "CustomerRole",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Name = table.Column<string>(maxLength: 255, nullable: false),
        //            FreeShipping = table.Column<bool>(nullable: false),
        //            TaxExempt = table.Column<bool>(nullable: false),
        //            Active = table.Column<bool>(nullable: false),
        //            IsSystemRole = table.Column<bool>(nullable: false),
        //            SystemName = table.Column<string>(maxLength: 255, nullable: true),
        //            EnablePasswordLifetime = table.Column<bool>(nullable: false),
        //            OverrideTaxDisplayType = table.Column<bool>(nullable: false),
        //            DefaultTaxDisplayTypeId = table.Column<int>(nullable: false),
        //            PurchasedWithProductId = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_CustomerRole", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "DeliveryDate",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Name = table.Column<string>(maxLength: 400, nullable: false),
        //            DisplayOrder = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_DeliveryDate", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Discount",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Name = table.Column<string>(maxLength: 200, nullable: false),
        //            DiscountTypeId = table.Column<int>(nullable: false),
        //            UsePercentage = table.Column<bool>(nullable: false),
        //            DiscountPercentage = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            DiscountAmount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            MaximumDiscountAmount = table.Column<decimal>(type: "decimal(18, 4)", nullable: true),
        //            StartDateUtc = table.Column<DateTime>(nullable: true),
        //            EndDateUtc = table.Column<DateTime>(nullable: true),
        //            RequiresCouponCode = table.Column<bool>(nullable: false),
        //            CouponCode = table.Column<string>(maxLength: 100, nullable: true),
        //            IsCumulative = table.Column<bool>(nullable: false),
        //            DiscountLimitationId = table.Column<int>(nullable: false),
        //            LimitationTimes = table.Column<int>(nullable: false),
        //            MaximumDiscountedQuantity = table.Column<int>(nullable: true),
        //            AppliedToSubCategories = table.Column<bool>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Discount", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Download",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            DownloadGuid = table.Column<Guid>(nullable: false),
        //            UseDownloadUrl = table.Column<bool>(nullable: false),
        //            DownloadUrl = table.Column<string>(nullable: true),
        //            DownloadBinary = table.Column<byte[]>(nullable: true),
        //            ContentType = table.Column<string>(nullable: true),
        //            Filename = table.Column<string>(nullable: true),
        //            Extension = table.Column<string>(nullable: true),
        //            IsNew = table.Column<bool>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Download", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "EmailAccount",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Email = table.Column<string>(maxLength: 255, nullable: false),
        //            DisplayName = table.Column<string>(maxLength: 255, nullable: true),
        //            Host = table.Column<string>(maxLength: 255, nullable: false),
        //            Port = table.Column<int>(nullable: false),
        //            Username = table.Column<string>(maxLength: 255, nullable: false),
        //            Password = table.Column<string>(maxLength: 255, nullable: false),
        //            EnableSsl = table.Column<bool>(nullable: false),
        //            UseDefaultCredentials = table.Column<bool>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_EmailAccount", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Forums_Group",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Name = table.Column<string>(maxLength: 200, nullable: false),
        //            DisplayOrder = table.Column<int>(nullable: false),
        //            CreatedOnUtc = table.Column<DateTime>(nullable: false),
        //            UpdatedOnUtc = table.Column<DateTime>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Forums_Group", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "GdprConsent",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Message = table.Column<string>(nullable: false),
        //            IsRequired = table.Column<bool>(nullable: false),
        //            RequiredMessage = table.Column<string>(nullable: true),
        //            DisplayDuringRegistration = table.Column<bool>(nullable: false),
        //            DisplayOnCustomerInfoPage = table.Column<bool>(nullable: false),
        //            DisplayOrder = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_GdprConsent", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "GdprLog",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            CustomerId = table.Column<int>(nullable: false),
        //            ConsentId = table.Column<int>(nullable: false),
        //            CustomerInfo = table.Column<string>(nullable: true),
        //            RequestTypeId = table.Column<int>(nullable: false),
        //            RequestDetails = table.Column<string>(nullable: true),
        //            CreatedOnUtc = table.Column<DateTime>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_GdprLog", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "GenericAttribute",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            EntityId = table.Column<int>(nullable: false),
        //            KeyGroup = table.Column<string>(maxLength: 400, nullable: false),
        //            Key = table.Column<string>(maxLength: 400, nullable: false),
        //            Value = table.Column<string>(nullable: false),
        //            StoreId = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_GenericAttribute", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Language",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Name = table.Column<string>(maxLength: 100, nullable: false),
        //            LanguageCulture = table.Column<string>(maxLength: 20, nullable: false),
        //            UniqueSeoCode = table.Column<string>(maxLength: 2, nullable: true),
        //            FlagImageFileName = table.Column<string>(maxLength: 50, nullable: true),
        //            Rtl = table.Column<bool>(nullable: false),
        //            LimitedToStores = table.Column<bool>(nullable: false),
        //            DefaultCurrencyId = table.Column<int>(nullable: false),
        //            Published = table.Column<bool>(nullable: false),
        //            DisplayOrder = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Language", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Manufacturer",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Name = table.Column<string>(maxLength: 400, nullable: false),
        //            Description = table.Column<string>(nullable: true),
        //            ManufacturerTemplateId = table.Column<int>(nullable: false),
        //            MetaKeywords = table.Column<string>(maxLength: 400, nullable: true),
        //            MetaDescription = table.Column<string>(nullable: true),
        //            MetaTitle = table.Column<string>(maxLength: 400, nullable: true),
        //            PictureId = table.Column<int>(nullable: false),
        //            PageSize = table.Column<int>(nullable: false),
        //            AllowCustomersToSelectPageSize = table.Column<bool>(nullable: false),
        //            PageSizeOptions = table.Column<string>(maxLength: 200, nullable: true),
        //            PriceRanges = table.Column<string>(maxLength: 400, nullable: true),
        //            SubjectToAcl = table.Column<bool>(nullable: false),
        //            LimitedToStores = table.Column<bool>(nullable: false),
        //            Published = table.Column<bool>(nullable: false),
        //            Deleted = table.Column<bool>(nullable: false),
        //            DisplayOrder = table.Column<int>(nullable: false),
        //            CreatedOnUtc = table.Column<DateTime>(nullable: false),
        //            UpdatedOnUtc = table.Column<DateTime>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Manufacturer", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ManufacturerTemplate",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Name = table.Column<string>(maxLength: 400, nullable: false),
        //            ViewPath = table.Column<string>(maxLength: 400, nullable: false),
        //            DisplayOrder = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ManufacturerTemplate", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "MeasureDimension",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Name = table.Column<string>(maxLength: 100, nullable: false),
        //            SystemKeyword = table.Column<string>(maxLength: 100, nullable: false),
        //            Ratio = table.Column<decimal>(type: "decimal(18, 8)", nullable: false),
        //            DisplayOrder = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_MeasureDimension", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "MeasureWeight",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Name = table.Column<string>(maxLength: 100, nullable: false),
        //            SystemKeyword = table.Column<string>(maxLength: 100, nullable: false),
        //            Ratio = table.Column<decimal>(type: "decimal(18, 8)", nullable: false),
        //            DisplayOrder = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_MeasureWeight", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "MessageTemplate",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Name = table.Column<string>(maxLength: 200, nullable: false),
        //            BccEmailAddresses = table.Column<string>(maxLength: 200, nullable: true),
        //            Subject = table.Column<string>(maxLength: 1000, nullable: true),
        //            Body = table.Column<string>(nullable: true),
        //            IsActive = table.Column<bool>(nullable: false),
        //            DelayBeforeSend = table.Column<int>(nullable: true),
        //            DelayPeriodId = table.Column<int>(nullable: false),
        //            AttachedDownloadId = table.Column<int>(nullable: false),
        //            EmailAccountId = table.Column<int>(nullable: false),
        //            LimitedToStores = table.Column<bool>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_MessageTemplate", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "NewsLetterSubscription",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            NewsLetterSubscriptionGuid = table.Column<Guid>(nullable: false),
        //            Email = table.Column<string>(maxLength: 255, nullable: false),
        //            Active = table.Column<bool>(nullable: false),
        //            StoreId = table.Column<int>(nullable: false),
        //            CreatedOnUtc = table.Column<DateTime>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_NewsLetterSubscription", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "PermissionRecord",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Name = table.Column<string>(nullable: false),
        //            SystemName = table.Column<string>(maxLength: 255, nullable: false),
        //            Category = table.Column<string>(maxLength: 255, nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_PermissionRecord", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Picture",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            MimeType = table.Column<string>(maxLength: 40, nullable: false),
        //            SeoFilename = table.Column<string>(maxLength: 300, nullable: true),
        //            AltAttribute = table.Column<string>(nullable: true),
        //            TitleAttribute = table.Column<string>(nullable: true),
        //            IsNew = table.Column<bool>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Picture", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Product",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            ProductTypeId = table.Column<int>(nullable: false),
        //            ParentGroupedProductId = table.Column<int>(nullable: false),
        //            VisibleIndividually = table.Column<bool>(nullable: false),
        //            Name = table.Column<string>(maxLength: 400, nullable: false),
        //            ShortDescription = table.Column<string>(nullable: true),
        //            FullDescription = table.Column<string>(nullable: true),
        //            AdminComment = table.Column<string>(nullable: true),
        //            ProductTemplateId = table.Column<int>(nullable: false),
        //            VendorId = table.Column<int>(nullable: false),
        //            ShowOnHomePage = table.Column<bool>(nullable: false),
        //            MetaKeywords = table.Column<string>(maxLength: 400, nullable: true),
        //            MetaDescription = table.Column<string>(nullable: true),
        //            MetaTitle = table.Column<string>(maxLength: 400, nullable: true),
        //            AllowCustomerReviews = table.Column<bool>(nullable: false),
        //            ApprovedRatingSum = table.Column<int>(nullable: false),
        //            NotApprovedRatingSum = table.Column<int>(nullable: false),
        //            ApprovedTotalReviews = table.Column<int>(nullable: false),
        //            NotApprovedTotalReviews = table.Column<int>(nullable: false),
        //            SubjectToAcl = table.Column<bool>(nullable: false),
        //            LimitedToStores = table.Column<bool>(nullable: false),
        //            Sku = table.Column<string>(maxLength: 400, nullable: true),
        //            ManufacturerPartNumber = table.Column<string>(maxLength: 400, nullable: true),
        //            Gtin = table.Column<string>(maxLength: 400, nullable: true),
        //            IsGiftCard = table.Column<bool>(nullable: false),
        //            GiftCardTypeId = table.Column<int>(nullable: false),
        //            OverriddenGiftCardAmount = table.Column<decimal>(type: "decimal(18, 4)", nullable: true),
        //            RequireOtherProducts = table.Column<bool>(nullable: false),
        //            RequiredProductIds = table.Column<string>(maxLength: 1000, nullable: true),
        //            AutomaticallyAddRequiredProducts = table.Column<bool>(nullable: false),
        //            IsDownload = table.Column<bool>(nullable: false),
        //            DownloadId = table.Column<int>(nullable: false),
        //            UnlimitedDownloads = table.Column<bool>(nullable: false),
        //            MaxNumberOfDownloads = table.Column<int>(nullable: false),
        //            DownloadExpirationDays = table.Column<int>(nullable: true),
        //            DownloadActivationTypeId = table.Column<int>(nullable: false),
        //            HasSampleDownload = table.Column<bool>(nullable: false),
        //            SampleDownloadId = table.Column<int>(nullable: false),
        //            HasUserAgreement = table.Column<bool>(nullable: false),
        //            UserAgreementText = table.Column<string>(nullable: true),
        //            IsRecurring = table.Column<bool>(nullable: false),
        //            RecurringCycleLength = table.Column<int>(nullable: false),
        //            RecurringCyclePeriodId = table.Column<int>(nullable: false),
        //            RecurringTotalCycles = table.Column<int>(nullable: false),
        //            IsRental = table.Column<bool>(nullable: false),
        //            RentalPriceLength = table.Column<int>(nullable: false),
        //            RentalPricePeriodId = table.Column<int>(nullable: false),
        //            IsShipEnabled = table.Column<bool>(nullable: false),
        //            IsFreeShipping = table.Column<bool>(nullable: false),
        //            ShipSeparately = table.Column<bool>(nullable: false),
        //            AdditionalShippingCharge = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            DeliveryDateId = table.Column<int>(nullable: false),
        //            IsTaxExempt = table.Column<bool>(nullable: false),
        //            TaxCategoryId = table.Column<int>(nullable: false),
        //            IsTelecommunicationsOrBroadcastingOrElectronicServices = table.Column<bool>(nullable: false),
        //            ManageInventoryMethodId = table.Column<int>(nullable: false),
        //            ProductAvailabilityRangeId = table.Column<int>(nullable: false),
        //            UseMultipleWarehouses = table.Column<bool>(nullable: false),
        //            WarehouseId = table.Column<int>(nullable: false),
        //            StockQuantity = table.Column<int>(nullable: false),
        //            DisplayStockAvailability = table.Column<bool>(nullable: false),
        //            DisplayStockQuantity = table.Column<bool>(nullable: false),
        //            MinStockQuantity = table.Column<int>(nullable: false),
        //            LowStockActivityId = table.Column<int>(nullable: false),
        //            NotifyAdminForQuantityBelow = table.Column<int>(nullable: false),
        //            BackorderModeId = table.Column<int>(nullable: false),
        //            AllowBackInStockSubscriptions = table.Column<bool>(nullable: false),
        //            OrderMinimumQuantity = table.Column<int>(nullable: false),
        //            OrderMaximumQuantity = table.Column<int>(nullable: false),
        //            AllowedQuantities = table.Column<string>(maxLength: 1000, nullable: true),
        //            AllowAddingOnlyExistingAttributeCombinations = table.Column<bool>(nullable: false),
        //            NotReturnable = table.Column<bool>(nullable: false),
        //            DisableBuyButton = table.Column<bool>(nullable: false),
        //            DisableWishlistButton = table.Column<bool>(nullable: false),
        //            AvailableForPreOrder = table.Column<bool>(nullable: false),
        //            PreOrderAvailabilityStartDateTimeUtc = table.Column<DateTime>(nullable: true),
        //            CallForPrice = table.Column<bool>(nullable: false),
        //            Price = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            OldPrice = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            ProductCost = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            CustomerEntersPrice = table.Column<bool>(nullable: false),
        //            MinimumCustomerEnteredPrice = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            MaximumCustomerEnteredPrice = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            BasepriceEnabled = table.Column<bool>(nullable: false),
        //            BasepriceAmount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            BasepriceUnitId = table.Column<int>(nullable: false),
        //            BasepriceBaseAmount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            BasepriceBaseUnitId = table.Column<int>(nullable: false),
        //            MarkAsNew = table.Column<bool>(nullable: false),
        //            MarkAsNewStartDateTimeUtc = table.Column<DateTime>(nullable: true),
        //            MarkAsNewEndDateTimeUtc = table.Column<DateTime>(nullable: true),
        //            HasTierPrices = table.Column<bool>(nullable: false),
        //            HasDiscountsApplied = table.Column<bool>(nullable: false),
        //            Weight = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            Length = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            Width = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            Height = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            AvailableStartDateTimeUtc = table.Column<DateTime>(nullable: true),
        //            AvailableEndDateTimeUtc = table.Column<DateTime>(nullable: true),
        //            DisplayOrder = table.Column<int>(nullable: false),
        //            Published = table.Column<bool>(nullable: false),
        //            Deleted = table.Column<bool>(nullable: false),
        //            CreatedOnUtc = table.Column<DateTime>(nullable: false),
        //            UpdatedOnUtc = table.Column<DateTime>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Product", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ProductAttribute",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Name = table.Column<string>(nullable: false),
        //            Description = table.Column<string>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ProductAttribute", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ProductAvailabilityRange",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Name = table.Column<string>(maxLength: 400, nullable: false),
        //            DisplayOrder = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ProductAvailabilityRange", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ProductTag",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Name = table.Column<string>(maxLength: 400, nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ProductTag", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ProductTemplate",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Name = table.Column<string>(maxLength: 400, nullable: false),
        //            ViewPath = table.Column<string>(maxLength: 400, nullable: false),
        //            DisplayOrder = table.Column<int>(nullable: false),
        //            IgnoredProductTypes = table.Column<string>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ProductTemplate", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "RelatedProduct",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            ProductId1 = table.Column<int>(nullable: false),
        //            ProductId2 = table.Column<int>(nullable: false),
        //            DisplayOrder = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_RelatedProduct", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ReturnRequestAction",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Name = table.Column<string>(maxLength: 400, nullable: false),
        //            DisplayOrder = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ReturnRequestAction", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ReturnRequestReason",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Name = table.Column<string>(maxLength: 400, nullable: false),
        //            DisplayOrder = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ReturnRequestReason", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ReviewType",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Name = table.Column<string>(maxLength: 400, nullable: false),
        //            Description = table.Column<string>(maxLength: 400, nullable: false),
        //            DisplayOrder = table.Column<int>(nullable: false),
        //            VisibleToAllCustomers = table.Column<bool>(nullable: false),
        //            IsRequired = table.Column<bool>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ReviewType", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ScheduleTask",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Name = table.Column<string>(nullable: false),
        //            Seconds = table.Column<int>(nullable: false),
        //            Type = table.Column<string>(nullable: false),
        //            Enabled = table.Column<bool>(nullable: false),
        //            StopOnError = table.Column<bool>(nullable: false),
        //            LastStartUtc = table.Column<DateTime>(nullable: true),
        //            LastEndUtc = table.Column<DateTime>(nullable: true),
        //            LastSuccessUtc = table.Column<DateTime>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ScheduleTask", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "SearchTerm",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Keyword = table.Column<string>(nullable: true),
        //            StoreId = table.Column<int>(nullable: false),
        //            Count = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_SearchTerm", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Setting",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Name = table.Column<string>(maxLength: 200, nullable: false),
        //            Value = table.Column<string>(maxLength: 2000, nullable: false),
        //            StoreId = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Setting", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ShippingMethod",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Name = table.Column<string>(maxLength: 400, nullable: false),
        //            Description = table.Column<string>(nullable: true),
        //            DisplayOrder = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ShippingMethod", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "SpecificationAttribute",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Name = table.Column<string>(nullable: false),
        //            DisplayOrder = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_SpecificationAttribute", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Store",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Name = table.Column<string>(maxLength: 400, nullable: false),
        //            Url = table.Column<string>(maxLength: 400, nullable: false),
        //            SslEnabled = table.Column<bool>(nullable: false),
        //            Hosts = table.Column<string>(maxLength: 1000, nullable: true),
        //            DefaultLanguageId = table.Column<int>(nullable: false),
        //            DisplayOrder = table.Column<int>(nullable: false),
        //            CompanyName = table.Column<string>(maxLength: 1000, nullable: true),
        //            CompanyAddress = table.Column<string>(maxLength: 1000, nullable: true),
        //            CompanyPhoneNumber = table.Column<string>(maxLength: 1000, nullable: true),
        //            CompanyVat = table.Column<string>(maxLength: 1000, nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Store", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "TaxCategory",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Name = table.Column<string>(maxLength: 400, nullable: false),
        //            DisplayOrder = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_TaxCategory", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Topic",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            SystemName = table.Column<string>(nullable: true),
        //            IncludeInSitemap = table.Column<bool>(nullable: false),
        //            IncludeInTopMenu = table.Column<bool>(nullable: false),
        //            IncludeInFooterColumn1 = table.Column<bool>(nullable: false),
        //            IncludeInFooterColumn2 = table.Column<bool>(nullable: false),
        //            IncludeInFooterColumn3 = table.Column<bool>(nullable: false),
        //            DisplayOrder = table.Column<int>(nullable: false),
        //            AccessibleWhenStoreClosed = table.Column<bool>(nullable: false),
        //            IsPasswordProtected = table.Column<bool>(nullable: false),
        //            Password = table.Column<string>(nullable: true),
        //            Title = table.Column<string>(nullable: true),
        //            Body = table.Column<string>(nullable: true),
        //            Published = table.Column<bool>(nullable: false),
        //            TopicTemplateId = table.Column<int>(nullable: false),
        //            MetaKeywords = table.Column<string>(nullable: true),
        //            MetaDescription = table.Column<string>(nullable: true),
        //            MetaTitle = table.Column<string>(nullable: true),
        //            SubjectToAcl = table.Column<bool>(nullable: false),
        //            LimitedToStores = table.Column<bool>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Topic", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "TopicTemplate",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Name = table.Column<string>(maxLength: 400, nullable: false),
        //            ViewPath = table.Column<string>(maxLength: 400, nullable: false),
        //            DisplayOrder = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_TopicTemplate", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "UrlRecord",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            EntityId = table.Column<int>(nullable: false),
        //            EntityName = table.Column<string>(maxLength: 400, nullable: false),
        //            Slug = table.Column<string>(maxLength: 400, nullable: false),
        //            IsActive = table.Column<bool>(nullable: false),
        //            LanguageId = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_UrlRecord", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Vendor",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Name = table.Column<string>(maxLength: 400, nullable: false),
        //            Email = table.Column<string>(maxLength: 400, nullable: true),
        //            Description = table.Column<string>(nullable: true),
        //            PictureId = table.Column<int>(nullable: false),
        //            AddressId = table.Column<int>(nullable: false),
        //            AdminComment = table.Column<string>(nullable: true),
        //            Active = table.Column<bool>(nullable: false),
        //            Deleted = table.Column<bool>(nullable: false),
        //            DisplayOrder = table.Column<int>(nullable: false),
        //            MetaKeywords = table.Column<string>(maxLength: 400, nullable: true),
        //            MetaDescription = table.Column<string>(nullable: true),
        //            MetaTitle = table.Column<string>(maxLength: 400, nullable: true),
        //            PageSize = table.Column<int>(nullable: false),
        //            AllowCustomersToSelectPageSize = table.Column<bool>(nullable: false),
        //            PageSizeOptions = table.Column<string>(maxLength: 200, nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Vendor", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "VendorAttribute",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Name = table.Column<string>(maxLength: 400, nullable: false),
        //            IsRequired = table.Column<bool>(nullable: false),
        //            DisplayOrder = table.Column<int>(nullable: false),
        //            AttributeControlTypeId = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_VendorAttribute", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Warehouse",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Name = table.Column<string>(maxLength: 400, nullable: false),
        //            AdminComment = table.Column<string>(nullable: true),
        //            AddressId = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Warehouse", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "AddressAttributeValue",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            AddressAttributeId = table.Column<int>(nullable: false),
        //            Name = table.Column<string>(maxLength: 400, nullable: false),
        //            IsPreSelected = table.Column<bool>(nullable: false),
        //            DisplayOrder = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_AddressAttributeValue", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_AddressAttributeValue_AddressAttribute_AddressAttributeId",
        //                column: x => x.AddressAttributeId,
        //                principalTable: "AddressAttribute",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "CheckoutAttributeValue",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            CheckoutAttributeId = table.Column<int>(nullable: false),
        //            Name = table.Column<string>(maxLength: 400, nullable: false),
        //            ColorSquaresRgb = table.Column<string>(maxLength: 100, nullable: true),
        //            PriceAdjustment = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            WeightAdjustment = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            IsPreSelected = table.Column<bool>(nullable: false),
        //            DisplayOrder = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_CheckoutAttributeValue", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_CheckoutAttributeValue_CheckoutAttribute_CheckoutAttributeId",
        //                column: x => x.CheckoutAttributeId,
        //                principalTable: "CheckoutAttribute",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "StateProvince",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            CountryId = table.Column<int>(nullable: false),
        //            Name = table.Column<string>(maxLength: 100, nullable: false),
        //            Abbreviation = table.Column<string>(maxLength: 100, nullable: true),
        //            Published = table.Column<bool>(nullable: false),
        //            DisplayOrder = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_StateProvince", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_StateProvince_Country_CountryId",
        //                column: x => x.CountryId,
        //                principalTable: "Country",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "CustomerAttributeValue",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            CustomerAttributeId = table.Column<int>(nullable: false),
        //            Name = table.Column<string>(maxLength: 400, nullable: false),
        //            IsPreSelected = table.Column<bool>(nullable: false),
        //            DisplayOrder = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_CustomerAttributeValue", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_CustomerAttributeValue_CustomerAttribute_CustomerAttributeId",
        //                column: x => x.CustomerAttributeId,
        //                principalTable: "CustomerAttribute",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "AclRecord",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            EntityId = table.Column<int>(nullable: false),
        //            EntityName = table.Column<string>(maxLength: 400, nullable: false),
        //            CustomerRoleId = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_AclRecord", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_AclRecord_CustomerRole_CustomerRoleId",
        //                column: x => x.CustomerRoleId,
        //                principalTable: "CustomerRole",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Discount_AppliedToCategories",
        //        columns: table => new
        //        {
        //            Discount_Id = table.Column<int>(nullable: false),
        //            Category_Id = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Discount_AppliedToCategories", x => new { x.Discount_Id, x.Category_Id });
        //            table.ForeignKey(
        //                name: "FK_Discount_AppliedToCategories_Category_Category_Id",
        //                column: x => x.Category_Id,
        //                principalTable: "Category",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Discount_AppliedToCategories_Discount_Discount_Id",
        //                column: x => x.Discount_Id,
        //                principalTable: "Discount",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "DiscountRequirement",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            DiscountId = table.Column<int>(nullable: false),
        //            DiscountRequirementRuleSystemName = table.Column<string>(nullable: true),
        //            ParentId = table.Column<int>(nullable: true),
        //            InteractionTypeId = table.Column<int>(nullable: true),
        //            IsGroup = table.Column<bool>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_DiscountRequirement", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_DiscountRequirement_Discount_DiscountId",
        //                column: x => x.DiscountId,
        //                principalTable: "Discount",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_DiscountRequirement_DiscountRequirement_ParentId",
        //                column: x => x.ParentId,
        //                principalTable: "DiscountRequirement",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "QueuedEmail",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            PriorityId = table.Column<int>(nullable: false),
        //            From = table.Column<string>(maxLength: 500, nullable: false),
        //            FromName = table.Column<string>(maxLength: 500, nullable: true),
        //            To = table.Column<string>(maxLength: 500, nullable: false),
        //            ToName = table.Column<string>(maxLength: 500, nullable: true),
        //            ReplyTo = table.Column<string>(maxLength: 500, nullable: true),
        //            ReplyToName = table.Column<string>(maxLength: 500, nullable: true),
        //            CC = table.Column<string>(maxLength: 500, nullable: true),
        //            Bcc = table.Column<string>(maxLength: 500, nullable: true),
        //            Subject = table.Column<string>(maxLength: 1000, nullable: true),
        //            Body = table.Column<string>(nullable: true),
        //            AttachmentFilePath = table.Column<string>(nullable: true),
        //            AttachmentFileName = table.Column<string>(nullable: true),
        //            AttachedDownloadId = table.Column<int>(nullable: false),
        //            CreatedOnUtc = table.Column<DateTime>(nullable: false),
        //            DontSendBeforeDateUtc = table.Column<DateTime>(nullable: true),
        //            SentTries = table.Column<int>(nullable: false),
        //            SentOnUtc = table.Column<DateTime>(nullable: true),
        //            EmailAccountId = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_QueuedEmail", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_QueuedEmail_EmailAccount_EmailAccountId",
        //                column: x => x.EmailAccountId,
        //                principalTable: "EmailAccount",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Forums_Forum",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            ForumGroupId = table.Column<int>(nullable: false),
        //            Name = table.Column<string>(maxLength: 200, nullable: false),
        //            Description = table.Column<string>(nullable: true),
        //            NumTopics = table.Column<int>(nullable: false),
        //            NumPosts = table.Column<int>(nullable: false),
        //            LastTopicId = table.Column<int>(nullable: false),
        //            LastPostId = table.Column<int>(nullable: false),
        //            LastPostCustomerId = table.Column<int>(nullable: false),
        //            LastPostTime = table.Column<DateTime>(nullable: true),
        //            DisplayOrder = table.Column<int>(nullable: false),
        //            CreatedOnUtc = table.Column<DateTime>(nullable: false),
        //            UpdatedOnUtc = table.Column<DateTime>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Forums_Forum", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Forums_Forum_Forums_Group_ForumGroupId",
        //                column: x => x.ForumGroupId,
        //                principalTable: "Forums_Group",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "BlogPost",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            LanguageId = table.Column<int>(nullable: false),
        //            Title = table.Column<string>(nullable: false),
        //            Body = table.Column<string>(nullable: false),
        //            BodyOverview = table.Column<string>(nullable: true),
        //            AllowComments = table.Column<bool>(nullable: false),
        //            Tags = table.Column<string>(nullable: true),
        //            StartDateUtc = table.Column<DateTime>(nullable: true),
        //            EndDateUtc = table.Column<DateTime>(nullable: true),
        //            MetaKeywords = table.Column<string>(maxLength: 400, nullable: true),
        //            MetaDescription = table.Column<string>(nullable: true),
        //            MetaTitle = table.Column<string>(maxLength: 400, nullable: true),
        //            LimitedToStores = table.Column<bool>(nullable: false),
        //            CreatedOnUtc = table.Column<DateTime>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_BlogPost", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_BlogPost_Language_LanguageId",
        //                column: x => x.LanguageId,
        //                principalTable: "Language",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "LocaleStringResource",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            LanguageId = table.Column<int>(nullable: false),
        //            ResourceName = table.Column<string>(maxLength: 200, nullable: false),
        //            ResourceValue = table.Column<string>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_LocaleStringResource", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_LocaleStringResource_Language_LanguageId",
        //                column: x => x.LanguageId,
        //                principalTable: "Language",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "LocalizedProperty",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            EntityId = table.Column<int>(nullable: false),
        //            LanguageId = table.Column<int>(nullable: false),
        //            LocaleKeyGroup = table.Column<string>(maxLength: 400, nullable: false),
        //            LocaleKey = table.Column<string>(maxLength: 400, nullable: false),
        //            LocaleValue = table.Column<string>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_LocalizedProperty", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_LocalizedProperty_Language_LanguageId",
        //                column: x => x.LanguageId,
        //                principalTable: "Language",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "News",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            LanguageId = table.Column<int>(nullable: false),
        //            Title = table.Column<string>(nullable: false),
        //            Short = table.Column<string>(nullable: false),
        //            Full = table.Column<string>(nullable: false),
        //            Published = table.Column<bool>(nullable: false),
        //            StartDateUtc = table.Column<DateTime>(nullable: true),
        //            EndDateUtc = table.Column<DateTime>(nullable: true),
        //            AllowComments = table.Column<bool>(nullable: false),
        //            LimitedToStores = table.Column<bool>(nullable: false),
        //            MetaKeywords = table.Column<string>(maxLength: 400, nullable: true),
        //            MetaDescription = table.Column<string>(nullable: true),
        //            MetaTitle = table.Column<string>(maxLength: 400, nullable: true),
        //            CreatedOnUtc = table.Column<DateTime>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_News", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_News_Language_LanguageId",
        //                column: x => x.LanguageId,
        //                principalTable: "Language",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Poll",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            LanguageId = table.Column<int>(nullable: false),
        //            Name = table.Column<string>(nullable: false),
        //            SystemKeyword = table.Column<string>(nullable: true),
        //            Published = table.Column<bool>(nullable: false),
        //            ShowOnHomePage = table.Column<bool>(nullable: false),
        //            AllowGuestsToVote = table.Column<bool>(nullable: false),
        //            DisplayOrder = table.Column<int>(nullable: false),
        //            LimitedToStores = table.Column<bool>(nullable: false),
        //            StartDateUtc = table.Column<DateTime>(nullable: true),
        //            EndDateUtc = table.Column<DateTime>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Poll", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Poll_Language_LanguageId",
        //                column: x => x.LanguageId,
        //                principalTable: "Language",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Discount_AppliedToManufacturers",
        //        columns: table => new
        //        {
        //            Discount_Id = table.Column<int>(nullable: false),
        //            Manufacturer_Id = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Discount_AppliedToManufacturers", x => new { x.Discount_Id, x.Manufacturer_Id });
        //            table.ForeignKey(
        //                name: "FK_Discount_AppliedToManufacturers_Discount_Discount_Id",
        //                column: x => x.Discount_Id,
        //                principalTable: "Discount",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Discount_AppliedToManufacturers_Manufacturer_Manufacturer_Id",
        //                column: x => x.Manufacturer_Id,
        //                principalTable: "Manufacturer",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "PermissionRecord_Role_Mapping",
        //        columns: table => new
        //        {
        //            PermissionRecord_Id = table.Column<int>(nullable: false),
        //            CustomerRole_Id = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_PermissionRecord_Role_Mapping", x => new { x.PermissionRecord_Id, x.CustomerRole_Id });
        //            table.ForeignKey(
        //                name: "FK_PermissionRecord_Role_Mapping_CustomerRole_CustomerRole_Id",
        //                column: x => x.CustomerRole_Id,
        //                principalTable: "CustomerRole",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_PermissionRecord_Role_Mapping_PermissionRecord_PermissionRecord_Id",
        //                column: x => x.PermissionRecord_Id,
        //                principalTable: "PermissionRecord",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "PictureBinary",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            BinaryData = table.Column<byte[]>(nullable: true),
        //            PictureId = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_PictureBinary", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_PictureBinary_Picture_PictureId",
        //                column: x => x.PictureId,
        //                principalTable: "Picture",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Discount_AppliedToProducts",
        //        columns: table => new
        //        {
        //            Discount_Id = table.Column<int>(nullable: false),
        //            Product_Id = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Discount_AppliedToProducts", x => new { x.Discount_Id, x.Product_Id });
        //            table.ForeignKey(
        //                name: "FK_Discount_AppliedToProducts_Discount_Discount_Id",
        //                column: x => x.Discount_Id,
        //                principalTable: "Discount",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Discount_AppliedToProducts_Product_Product_Id",
        //                column: x => x.Product_Id,
        //                principalTable: "Product",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Product_Category_Mapping",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            ProductId = table.Column<int>(nullable: false),
        //            CategoryId = table.Column<int>(nullable: false),
        //            IsFeaturedProduct = table.Column<bool>(nullable: false),
        //            DisplayOrder = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Product_Category_Mapping", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Product_Category_Mapping_Category_CategoryId",
        //                column: x => x.CategoryId,
        //                principalTable: "Category",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Product_Category_Mapping_Product_ProductId",
        //                column: x => x.ProductId,
        //                principalTable: "Product",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Product_Manufacturer_Mapping",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            ProductId = table.Column<int>(nullable: false),
        //            ManufacturerId = table.Column<int>(nullable: false),
        //            IsFeaturedProduct = table.Column<bool>(nullable: false),
        //            DisplayOrder = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Product_Manufacturer_Mapping", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Product_Manufacturer_Mapping_Manufacturer_ManufacturerId",
        //                column: x => x.ManufacturerId,
        //                principalTable: "Manufacturer",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Product_Manufacturer_Mapping_Product_ProductId",
        //                column: x => x.ProductId,
        //                principalTable: "Product",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Product_Picture_Mapping",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            ProductId = table.Column<int>(nullable: false),
        //            PictureId = table.Column<int>(nullable: false),
        //            DisplayOrder = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Product_Picture_Mapping", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Product_Picture_Mapping_Picture_PictureId",
        //                column: x => x.PictureId,
        //                principalTable: "Picture",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Product_Picture_Mapping_Product_ProductId",
        //                column: x => x.ProductId,
        //                principalTable: "Product",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ProductAttributeCombination",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            ProductId = table.Column<int>(nullable: false),
        //            AttributesXml = table.Column<string>(nullable: true),
        //            StockQuantity = table.Column<int>(nullable: false),
        //            AllowOutOfStockOrders = table.Column<bool>(nullable: false),
        //            Sku = table.Column<string>(maxLength: 400, nullable: true),
        //            ManufacturerPartNumber = table.Column<string>(maxLength: 400, nullable: true),
        //            Gtin = table.Column<string>(maxLength: 400, nullable: true),
        //            OverriddenPrice = table.Column<decimal>(type: "decimal(18, 4)", nullable: true),
        //            NotifyAdminForQuantityBelow = table.Column<int>(nullable: false),
        //            PictureId = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ProductAttributeCombination", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_ProductAttributeCombination_Product_ProductId",
        //                column: x => x.ProductId,
        //                principalTable: "Product",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "StockQuantityHistory",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            QuantityAdjustment = table.Column<int>(nullable: false),
        //            StockQuantity = table.Column<int>(nullable: false),
        //            Message = table.Column<string>(nullable: true),
        //            CreatedOnUtc = table.Column<DateTime>(nullable: false),
        //            ProductId = table.Column<int>(nullable: false),
        //            CombinationId = table.Column<int>(nullable: true),
        //            WarehouseId = table.Column<int>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_StockQuantityHistory", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_StockQuantityHistory_Product_ProductId",
        //                column: x => x.ProductId,
        //                principalTable: "Product",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "TierPrice",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            ProductId = table.Column<int>(nullable: false),
        //            StoreId = table.Column<int>(nullable: false),
        //            CustomerRoleId = table.Column<int>(nullable: true),
        //            Quantity = table.Column<int>(nullable: false),
        //            Price = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            StartDateTimeUtc = table.Column<DateTime>(nullable: true),
        //            EndDateTimeUtc = table.Column<DateTime>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_TierPrice", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_TierPrice_CustomerRole_CustomerRoleId",
        //                column: x => x.CustomerRoleId,
        //                principalTable: "CustomerRole",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_TierPrice_Product_ProductId",
        //                column: x => x.ProductId,
        //                principalTable: "Product",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "PredefinedProductAttributeValue",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            ProductAttributeId = table.Column<int>(nullable: false),
        //            Name = table.Column<string>(maxLength: 400, nullable: false),
        //            PriceAdjustment = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            PriceAdjustmentUsePercentage = table.Column<bool>(nullable: false),
        //            WeightAdjustment = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            Cost = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            IsPreSelected = table.Column<bool>(nullable: false),
        //            DisplayOrder = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_PredefinedProductAttributeValue", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_PredefinedProductAttributeValue_ProductAttribute_ProductAttributeId",
        //                column: x => x.ProductAttributeId,
        //                principalTable: "ProductAttribute",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Product_ProductAttribute_Mapping",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            ProductId = table.Column<int>(nullable: false),
        //            ProductAttributeId = table.Column<int>(nullable: false),
        //            TextPrompt = table.Column<string>(nullable: true),
        //            IsRequired = table.Column<bool>(nullable: false),
        //            AttributeControlTypeId = table.Column<int>(nullable: false),
        //            DisplayOrder = table.Column<int>(nullable: false),
        //            ValidationMinLength = table.Column<int>(nullable: true),
        //            ValidationMaxLength = table.Column<int>(nullable: true),
        //            ValidationFileAllowedExtensions = table.Column<string>(nullable: true),
        //            ValidationFileMaximumSize = table.Column<int>(nullable: true),
        //            DefaultValue = table.Column<string>(nullable: true),
        //            ConditionAttributeXml = table.Column<string>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Product_ProductAttribute_Mapping", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Product_ProductAttribute_Mapping_ProductAttribute_ProductAttributeId",
        //                column: x => x.ProductAttributeId,
        //                principalTable: "ProductAttribute",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Product_ProductAttribute_Mapping_Product_ProductId",
        //                column: x => x.ProductId,
        //                principalTable: "Product",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Product_ProductTag_Mapping",
        //        columns: table => new
        //        {
        //            Product_Id = table.Column<int>(nullable: false),
        //            ProductTag_Id = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Product_ProductTag_Mapping", x => new { x.Product_Id, x.ProductTag_Id });
        //            table.ForeignKey(
        //                name: "FK_Product_ProductTag_Mapping_Product_Product_Id",
        //                column: x => x.Product_Id,
        //                principalTable: "Product",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Product_ProductTag_Mapping_ProductTag_ProductTag_Id",
        //                column: x => x.ProductTag_Id,
        //                principalTable: "ProductTag",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ShippingMethodRestrictions",
        //        columns: table => new
        //        {
        //            ShippingMethod_Id = table.Column<int>(nullable: false),
        //            Country_Id = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ShippingMethodRestrictions", x => new { x.ShippingMethod_Id, x.Country_Id });
        //            table.ForeignKey(
        //                name: "FK_ShippingMethodRestrictions_Country_Country_Id",
        //                column: x => x.Country_Id,
        //                principalTable: "Country",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_ShippingMethodRestrictions_ShippingMethod_ShippingMethod_Id",
        //                column: x => x.ShippingMethod_Id,
        //                principalTable: "ShippingMethod",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "SpecificationAttributeOption",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            SpecificationAttributeId = table.Column<int>(nullable: false),
        //            Name = table.Column<string>(nullable: false),
        //            ColorSquaresRgb = table.Column<string>(maxLength: 100, nullable: true),
        //            DisplayOrder = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_SpecificationAttributeOption", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_SpecificationAttributeOption_SpecificationAttribute_SpecificationAttributeId",
        //                column: x => x.SpecificationAttributeId,
        //                principalTable: "SpecificationAttribute",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "StoreMapping",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            EntityId = table.Column<int>(nullable: false),
        //            EntityName = table.Column<string>(maxLength: 400, nullable: false),
        //            StoreId = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_StoreMapping", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_StoreMapping_Store_StoreId",
        //                column: x => x.StoreId,
        //                principalTable: "Store",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "VendorNote",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            VendorId = table.Column<int>(nullable: false),
        //            Note = table.Column<string>(nullable: false),
        //            CreatedOnUtc = table.Column<DateTime>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_VendorNote", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_VendorNote_Vendor_VendorId",
        //                column: x => x.VendorId,
        //                principalTable: "Vendor",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "VendorAttributeValue",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Name = table.Column<string>(maxLength: 400, nullable: false),
        //            IsPreSelected = table.Column<bool>(nullable: false),
        //            DisplayOrder = table.Column<int>(nullable: false),
        //            VendorAttributeId = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_VendorAttributeValue", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_VendorAttributeValue_VendorAttribute_VendorAttributeId",
        //                column: x => x.VendorAttributeId,
        //                principalTable: "VendorAttribute",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ProductWarehouseInventory",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            ProductId = table.Column<int>(nullable: false),
        //            WarehouseId = table.Column<int>(nullable: false),
        //            StockQuantity = table.Column<int>(nullable: false),
        //            ReservedQuantity = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ProductWarehouseInventory", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_ProductWarehouseInventory_Product_ProductId",
        //                column: x => x.ProductId,
        //                principalTable: "Product",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_ProductWarehouseInventory_Warehouse_WarehouseId",
        //                column: x => x.WarehouseId,
        //                principalTable: "Warehouse",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Address",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            FirstName = table.Column<string>(nullable: true),
        //            LastName = table.Column<string>(nullable: true),
        //            Email = table.Column<string>(nullable: true),
        //            Company = table.Column<string>(nullable: true),
        //            CountryId = table.Column<int>(nullable: true),
        //            StateProvinceId = table.Column<int>(nullable: true),
        //            County = table.Column<string>(nullable: true),
        //            City = table.Column<string>(nullable: true),
        //            Address1 = table.Column<string>(nullable: true),
        //            Address2 = table.Column<string>(nullable: true),
        //            ZipPostalCode = table.Column<string>(nullable: true),
        //            PhoneNumber = table.Column<string>(nullable: true),
        //            FaxNumber = table.Column<string>(nullable: true),
        //            CustomAttributes = table.Column<string>(nullable: true),
        //            CreatedOnUtc = table.Column<DateTime>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Address", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Address_Country_CountryId",
        //                column: x => x.CountryId,
        //                principalTable: "Country",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //            table.ForeignKey(
        //                name: "FK_Address_StateProvince_StateProvinceId",
        //                column: x => x.StateProvinceId,
        //                principalTable: "StateProvince",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "PollAnswer",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            PollId = table.Column<int>(nullable: false),
        //            Name = table.Column<string>(nullable: false),
        //            NumberOfVotes = table.Column<int>(nullable: false),
        //            DisplayOrder = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_PollAnswer", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_PollAnswer_Poll_PollId",
        //                column: x => x.PollId,
        //                principalTable: "Poll",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ProductAttributeValue",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            ProductAttributeMappingId = table.Column<int>(nullable: false),
        //            AttributeValueTypeId = table.Column<int>(nullable: false),
        //            AssociatedProductId = table.Column<int>(nullable: false),
        //            Name = table.Column<string>(maxLength: 400, nullable: false),
        //            ColorSquaresRgb = table.Column<string>(maxLength: 100, nullable: true),
        //            ImageSquaresPictureId = table.Column<int>(nullable: false),
        //            PriceAdjustment = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            PriceAdjustmentUsePercentage = table.Column<bool>(nullable: false),
        //            WeightAdjustment = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            Cost = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            CustomerEntersQty = table.Column<bool>(nullable: false),
        //            Quantity = table.Column<int>(nullable: false),
        //            IsPreSelected = table.Column<bool>(nullable: false),
        //            DisplayOrder = table.Column<int>(nullable: false),
        //            PictureId = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ProductAttributeValue", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_ProductAttributeValue_Product_ProductAttribute_Mapping_ProductAttributeMappingId",
        //                column: x => x.ProductAttributeMappingId,
        //                principalTable: "Product_ProductAttribute_Mapping",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Product_SpecificationAttribute_Mapping",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            ProductId = table.Column<int>(nullable: false),
        //            AttributeTypeId = table.Column<int>(nullable: false),
        //            SpecificationAttributeOptionId = table.Column<int>(nullable: false),
        //            CustomValue = table.Column<string>(maxLength: 4000, nullable: true),
        //            AllowFiltering = table.Column<bool>(nullable: false),
        //            ShowOnProductPage = table.Column<bool>(nullable: false),
        //            DisplayOrder = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Product_SpecificationAttribute_Mapping", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Product_SpecificationAttribute_Mapping_Product_ProductId",
        //                column: x => x.ProductId,
        //                principalTable: "Product",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Product_SpecificationAttribute_Mapping_SpecificationAttributeOption_SpecificationAttributeOptionId",
        //                column: x => x.SpecificationAttributeOptionId,
        //                principalTable: "SpecificationAttributeOption",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Affiliate",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            AddressId = table.Column<int>(nullable: false),
        //            AdminComment = table.Column<string>(nullable: true),
        //            FriendlyUrlName = table.Column<string>(nullable: true),
        //            Deleted = table.Column<bool>(nullable: false),
        //            Active = table.Column<bool>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Affiliate", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Affiliate_Address_AddressId",
        //                column: x => x.AddressId,
        //                principalTable: "Address",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Customer",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            CustomerGuid = table.Column<Guid>(nullable: false),
        //            Username = table.Column<string>(maxLength: 1000, nullable: true),
        //            Email = table.Column<string>(maxLength: 1000, nullable: true),
        //            EmailToRevalidate = table.Column<string>(maxLength: 1000, nullable: true),
        //            AdminComment = table.Column<string>(nullable: true),
        //            IsTaxExempt = table.Column<bool>(nullable: false),
        //            AffiliateId = table.Column<int>(nullable: false),
        //            VendorId = table.Column<int>(nullable: false),
        //            HasShoppingCartItems = table.Column<bool>(nullable: false),
        //            RequireReLogin = table.Column<bool>(nullable: false),
        //            FailedLoginAttempts = table.Column<int>(nullable: false),
        //            CannotLoginUntilDateUtc = table.Column<DateTime>(nullable: true),
        //            Active = table.Column<bool>(nullable: false),
        //            Deleted = table.Column<bool>(nullable: false),
        //            IsSystemAccount = table.Column<bool>(nullable: false),
        //            SystemName = table.Column<string>(maxLength: 400, nullable: true),
        //            LastIpAddress = table.Column<string>(nullable: true),
        //            CreatedOnUtc = table.Column<DateTime>(nullable: false),
        //            LastLoginDateUtc = table.Column<DateTime>(nullable: true),
        //            LastActivityDateUtc = table.Column<DateTime>(nullable: false),
        //            RegisteredInStoreId = table.Column<int>(nullable: false),
        //            BillingAddress_Id = table.Column<int>(nullable: true),
        //            ShippingAddress_Id = table.Column<int>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Customer", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Customer_Address_BillingAddress_Id",
        //                column: x => x.BillingAddress_Id,
        //                principalTable: "Address",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //            table.ForeignKey(
        //                name: "FK_Customer_Address_ShippingAddress_Id",
        //                column: x => x.ShippingAddress_Id,
        //                principalTable: "Address",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ActivityLog",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            ActivityLogTypeId = table.Column<int>(nullable: false),
        //            EntityId = table.Column<int>(nullable: true),
        //            EntityName = table.Column<string>(maxLength: 400, nullable: true),
        //            CustomerId = table.Column<int>(nullable: false),
        //            Comment = table.Column<string>(nullable: false),
        //            CreatedOnUtc = table.Column<DateTime>(nullable: false),
        //            IpAddress = table.Column<string>(maxLength: 200, nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ActivityLog", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_ActivityLog_ActivityLogType_ActivityLogTypeId",
        //                column: x => x.ActivityLogTypeId,
        //                principalTable: "ActivityLogType",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_ActivityLog_Customer_CustomerId",
        //                column: x => x.CustomerId,
        //                principalTable: "Customer",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "BackInStockSubscription",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            StoreId = table.Column<int>(nullable: false),
        //            ProductId = table.Column<int>(nullable: false),
        //            CustomerId = table.Column<int>(nullable: false),
        //            CreatedOnUtc = table.Column<DateTime>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_BackInStockSubscription", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_BackInStockSubscription_Customer_CustomerId",
        //                column: x => x.CustomerId,
        //                principalTable: "Customer",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_BackInStockSubscription_Product_ProductId",
        //                column: x => x.ProductId,
        //                principalTable: "Product",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "BlogComment",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            CustomerId = table.Column<int>(nullable: false),
        //            CommentText = table.Column<string>(nullable: true),
        //            IsApproved = table.Column<bool>(nullable: false),
        //            StoreId = table.Column<int>(nullable: false),
        //            BlogPostId = table.Column<int>(nullable: false),
        //            CreatedOnUtc = table.Column<DateTime>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_BlogComment", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_BlogComment_BlogPost_BlogPostId",
        //                column: x => x.BlogPostId,
        //                principalTable: "BlogPost",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_BlogComment_Customer_CustomerId",
        //                column: x => x.CustomerId,
        //                principalTable: "Customer",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_BlogComment_Store_StoreId",
        //                column: x => x.StoreId,
        //                principalTable: "Store",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Customer_CustomerRole_Mapping",
        //        columns: table => new
        //        {
        //            Customer_Id = table.Column<int>(nullable: false),
        //            CustomerRole_Id = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Customer_CustomerRole_Mapping", x => new { x.Customer_Id, x.CustomerRole_Id });
        //            table.ForeignKey(
        //                name: "FK_Customer_CustomerRole_Mapping_Customer_Customer_Id",
        //                column: x => x.Customer_Id,
        //                principalTable: "Customer",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Customer_CustomerRole_Mapping_CustomerRole_CustomerRole_Id",
        //                column: x => x.CustomerRole_Id,
        //                principalTable: "CustomerRole",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "CustomerAddresses",
        //        columns: table => new
        //        {
        //            Customer_Id = table.Column<int>(nullable: false),
        //            Address_Id = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_CustomerAddresses", x => new { x.Customer_Id, x.Address_Id });
        //            table.ForeignKey(
        //                name: "FK_CustomerAddresses_Address_Address_Id",
        //                column: x => x.Address_Id,
        //                principalTable: "Address",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_CustomerAddresses_Customer_Customer_Id",
        //                column: x => x.Customer_Id,
        //                principalTable: "Customer",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "CustomerPassword",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            CustomerId = table.Column<int>(nullable: false),
        //            Password = table.Column<string>(nullable: true),
        //            PasswordFormatId = table.Column<int>(nullable: false),
        //            PasswordSalt = table.Column<string>(nullable: true),
        //            CreatedOnUtc = table.Column<DateTime>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_CustomerPassword", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_CustomerPassword_Customer_CustomerId",
        //                column: x => x.CustomerId,
        //                principalTable: "Customer",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ExternalAuthenticationRecord",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            CustomerId = table.Column<int>(nullable: false),
        //            Email = table.Column<string>(nullable: true),
        //            ExternalIdentifier = table.Column<string>(nullable: true),
        //            ExternalDisplayIdentifier = table.Column<string>(nullable: true),
        //            OAuthToken = table.Column<string>(nullable: true),
        //            OAuthAccessToken = table.Column<string>(nullable: true),
        //            ProviderSystemName = table.Column<string>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ExternalAuthenticationRecord", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_ExternalAuthenticationRecord_Customer_CustomerId",
        //                column: x => x.CustomerId,
        //                principalTable: "Customer",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Forums_PrivateMessage",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            StoreId = table.Column<int>(nullable: false),
        //            FromCustomerId = table.Column<int>(nullable: false),
        //            ToCustomerId = table.Column<int>(nullable: false),
        //            Subject = table.Column<string>(maxLength: 450, nullable: false),
        //            Text = table.Column<string>(nullable: false),
        //            IsRead = table.Column<bool>(nullable: false),
        //            IsDeletedByAuthor = table.Column<bool>(nullable: false),
        //            IsDeletedByRecipient = table.Column<bool>(nullable: false),
        //            CreatedOnUtc = table.Column<DateTime>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Forums_PrivateMessage", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Forums_PrivateMessage_Customer_FromCustomerId",
        //                column: x => x.FromCustomerId,
        //                principalTable: "Customer",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //            table.ForeignKey(
        //                name: "FK_Forums_PrivateMessage_Customer_ToCustomerId",
        //                column: x => x.ToCustomerId,
        //                principalTable: "Customer",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Forums_Subscription",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            SubscriptionGuid = table.Column<Guid>(nullable: false),
        //            CustomerId = table.Column<int>(nullable: false),
        //            ForumId = table.Column<int>(nullable: false),
        //            TopicId = table.Column<int>(nullable: false),
        //            CreatedOnUtc = table.Column<DateTime>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Forums_Subscription", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Forums_Subscription_Customer_CustomerId",
        //                column: x => x.CustomerId,
        //                principalTable: "Customer",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Forums_Topic",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            ForumId = table.Column<int>(nullable: false),
        //            CustomerId = table.Column<int>(nullable: false),
        //            TopicTypeId = table.Column<int>(nullable: false),
        //            Subject = table.Column<string>(maxLength: 450, nullable: false),
        //            NumPosts = table.Column<int>(nullable: false),
        //            Views = table.Column<int>(nullable: false),
        //            LastPostId = table.Column<int>(nullable: false),
        //            LastPostCustomerId = table.Column<int>(nullable: false),
        //            LastPostTime = table.Column<DateTime>(nullable: true),
        //            CreatedOnUtc = table.Column<DateTime>(nullable: false),
        //            UpdatedOnUtc = table.Column<DateTime>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Forums_Topic", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Forums_Topic_Customer_CustomerId",
        //                column: x => x.CustomerId,
        //                principalTable: "Customer",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //            table.ForeignKey(
        //                name: "FK_Forums_Topic_Forums_Forum_ForumId",
        //                column: x => x.ForumId,
        //                principalTable: "Forums_Forum",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Log",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            LogLevelId = table.Column<int>(nullable: false),
        //            ShortMessage = table.Column<string>(nullable: false),
        //            FullMessage = table.Column<string>(nullable: true),
        //            IpAddress = table.Column<string>(maxLength: 200, nullable: true),
        //            CustomerId = table.Column<int>(nullable: true),
        //            PageUrl = table.Column<string>(nullable: true),
        //            ReferrerUrl = table.Column<string>(nullable: true),
        //            CreatedOnUtc = table.Column<DateTime>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Log", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Log_Customer_CustomerId",
        //                column: x => x.CustomerId,
        //                principalTable: "Customer",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "NewsComment",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            CommentTitle = table.Column<string>(nullable: true),
        //            CommentText = table.Column<string>(nullable: true),
        //            NewsItemId = table.Column<int>(nullable: false),
        //            CustomerId = table.Column<int>(nullable: false),
        //            IsApproved = table.Column<bool>(nullable: false),
        //            StoreId = table.Column<int>(nullable: false),
        //            CreatedOnUtc = table.Column<DateTime>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_NewsComment", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_NewsComment_Customer_CustomerId",
        //                column: x => x.CustomerId,
        //                principalTable: "Customer",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_NewsComment_News_NewsItemId",
        //                column: x => x.NewsItemId,
        //                principalTable: "News",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_NewsComment_Store_StoreId",
        //                column: x => x.StoreId,
        //                principalTable: "Store",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "PollVotingRecord",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            PollAnswerId = table.Column<int>(nullable: false),
        //            CustomerId = table.Column<int>(nullable: false),
        //            CreatedOnUtc = table.Column<DateTime>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_PollVotingRecord", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_PollVotingRecord_Customer_CustomerId",
        //                column: x => x.CustomerId,
        //                principalTable: "Customer",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_PollVotingRecord_PollAnswer_PollAnswerId",
        //                column: x => x.PollAnswerId,
        //                principalTable: "PollAnswer",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ProductReview",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            CustomerId = table.Column<int>(nullable: false),
        //            ProductId = table.Column<int>(nullable: false),
        //            StoreId = table.Column<int>(nullable: false),
        //            IsApproved = table.Column<bool>(nullable: false),
        //            Title = table.Column<string>(nullable: true),
        //            ReviewText = table.Column<string>(nullable: true),
        //            ReplyText = table.Column<string>(nullable: true),
        //            CustomerNotifiedOfReply = table.Column<bool>(nullable: false),
        //            Rating = table.Column<int>(nullable: false),
        //            HelpfulYesTotal = table.Column<int>(nullable: false),
        //            HelpfulNoTotal = table.Column<int>(nullable: false),
        //            CreatedOnUtc = table.Column<DateTime>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ProductReview", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_ProductReview_Customer_CustomerId",
        //                column: x => x.CustomerId,
        //                principalTable: "Customer",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_ProductReview_Product_ProductId",
        //                column: x => x.ProductId,
        //                principalTable: "Product",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_ProductReview_Store_StoreId",
        //                column: x => x.StoreId,
        //                principalTable: "Store",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ReturnRequest",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            CustomNumber = table.Column<string>(nullable: true),
        //            StoreId = table.Column<int>(nullable: false),
        //            OrderItemId = table.Column<int>(nullable: false),
        //            CustomerId = table.Column<int>(nullable: false),
        //            Quantity = table.Column<int>(nullable: false),
        //            ReasonForReturn = table.Column<string>(nullable: false),
        //            RequestedAction = table.Column<string>(nullable: false),
        //            CustomerComments = table.Column<string>(nullable: true),
        //            UploadedFileId = table.Column<int>(nullable: false),
        //            StaffNotes = table.Column<string>(nullable: true),
        //            ReturnRequestStatusId = table.Column<int>(nullable: false),
        //            CreatedOnUtc = table.Column<DateTime>(nullable: false),
        //            UpdatedOnUtc = table.Column<DateTime>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ReturnRequest", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_ReturnRequest_Customer_CustomerId",
        //                column: x => x.CustomerId,
        //                principalTable: "Customer",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "RewardPointsHistory",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            CustomerId = table.Column<int>(nullable: false),
        //            StoreId = table.Column<int>(nullable: false),
        //            Points = table.Column<int>(nullable: false),
        //            PointsBalance = table.Column<int>(nullable: true),
        //            UsedAmount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            Message = table.Column<string>(nullable: true),
        //            CreatedOnUtc = table.Column<DateTime>(nullable: false),
        //            EndDateUtc = table.Column<DateTime>(nullable: true),
        //            ValidPoints = table.Column<int>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_RewardPointsHistory", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_RewardPointsHistory_Customer_CustomerId",
        //                column: x => x.CustomerId,
        //                principalTable: "Customer",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ShoppingCartItem",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            StoreId = table.Column<int>(nullable: false),
        //            ShoppingCartTypeId = table.Column<int>(nullable: false),
        //            CustomerId = table.Column<int>(nullable: false),
        //            ProductId = table.Column<int>(nullable: false),
        //            AttributesXml = table.Column<string>(nullable: true),
        //            CustomerEnteredPrice = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            Quantity = table.Column<int>(nullable: false),
        //            RentalStartDateUtc = table.Column<DateTime>(nullable: true),
        //            RentalEndDateUtc = table.Column<DateTime>(nullable: true),
        //            CreatedOnUtc = table.Column<DateTime>(nullable: false),
        //            UpdatedOnUtc = table.Column<DateTime>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ShoppingCartItem", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_ShoppingCartItem_Customer_CustomerId",
        //                column: x => x.CustomerId,
        //                principalTable: "Customer",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_ShoppingCartItem_Product_ProductId",
        //                column: x => x.ProductId,
        //                principalTable: "Product",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Forums_Post",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            TopicId = table.Column<int>(nullable: false),
        //            CustomerId = table.Column<int>(nullable: false),
        //            Text = table.Column<string>(nullable: false),
        //            IPAddress = table.Column<string>(maxLength: 100, nullable: true),
        //            CreatedOnUtc = table.Column<DateTime>(nullable: false),
        //            UpdatedOnUtc = table.Column<DateTime>(nullable: false),
        //            VoteCount = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Forums_Post", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Forums_Post_Customer_CustomerId",
        //                column: x => x.CustomerId,
        //                principalTable: "Customer",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //            table.ForeignKey(
        //                name: "FK_Forums_Post_Forums_Topic_TopicId",
        //                column: x => x.TopicId,
        //                principalTable: "Forums_Topic",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ProductReview_ReviewType_Mapping",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            ProductReviewId = table.Column<int>(nullable: false),
        //            ReviewTypeId = table.Column<int>(nullable: false),
        //            Rating = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ProductReview_ReviewType_Mapping", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_ProductReview_ReviewType_Mapping_ProductReview_ProductReviewId",
        //                column: x => x.ProductReviewId,
        //                principalTable: "ProductReview",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_ProductReview_ReviewType_Mapping_ReviewType_ReviewTypeId",
        //                column: x => x.ReviewTypeId,
        //                principalTable: "ReviewType",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ProductReviewHelpfulness",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            ProductReviewId = table.Column<int>(nullable: false),
        //            WasHelpful = table.Column<bool>(nullable: false),
        //            CustomerId = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ProductReviewHelpfulness", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_ProductReviewHelpfulness_ProductReview_ProductReviewId",
        //                column: x => x.ProductReviewId,
        //                principalTable: "ProductReview",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Order",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            OrderGuid = table.Column<Guid>(nullable: false),
        //            StoreId = table.Column<int>(nullable: false),
        //            CustomerId = table.Column<int>(nullable: false),
        //            BillingAddressId = table.Column<int>(nullable: false),
        //            ShippingAddressId = table.Column<int>(nullable: true),
        //            PickupAddressId = table.Column<int>(nullable: true),
        //            PickUpInStore = table.Column<bool>(nullable: false),
        //            OrderStatusId = table.Column<int>(nullable: false),
        //            ShippingStatusId = table.Column<int>(nullable: false),
        //            PaymentStatusId = table.Column<int>(nullable: false),
        //            PaymentMethodSystemName = table.Column<string>(nullable: true),
        //            CustomerCurrencyCode = table.Column<string>(nullable: true),
        //            CurrencyRate = table.Column<decimal>(type: "decimal(18, 8)", nullable: false),
        //            CustomerTaxDisplayTypeId = table.Column<int>(nullable: false),
        //            VatNumber = table.Column<string>(nullable: true),
        //            OrderSubtotalInclTax = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            OrderSubtotalExclTax = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            OrderSubTotalDiscountInclTax = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            OrderSubTotalDiscountExclTax = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            OrderShippingInclTax = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            OrderShippingExclTax = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            PaymentMethodAdditionalFeeInclTax = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            PaymentMethodAdditionalFeeExclTax = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            TaxRates = table.Column<string>(nullable: true),
        //            OrderTax = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            OrderDiscount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            OrderTotal = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            RefundedAmount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            RewardPointsHistoryEntryId = table.Column<int>(nullable: true),
        //            CheckoutAttributeDescription = table.Column<string>(nullable: true),
        //            CheckoutAttributesXml = table.Column<string>(nullable: true),
        //            CustomerLanguageId = table.Column<int>(nullable: false),
        //            AffiliateId = table.Column<int>(nullable: false),
        //            CustomerIp = table.Column<string>(nullable: true),
        //            AllowStoringCreditCardNumber = table.Column<bool>(nullable: false),
        //            CardType = table.Column<string>(nullable: true),
        //            CardName = table.Column<string>(nullable: true),
        //            CardNumber = table.Column<string>(nullable: true),
        //            MaskedCreditCardNumber = table.Column<string>(nullable: true),
        //            CardCvv2 = table.Column<string>(nullable: true),
        //            CardExpirationMonth = table.Column<string>(nullable: true),
        //            CardExpirationYear = table.Column<string>(nullable: true),
        //            AuthorizationTransactionId = table.Column<string>(nullable: true),
        //            AuthorizationTransactionCode = table.Column<string>(nullable: true),
        //            AuthorizationTransactionResult = table.Column<string>(nullable: true),
        //            CaptureTransactionId = table.Column<string>(nullable: true),
        //            CaptureTransactionResult = table.Column<string>(nullable: true),
        //            SubscriptionTransactionId = table.Column<string>(nullable: true),
        //            PaidDateUtc = table.Column<DateTime>(nullable: true),
        //            ShippingMethod = table.Column<string>(nullable: true),
        //            ShippingRateComputationMethodSystemName = table.Column<string>(nullable: true),
        //            CustomValuesXml = table.Column<string>(nullable: true),
        //            Deleted = table.Column<bool>(nullable: false),
        //            CreatedOnUtc = table.Column<DateTime>(nullable: false),
        //            CustomOrderNumber = table.Column<string>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Order", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Order_Address_BillingAddressId",
        //                column: x => x.BillingAddressId,
        //                principalTable: "Address",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //            table.ForeignKey(
        //                name: "FK_Order_Customer_CustomerId",
        //                column: x => x.CustomerId,
        //                principalTable: "Customer",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Order_Address_PickupAddressId",
        //                column: x => x.PickupAddressId,
        //                principalTable: "Address",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //            table.ForeignKey(
        //                name: "FK_Order_RewardPointsHistory_RewardPointsHistoryEntryId",
        //                column: x => x.RewardPointsHistoryEntryId,
        //                principalTable: "RewardPointsHistory",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //            table.ForeignKey(
        //                name: "FK_Order_Address_ShippingAddressId",
        //                column: x => x.ShippingAddressId,
        //                principalTable: "Address",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Forums_PostVote",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            ForumPostId = table.Column<int>(nullable: false),
        //            CustomerId = table.Column<int>(nullable: false),
        //            IsUp = table.Column<bool>(nullable: false),
        //            CreatedOnUtc = table.Column<DateTime>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Forums_PostVote", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Forums_PostVote_Forums_Post_ForumPostId",
        //                column: x => x.ForumPostId,
        //                principalTable: "Forums_Post",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "DiscountUsageHistory",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            DiscountId = table.Column<int>(nullable: false),
        //            OrderId = table.Column<int>(nullable: false),
        //            CreatedOnUtc = table.Column<DateTime>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_DiscountUsageHistory", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_DiscountUsageHistory_Discount_DiscountId",
        //                column: x => x.DiscountId,
        //                principalTable: "Discount",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_DiscountUsageHistory_Order_OrderId",
        //                column: x => x.OrderId,
        //                principalTable: "Order",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "OrderItem",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            OrderItemGuid = table.Column<Guid>(nullable: false),
        //            OrderId = table.Column<int>(nullable: false),
        //            ProductId = table.Column<int>(nullable: false),
        //            Quantity = table.Column<int>(nullable: false),
        //            UnitPriceInclTax = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            UnitPriceExclTax = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            PriceInclTax = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            PriceExclTax = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            DiscountAmountInclTax = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            DiscountAmountExclTax = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            OriginalProductCost = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            AttributeDescription = table.Column<string>(nullable: true),
        //            AttributesXml = table.Column<string>(nullable: true),
        //            DownloadCount = table.Column<int>(nullable: false),
        //            IsDownloadActivated = table.Column<bool>(nullable: false),
        //            LicenseDownloadId = table.Column<int>(nullable: true),
        //            ItemWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: true),
        //            RentalStartDateUtc = table.Column<DateTime>(nullable: true),
        //            RentalEndDateUtc = table.Column<DateTime>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_OrderItem", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_OrderItem_Order_OrderId",
        //                column: x => x.OrderId,
        //                principalTable: "Order",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_OrderItem_Product_ProductId",
        //                column: x => x.ProductId,
        //                principalTable: "Product",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "OrderNote",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            OrderId = table.Column<int>(nullable: false),
        //            Note = table.Column<string>(nullable: false),
        //            DownloadId = table.Column<int>(nullable: false),
        //            DisplayToCustomer = table.Column<bool>(nullable: false),
        //            CreatedOnUtc = table.Column<DateTime>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_OrderNote", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_OrderNote_Order_OrderId",
        //                column: x => x.OrderId,
        //                principalTable: "Order",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "RecurringPayment",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            CycleLength = table.Column<int>(nullable: false),
        //            CyclePeriodId = table.Column<int>(nullable: false),
        //            TotalCycles = table.Column<int>(nullable: false),
        //            StartDateUtc = table.Column<DateTime>(nullable: false),
        //            IsActive = table.Column<bool>(nullable: false),
        //            LastPaymentFailed = table.Column<bool>(nullable: false),
        //            Deleted = table.Column<bool>(nullable: false),
        //            InitialOrderId = table.Column<int>(nullable: false),
        //            CreatedOnUtc = table.Column<DateTime>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_RecurringPayment", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_RecurringPayment_Order_InitialOrderId",
        //                column: x => x.InitialOrderId,
        //                principalTable: "Order",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Shipment",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            OrderId = table.Column<int>(nullable: false),
        //            TrackingNumber = table.Column<string>(nullable: true),
        //            TotalWeight = table.Column<decimal>(type: "decimal(18, 4)", nullable: true),
        //            ShippedDateUtc = table.Column<DateTime>(nullable: true),
        //            DeliveryDateUtc = table.Column<DateTime>(nullable: true),
        //            AdminComment = table.Column<string>(nullable: true),
        //            CreatedOnUtc = table.Column<DateTime>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Shipment", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Shipment_Order_OrderId",
        //                column: x => x.OrderId,
        //                principalTable: "Order",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "GiftCard",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            PurchasedWithOrderItemId = table.Column<int>(nullable: true),
        //            GiftCardTypeId = table.Column<int>(nullable: false),
        //            Amount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            IsGiftCardActivated = table.Column<bool>(nullable: false),
        //            GiftCardCouponCode = table.Column<string>(nullable: true),
        //            RecipientName = table.Column<string>(nullable: true),
        //            RecipientEmail = table.Column<string>(nullable: true),
        //            SenderName = table.Column<string>(nullable: true),
        //            SenderEmail = table.Column<string>(nullable: true),
        //            Message = table.Column<string>(nullable: true),
        //            IsRecipientNotified = table.Column<bool>(nullable: false),
        //            CreatedOnUtc = table.Column<DateTime>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_GiftCard", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_GiftCard_OrderItem_PurchasedWithOrderItemId",
        //                column: x => x.PurchasedWithOrderItemId,
        //                principalTable: "OrderItem",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "RecurringPaymentHistory",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            RecurringPaymentId = table.Column<int>(nullable: false),
        //            OrderId = table.Column<int>(nullable: false),
        //            CreatedOnUtc = table.Column<DateTime>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_RecurringPaymentHistory", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_RecurringPaymentHistory_RecurringPayment_RecurringPaymentId",
        //                column: x => x.RecurringPaymentId,
        //                principalTable: "RecurringPayment",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ShipmentItem",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            ShipmentId = table.Column<int>(nullable: false),
        //            OrderItemId = table.Column<int>(nullable: false),
        //            Quantity = table.Column<int>(nullable: false),
        //            WarehouseId = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ShipmentItem", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_ShipmentItem_Shipment_ShipmentId",
        //                column: x => x.ShipmentId,
        //                principalTable: "Shipment",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "GiftCardUsageHistory",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            GiftCardId = table.Column<int>(nullable: false),
        //            UsedWithOrderId = table.Column<int>(nullable: false),
        //            UsedValue = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
        //            CreatedOnUtc = table.Column<DateTime>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_GiftCardUsageHistory", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_GiftCardUsageHistory_GiftCard_GiftCardId",
        //                column: x => x.GiftCardId,
        //                principalTable: "GiftCard",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_GiftCardUsageHistory_Order_UsedWithOrderId",
        //                column: x => x.UsedWithOrderId,
        //                principalTable: "Order",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateIndex(
        //        name: "IX_AclRecord_CustomerRoleId",
        //        table: "AclRecord",
        //        column: "CustomerRoleId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ActivityLog_ActivityLogTypeId",
        //        table: "ActivityLog",
        //        column: "ActivityLogTypeId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ActivityLog_CustomerId",
        //        table: "ActivityLog",
        //        column: "CustomerId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Address_CountryId",
        //        table: "Address",
        //        column: "CountryId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Address_StateProvinceId",
        //        table: "Address",
        //        column: "StateProvinceId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_AddressAttributeValue_AddressAttributeId",
        //        table: "AddressAttributeValue",
        //        column: "AddressAttributeId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Affiliate_AddressId",
        //        table: "Affiliate",
        //        column: "AddressId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_BackInStockSubscription_CustomerId",
        //        table: "BackInStockSubscription",
        //        column: "CustomerId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_BackInStockSubscription_ProductId",
        //        table: "BackInStockSubscription",
        //        column: "ProductId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_BlogComment_BlogPostId",
        //        table: "BlogComment",
        //        column: "BlogPostId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_BlogComment_CustomerId",
        //        table: "BlogComment",
        //        column: "CustomerId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_BlogComment_StoreId",
        //        table: "BlogComment",
        //        column: "StoreId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_BlogPost_LanguageId",
        //        table: "BlogPost",
        //        column: "LanguageId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_CheckoutAttributeValue_CheckoutAttributeId",
        //        table: "CheckoutAttributeValue",
        //        column: "CheckoutAttributeId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Customer_BillingAddress_Id",
        //        table: "Customer",
        //        column: "BillingAddress_Id");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Customer_ShippingAddress_Id",
        //        table: "Customer",
        //        column: "ShippingAddress_Id");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Customer_CustomerRole_Mapping_CustomerRole_Id",
        //        table: "Customer_CustomerRole_Mapping",
        //        column: "CustomerRole_Id");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_CustomerAddresses_Address_Id",
        //        table: "CustomerAddresses",
        //        column: "Address_Id");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_CustomerAttributeValue_CustomerAttributeId",
        //        table: "CustomerAttributeValue",
        //        column: "CustomerAttributeId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_CustomerPassword_CustomerId",
        //        table: "CustomerPassword",
        //        column: "CustomerId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Discount_AppliedToCategories_Category_Id",
        //        table: "Discount_AppliedToCategories",
        //        column: "Category_Id");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Discount_AppliedToManufacturers_Manufacturer_Id",
        //        table: "Discount_AppliedToManufacturers",
        //        column: "Manufacturer_Id");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Discount_AppliedToProducts_Product_Id",
        //        table: "Discount_AppliedToProducts",
        //        column: "Product_Id");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_DiscountRequirement_DiscountId",
        //        table: "DiscountRequirement",
        //        column: "DiscountId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_DiscountRequirement_ParentId",
        //        table: "DiscountRequirement",
        //        column: "ParentId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_DiscountUsageHistory_DiscountId",
        //        table: "DiscountUsageHistory",
        //        column: "DiscountId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_DiscountUsageHistory_OrderId",
        //        table: "DiscountUsageHistory",
        //        column: "OrderId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ExternalAuthenticationRecord_CustomerId",
        //        table: "ExternalAuthenticationRecord",
        //        column: "CustomerId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Forums_Forum_ForumGroupId",
        //        table: "Forums_Forum",
        //        column: "ForumGroupId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Forums_Post_CustomerId",
        //        table: "Forums_Post",
        //        column: "CustomerId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Forums_Post_TopicId",
        //        table: "Forums_Post",
        //        column: "TopicId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Forums_PostVote_ForumPostId",
        //        table: "Forums_PostVote",
        //        column: "ForumPostId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Forums_PrivateMessage_FromCustomerId",
        //        table: "Forums_PrivateMessage",
        //        column: "FromCustomerId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Forums_PrivateMessage_ToCustomerId",
        //        table: "Forums_PrivateMessage",
        //        column: "ToCustomerId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Forums_Subscription_CustomerId",
        //        table: "Forums_Subscription",
        //        column: "CustomerId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Forums_Topic_CustomerId",
        //        table: "Forums_Topic",
        //        column: "CustomerId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Forums_Topic_ForumId",
        //        table: "Forums_Topic",
        //        column: "ForumId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_GiftCard_PurchasedWithOrderItemId",
        //        table: "GiftCard",
        //        column: "PurchasedWithOrderItemId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_GiftCardUsageHistory_GiftCardId",
        //        table: "GiftCardUsageHistory",
        //        column: "GiftCardId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_GiftCardUsageHistory_UsedWithOrderId",
        //        table: "GiftCardUsageHistory",
        //        column: "UsedWithOrderId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_LocaleStringResource_LanguageId",
        //        table: "LocaleStringResource",
        //        column: "LanguageId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_LocalizedProperty_LanguageId",
        //        table: "LocalizedProperty",
        //        column: "LanguageId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Log_CustomerId",
        //        table: "Log",
        //        column: "CustomerId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_News_LanguageId",
        //        table: "News",
        //        column: "LanguageId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_NewsComment_CustomerId",
        //        table: "NewsComment",
        //        column: "CustomerId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_NewsComment_NewsItemId",
        //        table: "NewsComment",
        //        column: "NewsItemId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_NewsComment_StoreId",
        //        table: "NewsComment",
        //        column: "StoreId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Order_BillingAddressId",
        //        table: "Order",
        //        column: "BillingAddressId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Order_CustomerId",
        //        table: "Order",
        //        column: "CustomerId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Order_PickupAddressId",
        //        table: "Order",
        //        column: "PickupAddressId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Order_RewardPointsHistoryEntryId",
        //        table: "Order",
        //        column: "RewardPointsHistoryEntryId",
        //        unique: true,
        //        filter: "[RewardPointsHistoryEntryId] IS NOT NULL");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Order_ShippingAddressId",
        //        table: "Order",
        //        column: "ShippingAddressId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_OrderItem_OrderId",
        //        table: "OrderItem",
        //        column: "OrderId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_OrderItem_ProductId",
        //        table: "OrderItem",
        //        column: "ProductId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_OrderNote_OrderId",
        //        table: "OrderNote",
        //        column: "OrderId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_PermissionRecord_Role_Mapping_CustomerRole_Id",
        //        table: "PermissionRecord_Role_Mapping",
        //        column: "CustomerRole_Id");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_PictureBinary_PictureId",
        //        table: "PictureBinary",
        //        column: "PictureId",
        //        unique: true);

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Poll_LanguageId",
        //        table: "Poll",
        //        column: "LanguageId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_PollAnswer_PollId",
        //        table: "PollAnswer",
        //        column: "PollId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_PollVotingRecord_CustomerId",
        //        table: "PollVotingRecord",
        //        column: "CustomerId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_PollVotingRecord_PollAnswerId",
        //        table: "PollVotingRecord",
        //        column: "PollAnswerId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_PredefinedProductAttributeValue_ProductAttributeId",
        //        table: "PredefinedProductAttributeValue",
        //        column: "ProductAttributeId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Product_Category_Mapping_CategoryId",
        //        table: "Product_Category_Mapping",
        //        column: "CategoryId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Product_Category_Mapping_ProductId",
        //        table: "Product_Category_Mapping",
        //        column: "ProductId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Product_Manufacturer_Mapping_ManufacturerId",
        //        table: "Product_Manufacturer_Mapping",
        //        column: "ManufacturerId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Product_Manufacturer_Mapping_ProductId",
        //        table: "Product_Manufacturer_Mapping",
        //        column: "ProductId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Product_Picture_Mapping_PictureId",
        //        table: "Product_Picture_Mapping",
        //        column: "PictureId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Product_Picture_Mapping_ProductId",
        //        table: "Product_Picture_Mapping",
        //        column: "ProductId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Product_ProductAttribute_Mapping_ProductAttributeId",
        //        table: "Product_ProductAttribute_Mapping",
        //        column: "ProductAttributeId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Product_ProductAttribute_Mapping_ProductId",
        //        table: "Product_ProductAttribute_Mapping",
        //        column: "ProductId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Product_ProductTag_Mapping_ProductTag_Id",
        //        table: "Product_ProductTag_Mapping",
        //        column: "ProductTag_Id");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Product_SpecificationAttribute_Mapping_ProductId",
        //        table: "Product_SpecificationAttribute_Mapping",
        //        column: "ProductId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Product_SpecificationAttribute_Mapping_SpecificationAttributeOptionId",
        //        table: "Product_SpecificationAttribute_Mapping",
        //        column: "SpecificationAttributeOptionId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ProductAttributeCombination_ProductId",
        //        table: "ProductAttributeCombination",
        //        column: "ProductId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ProductAttributeValue_ProductAttributeMappingId",
        //        table: "ProductAttributeValue",
        //        column: "ProductAttributeMappingId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ProductReview_CustomerId",
        //        table: "ProductReview",
        //        column: "CustomerId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ProductReview_ProductId",
        //        table: "ProductReview",
        //        column: "ProductId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ProductReview_StoreId",
        //        table: "ProductReview",
        //        column: "StoreId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ProductReview_ReviewType_Mapping_ProductReviewId",
        //        table: "ProductReview_ReviewType_Mapping",
        //        column: "ProductReviewId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ProductReview_ReviewType_Mapping_ReviewTypeId",
        //        table: "ProductReview_ReviewType_Mapping",
        //        column: "ReviewTypeId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ProductReviewHelpfulness_ProductReviewId",
        //        table: "ProductReviewHelpfulness",
        //        column: "ProductReviewId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ProductWarehouseInventory_ProductId",
        //        table: "ProductWarehouseInventory",
        //        column: "ProductId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ProductWarehouseInventory_WarehouseId",
        //        table: "ProductWarehouseInventory",
        //        column: "WarehouseId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_QueuedEmail_EmailAccountId",
        //        table: "QueuedEmail",
        //        column: "EmailAccountId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_RecurringPayment_InitialOrderId",
        //        table: "RecurringPayment",
        //        column: "InitialOrderId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_RecurringPaymentHistory_RecurringPaymentId",
        //        table: "RecurringPaymentHistory",
        //        column: "RecurringPaymentId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ReturnRequest_CustomerId",
        //        table: "ReturnRequest",
        //        column: "CustomerId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_RewardPointsHistory_CustomerId",
        //        table: "RewardPointsHistory",
        //        column: "CustomerId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Shipment_OrderId",
        //        table: "Shipment",
        //        column: "OrderId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ShipmentItem_ShipmentId",
        //        table: "ShipmentItem",
        //        column: "ShipmentId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ShippingMethodRestrictions_Country_Id",
        //        table: "ShippingMethodRestrictions",
        //        column: "Country_Id");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ShoppingCartItem_CustomerId",
        //        table: "ShoppingCartItem",
        //        column: "CustomerId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ShoppingCartItem_ProductId",
        //        table: "ShoppingCartItem",
        //        column: "ProductId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_SpecificationAttributeOption_SpecificationAttributeId",
        //        table: "SpecificationAttributeOption",
        //        column: "SpecificationAttributeId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_StateProvince_CountryId",
        //        table: "StateProvince",
        //        column: "CountryId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_StockQuantityHistory_ProductId",
        //        table: "StockQuantityHistory",
        //        column: "ProductId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_StoreMapping_StoreId",
        //        table: "StoreMapping",
        //        column: "StoreId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_TierPrice_CustomerRoleId",
        //        table: "TierPrice",
        //        column: "CustomerRoleId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_TierPrice_ProductId",
        //        table: "TierPrice",
        //        column: "ProductId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_VendorAttributeValue_VendorAttributeId",
        //        table: "VendorAttributeValue",
        //        column: "VendorAttributeId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_VendorNote_VendorId",
        //        table: "VendorNote",
        //        column: "VendorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        //    migrationBuilder.DropTable(
        //        name: "AclRecord");

        //    migrationBuilder.DropTable(
        //        name: "ActivityLog");

        //    migrationBuilder.DropTable(
        //        name: "AddressAttributeValue");

        //    migrationBuilder.DropTable(
        //        name: "Affiliate");

        //    migrationBuilder.DropTable(
        //        name: "BackInStockSubscription");

        //    migrationBuilder.DropTable(
        //        name: "BlogComment");

        //    migrationBuilder.DropTable(
        //        name: "Campaign");

        //    migrationBuilder.DropTable(
        //        name: "CategoryTemplate");

        //    migrationBuilder.DropTable(
        //        name: "CheckoutAttributeValue");

        //    migrationBuilder.DropTable(
        //        name: "CrossSellProduct");

        //    migrationBuilder.DropTable(
        //        name: "Currency");

        //    migrationBuilder.DropTable(
        //        name: "Customer_CustomerRole_Mapping");

        //    migrationBuilder.DropTable(
        //        name: "CustomerAddresses");

        //    migrationBuilder.DropTable(
        //        name: "CustomerAttributeValue");

        //    migrationBuilder.DropTable(
        //        name: "CustomerPassword");

        //    migrationBuilder.DropTable(
        //        name: "DeliveryDate");

        //    migrationBuilder.DropTable(
        //        name: "Discount_AppliedToCategories");

        //    migrationBuilder.DropTable(
        //        name: "Discount_AppliedToManufacturers");

        //    migrationBuilder.DropTable(
        //        name: "Discount_AppliedToProducts");

        //    migrationBuilder.DropTable(
        //        name: "DiscountRequirement");

        //    migrationBuilder.DropTable(
        //        name: "DiscountUsageHistory");

        //    migrationBuilder.DropTable(
        //        name: "Download");

        //    migrationBuilder.DropTable(
        //        name: "ExternalAuthenticationRecord");

        //    migrationBuilder.DropTable(
        //        name: "Forums_PostVote");

        //    migrationBuilder.DropTable(
        //        name: "Forums_PrivateMessage");

        //    migrationBuilder.DropTable(
        //        name: "Forums_Subscription");

        //    migrationBuilder.DropTable(
        //        name: "GdprConsent");

        //    migrationBuilder.DropTable(
        //        name: "GdprLog");

        //    migrationBuilder.DropTable(
        //        name: "GenericAttribute");

        //    migrationBuilder.DropTable(
        //        name: "GiftCardUsageHistory");

        //    migrationBuilder.DropTable(
        //        name: "LocaleStringResource");

        //    migrationBuilder.DropTable(
        //        name: "LocalizedProperty");

        //    migrationBuilder.DropTable(
        //        name: "Log");

        //    migrationBuilder.DropTable(
        //        name: "ManufacturerTemplate");

        //    migrationBuilder.DropTable(
        //        name: "MeasureDimension");

        //    migrationBuilder.DropTable(
        //        name: "MeasureWeight");

        //    migrationBuilder.DropTable(
        //        name: "MessageTemplate");

        //    migrationBuilder.DropTable(
        //        name: "NewsComment");

        //    migrationBuilder.DropTable(
        //        name: "NewsLetterSubscription");

        //    migrationBuilder.DropTable(
        //        name: "OrderNote");

        //    migrationBuilder.DropTable(
        //        name: "PermissionRecord_Role_Mapping");

        //    migrationBuilder.DropTable(
        //        name: "PictureBinary");

        //    migrationBuilder.DropTable(
        //        name: "PollVotingRecord");

        //    migrationBuilder.DropTable(
        //        name: "PredefinedProductAttributeValue");

        //    migrationBuilder.DropTable(
        //        name: "Product_Category_Mapping");

        //    migrationBuilder.DropTable(
        //        name: "Product_Manufacturer_Mapping");

        //    migrationBuilder.DropTable(
        //        name: "Product_Picture_Mapping");

        //    migrationBuilder.DropTable(
        //        name: "Product_ProductTag_Mapping");

        //    migrationBuilder.DropTable(
        //        name: "Product_SpecificationAttribute_Mapping");

        //    migrationBuilder.DropTable(
        //        name: "ProductAttributeCombination");

        //    migrationBuilder.DropTable(
        //        name: "ProductAttributeValue");

        //    migrationBuilder.DropTable(
        //        name: "ProductAvailabilityRange");

        //    migrationBuilder.DropTable(
        //        name: "ProductReview_ReviewType_Mapping");

        //    migrationBuilder.DropTable(
        //        name: "ProductReviewHelpfulness");

        //    migrationBuilder.DropTable(
        //        name: "ProductTemplate");

        //    migrationBuilder.DropTable(
        //        name: "ProductWarehouseInventory");

        //    migrationBuilder.DropTable(
        //        name: "QueuedEmail");

        //    migrationBuilder.DropTable(
        //        name: "RecurringPaymentHistory");

        //    migrationBuilder.DropTable(
        //        name: "RelatedProduct");

        //    migrationBuilder.DropTable(
        //        name: "ReturnRequest");

        //    migrationBuilder.DropTable(
        //        name: "ReturnRequestAction");

        //    migrationBuilder.DropTable(
        //        name: "ReturnRequestReason");

        //    migrationBuilder.DropTable(
        //        name: "ScheduleTask");

        //    migrationBuilder.DropTable(
        //        name: "SearchTerm");

        //    migrationBuilder.DropTable(
        //        name: "Setting");

        //    migrationBuilder.DropTable(
        //        name: "ShipmentItem");

        //    migrationBuilder.DropTable(
        //        name: "ShippingMethodRestrictions");

        //    migrationBuilder.DropTable(
        //        name: "ShoppingCartItem");

        //    migrationBuilder.DropTable(
        //        name: "StockQuantityHistory");

        //    migrationBuilder.DropTable(
        //        name: "StoreMapping");

        //    migrationBuilder.DropTable(
        //        name: "TaxCategory");

        //    migrationBuilder.DropTable(
        //        name: "TierPrice");

        //    migrationBuilder.DropTable(
        //        name: "Topic");

        //    migrationBuilder.DropTable(
        //        name: "TopicTemplate");

        //    migrationBuilder.DropTable(
        //        name: "UrlRecord");

        //    migrationBuilder.DropTable(
        //        name: "VendorAttributeValue");

        //    migrationBuilder.DropTable(
        //        name: "VendorNote");

        //    migrationBuilder.DropTable(
        //        name: "ActivityLogType");

        //    migrationBuilder.DropTable(
        //        name: "AddressAttribute");

        //    migrationBuilder.DropTable(
        //        name: "BlogPost");

        //    migrationBuilder.DropTable(
        //        name: "CheckoutAttribute");

        //    migrationBuilder.DropTable(
        //        name: "CustomerAttribute");

        //    migrationBuilder.DropTable(
        //        name: "Discount");

        //    migrationBuilder.DropTable(
        //        name: "Forums_Post");

        //    migrationBuilder.DropTable(
        //        name: "GiftCard");

        //    migrationBuilder.DropTable(
        //        name: "News");

        //    migrationBuilder.DropTable(
        //        name: "PermissionRecord");

        //    migrationBuilder.DropTable(
        //        name: "PollAnswer");

        //    migrationBuilder.DropTable(
        //        name: "Category");

        //    migrationBuilder.DropTable(
        //        name: "Manufacturer");

        //    migrationBuilder.DropTable(
        //        name: "Picture");

        //    migrationBuilder.DropTable(
        //        name: "ProductTag");

        //    migrationBuilder.DropTable(
        //        name: "SpecificationAttributeOption");

        //    migrationBuilder.DropTable(
        //        name: "Product_ProductAttribute_Mapping");

        //    migrationBuilder.DropTable(
        //        name: "ReviewType");

        //    migrationBuilder.DropTable(
        //        name: "ProductReview");

        //    migrationBuilder.DropTable(
        //        name: "Warehouse");

        //    migrationBuilder.DropTable(
        //        name: "EmailAccount");

        //    migrationBuilder.DropTable(
        //        name: "RecurringPayment");

        //    migrationBuilder.DropTable(
        //        name: "Shipment");

        //    migrationBuilder.DropTable(
        //        name: "ShippingMethod");

        //    migrationBuilder.DropTable(
        //        name: "CustomerRole");

        //    migrationBuilder.DropTable(
        //        name: "VendorAttribute");

        //    migrationBuilder.DropTable(
        //        name: "Vendor");

        //    migrationBuilder.DropTable(
        //        name: "Forums_Topic");

        //    migrationBuilder.DropTable(
        //        name: "OrderItem");

        //    migrationBuilder.DropTable(
        //        name: "Poll");

        //    migrationBuilder.DropTable(
        //        name: "SpecificationAttribute");

        //    migrationBuilder.DropTable(
        //        name: "ProductAttribute");

        //    migrationBuilder.DropTable(
        //        name: "Store");

        //    migrationBuilder.DropTable(
        //        name: "Forums_Forum");

        //    migrationBuilder.DropTable(
        //        name: "Order");

        //    migrationBuilder.DropTable(
        //        name: "Product");

        //    migrationBuilder.DropTable(
        //        name: "Language");

        //    migrationBuilder.DropTable(
        //        name: "Forums_Group");

        //    migrationBuilder.DropTable(
        //        name: "RewardPointsHistory");

        //    migrationBuilder.DropTable(
        //        name: "Customer");

        //    migrationBuilder.DropTable(
        //        name: "Address");

        //    migrationBuilder.DropTable(
        //        name: "StateProvince");

        //    migrationBuilder.DropTable(
        //        name: "Country");
        }
    }
}
