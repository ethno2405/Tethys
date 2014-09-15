namespace Tethys.Observer.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Calls_And_Call_types : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Call",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        Type_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CallType", t => t.Type_Id)
                .Index(t => t.Type_Id);
            
            CreateTable(
                "dbo.CallType",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Call", "Type_Id", "dbo.CallType");
            DropIndex("dbo.Call", new[] { "Type_Id" });
            DropTable("dbo.CallType");
            DropTable("dbo.Call");
        }
    }
}
