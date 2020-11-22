namespace SetSail.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbchange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DesToCats", "DestinationId", "dbo.Destinations");
            DropForeignKey("dbo.DesToCats", "TourCategoryId", "dbo.TourCategories");
            DropForeignKey("dbo.DesToTypes", "DestinationId", "dbo.Destinations");
            DropForeignKey("dbo.DesToTypes", "TourTypeId", "dbo.TourTypes");
            DropIndex("dbo.DesToCats", new[] { "DestinationId" });
            DropIndex("dbo.DesToCats", new[] { "TourCategoryId" });
            DropIndex("dbo.DesToTypes", new[] { "DestinationId" });
            DropIndex("dbo.DesToTypes", new[] { "TourTypeId" });
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        ProductCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategoryId, cascadeDelete: true)
                .Index(t => t.ProductCategoryId);
            
            AddColumn("dbo.Tours", "TourCategoryId", c => c.Int());
            AddColumn("dbo.Tours", "TourTypeId", c => c.Int());
            AddColumn("dbo.HomePages", "BestTourName", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.SummerPages", "BestTourName", c => c.String(nullable: false, maxLength: 30));
            CreateIndex("dbo.Tours", "TourCategoryId");
            CreateIndex("dbo.Tours", "TourTypeId");
            AddForeignKey("dbo.Tours", "TourCategoryId", "dbo.TourCategories", "Id");
            AddForeignKey("dbo.Tours", "TourTypeId", "dbo.TourTypes", "Id");
            DropTable("dbo.DesToCats");
            DropTable("dbo.DesToTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DesToTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DestinationId = c.Int(nullable: false),
                        TourTypeId = c.Int(nullable: false),
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
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Products", "ProductCategoryId", "dbo.ProductCategories");
            DropForeignKey("dbo.Tours", "TourTypeId", "dbo.TourTypes");
            DropForeignKey("dbo.Tours", "TourCategoryId", "dbo.TourCategories");
            DropIndex("dbo.Products", new[] { "ProductCategoryId" });
            DropIndex("dbo.Tours", new[] { "TourTypeId" });
            DropIndex("dbo.Tours", new[] { "TourCategoryId" });
            DropColumn("dbo.SummerPages", "BestTourName");
            DropColumn("dbo.HomePages", "BestTourName");
            DropColumn("dbo.Tours", "TourTypeId");
            DropColumn("dbo.Tours", "TourCategoryId");
            DropTable("dbo.Products");
            DropTable("dbo.ProductCategories");
            CreateIndex("dbo.DesToTypes", "TourTypeId");
            CreateIndex("dbo.DesToTypes", "DestinationId");
            CreateIndex("dbo.DesToCats", "TourCategoryId");
            CreateIndex("dbo.DesToCats", "DestinationId");
            AddForeignKey("dbo.DesToTypes", "TourTypeId", "dbo.TourTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DesToTypes", "DestinationId", "dbo.Destinations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DesToCats", "TourCategoryId", "dbo.TourCategories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DesToCats", "DestinationId", "dbo.Destinations", "Id", cascadeDelete: true);
        }
    }
}
