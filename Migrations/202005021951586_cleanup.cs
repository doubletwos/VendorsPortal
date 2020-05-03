namespace VendorsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cleanup : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.VendorAreas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.VendorAreas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VendorAreaName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
