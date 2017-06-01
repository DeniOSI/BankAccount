using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

using BankAccount.Models;

namespace BankAccount.Controllers
{    [Authorize]
    public class UserPrintController : Controller
    {

        // GET: User
        BankaccountContext _db ;
        [Authorize]
        [HttpGet]
        public ActionResult Index(int mod)
        {
            int gid;
            if(User.Identity.IsAuthenticated)
            {
                if(User.Identity.Name == "root")
                {
                   return RedirectToAction("AdminList", "Control");
                }
                if(UserIdent(User.Identity.Name, mod, out gid))
                {
                    using (_db = new Models.BankaccountContext())
                    {
                        var user = _db.Users.Include(u => u.Account).Include(o => o.Account.Operations).Include(c => c.Account.Currency).Where(u => u.Id == mod).FirstOrDefault();
                        // var operation
                        foreach (var item in user.Account.Operations)
                        {
                            item.Money = Math.Round(item.Money, 2);
                        }
                        user.Account.Money = Math.Round(user.Account.Money, 2);
                        return View(user);
                    }
                }
                else
                {
                    using (_db = new Models.BankaccountContext())
                    {
                        var user = _db.Users.Include(u => u.Account).Include(o => o.Account.Operations).Include(c => c.Account.Currency).Where(u => u.Id == gid).FirstOrDefault();
                        // var operation
                        foreach (var item in user.Account.Operations)
                        {
                            item.Money = Math.Round(item.Money, 2);
                        }
                        user.Account.Money = Math.Round(user.Account.Money, 2);
                        return View(user);
                    }
                }
            }
            return RedirectToAction("Login", "Account");
            
         
        }

        private bool UserIdent(string name, int mod, out int gid)
        {
            int gId;
            using (BankaccountContext _db = new BankaccountContext())
            {
               gId = _db.Users.Where(u => u.Login == name).Select(u => u.Id).FirstOrDefault();
                
            }
            gid = gId;
            return gId == mod;
        }

        [Authorize]
        public ActionResult Index(User user)
        {
           
            return View(user);
        }
    }
}