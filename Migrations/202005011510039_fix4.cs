namespace VendorsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "VendorAreasId", "dbo.VendorAreas");
            DropIndex("dbo.AspNetUsers", new[] { "VendorAreasId" });
            DropColumn("dbo.AspNetUsers", "VendorAreasId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "VendorAreasId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "VendorAreasId");
            AddForeignKey("dbo.AspNetUsers", "VendorAreasId", "dbo.VendorAreas", "Id", cascadeDelete: true);
        }
    }
}
