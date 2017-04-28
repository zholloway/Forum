namespace Forum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentstiedtoUserPosts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Body = c.String(),
                        DatePosted = c.DateTime(nullable: false),
                        UpVoteCount = c.Int(nullable: false),
                        DownVoteCount = c.Int(nullable: false),
                        MarkedAsAnswer = c.Boolean(nullable: false),
                        UserID = c.String(maxLength: 128),
                        PostID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Posts", t => t.PostID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.PostID);
            
            AddColumn("dbo.Posts", "UpVoteCount", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "DownVoteCount", c => c.Int(nullable: false));
            DropColumn("dbo.Posts", "UpVotes");
            DropColumn("dbo.Posts", "DownVotes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "DownVotes", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "UpVotes", c => c.Int(nullable: false));
            DropForeignKey("dbo.Comments", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "PostID", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "PostID" });
            DropIndex("dbo.Comments", new[] { "UserID" });
            DropColumn("dbo.Posts", "DownVoteCount");
            DropColumn("dbo.Posts", "UpVoteCount");
            DropTable("dbo.Comments");
        }
    }
}
