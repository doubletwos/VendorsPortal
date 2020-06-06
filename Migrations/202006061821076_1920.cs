namespace VendorsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1920 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuotesProvideds",
                c => new
                    {
                        QuoteId = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        AdditionalInformation = c.String(),
                    })
                .PrimaryKey(t => t.QuoteId)
                .ForeignKey("dbo.Quotes", t => t.QuoteId)
                .Index(t => t.QuoteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuotesProvideds", "QuoteId", "dbo.Quotes");
            DropIndex("dbo.QuotesProvideds", new[] { "QuoteId" });
            DropTable("dbo.QuotesProvideds");
        }
    }
}
