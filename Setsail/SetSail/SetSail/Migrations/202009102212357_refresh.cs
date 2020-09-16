namespace SetSail.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refresh : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tours", "DepartureTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Tours", "ReturnTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tours", "ReturnTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tours", "DepartureTime", c => c.DateTime(nullable: false));
        }
    }
}
