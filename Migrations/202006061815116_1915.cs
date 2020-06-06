namespace VendorsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1915 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QuotesProvideds", "QuoteId", "dbo.Quotes");
            DropIndex("dbo.QuotesProvideds", new[] { "QuoteId" });
            DropTable("dbo.QuotesProvideds");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.QuotesProvideds",
                c => new
                    {
                        QuoteId = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        AdditionalInformation = c.String(),
                    })
                .PrimaryKey(t => t.QuoteId);
            
            CreateIndex("dbo.QuotesProvideds", "QuoteId");
            AddForeignKey("dbo.QuotesProvideds", "QuoteId", "dbo.Quotes", "QuoteId");
        }
    }
}
