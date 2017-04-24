namespace Forum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alsdkfj : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "UserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Posts", "UserID");
            AddForeignKey("dbo.Posts", "UserID", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Posts", "Username");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "Username", c => c.String());
            DropForeignKey("dbo.Posts", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.Posts", new[] { "UserID" });
            DropColumn("dbo.Posts", "UserID");
        }
    }
}
