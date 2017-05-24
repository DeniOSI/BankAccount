using BankAccount.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankAccount.Controllers
{
    public class AccountConfigController : Controller
    {
        // GET: AccountConfig
        [Authorize]
        [HttpGet]
        public ActionResult Index(int id)
        {
            
            return View(getData.getWorker(id));
        }
        [Authorize]
        [HttpPost]
        public ActionResult Index(User model)
        {
            if(ModelState.IsValid)
            {
                using (BankaccountContext _db = new BankaccountContext())
                {
                    _db.Entry(model).State = EntityState.Modified;
                    _db.SaveChanges();
                    return RedirectToAction("Index", "UserPrint", new { mod = model.Id });
                }
            }

            return View(model);
        }
    }
}