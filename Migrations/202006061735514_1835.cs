namespace VendorsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1835 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.QuotesProvideds", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.QuotesProvideds", "Price", c => c.Double());
        }
    }
}
