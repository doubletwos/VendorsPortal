namespace VendorsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cleanslate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "AreaId", "dbo.Areas");
            DropForeignKey("dbo.AspNetUsers", "VendorTypeId", "dbo.VendorTypes");
            DropIndex("dbo.AspNetUsers", new[] { "VendorTypeId" });
            DropIndex("dbo.AspNetUsers", new[] { "AreaId" });
            DropColumn("dbo.AspNetUsers", "OrganisationName");
            DropColumn("dbo.AspNetUsers", "VendorTelephone");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "RegistrationDate");
            DropColumn("dbo.AspNetUsers", "VendorTypeId");
            DropColumn("dbo.AspNetUsers", "AreaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "AreaId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "VendorTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "RegistrationDate", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "VendorTelephone", c => c.String());
            AddColumn("dbo.AspNetUsers", "OrganisationName", c => c.String());
            CreateIndex("dbo.AspNetUsers", "AreaId");
            CreateIndex("dbo.AspNetUsers", "VendorTypeId");
            AddForeignKey("dbo.AspNetUsers", "VendorTypeId", "dbo.VendorTypes", "VendorTypeId", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", "AreaId", "dbo.Areas", "AreaId", cascadeDelete: true);
        }
    }
}
