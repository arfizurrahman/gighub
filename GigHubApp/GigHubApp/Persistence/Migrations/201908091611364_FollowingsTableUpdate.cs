namespace GigHubApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FollowingsTableUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Followings", "FolloweeId", "dbo.AspNetUsers");
            AddForeignKey("dbo.Followings", "FolloweeId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Followings", "FolloweeId", "dbo.AspNetUsers");
            AddForeignKey("dbo.Followings", "FolloweeId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
