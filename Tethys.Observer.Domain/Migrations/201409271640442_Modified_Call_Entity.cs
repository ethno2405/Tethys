namespace Tethys.Observer.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modified_Call_Entity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Call", "Department", c => c.String(nullable: false));
            AddColumn("dbo.Call", "Device", c => c.String(nullable: false));
            AddColumn("dbo.Call", "IpAddress", c => c.String());
            AddColumn("dbo.Call", "Location", c => c.String(nullable: false));
            AddColumn("dbo.Call", "MacAddress", c => c.String());
            AddColumn("dbo.Call", "Room", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Call", "Room");
            DropColumn("dbo.Call", "MacAddress");
            DropColumn("dbo.Call", "Location");
            DropColumn("dbo.Call", "IpAddress");
            DropColumn("dbo.Call", "Device");
            DropColumn("dbo.Call", "Department");
        }
    }
}
