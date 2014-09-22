namespace Tethys.Observer.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Unique_Room_For_Department : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Room", "IX_Unique_Department_Room");
            AlterColumn("dbo.Room", "Name", c => c.String(nullable: false, maxLength: 20));
            CreateIndex("dbo.Room", new[] { "Department_Id", "Name" }, unique: true, name: "IX_Unique_Department_Room");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Room", "IX_Unique_Department_Room");
            AlterColumn("dbo.Room", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.Room", "Department_Id", unique: true, name: "IX_Unique_Department_Room");
        }
    }
}
