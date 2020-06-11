namespace VendorsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1919 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QuotesProvideds", "BookingId", "dbo.Bookings");
            DropIndex("dbo.QuotesProvideds", new[] { "BookingId" });
            AddColumn("dbo.Bookings", "QuotesProvided_QuoteId", c => c.Int());
            CreateIndex("dbo.Bookings", "QuotesProvided_QuoteId");
            AddForeignKey("dbo.Bookings", "QuotesProvided_QuoteId", "dbo.QuotesProvideds", "QuoteId");
            DropColumn("dbo.QuotesProvideds", "BookingId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.QuotesProvideds", "BookingId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Bookings", "QuotesProvided_QuoteId", "dbo.QuotesProvideds");
            DropIndex("dbo.Bookings", new[] { "QuotesProvided_QuoteId" });
            DropColumn("dbo.Bookings", "QuotesProvided_QuoteId");
            CreateIndex("dbo.QuotesProvideds", "BookingId");
            AddForeignKey("dbo.QuotesProvideds", "BookingId", "dbo.Bookings", "BookingId", cascadeDelete: true);
        }
    }
}
