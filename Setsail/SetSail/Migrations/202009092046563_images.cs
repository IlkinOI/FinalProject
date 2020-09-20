namespace SetSail.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class images : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "MPImage", c => c.String(maxLength: 250));
            AddColumn("dbo.Abouts", "BlogsBgImage", c => c.String(maxLength: 250));
            AddColumn("dbo.Abouts", "HomeIntroImage1", c => c.String());
            AddColumn("dbo.Abouts", "HomeIntroImage2", c => c.String());
            AddColumn("dbo.Destinations", "BgImage", c => c.String(maxLength: 250));
            AddColumn("dbo.Destinations", "SliderImage", c => c.String(maxLength: 250));
            AddColumn("dbo.TourCategories", "IntroImage1", c => c.String(maxLength: 250));
            AddColumn("dbo.TourCategories", "IntroImage2", c => c.String(maxLength: 250));
            AddColumn("dbo.TourCategories", "IntroImage3", c => c.String(maxLength: 250));
            AddColumn("dbo.TourCategories", "IntroImage4", c => c.String(maxLength: 250));
            AddColumn("dbo.Faqs", "BgImage", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Faqs", "BgImage");
            DropColumn("dbo.TourCategories", "IntroImage4");
            DropColumn("dbo.TourCategories", "IntroImage3");
            DropColumn("dbo.TourCategories", "IntroImage2");
            DropColumn("dbo.TourCategories", "IntroImage1");
            DropColumn("dbo.Destinations", "SliderImage");
            DropColumn("dbo.Destinations", "BgImage");
            DropColumn("dbo.Abouts", "HomeIntroImage2");
            DropColumn("dbo.Abouts", "HomeIntroImage1");
            DropColumn("dbo.Abouts", "BlogsBgImage");
            DropColumn("dbo.Abouts", "MPImage");
        }
    }
}
