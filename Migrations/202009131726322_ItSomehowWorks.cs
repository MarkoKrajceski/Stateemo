namespace Stateemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItSomehowWorks : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ChampionModels", "AttackDamage", c => c.String());
            AlterColumn("dbo.ChampionModels", "Health", c => c.String());
            AlterColumn("dbo.ChampionModels", "HealthRegen", c => c.String());
            AlterColumn("dbo.ChampionModels", "Mana", c => c.String());
            AlterColumn("dbo.ChampionModels", "ManaRegen", c => c.String());
            AlterColumn("dbo.ChampionModels", "Armor", c => c.String());
            AlterColumn("dbo.ChampionModels", "MagicResist", c => c.String());
            AlterColumn("dbo.ChampionModels", "MovementSpeed", c => c.String());
            AlterColumn("dbo.RoleModels", "Name", c => c.String());
            AlterColumn("dbo.RoleModels", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RoleModels", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.RoleModels", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.ChampionModels", "MovementSpeed", c => c.String(nullable: false));
            AlterColumn("dbo.ChampionModels", "MagicResist", c => c.String(nullable: false));
            AlterColumn("dbo.ChampionModels", "Armor", c => c.String(nullable: false));
            AlterColumn("dbo.ChampionModels", "ManaRegen", c => c.String(nullable: false));
            AlterColumn("dbo.ChampionModels", "Mana", c => c.String(nullable: false));
            AlterColumn("dbo.ChampionModels", "HealthRegen", c => c.String(nullable: false));
            AlterColumn("dbo.ChampionModels", "Health", c => c.String(nullable: false));
            AlterColumn("dbo.ChampionModels", "AttackDamage", c => c.String(nullable: false));
        }
    }
}
