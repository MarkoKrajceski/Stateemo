namespace Stateemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserIdToString : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.FavouriteModels", new[] { "User_Id" });
            DropColumn("dbo.FavouriteModels", "UserId");
            RenameColumn(table: "dbo.FavouriteModels", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.FavouriteModels", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.FavouriteModels", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.FavouriteModels", new[] { "UserId" });
            AlterColumn("dbo.FavouriteModels", "UserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.FavouriteModels", name: "UserId", newName: "User_Id");
            AddColumn("dbo.FavouriteModels", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.FavouriteModels", "User_Id");
        }
    }
}
