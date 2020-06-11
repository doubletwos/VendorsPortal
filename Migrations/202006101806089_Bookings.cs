namespace VendorsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Bookings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Telephone = c.String(),
                        Email = c.String(),
                        EventType = c.String(),
                        EventDate = c.DateTime(),
                        BookingDate = c.DateTime(),
                        Price = c.Double(),
                        IsBooked = c.Boolean(),
                        Vendor_VendorId = c.Int(),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.Vendors", t => t.Vendor_VendorId)
                .Index(t => t.Vendor_VendorId);
            
            AddColumn("dbo.QuotesProvideds", "BookingId", c => c.Int(nullable: false));
            CreateIndex("dbo.QuotesProvideds", "BookingId");
            AddForeignKey("dbo.QuotesProvideds", "BookingId", "dbo.Bookings", "BookingId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuotesProvideds", "BookingId", "dbo.Bookings");
            DropForeignKey("dbo.Bookings", "Vendor_VendorId", "dbo.Vendors");
            DropIndex("dbo.QuotesProvideds", new[] { "BookingId" });
            DropIndex("dbo.Bookings", new[] { "Vendor_VendorId" });
            DropColumn("dbo.QuotesProvideds", "BookingId");
            DropTable("dbo.Bookings");
        }
    }
}
