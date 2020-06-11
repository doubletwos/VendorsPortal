namespace VendorsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1908 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Quotes", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Quotes", "Email", c => c.String(nullable: false, maxLength: 15));
        }
    }
}
