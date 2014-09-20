namespace Tethys.Observer.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updated_Device_And_Location : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Location", "Room_Id", "dbo.Room");
            DropIndex("dbo.Location", new[] { "Room_Id" });
            AddColumn("dbo.Device", "Location_Id", c => c.Guid());
            AlterColumn("dbo.Location", "Room_Id", c => c.Guid());
            CreateIndex("dbo.Device", "Location_Id");
            CreateIndex("dbo.Location", "Room_Id");
            AddForeignKey("dbo.Device", "Location_Id", "dbo.Location", "Id");
            AddForeignKey("dbo.Location", "Room_Id", "dbo.Room", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Location", "Room_Id", "dbo.Room");
            DropForeignKey("dbo.Device", "Location_Id", "dbo.Location");
            DropIndex("dbo.Location", new[] { "Room_Id" });
            DropIndex("dbo.Device", new[] { "Location_Id" });
            AlterColumn("dbo.Location", "Room_Id", c => c.Guid(nullable: false));
            DropColumn("dbo.Device", "Location_Id");
            CreateIndex("dbo.Location", "Room_Id");
            AddForeignKey("dbo.Location", "Room_Id", "dbo.Room", "Id", cascadeDelete: true);
        }
    }
}
