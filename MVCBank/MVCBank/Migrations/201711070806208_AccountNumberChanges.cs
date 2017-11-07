namespace MVCBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccountNumberChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CheckAccounts", "AccountNumber", c => c.String(nullable: false, maxLength: 10, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CheckAccounts", "AccountNumber", c => c.String(nullable: false));
        }
    }
}
