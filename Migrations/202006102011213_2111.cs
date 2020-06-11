namespace VendorsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2111 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "AdditionalInformation", c => c.String());
            AddColumn("dbo.Bookings", "Quote_QuoteId", c => c.Int());
            CreateIndex("dbo.Bookings", "Quote_QuoteId");
            AddForeignKey("dbo.Bookings", "Quote_QuoteId", "dbo.Quotes", "QuoteId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "Quote_QuoteId", "dbo.Quotes");
            DropIndex("dbo.Bookings", new[] { "Quote_QuoteId" });
            DropColumn("dbo.Bookings", "Quote_QuoteId");
            DropColumn("dbo.Bookings", "AdditionalInformation");
        }
    }
}
