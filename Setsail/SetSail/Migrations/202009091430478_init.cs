namespace SetSail.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TopText = c.String(nullable: false, maxLength: 200),
                        Text = c.String(nullable: false, storeType: "ntext"),
                        BgImage = c.String(maxLength: 250),
                        Image = c.String(maxLength: 250),
                        PopImage = c.String(maxLength: 250),
                        VideoImage = c.String(maxLength: 250),
                        Video = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 250),
                        Photo = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        BgImage = c.String(maxLength: 250),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                        About = c.String(nullable: false, storeType: "ntext"),
                        Age = c.Byte(nullable: false),
                        DeparturePlace = c.String(nullable: false, maxLength: 50),
                        DepartureTime = c.DateTime(nullable: false),
                        ReturnTime = c.DateTime(nullable: false),
                        DressCode = c.String(nullable: false, maxLength: 30),
                        Text = c.String(nullable: false, storeType: "ntext"),
                        DateFrom = c.DateTime(nullable: false),
                        DateTo = c.DateTime(nullable: false),
                        TicketsNum = c.Byte(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        AdminId = c.Int(nullable: false),
                        TourCityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.AdminId, cascadeDelete: false)
                .ForeignKey("dbo.TourCities", t => t.TourCityId, cascadeDelete: true)
                .Index(t => t.AdminId)
                .Index(t => t.TourCityId);
            
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 30),
                        Consist = c.String(nullable: false, maxLength: 300),
                        TourId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tours", t => t.TourId, cascadeDelete: true)
                .Index(t => t.TourId);
            
            CreateTable(
                "dbo.DayIncludes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Feature = c.String(nullable: false, maxLength: 30),
                        DayId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Days", t => t.DayId, cascadeDelete: true)
                .Index(t => t.DayId);
            
            CreateTable(
                "dbo.Includes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Feature = c.String(nullable: false, maxLength: 30),
                        TourId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tours", t => t.TourId, cascadeDelete: true)
                .Index(t => t.TourId);
            
            CreateTable(
                "dbo.NotIncludes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Feature = c.String(nullable: false, maxLength: 30),
                        TourId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tours", t => t.TourId, cascadeDelete: true)
                .Index(t => t.TourId);
            
            CreateTable(
                "dbo.TourCities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        History = c.String(nullable: false, storeType: "ntext"),
                        Map = c.String(nullable: false, maxLength: 500),
                        DestinationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Destinations", t => t.DestinationId, cascadeDelete: true)
                .Index(t => t.DestinationId);
            
            CreateTable(
                "dbo.Destinations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Text1 = c.String(nullable: false, storeType: "ntext"),
                        Pic1 = c.String(maxLength: 250),
                        Pic2 = c.String(maxLength: 250),
                        Text2 = c.String(nullable: false, storeType: "ntext"),
                        Visa = c.String(nullable: false, maxLength: 50),
                        Language = c.String(nullable: false, maxLength: 50),
                        Area = c.String(nullable: false, maxLength: 50),
                        MunText = c.String(nullable: false, storeType: "ntext"),
                        Pic3 = c.String(maxLength: 250),
                        Pic4 = c.String(maxLength: 250),
                        Pic5 = c.String(maxLength: 250),
                        Pic6 = c.String(maxLength: 250),
                        Video = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DesToCats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DestinationId = c.Int(nullable: false),
                        TourCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Destinations", t => t.DestinationId, cascadeDelete: true)
                .ForeignKey("dbo.TourCategories", t => t.TourCategoryId, cascadeDelete: true)
                .Index(t => t.DestinationId)
                .Index(t => t.TourCategoryId);
            
            CreateTable(
                "dbo.TourCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Video = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DesToTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DestinationId = c.Int(nullable: false),
                        TourTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Destinations", t => t.DestinationId, cascadeDelete: true)
                .ForeignKey("dbo.TourTypes", t => t.TourTypeId, cascadeDelete: true)
                .Index(t => t.DestinationId)
                .Index(t => t.TourTypeId);
            
            CreateTable(
                "dbo.TourTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TourImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageName = c.String(nullable: false, maxLength: 250),
                        TourId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tours", t => t.TourId, cascadeDelete: true)
                .Index(t => t.TourId);
            
            CreateTable(
                "dbo.TourReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(nullable: false, maxLength: 500),
                        Fullname = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Rating = c.Byte(nullable: false),
                        Comfort = c.Byte(nullable: false),
                        Food = c.Byte(nullable: false),
                        Hospitality = c.Byte(nullable: false),
                        Hygiene = c.Byte(nullable: false),
                        Reception = c.Byte(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        TourId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tours", t => t.TourId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.TourId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 250),
                        Photo = c.String(maxLength: 250),
                        IsRegistered = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BlogComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(nullable: false, maxLength: 500),
                        Fullname = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        BlogId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blogs", t => t.BlogId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.BlogId);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        BgImage = c.String(maxLength: 250),
                        MainImage = c.String(maxLength: 250),
                        TopText = c.String(nullable: false, maxLength: 200),
                        Text1 = c.String(nullable: false, storeType: "ntext"),
                        Quote = c.String(nullable: false, maxLength: 250),
                        Text2 = c.String(nullable: false, storeType: "ntext"),
                        Image1 = c.String(maxLength: 250),
                        Image2 = c.String(maxLength: 250),
                        Text3 = c.String(nullable: false, storeType: "ntext"),
                        CreatedDate = c.DateTime(nullable: false),
                        BlogCategoryId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BlogCategories", t => t.BlogCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.BlogCategoryId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.BlogCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 50),
                        Tickets = c.Byte(nullable: false),
                        DateFrom = c.DateTime(nullable: false),
                        DateTo = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        TourId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tours", t => t.TourId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.TourId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ContactReplies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(nullable: false, maxLength: 500),
                        Fullname = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserSocials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Link = c.String(nullable: false, maxLength: 250),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ContactCities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        ContactCountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContactCountries", t => t.ContactCountryId, cascadeDelete: true)
                .Index(t => t.ContactCountryId);
            
            CreateTable(
                "dbo.ContactCountries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 50),
                        Phone1 = c.String(nullable: false, maxLength: 50),
                        Phone2 = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 50),
                        Map = c.String(nullable: false, maxLength: 500),
                        ContactCityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContactCities", t => t.ContactCityId, cascadeDelete: true)
                .Index(t => t.ContactCityId);
            
            CreateTable(
                "dbo.ContactSocials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Icon = c.String(nullable: false, maxLength: 30),
                        Link = c.String(nullable: false, maxLength: 250),
                        ContactId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.Faqs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(nullable: false, maxLength: 50),
                        Answer = c.String(nullable: false, storeType: "ntext"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false, maxLength: 30),
                        About = c.String(nullable: false, maxLength: 100),
                        Photo = c.String(maxLength: 250),
                        PositionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Positions", t => t.PositionId, cascadeDelete: true)
                .Index(t => t.PositionId);
            
            CreateTable(
                "dbo.TeamSocials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Icon = c.String(nullable: false, maxLength: 30),
                        Link = c.String(nullable: false, maxLength: 250),
                        TeamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.TeamId, cascadeDelete: true)
                .Index(t => t.TeamId);
            
            CreateTable(
                "dbo.Subscriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeamSocials", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.Teams", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.ContactSocials", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Contacts", "ContactCityId", "dbo.ContactCities");
            DropForeignKey("dbo.ContactCities", "ContactCountryId", "dbo.ContactCountries");
            DropForeignKey("dbo.UserSocials", "UserId", "dbo.Users");
            DropForeignKey("dbo.TourReviews", "UserId", "dbo.Users");
            DropForeignKey("dbo.ContactReplies", "UserId", "dbo.Users");
            DropForeignKey("dbo.Bookings", "UserId", "dbo.Users");
            DropForeignKey("dbo.Bookings", "TourId", "dbo.Tours");
            DropForeignKey("dbo.BlogComments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Blogs", "UserId", "dbo.Users");
            DropForeignKey("dbo.BlogComments", "BlogId", "dbo.Blogs");
            DropForeignKey("dbo.Blogs", "BlogCategoryId", "dbo.BlogCategories");
            DropForeignKey("dbo.TourReviews", "TourId", "dbo.Tours");
            DropForeignKey("dbo.TourImages", "TourId", "dbo.Tours");
            DropForeignKey("dbo.Tours", "TourCityId", "dbo.TourCities");
            DropForeignKey("dbo.TourCities", "DestinationId", "dbo.Destinations");
            DropForeignKey("dbo.DesToTypes", "TourTypeId", "dbo.TourTypes");
            DropForeignKey("dbo.DesToTypes", "DestinationId", "dbo.Destinations");
            DropForeignKey("dbo.DesToCats", "TourCategoryId", "dbo.TourCategories");
            DropForeignKey("dbo.DesToCats", "DestinationId", "dbo.Destinations");
            DropForeignKey("dbo.NotIncludes", "TourId", "dbo.Tours");
            DropForeignKey("dbo.Includes", "TourId", "dbo.Tours");
            DropForeignKey("dbo.Days", "TourId", "dbo.Tours");
            DropForeignKey("dbo.DayIncludes", "DayId", "dbo.Days");
            DropForeignKey("dbo.Tours", "AdminId", "dbo.Admins");
            DropIndex("dbo.TeamSocials", new[] { "TeamId" });
            DropIndex("dbo.Teams", new[] { "PositionId" });
            DropIndex("dbo.ContactSocials", new[] { "ContactId" });
            DropIndex("dbo.Contacts", new[] { "ContactCityId" });
            DropIndex("dbo.ContactCities", new[] { "ContactCountryId" });
            DropIndex("dbo.UserSocials", new[] { "UserId" });
            DropIndex("dbo.ContactReplies", new[] { "UserId" });
            DropIndex("dbo.Bookings", new[] { "UserId" });
            DropIndex("dbo.Bookings", new[] { "TourId" });
            DropIndex("dbo.Blogs", new[] { "UserId" });
            DropIndex("dbo.Blogs", new[] { "BlogCategoryId" });
            DropIndex("dbo.BlogComments", new[] { "BlogId" });
            DropIndex("dbo.BlogComments", new[] { "UserId" });
            DropIndex("dbo.TourReviews", new[] { "UserId" });
            DropIndex("dbo.TourReviews", new[] { "TourId" });
            DropIndex("dbo.TourImages", new[] { "TourId" });
            DropIndex("dbo.DesToTypes", new[] { "TourTypeId" });
            DropIndex("dbo.DesToTypes", new[] { "DestinationId" });
            DropIndex("dbo.DesToCats", new[] { "TourCategoryId" });
            DropIndex("dbo.DesToCats", new[] { "DestinationId" });
            DropIndex("dbo.TourCities", new[] { "DestinationId" });
            DropIndex("dbo.NotIncludes", new[] { "TourId" });
            DropIndex("dbo.Includes", new[] { "TourId" });
            DropIndex("dbo.DayIncludes", new[] { "DayId" });
            DropIndex("dbo.Days", new[] { "TourId" });
            DropIndex("dbo.Tours", new[] { "TourCityId" });
            DropIndex("dbo.Tours", new[] { "AdminId" });
            DropTable("dbo.Subscriptions");
            DropTable("dbo.TeamSocials");
            DropTable("dbo.Teams");
            DropTable("dbo.Positions");
            DropTable("dbo.Faqs");
            DropTable("dbo.ContactSocials");
            DropTable("dbo.Contacts");
            DropTable("dbo.ContactCountries");
            DropTable("dbo.ContactCities");
            DropTable("dbo.UserSocials");
            DropTable("dbo.ContactReplies");
            DropTable("dbo.Bookings");
            DropTable("dbo.BlogCategories");
            DropTable("dbo.Blogs");
            DropTable("dbo.BlogComments");
            DropTable("dbo.Users");
            DropTable("dbo.TourReviews");
            DropTable("dbo.TourImages");
            DropTable("dbo.TourTypes");
            DropTable("dbo.DesToTypes");
            DropTable("dbo.TourCategories");
            DropTable("dbo.DesToCats");
            DropTable("dbo.Destinations");
            DropTable("dbo.TourCities");
            DropTable("dbo.NotIncludes");
            DropTable("dbo.Includes");
            DropTable("dbo.DayIncludes");
            DropTable("dbo.Days");
            DropTable("dbo.Tours");
            DropTable("dbo.Admins");
            DropTable("dbo.Abouts");
        }
    }
}
