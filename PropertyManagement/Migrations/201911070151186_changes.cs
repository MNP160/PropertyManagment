namespace PropertyManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Houses", "Description", c => c.String(nullable: false));
            AddColumn("dbo.House1", "Description", c => c.String(nullable: false));
            DropColumn("dbo.Houses", "ISBN");
           
            DropColumn("dbo.House1", "ISBN");
        }
        
        public override void Down()
        {
            AddColumn("dbo.House1", "ISBN", c => c.String(nullable: false));
          
            AddColumn("dbo.Houses", "ISBN", c => c.String(nullable: false));
            DropColumn("dbo.House1", "Description");
            DropColumn("dbo.Houses", "Description");
        }
    }
}
