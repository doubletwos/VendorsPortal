namespace VendorsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class errormessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vendors", "LoginErrorMsg", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vendors", "LoginErrorMsg");
        }
    }
}
