namespace Tethys.Observer.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Ip_And_Mac_To_Device : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Device", "IpAddress", c => c.String());
            AddColumn("dbo.Device", "MacAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Device", "MacAddress");
            DropColumn("dbo.Device", "IpAddress");
        }
    }
}
