namespace PropertyManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class house1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.House1",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        NumberOfRooms = c.Int(nullable: false),
                        NumberOfBathrooms = c.Int(nullable: false),
                        NumberOfBedrooms = c.Int(nullable: false),
                        ImageUrl = c.String(nullable: false),
                        Avaibility = c.Int(nullable: false),
                        RentalPrice = c.Double(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        Owner = c.String(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.House1");
        }
    }
}
