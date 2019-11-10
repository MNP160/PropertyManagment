namespace PropertyManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.House1", "RentalDuration");
        }
        
        public override void Down()
        {
            AddColumn("dbo.House1", "RentalDuration", c => c.String(nullable: false));
        }
    }
}
