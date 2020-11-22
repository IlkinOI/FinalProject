namespace SetSail.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nulle : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tours", "TourCategoryId", "dbo.TourCategories");
            DropForeignKey("dbo.Tours", "TourTypeId", "dbo.TourTypes");
            DropIndex("dbo.Tours", new[] { "TourCategoryId" });
            DropIndex("dbo.Tours", new[] { "TourTypeId" });
            AlterColumn("dbo.Tours", "TourCategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Tours", "TourTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tours", "TourCategoryId");
            CreateIndex("dbo.Tours", "TourTypeId");
            AddForeignKey("dbo.Tours", "TourCategoryId", "dbo.TourCategories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tours", "TourTypeId", "dbo.TourTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tours", "TourTypeId", "dbo.TourTypes");
            DropForeignKey("dbo.Tours", "TourCategoryId", "dbo.TourCategories");
            DropIndex("dbo.Tours", new[] { "TourTypeId" });
            DropIndex("dbo.Tours", new[] { "TourCategoryId" });
            AlterColumn("dbo.Tours", "TourTypeId", c => c.Int());
            AlterColumn("dbo.Tours", "TourCategoryId", c => c.Int());
            CreateIndex("dbo.Tours", "TourTypeId");
            CreateIndex("dbo.Tours", "TourCategoryId");
            AddForeignKey("dbo.Tours", "TourTypeId", "dbo.TourTypes", "Id");
            AddForeignKey("dbo.Tours", "TourCategoryId", "dbo.TourCategories", "Id");
        }
    }
}
