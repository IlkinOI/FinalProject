namespace SetSail.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class des : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HomePages", "Destination1", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.HomePages", "Destination2", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.HomePages", "Destination3", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HomePages", "Destination3");
            DropColumn("dbo.HomePages", "Destination2");
            DropColumn("dbo.HomePages", "Destination1");
        }
    }
}
