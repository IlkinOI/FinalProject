namespace SetSail.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upd2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TourReviews", "Fullname");
            DropColumn("dbo.TourReviews", "Email");
            DropColumn("dbo.BlogComments", "Fullname");
            DropColumn("dbo.BlogComments", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BlogComments", "Email", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.BlogComments", "Fullname", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.TourReviews", "Email", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.TourReviews", "Fullname", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
