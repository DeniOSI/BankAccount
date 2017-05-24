using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BankAccount.Models
{
    public class BankaccountContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Currency> Currencys { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<TypeAccount> TypeAccounts { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public BankaccountContext() : base("BankAccountDB")
        {

        }
    }
}