namespace Stateemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MAKEEVERYTHINGREQUIRED : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ChampionModels", "AttackDamage", c => c.String(nullable: false));
            AlterColumn("dbo.ChampionModels", "Health", c => c.String(nullable: false));
            AlterColumn("dbo.ChampionModels", "HealthRegen", c => c.String(nullable: false));
            AlterColumn("dbo.ChampionModels", "Mana", c => c.String(nullable: false));
            AlterColumn("dbo.ChampionModels", "ManaRegen", c => c.String(nullable: false));
            AlterColumn("dbo.ChampionModels", "Armor", c => c.String(nullable: false));
            AlterColumn("dbo.ChampionModels", "MagicResist", c => c.String(nullable: false));
            AlterColumn("dbo.ChampionModels", "MovementSpeed", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ChampionModels", "MovementSpeed", c => c.String());
            AlterColumn("dbo.ChampionModels", "MagicResist", c => c.String());
            AlterColumn("dbo.ChampionModels", "Armor", c => c.String());
            AlterColumn("dbo.ChampionModels", "ManaRegen", c => c.String());
            AlterColumn("dbo.ChampionModels", "Mana", c => c.String());
            AlterColumn("dbo.ChampionModels", "HealthRegen", c => c.String());
            AlterColumn("dbo.ChampionModels", "Health", c => c.String());
            AlterColumn("dbo.ChampionModels", "AttackDamage", c => c.String());
        }
    }
}
