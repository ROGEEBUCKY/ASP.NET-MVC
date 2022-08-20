namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserIdColumninInvestmentTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Investments", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Investments", "UserId");
            AddForeignKey("dbo.Investments", "UserId", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Investments", "UserId", "dbo.Users");
            DropIndex("dbo.Investments", new[] { "UserId" });
            DropColumn("dbo.Investments", "UserId");
        }
    }
}
