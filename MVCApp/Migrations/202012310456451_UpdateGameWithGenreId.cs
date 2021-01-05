namespace MVCApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateGameWithGenreId : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.GameModels", "GenreId", c => c.Byte(nullable: false));
            CreateIndex("dbo.GameModels", "GenreId");
            AddForeignKey("dbo.GameModels", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
            DropColumn("dbo.GameModels", "Genre_Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GameModels", "Genre_Name", c => c.String());
            DropForeignKey("dbo.GameModels", "GenreId", "dbo.Genres");
            DropIndex("dbo.GameModels", new[] { "GenreId" });
            DropColumn("dbo.GameModels", "GenreId");
            DropTable("dbo.Genres");
        }
    }
}
