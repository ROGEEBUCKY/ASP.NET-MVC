namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRolesTable : DbMigration
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
            
            AddColumn("dbo.Users", "RoleId", c => c.Int(nullable: false));
            Sql("Insert into Roles(Name) Values('SuperAdmin')");
            Sql("Insert into Roles(Name) Values('Admin')");
            Sql("Insert into Roles(Name) Values('Normal')");
            Sql("Insert into Users(Name, password, Email, BirthDate, RoleId) Values('SuperAdmin','SuperAdmin@123','SuperAdmin@gmail.com','12-05-2000',1)");
            Sql("Insert into Users(Name, password, Email, BirthDate, RoleId) Values('Admin','Admin@123','Admin@gmail.com','12-05-2000',2)");
            Sql("Insert into Users(Name, password, Email, BirthDate, RoleId) Values('Rituraj','Rituraj@123','Rituraj@gmail.com','12-05-2000',3)");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "RoleId");
            DropTable("dbo.Roles");
        }
    }
}
