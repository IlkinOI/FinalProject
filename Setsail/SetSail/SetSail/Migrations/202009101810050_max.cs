namespace SetSail.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class max : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WinePages", "PopText1", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.WinePages", "PopText2", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.WinePages", "PopText3", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.WinePages", "PopText4", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WinePages", "PopText4", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.WinePages", "PopText3", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.WinePages", "PopText2", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.WinePages", "PopText1", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
