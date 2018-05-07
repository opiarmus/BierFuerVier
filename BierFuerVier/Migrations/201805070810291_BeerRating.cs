namespace BierFuerVier.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BeerRating : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Beers", "Upvotes", c => c.Int(nullable: false));
            AddColumn("dbo.Beers", "Downvotes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Beers", "Downvotes");
            DropColumn("dbo.Beers", "Upvotes");
        }
    }
}
