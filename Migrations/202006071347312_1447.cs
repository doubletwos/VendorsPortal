namespace VendorsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1447 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Quotes", "FirstName", c => c.String(nullable: false, maxLength: 14));
            AlterColumn("dbo.Quotes", "LastName", c => c.String(nullable: false, maxLength: 14));
            AlterColumn("dbo.Quotes", "Telephone", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.Quotes", "Email", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Quotes", "EventType", c => c.String(nullable: false, maxLength: 12));
            AlterColumn("dbo.Quotes", "BriefDescription", c => c.String(maxLength: 40));
            DropColumn("dbo.Quotes", "Budget");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Quotes", "Budget", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Quotes", "BriefDescription", c => c.String());
            AlterColumn("dbo.Quotes", "EventType", c => c.String());
            AlterColumn("dbo.Quotes", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Quotes", "Telephone", c => c.String(nullable: false));
            AlterColumn("dbo.Quotes", "LastName", c => c.String());
            AlterColumn("dbo.Quotes", "FirstName", c => c.String());
        }
    }
}
