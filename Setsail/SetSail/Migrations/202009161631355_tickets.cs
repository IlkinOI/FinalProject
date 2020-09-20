namespace SetSail.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tickets : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TourDates", "TicketsNum", c => c.Byte(nullable: false));
            AlterColumn("dbo.Tours", "CreatedDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Tours", "TicketsNum");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tours", "TicketsNum", c => c.Byte(nullable: false));
            AlterColumn("dbo.Tours", "CreatedDate", c => c.DateTime());
            DropColumn("dbo.TourDates", "TicketsNum");
        }
    }
}
