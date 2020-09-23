namespace SetSail.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usls : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserSocials", "UserId", "dbo.Users");
            DropIndex("dbo.UserSocials", new[] { "UserId" });
            DropTable("dbo.UserSocials");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserSocials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Icon = c.String(nullable: false, maxLength: 30),
                        Link = c.String(nullable: false, maxLength: 250),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.UserSocials", "UserId");
            AddForeignKey("dbo.UserSocials", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
