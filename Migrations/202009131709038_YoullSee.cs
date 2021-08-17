namespace Stateemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class YoullSee : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ChampionModels", "Name", c => c.String());
            AlterColumn("dbo.ChampionModels", "Title", c => c.String());
            AlterColumn("dbo.ChampionModels", "IconURL", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ChampionModels", "IconURL", c => c.String(nullable: false));
            AlterColumn("dbo.ChampionModels", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.ChampionModels", "Name", c => c.String(nullable: false));
        }
    }
}
