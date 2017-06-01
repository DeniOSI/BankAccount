using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankAccount.Models;

namespace BankAccount.Controllers
{
    public class CreateController : Controller
    {
        BankaccountContext db = new BankaccountContext();
        // GET: Create
        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            var ls = new SelectList(db.Currencys, "Id", "Name");
            
            ViewBag.CurrencyId = ls ;
            User user = new Models.User();
            return View(user);
        }

        [HttpPost]
        public ActionResult Create(User model)
        {

           var i = ModelState.IsValid;

            using (BankaccountContext _db = new BankaccountContext())
            {
                model.DateRegistration = DateTime.Now;
                _db.Users.Add(model);
                _db.SaveChanges();


            }
            ////  }
            return View();
        }
    }
}