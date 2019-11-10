namespace PropertyManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ch : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HouseRents", "HouseId", c => c.Int(nullable: false));
            DropColumn("dbo.HouseRents", "BookId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HouseRents", "BookId", c => c.Int(nullable: false));
            DropColumn("dbo.HouseRents", "HouseId");
        }
    }
}
