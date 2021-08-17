namespace Stateemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MOREREQUIRES : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RoleModels", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.RoleModels", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RoleModels", "Description", c => c.String());
            AlterColumn("dbo.RoleModels", "Name", c => c.String());
        }
    }
}
