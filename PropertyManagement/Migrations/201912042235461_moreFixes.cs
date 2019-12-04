namespace PropertyManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moreFixes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Houses", "Sold", c => c.Boolean(nullable: false));
            DropColumn("dbo.Houses", "Rented");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Houses", "Rented", c => c.Boolean(nullable: false));
            DropColumn("dbo.Houses", "Sold");
        }
    }
}
