namespace PropertyManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HouseRents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false),
                        BookId = c.Int(nullable: false),
                        StartDate = c.DateTime(),
                        ScheduledEndDate = c.DateTime(),
                        RentalPrice = c.Double(nullable: false),
                        RentalDuration = c.String(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Houses", "Description", c => c.String(nullable: false));
            AddColumn("dbo.Houses", "ExtraInformation", c => c.String(nullable: false));
            AddColumn("dbo.House1", "Description", c => c.String(nullable: false));
            AddColumn("dbo.House1", "ExtraInformation", c => c.String(nullable: false));
            DropColumn("dbo.Houses", "ISBN");
           
            DropColumn("dbo.Houses", "Owner");
            DropColumn("dbo.House1", "ISBN");
            DropColumn("dbo.House1", "Owner");
            
            DropColumn("dbo.AspNetUsers", "RentalCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "RentalCount", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "MembershipTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.House1", "Owner", c => c.String(nullable: false));
            AddColumn("dbo.House1", "ISBN", c => c.String(nullable: false));
            AddColumn("dbo.Houses", "Owner", c => c.String(nullable: false));
            AddColumn("dbo.Houses", "RentalPrice", c => c.Double(nullable: false));
            AddColumn("dbo.Houses", "ISBN", c => c.String(nullable: false));
            DropColumn("dbo.House1", "ExtraInformation");
            DropColumn("dbo.House1", "Description");
            DropColumn("dbo.Houses", "ExtraInformation");
            DropColumn("dbo.Houses", "Description");
            DropTable("dbo.HouseRents");
        }
    }
}
