namespace SetSail.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usersoc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserSocials", "Icon", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserSocials", "Icon");
        }
    }
}
