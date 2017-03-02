namespace Assignment2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        ActivityID = c.Int(nullable: false, identity: true),
                        ActivityName = c.String(),
                        ActivityDate = c.DateTime(nullable: false),
                        IpAddress = c.String(),
                    })
                .PrimaryKey(t => t.ActivityID);
            
            CreateTable(
                "dbo.Passwords",
                c => new
                    {
                        PasswordID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false),
                        BirthYear = c.String(nullable: false),
                        Color = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PasswordID);
            
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        ProgramID = c.Int(nullable: false, identity: true),
                        ProgramName = c.String(),
                    })
                .PrimaryKey(t => t.ProgramID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Password = c.String(),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        EmailUpdates = c.Boolean(nullable: false),
                        ProgramID = c.Int(nullable: false),
                        LoggedIn = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Programs");
            DropTable("dbo.Passwords");
            DropTable("dbo.Activities");
        }
    }
}
