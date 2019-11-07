namespace PropertyManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedMigration : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[UserTypes]([Name],[SignUpFee],[ChargeRateOneMonth]) VALUES ('Pay per Rental',0,25)");
            Sql("INSERT INTO [dbo].[UserTypes]([Name],[SignUpFee],[ChargeRateOneMonth]) VALUES ('SuperAdmin',0,0)");
          
        }
        
        public override void Down()
        {
        }
    }
}
