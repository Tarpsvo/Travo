namespace Travo.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BoardInTeams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeamId = c.Int(nullable: false),
                        BoardId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Boards", t => t.BoardId, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.TeamId, cascadeDelete: true)
                .Index(t => t.TeamId)
                .Index(t => t.BoardId);
            
            CreateTable(
                "dbo.Boards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedByUserId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Name = c.String(maxLength: 30),
                        Description = c.String(maxLength: 3000),
                        CreatedByUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedByUser_Id)
                .Index(t => t.CreatedByUser_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
                        DisplayName = c.String(maxLength: 30),
                        Created = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
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
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        Description = c.String(maxLength: 3000),
                        Created = c.DateTime(nullable: false),
                        CreatedByUserId = c.Int(nullable: false),
                        CreatedByUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedByUser_Id)
                .Index(t => t.CreatedByUser_Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ByUserId = c.Int(nullable: false),
                        TaskId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Text = c.String(maxLength: 3000),
                        ByUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ByUser_Id)
                .ForeignKey("dbo.Tasks", t => t.TaskId, cascadeDelete: true)
                .Index(t => t.TaskId)
                .Index(t => t.ByUser_Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TagId = c.Int(nullable: false),
                        CreatedByUserId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Description = c.String(maxLength: 3000),
                        CreatedByUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedByUser_Id)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.TagId)
                .Index(t => t.CreatedByUser_Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BoardId = c.Int(nullable: false),
                        Name = c.String(maxLength: 30),
                        Created = c.DateTime(nullable: false),
                        CreatedByUserId = c.Int(nullable: false),
                        PositionInBoard = c.Int(nullable: false),
                        CreatedByUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Boards", t => t.BoardId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedByUser_Id)
                .Index(t => t.BoardId)
                .Index(t => t.CreatedByUser_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.TaskActivities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskId = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        Time = c.DateTime(nullable: false),
                        ByUserId = c.Int(nullable: false),
                        NewValue = c.String(maxLength: 3000),
                        ByUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ByUser_Id)
                .ForeignKey("dbo.Tasks", t => t.TaskId, cascadeDelete: true)
                .Index(t => t.TaskId)
                .Index(t => t.ByUser_Id);
            
            CreateTable(
                "dbo.TimeTracks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        TaskId = c.Int(nullable: false),
                        Start = c.Long(nullable: false),
                        End = c.Long(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tasks", t => t.TaskId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.TaskId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.UserInTeams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        TeamId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Role = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.TeamId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.TeamId)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserInTeams", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserInTeams", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.TimeTracks", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.TimeTracks", "TaskId", "dbo.Tasks");
            DropForeignKey("dbo.TaskActivities", "TaskId", "dbo.Tasks");
            DropForeignKey("dbo.TaskActivities", "ByUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Comments", "TaskId", "dbo.Tasks");
            DropForeignKey("dbo.Tasks", "TagId", "dbo.Tags");
            DropForeignKey("dbo.Tags", "CreatedByUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tags", "BoardId", "dbo.Boards");
            DropForeignKey("dbo.Tasks", "CreatedByUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "ByUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.BoardInTeams", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.Teams", "CreatedByUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.BoardInTeams", "BoardId", "dbo.Boards");
            DropForeignKey("dbo.Boards", "CreatedByUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserInTeams", new[] { "User_Id" });
            DropIndex("dbo.UserInTeams", new[] { "TeamId" });
            DropIndex("dbo.TimeTracks", new[] { "User_Id" });
            DropIndex("dbo.TimeTracks", new[] { "TaskId" });
            DropIndex("dbo.TaskActivities", new[] { "ByUser_Id" });
            DropIndex("dbo.TaskActivities", new[] { "TaskId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Tags", new[] { "CreatedByUser_Id" });
            DropIndex("dbo.Tags", new[] { "BoardId" });
            DropIndex("dbo.Tasks", new[] { "CreatedByUser_Id" });
            DropIndex("dbo.Tasks", new[] { "TagId" });
            DropIndex("dbo.Comments", new[] { "ByUser_Id" });
            DropIndex("dbo.Comments", new[] { "TaskId" });
            DropIndex("dbo.Teams", new[] { "CreatedByUser_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Boards", new[] { "CreatedByUser_Id" });
            DropIndex("dbo.BoardInTeams", new[] { "BoardId" });
            DropIndex("dbo.BoardInTeams", new[] { "TeamId" });
            DropTable("dbo.UserInTeams");
            DropTable("dbo.TimeTracks");
            DropTable("dbo.TaskActivities");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Tags");
            DropTable("dbo.Tasks");
            DropTable("dbo.Comments");
            DropTable("dbo.Teams");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Boards");
            DropTable("dbo.BoardInTeams");
        }
    }
}
