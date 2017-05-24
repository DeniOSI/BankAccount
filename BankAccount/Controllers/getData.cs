using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BankAccount.Models;
using System.Data.Entity;

namespace BankAccount.Controllers
{
    
    public class getData
    {
         
        public static User getWorker(int id)
        {
            using (BankaccountContext _db = new BankaccountContext())
            {
                return _db.Users.Find(id);
            }
        }
    }
}