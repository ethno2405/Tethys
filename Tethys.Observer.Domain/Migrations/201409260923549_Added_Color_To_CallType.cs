namespace Tethys.Observer.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Color_To_CallType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CallType", "Color", c => c.String(maxLength: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CallType", "Color", c => c.String());
        }
    }
}
