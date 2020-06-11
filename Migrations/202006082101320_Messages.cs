namespace VendorsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Messages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        SendersEmail = c.String(),
                        DateReceived = c.DateTime(),
                        ContactFirstName = c.String(nullable: false),
                        ContactLastName = c.String(nullable: false),
                        VendorId = c.Int(nullable: false),
                        MessageReceived = c.String(nullable: false),
                        MessageSent = c.String(),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.Vendors", t => t.VendorId, cascadeDelete: true)
                .Index(t => t.VendorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "VendorId", "dbo.Vendors");
            DropIndex("dbo.Messages", new[] { "VendorId" });
            DropTable("dbo.Messages");
        }
    }
}
