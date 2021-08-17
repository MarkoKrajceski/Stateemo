namespace Stateemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlmostDone : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ChampionModels", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.ChampionModels", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.ChampionModels", "IconURL", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ChampionModels", "IconURL", c => c.String());
            AlterColumn("dbo.ChampionModels", "Title", c => c.String());
            AlterColumn("dbo.ChampionModels", "Name", c => c.String());
        }
    }
}
