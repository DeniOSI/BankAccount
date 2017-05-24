using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BankAccount.Models
{
    public class ContentDB: DropCreateDatabaseAlways<BankaccountContext>
    {
        protected override void Seed(BankaccountContext db)
        {
            db.UserTypes.AddRange(new List<UserType>() { new UserType {Id =1,  Name = "VIP" }, new UserType {Id = 2, Name = "Gold" }, new UserType {Id =3, Name = "Обычный" } });
            db.Currencys.AddRange(new List<Currency>() { new Currency {Id = 1, Name = "Доллары" }, new Currency { Id = 2, Name = "Гривны" }, new Currency {Id=3, Name = "Рубли" }, new Currency {Id = 4, Name = "Евро" } });
            db.TypeAccounts.AddRange(new List<TypeAccount> { new TypeAccount { Id =1, Name = "Дебитный" }, new TypeAccount {Id =2, Name = "Кредитный" } });
            db.Roles.AddRange(new List<Role>() { new Role { Id = 1, Name = "Admin" }, new Role {Id = 2, Name = "Client" } });
            db.Accounts.Add(new Account { Name = "MyAccount", CurrencyId = 1, Money = 5999.23, NumberAccount = 668581, TypeAccountId = 2 });
            db.Users.Add(new User { Name = "John Smith", Login = "Admin", Password = "Admin", Email = "user@gmail.com", Address = "New Vasuki", Phone = "55-44-33", Passport = "KK556622", INN = 585099, Bday = new DateTime(1983, 10, 05), DateRegistration = DateTime.Now, AccountId = 1, RoleId = 1, UserTypeId = 1 });
            base.Seed(db); 
        }
    }
}