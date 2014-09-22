namespace Tethys.Observer.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Room_Location_Many_To_Many : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Location", "Room_Id", "dbo.Room");
            DropIndex("dbo.Location", new[] { "Room_Id" });
            CreateTable(
                "dbo.RoomLocation",
                c => new
                    {
                        Room_Id = c.Guid(nullable: false),
                        Location_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Room_Id, t.Location_Id })
                .ForeignKey("dbo.Room", t => t.Room_Id, cascadeDelete: true)
                .ForeignKey("dbo.Location", t => t.Location_Id, cascadeDelete: true)
                .Index(t => t.Room_Id)
                .Index(t => t.Location_Id);
            
            DropColumn("dbo.Location", "Room_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Location", "Room_Id", c => c.Guid());
            DropForeignKey("dbo.RoomLocation", "Location_Id", "dbo.Location");
            DropForeignKey("dbo.RoomLocation", "Room_Id", "dbo.Room");
            DropIndex("dbo.RoomLocation", new[] { "Location_Id" });
            DropIndex("dbo.RoomLocation", new[] { "Room_Id" });
            DropTable("dbo.RoomLocation");
            CreateIndex("dbo.Location", "Room_Id");
            AddForeignKey("dbo.Location", "Room_Id", "dbo.Room", "Id");
        }
    }
}
