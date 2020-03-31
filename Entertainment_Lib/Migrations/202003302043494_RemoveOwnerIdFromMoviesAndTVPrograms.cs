namespace Entertainment_Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveOwnerIdFromMoviesAndTVPrograms : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "OwnerId");
            DropColumn("dbo.TVPrograms", "OwnerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TVPrograms", "OwnerId", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "OwnerId", c => c.Int(nullable: false));
        }
    }
}
