namespace PropertyManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HouseSaleDetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HouseSales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false),
                        HouseId = c.Int(nullable: false),
                        StartDate = c.DateTime(),
                        ScheduledEndDate = c.DateTime(),
                        SalePrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.HouseRents", "RentalDuration");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HouseRents", "RentalDuration", c => c.String(nullable: false));
            DropTable("dbo.HouseSales");
        }
    }
}
