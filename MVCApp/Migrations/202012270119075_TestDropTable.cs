namespace MVCApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestDropTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerModels",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    FirstName = c.String(),
                    LastName = c.String(),
                })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.CustomerModels", "IsSubscribedToNewsletter", c => c.Boolean(nullable: false));
            AddColumn("dbo.CustomerModels", "MembershipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.CustomerModels", "MembershipTypeId");
            AddForeignKey("dbo.CustomerModels", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);

            CreateTable(
                "dbo.GameModels",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Title = c.String(),
                    Genre = c.String(),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.GameModels");
            DropTable("dbo.CustomerModels");
            DropColumn("dbo.CustomerModels", "IsSubscribedToNewsletter");
            DropForeignKey("dbo.CustomerModels", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.CustomerModels", new[] { "MembershipTypeId" });
            DropColumn("dbo.CustomerModels", "MembershipTypeId");
        }
    }
}
