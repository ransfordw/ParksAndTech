namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyPark",
                c => new
                    {
                        MyParkID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        ParkID = c.Int(nullable: false),
                        TrailID = c.Int(nullable: false),
                        MyTrailStatus = c.Int(nullable: false),
                        TrailComment = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MyParkID)
                .ForeignKey("dbo.Park", t => t.ParkID)
                .ForeignKey("dbo.Trail", t => t.TrailID)
                .Index(t => t.ParkID)
                .Index(t => t.TrailID);
            
            CreateTable(
                "dbo.Park",
                c => new
                    {
                        ParkID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        ParkName = c.String(nullable: false),
                        ParkCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ParkAddress = c.String(nullable: false),
                        ParkCity = c.String(nullable: false),
                        ParkState = c.Int(nullable: false),
                        ParkZip = c.Int(nullable: false),
                        ParkPhone = c.String(nullable: false),
                        ParkWebsite = c.String(nullable: false),
                        ParkDescription = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ParkID);
            
            CreateTable(
                "dbo.Trail",
                c => new
                    {
                        TrailID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        TrailName = c.String(nullable: false),
                        TrailDistance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TrailDifficulty = c.Int(nullable: false),
                        IsOpen = c.Boolean(nullable: false),
                        ParkID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TrailID)
                .ForeignKey("dbo.Park", t => t.ParkID)
                .Index(t => t.ParkID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RoleId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.MyPark", "TrailID", "dbo.Trail");
            DropForeignKey("dbo.Trail", "ParkID", "dbo.Park");
            DropForeignKey("dbo.MyPark", "ParkID", "dbo.Park");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Trail", new[] { "ParkID" });
            DropIndex("dbo.MyPark", new[] { "TrailID" });
            DropIndex("dbo.MyPark", new[] { "ParkID" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Trail");
            DropTable("dbo.Park");
            DropTable("dbo.MyPark");
        }
    }
}
