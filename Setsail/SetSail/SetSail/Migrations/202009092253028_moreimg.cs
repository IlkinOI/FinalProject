namespace SetSail.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moreimg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TourCategories", "ParallaxImage1", c => c.String(maxLength: 250));
            AddColumn("dbo.TourCategories", "ParallaxImage2", c => c.String(maxLength: 250));
            AddColumn("dbo.TourCategories", "VideoImage", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TourCategories", "VideoImage");
            DropColumn("dbo.TourCategories", "ParallaxImage2");
            DropColumn("dbo.TourCategories", "ParallaxImage1");
        }
    }
}
