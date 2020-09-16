namespace SetSail.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class frontpic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tours", "FrontImage", c => c.String(maxLength: 250));
            AlterColumn("dbo.Tours", "DateFrom", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tours", "DateTo", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tours", "DateTo", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Tours", "DateFrom", c => c.DateTime(precision: 7, storeType: "datetime2"));
            DropColumn("dbo.Tours", "FrontImage");
        }
    }
}
