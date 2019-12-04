namespace PropertyManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class offers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OffersForSales",
                c => new
                    {
                        OfferId = c.Int(nullable: false, identity: true),
                        OfferAmount = c.Double(nullable: false),
                        Accepted = c.Boolean(nullable: false),
                        userId = c.String(maxLength: 128),
                        Id = c.Int(),
                    })
                .PrimaryKey(t => t.OfferId)
                .ForeignKey("dbo.Houses", t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.userId)
                .Index(t => t.userId)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.OffersForRents",
                c => new
                    {
                        OfferId = c.Int(nullable: false, identity: true),
                        OfferAmount = c.Double(nullable: false),
                        Accepted = c.Boolean(nullable: false),
                        userId = c.String(maxLength: 128),
                        Id = c.Int(),
                    })
                .PrimaryKey(t => t.OfferId)
                .ForeignKey("dbo.House1", t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.userId)
                .Index(t => t.userId)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OffersForSales", "userId", "dbo.AspNetUsers");
            DropForeignKey("dbo.OffersForRents", "userId", "dbo.AspNetUsers");
            DropForeignKey("dbo.OffersForRents", "Id", "dbo.House1");
            DropForeignKey("dbo.OffersForSales", "Id", "dbo.Houses");
            DropIndex("dbo.OffersForRents", new[] { "Id" });
            DropIndex("dbo.OffersForRents", new[] { "userId" });
            DropIndex("dbo.OffersForSales", new[] { "Id" });
            DropIndex("dbo.OffersForSales", new[] { "userId" });
            DropTable("dbo.OffersForRents");
            DropTable("dbo.OffersForSales");
        }
    }
}
