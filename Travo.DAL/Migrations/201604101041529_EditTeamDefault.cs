namespace Travo.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditTeamDefault : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teams", "Default", c => c.Boolean(nullable: false));
            DropColumn("dbo.Teams", "isDefault");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teams", "isDefault", c => c.Boolean(nullable: false));
            DropColumn("dbo.Teams", "Default");
        }
    }
}
