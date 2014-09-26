namespace Tethys.Observer.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Added_IsLocalized_Property_To_Device : DbMigration
    {
        public override void Down()
        {
            DropColumn("dbo.Device", "IsLocalized");
        }

        public override void Up()
        {
            AddColumn("dbo.Device", "IsLocalized", c => c.Boolean(nullable: false, defaultValue: false));
        }
    }
}