namespace SetSail.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tours", "DepartureTime", c => c.Time(precision: 7));
            AlterColumn("dbo.Tours", "ReturnTime", c => c.Time(precision: 7));
            AlterColumn("dbo.Tours", "CreatedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tours", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tours", "ReturnTime", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Tours", "DepartureTime", c => c.Time(nullable: false, precision: 7));
        }
    }
}
