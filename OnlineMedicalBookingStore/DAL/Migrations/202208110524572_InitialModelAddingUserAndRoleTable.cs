namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModelAddingUserAndRoleTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Duties", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Duties", "DutyTypeId", "dbo.DutyTypes");
            DropForeignKey("dbo.AssignedDuties", "DutyId", "dbo.Duties");
            DropForeignKey("dbo.AssignedDuties", "RosterId", "dbo.Rosters");
            DropForeignKey("dbo.AssignedDuties", "UserId", "dbo.Users");
            DropForeignKey("dbo.Messages", "UserId", "dbo.Users");
            DropForeignKey("dbo.Requests", "DutyId", "dbo.Duties");
            DropForeignKey("dbo.Requests", "UserId", "dbo.Users");
            DropIndex("dbo.AssignedDuties", new[] { "DutyId" });
            DropIndex("dbo.AssignedDuties", new[] { "UserId" });
            DropIndex("dbo.AssignedDuties", new[] { "RosterId" });
            DropIndex("dbo.Duties", new[] { "DutyTypeId" });
            DropIndex("dbo.Duties", new[] { "CategoryId" });
            DropIndex("dbo.Messages", new[] { "UserId" });
            DropIndex("dbo.Requests", new[] { "UserId" });
            DropIndex("dbo.Requests", new[] { "DutyId" });
            AddColumn("dbo.Users", "Name", c => c.String());
            AddColumn("dbo.Users", "Password", c => c.String());
            AddColumn("dbo.Users", "City", c => c.String());
            AddColumn("dbo.Users", "State", c => c.String());
            AddColumn("dbo.Users", "Zip", c => c.String());
            AddColumn("dbo.Users", "PhoneNumber", c => c.String());
            AddColumn("dbo.Users", "Address", c => c.String());
            AlterColumn("dbo.Users", "IsBlocked", c => c.Boolean(nullable: false));
            DropColumn("dbo.Users", "FirstName");
            DropColumn("dbo.Users", "LastName");
            DropColumn("dbo.Users", "MobileNumber");
            DropColumn("dbo.Users", "BasicSalary");
            DropColumn("dbo.Users", "LoginId");
            DropColumn("dbo.Users", "LoginPass");
            DropColumn("dbo.Users", "Gender");
            DropColumn("dbo.Users", "DateOfBirth");
            DropColumn("dbo.Users", "LastLoginTime");
            DropTable("dbo.AssignedDuties");
            DropTable("dbo.Duties");
            DropTable("dbo.Categories");
            DropTable("dbo.DutyTypes");
            DropTable("dbo.Rosters");
            DropTable("dbo.Messages");
            DropTable("dbo.Requests");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        DutyId = c.Int(nullable: false),
                        Status = c.String(),
                        Readstatus = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MessageText = c.String(),
                        CreatedTime = c.DateTime(nullable: false),
                        Type = c.String(),
                        UserId = c.Int(nullable: false),
                        Readstatus = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rosters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DutyTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Duties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DutyTypeId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AssignedDuties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DutyId = c.Int(nullable: false),
                        UserId = c.Int(),
                        RosterId = c.Int(nullable: false),
                        DutyType = c.String(),
                        AssignedTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "LastLoginTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "DateOfBirth", c => c.DateTime());
            AddColumn("dbo.Users", "Gender", c => c.String());
            AddColumn("dbo.Users", "LoginPass", c => c.String());
            AddColumn("dbo.Users", "LoginId", c => c.String());
            AddColumn("dbo.Users", "BasicSalary", c => c.Single());
            AddColumn("dbo.Users", "MobileNumber", c => c.String());
            AddColumn("dbo.Users", "LastName", c => c.String());
            AddColumn("dbo.Users", "FirstName", c => c.String());
            AlterColumn("dbo.Users", "IsBlocked", c => c.String());
            DropColumn("dbo.Users", "Address");
            DropColumn("dbo.Users", "PhoneNumber");
            DropColumn("dbo.Users", "Zip");
            DropColumn("dbo.Users", "State");
            DropColumn("dbo.Users", "City");
            DropColumn("dbo.Users", "Password");
            DropColumn("dbo.Users", "Name");
            CreateIndex("dbo.Requests", "DutyId");
            CreateIndex("dbo.Requests", "UserId");
            CreateIndex("dbo.Messages", "UserId");
            CreateIndex("dbo.Duties", "CategoryId");
            CreateIndex("dbo.Duties", "DutyTypeId");
            CreateIndex("dbo.AssignedDuties", "RosterId");
            CreateIndex("dbo.AssignedDuties", "UserId");
            CreateIndex("dbo.AssignedDuties", "DutyId");
            AddForeignKey("dbo.Requests", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Requests", "DutyId", "dbo.Duties", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Messages", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AssignedDuties", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.AssignedDuties", "RosterId", "dbo.Rosters", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AssignedDuties", "DutyId", "dbo.Duties", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Duties", "DutyTypeId", "dbo.DutyTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Duties", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
