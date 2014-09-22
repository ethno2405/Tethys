namespace Tethys.Observer.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Department_Name : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Department", "Name", c => c.String(nullable: false, maxLength: 20));
            CreateIndex("dbo.Department", "Name", unique: true, name: "IX_DeparatmentName_Unique");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Department", "IX_DeparatmentName_Unique");
            AlterColumn("dbo.Department", "Name", c => c.String(nullable: false));
        }
    }
}
