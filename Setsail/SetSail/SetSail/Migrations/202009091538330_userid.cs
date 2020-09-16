namespace SetSail.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "UserId", "dbo.Users");
            DropIndex("dbo.Bookings", new[] { "UserId" });
            AlterColumn("dbo.Bookings", "UserId", c => c.Int());
            CreateIndex("dbo.Bookings", "UserId");
            AddForeignKey("dbo.Bookings", "UserId", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "UserId", "dbo.Users");
            DropIndex("dbo.Bookings", new[] { "UserId" });
            AlterColumn("dbo.Bookings", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Bookings", "UserId");
            AddForeignKey("dbo.Bookings", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
