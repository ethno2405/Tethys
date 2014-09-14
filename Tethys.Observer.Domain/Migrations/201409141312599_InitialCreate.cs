namespace Tethys.Observer.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Down()
        {
            DropForeignKey("dbo.Location", "Room_Id", "dbo.Room");
            DropForeignKey("dbo.Device", "Room_Id", "dbo.Room");
            DropForeignKey("dbo.Room", "Department_Id", "dbo.Department");
            DropIndex("dbo.Location", new[] { "Room_Id" });
            DropIndex("dbo.Device", new[] { "Room_Id" });
            DropIndex("dbo.Room", new[] { "Department_Id" });
            DropTable("dbo.Location");
            DropTable("dbo.Device");
            DropTable("dbo.Room");
            DropTable("dbo.Department");
        }

        public override void Up()
        {
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Room",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Department_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Department", t => t.Department_Id)
                .Index(t => t.Department_Id);

            CreateTable(
                "dbo.Device",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Room_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Room", t => t.Room_Id)
                .Index(t => t.Room_Id);

            CreateTable(
                "dbo.Location",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Room_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Room", t => t.Room_Id)
                .Index(t => t.Room_Id);
        }
    }
}