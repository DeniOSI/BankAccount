using BankAccount.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankAccount.Controllers
{
    public class ControlController : Controller
    {
        // GET: Control
        public ActionResult AdminList()
        {
            if (User.Identity.IsAuthenticated)
            {
                if(User.Identity.Name == "root")
                {
                    ICollection<User> user = new List<User>();
                    using (BankaccountContext _db = new BankaccountContext())
                    {
                        user = _db.Users.ToList();
                    }
                    return View(user);
                }
                return Redirect("Account\\Login");
            }
            return Redirect("Account\\Login");


        }
    }
}