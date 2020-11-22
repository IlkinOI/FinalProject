namespace SetSail.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class product : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(nullable: false, maxLength: 500),
                        Rating = c.Byte(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ProductId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.UserId);
            
            AddColumn("dbo.Products", "About", c => c.String(nullable: false, maxLength: 250));
            AddColumn("dbo.Products", "Price", c => c.Decimal(nullable: false, storeType: "money"));
            AddColumn("dbo.Products", "Quantity", c => c.Byte(nullable: false));
            AddColumn("dbo.Products", "Code", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Products", "Description", c => c.String(nullable: false, maxLength: 1000));
            AddColumn("dbo.Products", "Information", c => c.String(nullable: false, maxLength: 1000));
            AddColumn("dbo.Products", "Rating", c => c.Byte(nullable: false));
            AddColumn("dbo.Products", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "AdminId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "AdminId");
            AddForeignKey("dbo.Products", "AdminId", "dbo.Admins", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductReviews", "UserId", "dbo.Users");
            DropForeignKey("dbo.ProductReviews", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductImages", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "AdminId", "dbo.Admins");
            DropIndex("dbo.ProductReviews", new[] { "UserId" });
            DropIndex("dbo.ProductReviews", new[] { "ProductId" });
            DropIndex("dbo.ProductImages", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "AdminId" });
            DropColumn("dbo.Products", "AdminId");
            DropColumn("dbo.Products", "CreatedDate");
            DropColumn("dbo.Products", "Rating");
            DropColumn("dbo.Products", "Information");
            DropColumn("dbo.Products", "Description");
            DropColumn("dbo.Products", "Code");
            DropColumn("dbo.Products", "Quantity");
            DropColumn("dbo.Products", "Price");
            DropColumn("dbo.Products", "About");
            DropTable("dbo.ProductReviews");
            DropTable("dbo.ProductImages");
        }
    }
}
