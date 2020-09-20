namespace SetSail.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hometable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HomePages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TopTitle1 = c.String(nullable: false, maxLength: 30),
                        Title1 = c.String(nullable: false, maxLength: 30),
                        introText2 = c.String(nullable: false, maxLength: 150),
                        TopTitle2 = c.String(nullable: false, maxLength: 30),
                        Title2 = c.String(nullable: false, maxLength: 30),
                        introText1 = c.String(nullable: false, maxLength: 150),
                        IntroImage1 = c.String(maxLength: 250),
                        IntroImage2 = c.String(maxLength: 250),
                        VideoImage = c.String(maxLength: 250),
                        ParallaxImage1 = c.String(maxLength: 250),
                        ParallaxImage2 = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HomePages");
        }
    }
}
