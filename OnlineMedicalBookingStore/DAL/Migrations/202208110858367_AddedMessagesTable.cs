namespace DAL.Migrations
    {
    using System.Data.Entity.Migrations;

    public partial class AddedMessagesTable : DbMigration
        {
        public override void Up()
            {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                    Id = c.Int(nullable: false, identity: true),
                    MessageText = c.String(),
                    CreatedTime = c.DateTime(nullable: false),
                    Type = c.String(),
                    UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            }

        public override void Down()
            {
            DropForeignKey("dbo.Messages", "UserId", "dbo.Users");
            DropIndex("dbo.Messages", new[] { "UserId" });
            DropTable("dbo.Messages");
            }
        }
    }
