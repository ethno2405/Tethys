namespace Tethys.Observer.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Location_Name : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Location", "Name", c => c.String(nullable: false, maxLength: 20));
            CreateIndex("dbo.Location", "Name", name: "IX_Location_Name");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Location", "IX_Location_Name");
            AlterColumn("dbo.Location", "Name", c => c.String(nullable: false));
        }
    }
}
