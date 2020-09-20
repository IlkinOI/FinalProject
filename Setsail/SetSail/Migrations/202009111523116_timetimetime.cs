namespace SetSail.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class timetimetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tours", "DateFrom", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Tours", "DateTo", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tours", "DateTo", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tours", "DateFrom", c => c.DateTime(nullable: false));
        }
    }
}
