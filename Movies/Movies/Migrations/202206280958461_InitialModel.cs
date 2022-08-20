namespace Movies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Year = c.String(),
                        Runtime = c.String(),
                        Director = c.String(),
                        Actor = c.String(),
                        Plot = c.String(),
                        PosterUrl = c.String(),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GenresMovies",
                c => new
                    {
                        Genres_Id = c.Int(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genres_Id, t.Movie_Id })
                .ForeignKey("dbo.Genres", t => t.Genres_Id, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_Id, cascadeDelete: true)
                .Index(t => t.Genres_Id)
                .Index(t => t.Movie_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.GenresMovies", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.GenresMovies", "Genres_Id", "dbo.Genres");
            DropIndex("dbo.GenresMovies", new[] { "Movie_Id" });
            DropIndex("dbo.GenresMovies", new[] { "Genres_Id" });
            DropIndex("dbo.Movies", new[] { "Customer_Id" });
            DropTable("dbo.GenresMovies");
            DropTable("dbo.Genres");
            DropTable("dbo.Movies");
            DropTable("dbo.Customers");
        }
    }
}
