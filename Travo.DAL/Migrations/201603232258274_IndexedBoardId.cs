namespace Travo.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IndexedBoardId : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.BoardInTeams", new[] { "BoardId" });
            CreateIndex("dbo.BoardInTeams", "BoardId", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.BoardInTeams", new[] { "BoardId" });
            CreateIndex("dbo.BoardInTeams", "BoardId");
        }
    }
}
