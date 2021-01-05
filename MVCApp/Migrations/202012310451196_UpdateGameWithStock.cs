namespace MVCApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateGameWithStock : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameModels", "Genre_Name", c => c.String());
            AddColumn("dbo.GameModels", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.GameModels", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.GameModels", "AvailableStock", c => c.Int(nullable: false));
            AlterColumn("dbo.GameModels", "Title", c => c.String(nullable: false));
            DropColumn("dbo.GameModels", "Genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GameModels", "Genre", c => c.String());
            AlterColumn("dbo.GameModels", "Title", c => c.String());
            DropColumn("dbo.GameModels", "AvailableStock");
            DropColumn("dbo.GameModels", "DateAdded");
            DropColumn("dbo.GameModels", "ReleaseDate");
            DropColumn("dbo.GameModels", "Genre_Name");
        }
    }
}
