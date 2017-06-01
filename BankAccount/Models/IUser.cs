using System;

namespace BankAccount.Models
{
    public interface IUser
    {
      
      //  int? AccountId { get; set; }
        //
        Account Account { get; set; }
        string Address { get; set; }
        DateTime Bday { get; set; }
        string ConfirmPassword { get; set; }
        DateTime DateRegistration { get; set; }
        string Email { get; set; }
      
        int INN { get; set; }
        string Login { get; set; }
        string Name { get; set; }
        string Passport { get; set; }
        string Password { get; set; }
        string Phone { get; set; }
    }
}