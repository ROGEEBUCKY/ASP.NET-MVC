namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Type = c.String(),
                        Episodes = c.Int(nullable: false),
                        Status = c.String(),
                        Picture = c.String(),
                        ThumbNail = c.String(),
                        Season_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Seasons", t => t.Season_Id)
                .Index(t => t.Season_Id);
            
            CreateTable(
                "dbo.Relations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        Anime_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Animes", t => t.Anime_Id, cascadeDelete: true)
                .Index(t => t.Anime_Id);
            
            CreateTable(
                "dbo.Seasons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Season = c.String(),
                        Year = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        Anime_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Animes", t => t.Anime_Id, cascadeDelete: true)
                .Index(t => t.Anime_Id);
            
            CreateTable(
                "dbo.Synonyms",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Anime_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Animes", t => t.Anime_Id, cascadeDelete: true)
                .Index(t => t.Anime_Id);
            
            CreateTable(
                "dbo.Tags",
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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TagsAnimes",
                c => new
                    {
                        Tags_Id = c.Int(nullable: false),
                        Anime_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tags_Id, t.Anime_Id })
                .ForeignKey("dbo.Tags", t => t.Tags_Id, cascadeDelete: true)
                .ForeignKey("dbo.Animes", t => t.Anime_Id, cascadeDelete: true)
                .Index(t => t.Tags_Id)
                .Index(t => t.Anime_Id);
            
            CreateTable(
                "dbo.UserAnimes",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Anime_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Anime_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Animes", t => t.Anime_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Anime_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAnimes", "Anime_Id", "dbo.Animes");
            DropForeignKey("dbo.UserAnimes", "User_Id", "dbo.Users");
            DropForeignKey("dbo.TagsAnimes", "Anime_Id", "dbo.Animes");
            DropForeignKey("dbo.TagsAnimes", "Tags_Id", "dbo.Tags");
            DropForeignKey("dbo.Synonyms", "Anime_Id", "dbo.Animes");
            DropForeignKey("dbo.Sources", "Anime_Id", "dbo.Animes");
            DropForeignKey("dbo.Animes", "Season_Id", "dbo.Seasons");
            DropForeignKey("dbo.Relations", "Anime_Id", "dbo.Animes");
            DropIndex("dbo.UserAnimes", new[] { "Anime_Id" });
            DropIndex("dbo.UserAnimes", new[] { "User_Id" });
            DropIndex("dbo.TagsAnimes", new[] { "Anime_Id" });
            DropIndex("dbo.TagsAnimes", new[] { "Tags_Id" });
            DropIndex("dbo.Synonyms", new[] { "Anime_Id" });
            DropIndex("dbo.Sources", new[] { "Anime_Id" });
            DropIndex("dbo.Relations", new[] { "Anime_Id" });
            DropIndex("dbo.Animes", new[] { "Season_Id" });
            DropTable("dbo.UserAnimes");
            DropTable("dbo.TagsAnimes");
            DropTable("dbo.Users");
            DropTable("dbo.Tags");
            DropTable("dbo.Synonyms");
            DropTable("dbo.Sources");
            DropTable("dbo.Seasons");
            DropTable("dbo.Relations");
            DropTable("dbo.Animes");
        }
    }
}
