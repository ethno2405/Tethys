namespace Tethys.Observer.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Added_Role_Entity : DbMigration
    {
        public override void Down()
        {
            AddColumn("dbo.User", "Role", c => c.String(nullable: false));
            DropForeignKey("dbo.User", "Role_Id", "dbo.Role");
            DropIndex("dbo.User", new[] { "Role_Id" });
            DropColumn("dbo.User", "Role_Id");
            DropTable("dbo.Role");
        }

        public override void Up()
        {
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.User", "Role_Id", c => c.Guid(nullable: false));
            CreateIndex("dbo.User", "Role_Id");
            AddForeignKey("dbo.User", "Role_Id", "dbo.Role", "Id", cascadeDelete: false);
            DropColumn("dbo.User", "Role");
        }
    }
}