namespace CustomAuthorization.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
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
                        UserId = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            Sql("Insert into Roles(Name) Values ('SuperAdmin')");
            Sql("Insert into Roles(Name) Values ('Admin')");
            Sql("Insert into Roles(Name) Values ('Normal')");
            Sql("Insert into Users (UserId,UserName,Password,RoleId) Values ('sarathlal','Sarathlal Saseendran','pwd',1)");
            Sql("Insert into Users (UserId,UserName,Password,RoleId) Values ('sarath','Sarath Lal','pwd',2)");
            Sql("Insert into Users (UserId,UserName,Password,RoleId) Values ('lal','Sarath Lal','pwd',3)");

            }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
        }
    }
}
