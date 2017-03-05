namespace Assignment2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Visitor : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: true));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: true));
            DropTable("dbo.Passwords");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Passwords",
                c => new
                    {
                        PasswordID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: true),
                        BirthYear = c.String(nullable: true),
                        Color = c.String(nullable: true),
                    })
                .PrimaryKey(t => t.PasswordID);
            
            AlterColumn("dbo.Users", "LastName", c => c.String());
            AlterColumn("dbo.Users", "FirstName", c => c.String());
        }
    }
}
