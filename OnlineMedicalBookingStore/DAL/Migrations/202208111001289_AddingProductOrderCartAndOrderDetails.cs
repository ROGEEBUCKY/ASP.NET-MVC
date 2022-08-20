namespace DAL.Migrations
    {
    using System.Data.Entity.Migrations;

    public partial class AddingProductOrderCartAndOrderDetails : DbMigration
        {
        public override void Up()
            {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.Int(nullable: false),
                    ProductId = c.Int(nullable: false),
                    Price = c.Single(nullable: false),
                    Quantity = c.Int(nullable: false),
                    CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ProductId);

            CreateTable(
                "dbo.Products",
                c => new
                    {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Description = c.String(),
                    Price = c.Single(nullable: false),
                    Weight = c.Single(nullable: false),
                    Image = c.String(),
                    Manufacturer = c.String(),
                    Discount = c.Single(nullable: false),
                    RemarkId = c.Int(nullable: false),
                    Stock = c.Int(nullable: false),
                    ExpiryDate = c.DateTime(nullable: false),
                    FinalAmount = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Remarks", t => t.RemarkId, cascadeDelete: true)
                .Index(t => t.RemarkId);

            CreateTable(
                "dbo.Remarks",
                c => new
                    {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                    Id = c.Int(nullable: false, identity: true),
                    OrderId = c.Int(nullable: false),
                    ProductId = c.Int(nullable: false),
                    Price = c.Single(nullable: false),
                    Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);

            CreateTable(
                "dbo.Orders",
                c => new
                    {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.Int(nullable: false),
                    Amount = c.Single(nullable: false),
                    Created = c.DateTime(nullable: false),
                    Address = c.String(),
                    City = c.String(),
                    State = c.String(),
                    ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            }

        public override void Down()
            {
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.Carts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Carts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "RemarkId", "dbo.Remarks");
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.Products", new[] { "RemarkId" });
            DropIndex("dbo.Carts", new[] { "ProductId" });
            DropIndex("dbo.Carts", new[] { "UserId" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Remarks");
            DropTable("dbo.Products");
            DropTable("dbo.Carts");
            }
        }
    }
