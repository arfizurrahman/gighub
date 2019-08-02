namespace GigHubApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedPropertyIsCanceledOfGig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gigs", "IsCanceled", c => c.Boolean(nullable: false));
            DropColumn("dbo.Gigs", "InCanceled");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Gigs", "InCanceled", c => c.Boolean(nullable: false));
            DropColumn("dbo.Gigs", "IsCanceled");
        }
    }
}
