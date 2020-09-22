namespace SetSail.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dateid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "DateId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "DateId");
        }
    }
}
