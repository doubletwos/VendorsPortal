namespace VendorsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2241 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "Quote_QuoteId", "dbo.Quotes");
            DropForeignKey("dbo.Bookings", "QuotesProvided_QuoteId", "dbo.QuotesProvideds");
            DropIndex("dbo.Bookings", new[] { "Quote_QuoteId" });
            DropIndex("dbo.Bookings", new[] { "QuotesProvided_QuoteId" });
            RenameColumn(table: "dbo.Bookings", name: "QuotesProvided_QuoteId", newName: "QuoteId");
            AlterColumn("dbo.Bookings", "QuoteId", c => c.Int(nullable: false));
            CreateIndex("dbo.Bookings", "QuoteId");
            AddForeignKey("dbo.Bookings", "QuoteId", "dbo.QuotesProvideds", "QuoteId", cascadeDelete: true);
            DropColumn("dbo.Bookings", "Quote_QuoteId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "Quote_QuoteId", c => c.Int());
            DropForeignKey("dbo.Bookings", "QuoteId", "dbo.QuotesProvideds");
            DropIndex("dbo.Bookings", new[] { "QuoteId" });
            AlterColumn("dbo.Bookings", "QuoteId", c => c.Int());
            RenameColumn(table: "dbo.Bookings", name: "QuoteId", newName: "QuotesProvided_QuoteId");
            CreateIndex("dbo.Bookings", "QuotesProvided_QuoteId");
            CreateIndex("dbo.Bookings", "Quote_QuoteId");
            AddForeignKey("dbo.Bookings", "QuotesProvided_QuoteId", "dbo.QuotesProvideds", "QuoteId");
            AddForeignKey("dbo.Bookings", "Quote_QuoteId", "dbo.Quotes", "QuoteId");
        }
    }
}
