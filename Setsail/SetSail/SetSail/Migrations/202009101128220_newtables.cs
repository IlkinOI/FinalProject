namespace SetSail.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CityPages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TopTitle1 = c.String(nullable: false, maxLength: 30),
                        Title1 = c.String(nullable: false, maxLength: 30),
                        introText1 = c.String(nullable: false, maxLength: 150),
                        TopTitle2 = c.String(nullable: false, maxLength: 30),
                        Title2 = c.String(nullable: false, maxLength: 30),
                        introText2 = c.String(nullable: false, maxLength: 150),
                        TopTitle3 = c.String(nullable: false, maxLength: 30),
                        Title3 = c.String(nullable: false, maxLength: 30),
                        introText3 = c.String(nullable: false, maxLength: 150),
                        IntroImage1 = c.String(maxLength: 250),
                        IntroImage2 = c.String(maxLength: 250),
                        IntroImage3 = c.String(maxLength: 250),
                        Video = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExoticPages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TopTitle1 = c.String(nullable: false, maxLength: 30),
                        Title1 = c.String(nullable: false, maxLength: 30),
                        introText1 = c.String(nullable: false, maxLength: 150),
                        TopTitle2 = c.String(nullable: false, maxLength: 30),
                        Title2 = c.String(nullable: false, maxLength: 30),
                        introText2 = c.String(nullable: false, maxLength: 150),
                        IntroImage1 = c.String(maxLength: 250),
                        IntroImage2 = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SummerPages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TopTitle1 = c.String(nullable: false, maxLength: 30),
                        Title1 = c.String(nullable: false, maxLength: 30),
                        introText1 = c.String(nullable: false, maxLength: 150),
                        TopTitle2 = c.String(nullable: false, maxLength: 30),
                        Title2 = c.String(nullable: false, maxLength: 30),
                        introText2 = c.String(nullable: false, maxLength: 150),
                        TopTitle3 = c.String(nullable: false, maxLength: 30),
                        Title3 = c.String(nullable: false, maxLength: 30),
                        introText3 = c.String(nullable: false, maxLength: 150),
                        TopTitle4 = c.String(nullable: false, maxLength: 30),
                        Title4 = c.String(nullable: false, maxLength: 30),
                        introText4 = c.String(nullable: false, maxLength: 150),
                        IntroImage1 = c.String(maxLength: 250),
                        IntroImage2 = c.String(maxLength: 250),
                        IntroImage3 = c.String(maxLength: 250),
                        IntroImage4 = c.String(maxLength: 250),
                        VideoImage = c.String(maxLength: 250),
                        ParallaxImage1 = c.String(maxLength: 250),
                        ParallaxImage2 = c.String(maxLength: 250),
                        Video = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WinePages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        introTitleImage1 = c.String(maxLength: 250),
                        introTitleImage2 = c.String(maxLength: 250),
                        introTitleImage3 = c.String(maxLength: 250),
                        IntroImage1 = c.String(maxLength: 250),
                        IntroImage1s = c.String(maxLength: 250),
                        IntroImage2 = c.String(maxLength: 250),
                        IntroImage2s = c.String(maxLength: 250),
                        IntroImage3 = c.String(maxLength: 250),
                        IntroImage3s = c.String(maxLength: 250),
                        VideoImage = c.String(maxLength: 250),
                        PopImage1 = c.String(maxLength: 250),
                        PopImage2 = c.String(maxLength: 250),
                        Glasses = c.Int(nullable: false),
                        Years = c.Int(nullable: false),
                        Uniques = c.Int(nullable: false),
                        Sorts = c.Int(nullable: false),
                        PopSlogan = c.String(nullable: false, maxLength: 150),
                        PopText1 = c.String(nullable: false, maxLength: 50),
                        PopText2 = c.String(nullable: false, maxLength: 50),
                        PopText3 = c.String(nullable: false, maxLength: 50),
                        PopText4 = c.String(nullable: false, maxLength: 50),
                        Video = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WinterPages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TopTitle1 = c.String(nullable: false, maxLength: 30),
                        Title1 = c.String(nullable: false, maxLength: 30),
                        introText1 = c.String(nullable: false, maxLength: 150),
                        TopTitle2 = c.String(nullable: false, maxLength: 30),
                        Title2 = c.String(nullable: false, maxLength: 30),
                        introText2 = c.String(nullable: false, maxLength: 150),
                        IntroImage1 = c.String(maxLength: 250),
                        IntroImage2 = c.String(maxLength: 250),
                        VideoImage = c.String(),
                        ParallaxImage1 = c.String(maxLength: 250),
                        Video = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Abouts", "HomeIntroImage1");
            DropColumn("dbo.Abouts", "HomeIntroImage2");
            DropColumn("dbo.TourCategories", "IntroImage1");
            DropColumn("dbo.TourCategories", "IntroImage2");
            DropColumn("dbo.TourCategories", "IntroImage3");
            DropColumn("dbo.TourCategories", "IntroImage4");
            DropColumn("dbo.TourCategories", "ParallaxImage1");
            DropColumn("dbo.TourCategories", "ParallaxImage2");
            DropColumn("dbo.TourCategories", "VideoImage");
            DropColumn("dbo.TourCategories", "Video");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TourCategories", "Video", c => c.String(nullable: false, maxLength: 250));
            AddColumn("dbo.TourCategories", "VideoImage", c => c.String(maxLength: 250));
            AddColumn("dbo.TourCategories", "ParallaxImage2", c => c.String(maxLength: 250));
            AddColumn("dbo.TourCategories", "ParallaxImage1", c => c.String(maxLength: 250));
            AddColumn("dbo.TourCategories", "IntroImage4", c => c.String(maxLength: 250));
            AddColumn("dbo.TourCategories", "IntroImage3", c => c.String(maxLength: 250));
            AddColumn("dbo.TourCategories", "IntroImage2", c => c.String(maxLength: 250));
            AddColumn("dbo.TourCategories", "IntroImage1", c => c.String(maxLength: 250));
            AddColumn("dbo.Abouts", "HomeIntroImage2", c => c.String());
            AddColumn("dbo.Abouts", "HomeIntroImage1", c => c.String());
            DropTable("dbo.WinterPages");
            DropTable("dbo.WinePages");
            DropTable("dbo.SummerPages");
            DropTable("dbo.ExoticPages");
            DropTable("dbo.CityPages");
        }
    }
}
