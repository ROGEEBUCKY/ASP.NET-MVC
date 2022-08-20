namespace DAL.Migrations
    {
    using System.Data.Entity.Migrations;

    public partial class AddedCreationdateInProduct : DbMigration
        {
        public override void Up()
            {
            AddColumn("dbo.Products", "CreatedDate", c => c.DateTime(nullable: false));
            }

        public override void Down()
            {
            DropColumn("dbo.Products", "CreatedDate");
            }
        }
    }
