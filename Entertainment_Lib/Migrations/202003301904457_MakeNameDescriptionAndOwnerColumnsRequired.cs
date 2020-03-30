namespace Entertainment_Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeNameDescriptionAndOwnerColumnsRequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "Owner_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.TVPrograms", "Owner_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Movies", new[] { "Owner_Id" });
            DropIndex("dbo.TVPrograms", new[] { "Owner_Id" });
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Movies", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "Owner_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.TVPrograms", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.TVPrograms", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.TVPrograms", "Owner_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Movies", "Owner_Id");
            CreateIndex("dbo.TVPrograms", "Owner_Id");
            AddForeignKey("dbo.Movies", "Owner_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TVPrograms", "Owner_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TVPrograms", "Owner_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Movies", "Owner_Id", "dbo.AspNetUsers");
            DropIndex("dbo.TVPrograms", new[] { "Owner_Id" });
            DropIndex("dbo.Movies", new[] { "Owner_Id" });
            AlterColumn("dbo.TVPrograms", "Owner_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.TVPrograms", "Description", c => c.String());
            AlterColumn("dbo.TVPrograms", "Name", c => c.String());
            AlterColumn("dbo.Movies", "Owner_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Movies", "Description", c => c.String());
            AlterColumn("dbo.Movies", "Name", c => c.String());
            CreateIndex("dbo.TVPrograms", "Owner_Id");
            CreateIndex("dbo.Movies", "Owner_Id");
            AddForeignKey("dbo.TVPrograms", "Owner_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Movies", "Owner_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
