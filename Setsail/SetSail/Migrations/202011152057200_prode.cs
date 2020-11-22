namespace SetSail.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Width", c => c.Decimal(nullable: false, storeType: "money"));
            AddColumn("dbo.Products", "Height", c => c.Decimal(nullable: false, storeType: "money"));
            AddColumn("dbo.Products", "Length", c => c.Decimal(nullable: false, storeType: "money"));
            AddColumn("dbo.Products", "Weight", c => c.Decimal(nullable: false, storeType: "money"));
            DropColumn("dbo.Products", "Information");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Information", c => c.String(nullable: false, maxLength: 1000));
            DropColumn("dbo.Products", "Weight");
            DropColumn("dbo.Products", "Length");
            DropColumn("dbo.Products", "Height");
            DropColumn("dbo.Products", "Width");
        }
    }
}
