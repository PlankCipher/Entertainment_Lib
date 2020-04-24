namespace Entertainment_Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDatabase : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0e213098-1a93-4c8e-bece-3a36fbd108bd', N'admin@some.domain', 0, N'AMGyH3MeN6UbGLS8B8wt3TOSQtUhHoK3Hn9QMpU0D5pJtEP5uD/WUY80s7O4TVnl1A==', N'e8aa717a-fd46-421f-94f1-729fe56143e5', NULL, 0, 0, NULL, 1, 0, N'admin@some.domain')");
        }
        
        public override void Down()
        {
        }
    }
}
