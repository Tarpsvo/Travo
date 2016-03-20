namespace Travo.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserIdEdit : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Boards", new[] { "CreatedByUser_Id" });
            DropIndex("dbo.Teams", new[] { "CreatedByUser_Id" });
            DropIndex("dbo.Comments", new[] { "ByUser_Id" });
            DropIndex("dbo.Tasks", new[] { "CreatedByUser_Id" });
            DropIndex("dbo.Tags", new[] { "CreatedByUser_Id" });
            DropIndex("dbo.TaskActivities", new[] { "ByUser_Id" });
            DropIndex("dbo.TimeTracks", new[] { "User_Id" });
            DropIndex("dbo.UserInTeams", new[] { "User_Id" });
            DropColumn("dbo.Boards", "CreatedByUserId");
            DropColumn("dbo.Teams", "CreatedByUserId");
            DropColumn("dbo.Comments", "ByUserId");
            DropColumn("dbo.Tasks", "CreatedByUserId");
            DropColumn("dbo.Tags", "CreatedByUserId");
            DropColumn("dbo.TaskActivities", "ByUserId");
            DropColumn("dbo.TimeTracks", "UserId");
            DropColumn("dbo.UserInTeams", "UserId");
            RenameColumn(table: "dbo.Boards", name: "CreatedByUser_Id", newName: "CreatedByUserId");
            RenameColumn(table: "dbo.Teams", name: "CreatedByUser_Id", newName: "CreatedByUserId");
            RenameColumn(table: "dbo.Comments", name: "ByUser_Id", newName: "ByUserId");
            RenameColumn(table: "dbo.Tasks", name: "CreatedByUser_Id", newName: "CreatedByUserId");
            RenameColumn(table: "dbo.Tags", name: "CreatedByUser_Id", newName: "CreatedByUserId");
            RenameColumn(table: "dbo.TaskActivities", name: "ByUser_Id", newName: "ByUserId");
            RenameColumn(table: "dbo.TimeTracks", name: "User_Id", newName: "UserId");
            RenameColumn(table: "dbo.UserInTeams", name: "User_Id", newName: "UserId");
            AddColumn("dbo.Teams", "isDefault", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Boards", "CreatedByUserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Teams", "CreatedByUserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Comments", "ByUserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Tasks", "CreatedByUserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Tags", "CreatedByUserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.TaskActivities", "ByUserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.TimeTracks", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.UserInTeams", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Boards", "CreatedByUserId");
            CreateIndex("dbo.Teams", "CreatedByUserId");
            CreateIndex("dbo.Comments", "ByUserId");
            CreateIndex("dbo.Tasks", "CreatedByUserId");
            CreateIndex("dbo.Tags", "CreatedByUserId");
            CreateIndex("dbo.TaskActivities", "ByUserId");
            CreateIndex("dbo.TimeTracks", "UserId");
            CreateIndex("dbo.UserInTeams", "UserId");
            DropColumn("dbo.Boards", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Boards", "Description", c => c.String(maxLength: 3000));
            DropIndex("dbo.UserInTeams", new[] { "UserId" });
            DropIndex("dbo.TimeTracks", new[] { "UserId" });
            DropIndex("dbo.TaskActivities", new[] { "ByUserId" });
            DropIndex("dbo.Tags", new[] { "CreatedByUserId" });
            DropIndex("dbo.Tasks", new[] { "CreatedByUserId" });
            DropIndex("dbo.Comments", new[] { "ByUserId" });
            DropIndex("dbo.Teams", new[] { "CreatedByUserId" });
            DropIndex("dbo.Boards", new[] { "CreatedByUserId" });
            AlterColumn("dbo.UserInTeams", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.TimeTracks", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.TaskActivities", "ByUserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Tags", "CreatedByUserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Tasks", "CreatedByUserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "ByUserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Teams", "CreatedByUserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Boards", "CreatedByUserId", c => c.Int(nullable: false));
            DropColumn("dbo.Teams", "isDefault");
            RenameColumn(table: "dbo.UserInTeams", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.TimeTracks", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.TaskActivities", name: "ByUserId", newName: "ByUser_Id");
            RenameColumn(table: "dbo.Tags", name: "CreatedByUserId", newName: "CreatedByUser_Id");
            RenameColumn(table: "dbo.Tasks", name: "CreatedByUserId", newName: "CreatedByUser_Id");
            RenameColumn(table: "dbo.Comments", name: "ByUserId", newName: "ByUser_Id");
            RenameColumn(table: "dbo.Teams", name: "CreatedByUserId", newName: "CreatedByUser_Id");
            RenameColumn(table: "dbo.Boards", name: "CreatedByUserId", newName: "CreatedByUser_Id");
            AddColumn("dbo.UserInTeams", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.TimeTracks", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.TaskActivities", "ByUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Tags", "CreatedByUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Tasks", "CreatedByUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "ByUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Teams", "CreatedByUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Boards", "CreatedByUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.UserInTeams", "User_Id");
            CreateIndex("dbo.TimeTracks", "User_Id");
            CreateIndex("dbo.TaskActivities", "ByUser_Id");
            CreateIndex("dbo.Tags", "CreatedByUser_Id");
            CreateIndex("dbo.Tasks", "CreatedByUser_Id");
            CreateIndex("dbo.Comments", "ByUser_Id");
            CreateIndex("dbo.Teams", "CreatedByUser_Id");
            CreateIndex("dbo.Boards", "CreatedByUser_Id");
        }
    }
}
