namespace DAL.Migrations
    {
    using System.Data.Entity.Migrations;

    public partial class InitialModelAddingUserAndRoleTable : DbMigration
        {
        public override void Up()
            {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Users",
                c => new
                    {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Email = c.String(),
                    CreatedDate = c.DateTime(nullable: false),
                    Password = c.String(),
                    City = c.String(),
                    State = c.String(),
                    Zip = c.String(),
                    PhoneNumber = c.String(),
                    Address = c.String(),
                    IsBlocked = c.Boolean(nullable: false),
                    RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            Sql("Insert into Roles(Name) Values('Admin')");
            Sql("Insert into Roles(Name) Values('User')");
            }

        public override void Down()
            {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            }
        }
    }
