namespace Tethys.Observer.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Room_Department_Not_Required : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Room", "Department_Id", "dbo.Department");
            DropIndex("dbo.Room", new[] { "Department_Id" });
            AlterColumn("dbo.Room", "Department_Id", c => c.Guid());
            CreateIndex("dbo.Room", "Department_Id");
            AddForeignKey("dbo.Room", "Department_Id", "dbo.Department", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Room", "Department_Id", "dbo.Department");
            DropIndex("dbo.Room", new[] { "Department_Id" });
            AlterColumn("dbo.Room", "Department_Id", c => c.Guid(nullable: false));
            CreateIndex("dbo.Room", "Department_Id");
            AddForeignKey("dbo.Room", "Department_Id", "dbo.Department", "Id", cascadeDelete: true);
        }
    }
}
