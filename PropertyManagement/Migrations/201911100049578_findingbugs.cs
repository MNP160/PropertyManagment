namespace PropertyManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class findingbugs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HouseSales", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.HouseSales", "StartDate");
            DropColumn("dbo.HouseSales", "ScheduledEndDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HouseSales", "ScheduledEndDate", c => c.DateTime());
            AddColumn("dbo.HouseSales", "StartDate", c => c.DateTime());
            DropColumn("dbo.HouseSales", "Status");
        }
    }
}
