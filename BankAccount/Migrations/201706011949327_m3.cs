namespace BankAccount.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "AccountId", "dbo.Accounts");
            DropIndex("dbo.Users", new[] { "AccountId" });
            AlterColumn("dbo.Users", "AccountId", c => c.Int());
            CreateIndex("dbo.Users", "AccountId");
            AddForeignKey("dbo.Users", "AccountId", "dbo.Accounts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "AccountId", "dbo.Accounts");
            DropIndex("dbo.Users", new[] { "AccountId" });
            AlterColumn("dbo.Users", "AccountId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "AccountId");
            AddForeignKey("dbo.Users", "AccountId", "dbo.Accounts", "Id", cascadeDelete: true);
        }
    }
}
