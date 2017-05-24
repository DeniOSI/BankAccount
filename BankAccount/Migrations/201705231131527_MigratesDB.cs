namespace BankAccount.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigratesDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Currencies", "Cur", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Currencies", "Cur");
        }
    }
}
