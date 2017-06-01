namespace BankAccount.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accounts", "TypeAccountId", "dbo.TypeAccounts");
            DropIndex("dbo.Accounts", new[] { "TypeAccountId" });
            DropColumn("dbo.Accounts", "TypeAccountId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accounts", "TypeAccountId", c => c.Int(nullable: false));
            CreateIndex("dbo.Accounts", "TypeAccountId");
            AddForeignKey("dbo.Accounts", "TypeAccountId", "dbo.TypeAccounts", "Id", cascadeDelete: true);
        }
    }
}
