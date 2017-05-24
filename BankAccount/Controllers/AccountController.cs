using BankAccount.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BankAccount.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "UserPrint", new { mod = getUserID(User.Identity.Name) });
            }
            return View();
        }

        private object getUserID(string name)
        {

            int gId;
            using (BankaccountContext _db = new BankaccountContext())
            {
                gId = _db.Users.Where(u => u.Login == name).Select(u => u.Id).FirstOrDefault();
            }
            return gId;
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel modl, string returnUrl)
        {
          
            if(ModelState.IsValid)
            {
                if (ValidateUser(modl.Login, modl.Password))
                {
                    FormsAuthentication.SetAuthCookie(modl.Login, modl.Remember);
                    //if (Url.IsLocalUrl(returnUrl))
                    //{
                    //    return Redirect(returnUrl);
                    //}
                    //else {
                         
                        return RedirectToAction("Index", "UserPrint", new {mod = getId(modl)});
                    //}
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный пароль или логин");
                }
                }
           
            return View(modl);
        }

        private int getId(LoginViewModel modl)
        {
            int gId;
            using (BankaccountContext _db = new BankaccountContext())
            {
                gId = _db.Users.Where(u => u.Login == modl.Login && u.Password == modl.Password).Select(u=>u.Id).FirstOrDefault();
            }
            return gId;
        }


        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        private bool ValidateUser(string login, string password)
        {
            using(BankaccountContext _db = new BankaccountContext())
            {
               
                    var pass = _db.Users.Where(u => u.Password == password & u.Login == login).FirstOrDefault();
                if (pass != null)
                {
                   
                    return true;
                }
                else
                {
                  
                    return false;
                }  
              
            }
        }
    }
}