using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using BankAccount.Models;
using System.Threading.Tasks;

namespace BankAccount.Controllers
{
    public class EditController : Controller
    {
        // GET: Edit
        public async Task<ActionResult>  Edit(int id)
        {
            User user;
            using (BankaccountContext _db = new BankaccountContext())
            {
                user = await _db.Users.Include(u => u.Account).Include(u => u.Account.Currency).
                    Include(o => o.Account.Operations).FirstOrDefaultAsync(u => u.Id == id);
            }
                return View(user);
        }

        [HttpGet]
        public async Task<ActionResult> EditUser(int id)
        {
            User user;
            using (BankaccountContext _db = new BankaccountContext())
            {
                user = await _db.Users.FindAsync(id);
            }
            return View(user);
         }
        [HttpPost]
        public async Task<ActionResult> EditUser(User model)
        {
            if(ModelState.IsValid)
            { 
            using (BankaccountContext _db = new BankaccountContext())
            {
                    _db.Entry(model).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                    return RedirectToAction("Edit", "Edit", new { id = model.Id });
            }
             
            }
            ModelState.AddModelError("", "Модель не вадидна");
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> EditCourseAsync()
        {
            ICollection<Currency> currency;
            using (BankaccountContext db = new BankaccountContext())
            {
                currency = await db.Currencys.ToListAsync();
            }
            return View(currency);
        }
        [HttpPost]
        public async Task<ActionResult> EditCourseAsync(Currency currency)
        {
            using (BankaccountContext db = new BankaccountContext())
            {
                db.Entry(currency).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("EditCourseAsync", "Edit");
            }
        //    return View(currency);
        }
    }
}