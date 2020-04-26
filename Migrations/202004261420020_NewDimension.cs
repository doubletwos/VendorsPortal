namespace VendorsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewDimension : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "OrganisationName", c => c.String());
            AddColumn("dbo.AspNetUsers", "VendorTelephone", c => c.String());
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "RegistrationDate", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "VendorTypeId", c => c.Int(nullable:true));
            AddColumn("dbo.AspNetUsers", "AreaId", c => c.Int(nullable: true));
            CreateIndex("dbo.AspNetUsers", "VendorTypeId");
            CreateIndex("dbo.AspNetUsers", "AreaId");
            AddForeignKey("dbo.AspNetUsers", "AreaId", "dbo.Areas", "AreaId", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", "VendorTypeId", "dbo.VendorTypes", "VendorTypeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "VendorTypeId", "dbo.VendorTypes");
            DropForeignKey("dbo.AspNetUsers", "AreaId", "dbo.Areas");
            DropIndex("dbo.AspNetUsers", new[] { "AreaId" });
            DropIndex("dbo.AspNetUsers", new[] { "VendorTypeId" });
            DropColumn("dbo.AspNetUsers", "AreaId");
            DropColumn("dbo.AspNetUsers", "VendorTypeId");
            DropColumn("dbo.AspNetUsers", "RegistrationDate");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetUsers", "VendorTelephone");
            DropColumn("dbo.AspNetUsers", "OrganisationName");
        }
    }
}
