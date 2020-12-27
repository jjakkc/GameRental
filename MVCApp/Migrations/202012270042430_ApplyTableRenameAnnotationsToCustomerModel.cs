namespace MVCApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyTableRenameAnnotationsToCustomerModel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CustomerModels", newName: "dbo.Customers");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Customers", newName: "CustomerModels");
        }
    }
}
