namespace PropertyManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class morechanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.House1", "RentalDuration", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.House1", "RentalDuration");
        }
    }
}
