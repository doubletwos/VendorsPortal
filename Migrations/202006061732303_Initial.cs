namespace VendorsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Areas",
            //    c => new
            //        {
            //            AreaId = c.Int(nullable: false, identity: true),
            //            AreaName = c.String(),
            //        })
            //    .PrimaryKey(t => t.AreaId);
            
            //CreateTable(
            //    "dbo.Files",
            //    c => new
            //        {
            //            FileId = c.Int(nullable: false, identity: true),
            //            FileName = c.String(maxLength: 255),
            //            FileType = c.Int(nullable: false),
            //            ContentType = c.String(maxLength: 100),
            //            Content = c.Binary(),
            //            VendorId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.FileId)
            //    .ForeignKey("dbo.Vendors", t => t.VendorId, cascadeDelete: true)
            //    .Index(t => t.VendorId);
            
            //CreateTable(
            //    "dbo.Vendors",
            //    c => new
            //        {
            //            VendorId = c.Int(nullable: false, identity: true),
            //            VendorName = c.String(nullable: false),
            //            Email = c.String(nullable: false),
            //            Password = c.String(nullable: false, maxLength: 100),
            //            ConfirmPassword = c.String(),
            //            VendorMobile = c.String(),
            //            VendorTelephone = c.String(nullable: false),
            //            ContactFirstName = c.String(nullable: false),
            //            ContactLastName = c.String(nullable: false),
            //            RegistrationDate = c.DateTime(),
            //            VendorTypeId = c.Int(nullable: false),
            //            AreaId = c.Int(nullable: false),
            //            LoginErrorMsg = c.String(),
            //        })
            //    .PrimaryKey(t => t.VendorId)
            //    .ForeignKey("dbo.Areas", t => t.AreaId, cascadeDelete: true)
            //    .ForeignKey("dbo.VendorTypes", t => t.VendorTypeId, cascadeDelete: true)
            //    .Index(t => t.VendorTypeId)
            //    .Index(t => t.AreaId);
            
            //CreateTable(
            //    "dbo.Quotes",
            //    c => new
            //        {
            //            QuoteId = c.Int(nullable: false, identity: true),
            //            FirstName = c.String(),
            //            LastName = c.String(),
            //            Telephone = c.String(nullable: false),
            //            Email = c.String(nullable: false),
            //            EventType = c.String(),
            //            BriefDescription = c.String(),
            //            Budget = c.Boolean(nullable: false),
            //            EventDate = c.DateTime(),
            //            DateConfirmed = c.Boolean(nullable: false),
            //            VendorId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.QuoteId)
            //    .ForeignKey("dbo.Vendors", t => t.VendorId, cascadeDelete: true)
            //    .Index(t => t.VendorId);
            
            //CreateTable(
            //    "dbo.QuotesProvideds",
            //    c => new
            //        {
            //            QuoteId = c.Int(nullable: false),
            //            Price = c.Double(),
            //            AdditionalInformation = c.String(),
            //        })
            //    .PrimaryKey(t => t.QuoteId)
            //    .ForeignKey("dbo.Quotes", t => t.QuoteId)
            //    .Index(t => t.QuoteId);
            
            //CreateTable(
            //    "dbo.VendorTypes",
            //    c => new
            //        {
            //            VendorTypeId = c.Int(nullable: false, identity: true),
            //            VendorTypeName = c.String(),
            //        })
            //    .PrimaryKey(t => t.VendorTypeId);
            
            //CreateTable(
            //    "dbo.AspNetRoles",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            Name = c.String(nullable: false, maxLength: 256),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            //CreateTable(
            //    "dbo.AspNetUserRoles",
            //    c => new
            //        {
            //            UserId = c.String(nullable: false, maxLength: 128),
            //            RoleId = c.String(nullable: false, maxLength: 128),
            //        })
            //    .PrimaryKey(t => new { t.UserId, t.RoleId })
            //    .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
            //    .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
            //    .Index(t => t.UserId)
            //    .Index(t => t.RoleId);
            
            //CreateTable(
            //    "dbo.AspNetUsers",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            Email = c.String(maxLength: 256),
            //            EmailConfirmed = c.Boolean(nullable: false),
            //            PasswordHash = c.String(),
            //            SecurityStamp = c.String(),
            //            PhoneNumber = c.String(),
            //            PhoneNumberConfirmed = c.Boolean(nullable: false),
            //            TwoFactorEnabled = c.Boolean(nullable: false),
            //            LockoutEndDateUtc = c.DateTime(),
            //            LockoutEnabled = c.Boolean(nullable: false),
            //            AccessFailedCount = c.Int(nullable: false),
            //            UserName = c.String(nullable: false, maxLength: 256),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            //CreateTable(
            //    "dbo.AspNetUserClaims",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            UserId = c.String(nullable: false, maxLength: 128),
            //            ClaimType = c.String(),
            //            ClaimValue = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
            //    .Index(t => t.UserId);
            
            //CreateTable(
            //    "dbo.AspNetUserLogins",
            //    c => new
            //        {
            //            LoginProvider = c.String(nullable: false, maxLength: 128),
            //            ProviderKey = c.String(nullable: false, maxLength: 128),
            //            UserId = c.String(nullable: false, maxLength: 128),
            //        })
            //    .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
            //    .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
            //    .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Vendors", "VendorTypeId", "dbo.VendorTypes");
            DropForeignKey("dbo.Quotes", "VendorId", "dbo.Vendors");
            DropForeignKey("dbo.QuotesProvideds", "QuoteId", "dbo.Quotes");
            DropForeignKey("dbo.Files", "VendorId", "dbo.Vendors");
            DropForeignKey("dbo.Vendors", "AreaId", "dbo.Areas");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.QuotesProvideds", new[] { "QuoteId" });
            DropIndex("dbo.Quotes", new[] { "VendorId" });
            DropIndex("dbo.Vendors", new[] { "AreaId" });
            DropIndex("dbo.Vendors", new[] { "VendorTypeId" });
            DropIndex("dbo.Files", new[] { "VendorId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.VendorTypes");
            DropTable("dbo.QuotesProvideds");
            DropTable("dbo.Quotes");
            DropTable("dbo.Vendors");
            DropTable("dbo.Files");
            DropTable("dbo.Areas");
        }
    }
}
