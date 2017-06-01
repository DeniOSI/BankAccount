using BankAccount.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
namespace BankAccount.Controllers
{
    public class OperationsController : Controller
    {
        BankaccountContext _db;
        // GET: Operations
        [HttpGet]
        public ActionResult Pay(int id)
        {
            ViewBag.iid = id;
            return View();
        }
        [HttpPost]
        public ActionResult Pay(Operation model)
        {
            if(ModelState.IsValid)
            {
                double accountMoney = getMoney(model.AccountId);
                if(accountMoney > model.Money)
                {
                    using (_db = new BankaccountContext())
                    {


                        model.Data = DateTime.Now;
                        _db.Operations.Add(model);
                        
                        _db.SaveChanges();

                        dbMinusMoney(model.AccountId, model.Money);// вычитаем деньги с основной суммы
                        setAccCont(model);

                        return RedirectToAction("Index", "UserPrint", new { mod = model.AccountId });
                    }
                }
                ModelState.AddModelError("", "Неправильный пароль или логин");
            }
            return View();
        }

        private void setAccCont(Operation model)
        {
            double conMany=0;
            Account getAcc;
            using (_db = new BankaccountContext())
            {
               getAcc  = _db.Accounts.Where(n => n.NumberAccount == model.NumberAccount).FirstOrDefault();
                if(getAcc != null)
                {
                    conMany = ConvertToMany(model, getAcc);
                    getAcc.Money = getAcc.Money + conMany;
                }

            }
            using (_db = new BankaccountContext()) { 
                _db.Entry(getAcc).State = EntityState.Modified;
                _db.Operations.Add(new Operation { Data = DateTime.Now, Money = conMany, AccountId = getAcc.Id, Name = model.Name, NumberAccount = model.NumberAccount });
                    _db.SaveChanges();
            }

        }

        private double ConvertToMany(Operation model, Account getAcc)
        {
            double money = 1;
            using(_db=new BankaccountContext()) {
                string ac1 = _db.Accounts.Where(a => a.NumberAccount == getAcc.NumberAccount).Select(c => c.Currency.Name).FirstOrDefault();
                string ac2 = _db.Accounts.Where(a => a.Id == model.AccountId).Select(c => c.Currency.Name).FirstOrDefault();
                if (ac1 == ac2)
                 money =     model.Account.Money;
                else if (ac1 == "Гривны" && ac2 == "Доллары")
                    money = model.Money * _db.Currencys.Where(n => n.Name == "Доллары").Select(c => c.Cur).FirstOrDefault();
                else if (ac1 == "Доллары" && ac2 == "Гривны")
                    money = model.Money / _db.Currencys.Where(n => n.Name == "Доллары").Select(c => c.Cur).FirstOrDefault();
            }
            return money;
        }

        private void dbMinusMoney(int accountId, double money)
        {
            using (_db = new BankaccountContext())
            {
               var account =  _db.Accounts.Where(ac => ac.Id == accountId).FirstOrDefault();
                account.Money = account.Money - money;
                _db.Entry(account).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
        }

        private double getMoney(int accountId)
        {
            using (_db = new BankaccountContext())
            {
                return _db.Accounts.Where(ac => ac.Id == accountId).Select(m => m.Money).FirstOrDefault();
            }
        }
    }
}