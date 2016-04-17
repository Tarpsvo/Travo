namespace Travo.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TaskTitle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "Title", c => c.String(maxLength: 60));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tasks", "Title");
        }
    }
}
