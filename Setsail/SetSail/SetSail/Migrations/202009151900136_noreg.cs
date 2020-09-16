namespace SetSail.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noreg : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tours", "DepartureTime", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Tours", "ReturnTime", c => c.Time(nullable: false, precision: 7));
            DropColumn("dbo.Users", "IsRegistered");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "IsRegistered", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tours", "ReturnTime", c => c.Time(precision: 7));
            AlterColumn("dbo.Tours", "DepartureTime", c => c.Time(precision: 7));
        }
    }
}
