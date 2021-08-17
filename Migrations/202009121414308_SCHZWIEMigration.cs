namespace Stateemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SCHZWIEMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Favourites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FavouriteChampionId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChampionModels", t => t.FavouriteChampionId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.FavouriteChampionId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.ChampionModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        Name = c.String(),
                        Title = c.String(),
                        IconURL = c.String(),
                        Ranged = c.Boolean(nullable: false),
                        AttackDamage = c.String(),
                        Health = c.String(),
                        HealthRegen = c.String(),
                        Mana = c.String(),
                        ManaRegen = c.String(),
                        Armor = c.String(),
                        MagicResist = c.String(),
                        MovementSpeed = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RoleModels", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.RoleModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Favourites", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Favourites", "FavouriteChampionId", "dbo.ChampionModels");
            DropForeignKey("dbo.ChampionModels", "RoleId", "dbo.RoleModels");
            DropIndex("dbo.ChampionModels", new[] { "RoleId" });
            DropIndex("dbo.Favourites", new[] { "User_Id" });
            DropIndex("dbo.Favourites", new[] { "FavouriteChampionId" });
            DropTable("dbo.RoleModels");
            DropTable("dbo.ChampionModels");
            DropTable("dbo.Favourites");
        }
    }
}
