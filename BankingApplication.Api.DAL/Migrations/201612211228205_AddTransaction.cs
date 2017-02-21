namespace BankingApplication.Api.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTransaction : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserFrom = c.String(maxLength: 100),
                        UserTo = c.String(maxLength: 100),
                        DateTime = c.DateTime(nullable: false),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserFrom)
                .Index(t => t.UserTo);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Transactions", new[] { "UserTo" });
            DropIndex("dbo.Transactions", new[] { "UserFrom" });
            DropTable("dbo.Transactions");
        }
    }
}
