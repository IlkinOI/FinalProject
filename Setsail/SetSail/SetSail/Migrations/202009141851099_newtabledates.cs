namespace SetSail.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtabledates : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TourDates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateFrom = c.DateTime(nullable: false),
                        DateTo = c.DateTime(nullable: false),
                        TourId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tours", t => t.TourId, cascadeDelete: true)
                .Index(t => t.TourId);
            
            DropColumn("dbo.Tours", "DateFrom");
            DropColumn("dbo.Tours", "DateTo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tours", "DateTo", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tours", "DateFrom", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.TourDates", "TourId", "dbo.Tours");
            DropIndex("dbo.TourDates", new[] { "TourId" });
            DropTable("dbo.TourDates");
        }
    }
}
