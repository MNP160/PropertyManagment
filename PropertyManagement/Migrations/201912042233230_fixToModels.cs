namespace PropertyManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixToModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Houses", "Rented", c => c.Boolean(nullable: false));
            AddColumn("dbo.House1", "Rented", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.House1", "Rented");
            DropColumn("dbo.Houses", "Rented");
        }
    }
}
