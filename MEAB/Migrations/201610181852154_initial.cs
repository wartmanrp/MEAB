namespace MEAB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArmyLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArmyName = c.String(),
                        PointsLimit = c.Int(nullable: false),
                        LeaderId = c.Int(nullable: false),
                        CreatorId = c.String(maxLength: 128),
                        Created = c.DateTimeOffset(nullable: false, precision: 7),
                        Updated = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatorId)
                .ForeignKey("dbo.Units", t => t.LeaderId, cascadeDelete: true)
                .Index(t => t.LeaderId)
                .Index(t => t.CreatorId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Points = c.Int(nullable: false),
                        Fight = c.Int(nullable: false),
                        Shoot = c.Int(nullable: false),
                        Strength = c.Int(nullable: false),
                        Defense = c.Int(nullable: false),
                        Attacks = c.Int(nullable: false),
                        Wounds = c.Int(nullable: false),
                        Courage = c.Int(nullable: false),
                        CreatorId = c.String(maxLength: 128),
                        Created = c.DateTimeOffset(nullable: false, precision: 7),
                        Updated = c.DateTimeOffset(precision: 7),
                        Might = c.Int(),
                        Will = c.Int(),
                        Fate = c.Int(),
                        Notes = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        Warband_Id = c.Int(),
                        ArmyList_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatorId)
                .ForeignKey("dbo.Warbands", t => t.Warband_Id)
                .ForeignKey("dbo.ArmyLists", t => t.ArmyList_Id)
                .Index(t => t.CreatorId)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Warband_Id)
                .Index(t => t.ArmyList_Id);
            
            CreateTable(
                "dbo.UnitTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Unit_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Units", t => t.Unit_Id)
                .Index(t => t.Unit_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Warbands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Notes = c.String(),
                        LeaderId = c.Int(nullable: false),
                        CreatorId = c.String(maxLength: 128),
                        Created = c.DateTimeOffset(nullable: false, precision: 7),
                        Updated = c.DateTimeOffset(precision: 7),
                        ArmyList_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatorId)
                .ForeignKey("dbo.Units", t => t.LeaderId, cascadeDelete: true)
                .ForeignKey("dbo.ArmyLists", t => t.ArmyList_Id)
                .Index(t => t.LeaderId)
                .Index(t => t.CreatorId)
                .Index(t => t.ArmyList_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Warbands", "ArmyList_Id", "dbo.ArmyLists");
            DropForeignKey("dbo.Units", "ArmyList_Id", "dbo.ArmyLists");
            DropForeignKey("dbo.ArmyLists", "LeaderId", "dbo.Units");
            DropForeignKey("dbo.Units", "Warband_Id", "dbo.Warbands");
            DropForeignKey("dbo.Warbands", "LeaderId", "dbo.Units");
            DropForeignKey("dbo.Warbands", "CreatorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UnitTypes", "Unit_Id", "dbo.Units");
            DropForeignKey("dbo.Units", "CreatorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Units", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ArmyLists", "CreatorId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Warbands", new[] { "ArmyList_Id" });
            DropIndex("dbo.Warbands", new[] { "CreatorId" });
            DropIndex("dbo.Warbands", new[] { "LeaderId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.UnitTypes", new[] { "Unit_Id" });
            DropIndex("dbo.Units", new[] { "ArmyList_Id" });
            DropIndex("dbo.Units", new[] { "Warband_Id" });
            DropIndex("dbo.Units", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Units", new[] { "CreatorId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.ArmyLists", new[] { "CreatorId" });
            DropIndex("dbo.ArmyLists", new[] { "LeaderId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Warbands");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.UnitTypes");
            DropTable("dbo.Units");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.ArmyLists");
        }
    }
}
