namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingFundsColumn : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FundRemarks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Funds",
                c => new
                    {
                        FundId = c.Int(nullable: false, identity: true),
                        Dated = c.DateTime(nullable: false),
                        fundAmount = c.Single(nullable: false),
                        FundRemarkId = c.Int(nullable: false),
                        AmountUsed = c.Single(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FundId)
                .ForeignKey("dbo.FundRemarks", t => t.FundRemarkId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.FundRemarkId)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.Investments",
                c => new
                    {
                    InvestmentId = c.Int(nullable: false, identity: true),
                    Dated = c.DateTime(nullable: false),
                    FundId = c.Int(nullable: false),
                    ForPeriod = c.Int(nullable: false),
                    InvestmentAmount = c.Single(nullable: false),
                    Status = c.String(),
                    FinalAmount = c.Single(nullable: false),
                    DateOfMaturity = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.InvestmentId)
                .ForeignKey("dbo.Funds", t => t.FundId, cascadeDelete: true)
                .Index(t => t.FundId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Investments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Investments", "FundId", "dbo.Funds");
            DropForeignKey("dbo.Funds", "UserId", "dbo.Users");
            DropForeignKey("dbo.Funds", "FundRemarkId", "dbo.FundRemarks");
            DropIndex("dbo.Investments", new[] { "UserId" });
            DropIndex("dbo.Investments", new[] { "FundId" });
            DropIndex("dbo.Funds", new[] { "UserId" });
            DropIndex("dbo.Funds", new[] { "FundRemarkId" });
            DropTable("dbo.Investments");
            DropTable("dbo.Funds");
            DropTable("dbo.FundRemarks");
        }
    }
}
