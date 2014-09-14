namespace Tethys.Observer.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Required_fields : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Room", "Department_Id", "dbo.Department");
            DropForeignKey("dbo.Device", "Room_Id", "dbo.Room");
            DropForeignKey("dbo.Location", "Room_Id", "dbo.Room");
            DropIndex("dbo.Room", new[] { "Department_Id" });
            DropIndex("dbo.Device", new[] { "Room_Id" });
            DropIndex("dbo.Location", new[] { "Room_Id" });
            AlterColumn("dbo.Department", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Room", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Room", "Department_Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Device", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Device", "Room_Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Location", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Location", "Room_Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.User", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.User", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Login", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Role", c => c.String(nullable: false));
            CreateIndex("dbo.Room", "Department_Id");
            CreateIndex("dbo.Device", "Room_Id");
            CreateIndex("dbo.Location", "Room_Id");
            AddForeignKey("dbo.Room", "Department_Id", "dbo.Department", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Device", "Room_Id", "dbo.Room", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Location", "Room_Id", "dbo.Room", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Location", "Room_Id", "dbo.Room");
            DropForeignKey("dbo.Device", "Room_Id", "dbo.Room");
            DropForeignKey("dbo.Room", "Department_Id", "dbo.Department");
            DropIndex("dbo.Location", new[] { "Room_Id" });
            DropIndex("dbo.Device", new[] { "Room_Id" });
            DropIndex("dbo.Room", new[] { "Department_Id" });
            AlterColumn("dbo.User", "Role", c => c.String());
            AlterColumn("dbo.User", "Password", c => c.String());
            AlterColumn("dbo.User", "Login", c => c.String());
            AlterColumn("dbo.User", "LastName", c => c.String());
            AlterColumn("dbo.User", "FirstName", c => c.String());
            AlterColumn("dbo.Location", "Room_Id", c => c.Guid());
            AlterColumn("dbo.Location", "Name", c => c.String());
            AlterColumn("dbo.Device", "Room_Id", c => c.Guid());
            AlterColumn("dbo.Device", "Name", c => c.String());
            AlterColumn("dbo.Room", "Department_Id", c => c.Guid());
            AlterColumn("dbo.Room", "Name", c => c.String());
            AlterColumn("dbo.Department", "Name", c => c.String());
            CreateIndex("dbo.Location", "Room_Id");
            CreateIndex("dbo.Device", "Room_Id");
            CreateIndex("dbo.Room", "Department_Id");
            AddForeignKey("dbo.Location", "Room_Id", "dbo.Room", "Id");
            AddForeignKey("dbo.Device", "Room_Id", "dbo.Room", "Id");
            AddForeignKey("dbo.Room", "Department_Id", "dbo.Department", "Id");
        }
    }
}
