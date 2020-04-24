namespace VendorsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Area : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        AreaId = c.Int(nullable: false, identity: true),
                        AreaName = c.String(),
                    })
                .PrimaryKey(t => t.AreaId);
            
            AddColumn("dbo.Vendors", "AreaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Vendors", "AreaId");
            AddForeignKey("dbo.Vendors", "AreaId", "dbo.Areas", "AreaId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vendors", "AreaId", "dbo.Areas");
            DropIndex("dbo.Vendors", new[] { "AreaId" });
            DropColumn("dbo.Vendors", "AreaId");
            DropTable("dbo.Areas");
        }
    }
}
