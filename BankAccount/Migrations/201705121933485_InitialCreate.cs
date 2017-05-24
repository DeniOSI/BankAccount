namespace BankAccount.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Money = c.Double(nullable: false),
                        NumberAccount = c.Int(nullable: false),
                        TypeAccountId = c.Int(nullable: false),
                        CurrencyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currencies", t => t.CurrencyId, cascadeDelete: true)
                .ForeignKey("dbo.TypeAccounts", t => t.TypeAccountId, cascadeDelete: true)
                .Index(t => t.TypeAccountId)
                .Index(t => t.CurrencyId);
            
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Operations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Data = c.DateTime(nullable: false),
                        Money = c.Double(nullable: false),
                        NumberAccount = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.TypeAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Login = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 50),
                        Passport = c.String(nullable: false, maxLength: 30),
                        INN = c.Int(nullable: false),
                        Bday = c.DateTime(nullable: false),
                        DateRegistration = c.DateTime(nullable: false),
                        UserTypeId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.UserTypes", t => t.UserTypeId, cascadeDelete: true)
                .Index(t => t.UserTypeId)
                .Index(t => t.RoleId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserTypeId", "dbo.UserTypes");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Users", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "TypeAccountId", "dbo.TypeAccounts");
            DropForeignKey("dbo.Operations", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "CurrencyId", "dbo.Currencies");
            DropIndex("dbo.Users", new[] { "AccountId" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Users", new[] { "UserTypeId" });
            DropIndex("dbo.Operations", new[] { "AccountId" });
            DropIndex("dbo.Accounts", new[] { "CurrencyId" });
            DropIndex("dbo.Accounts", new[] { "TypeAccountId" });
            DropTable("dbo.UserTypes");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.TypeAccounts");
            DropTable("dbo.Operations");
            DropTable("dbo.Currencies");
            DropTable("dbo.Accounts");
        }
    }
}
