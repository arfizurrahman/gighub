namespace GigHubApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsCanceledToGig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gigs", "InCanceled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Gigs", "InCanceled");
        }
    }
}
