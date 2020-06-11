namespace VendorsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1646 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "MessageReceived", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Messages", "MessageSent", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "MessageSent", c => c.String());
            AlterColumn("dbo.Messages", "MessageReceived", c => c.String(nullable: false));
        }
    }
}
