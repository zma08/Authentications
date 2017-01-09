namespace FormAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shippingInfoAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ShippingAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ShippingAddress");
        }
    }
}
