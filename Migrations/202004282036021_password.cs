namespace VendorsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class password : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vendors", "Password", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Vendors", "ConfirmPassword", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vendors", "ConfirmPassword");
            DropColumn("dbo.Vendors", "Password");
        }
    }
}
