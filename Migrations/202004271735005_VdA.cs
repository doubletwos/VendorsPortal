namespace VendorsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VdA : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VendorAreas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VendorAreaName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "VendorAreasId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "VendorAreasId");
            AddForeignKey("dbo.AspNetUsers", "VendorAreasId", "dbo.VendorAreas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "VendorAreasId", "dbo.VendorAreas");
            DropIndex("dbo.AspNetUsers", new[] { "VendorAreasId" });
            DropColumn("dbo.AspNetUsers", "VendorAreasId");
            DropTable("dbo.VendorAreas");
        }
    }
}
