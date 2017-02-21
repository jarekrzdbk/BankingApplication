namespace BankingApplication.Api.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMessageField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "Message", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "Message");
        }
    }
}
