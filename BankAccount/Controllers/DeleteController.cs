using BankAccount.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankAccount.Controllers
{
    public class DeleteController : Controller
    {
        // GET: Delete
        public async System.Threading.Tasks.Task<ActionResult> Delete(int id)
        {
            User tempUser = null;
            using (BankaccountContext db = new BankaccountContext()) { 
                 tempUser = await db.Users.FindAsync(id);
            }
            return View(tempUser);

        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Delete(User model)
        {
            
            using (BankaccountContext db = new BankaccountContext())
            {
                try
                {
                    db.Entry(model).State = System.Data.Entity.EntityState.Deleted;
                    await db.SaveChangesAsync();
                    return RedirectToAction("AdminList", "Control");

                }
                catch (Exception ex)
                {

                    ModelState.AddModelError("", "Ошибка" + ex.Message);
                }
            }
            return View();

        }
    }
}