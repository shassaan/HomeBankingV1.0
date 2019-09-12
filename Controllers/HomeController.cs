using HomeBankingV1._0.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeBankingV1._0.Controllers
{
    public class HomeController : Controller
    {
        private readonly bankingEntities _db = new bankingEntities();
        public ActionResult Index()
        {
            var user = _db.USERs.FirstOrDefault();
            var accounts = _db.accounts.Where(u => u.uid == user.uid).ToList();
            var deposits = _db.deposits.Where(u => u.u_id == user.uid).ToList();
            var expenses = _db.expenses.ToList();

            MainPageViewModel mainPageViewModel = new MainPageViewModel();
            mainPageViewModel.accounts = accounts;
            mainPageViewModel.user = user;
            mainPageViewModel.deposits = deposits;
            mainPageViewModel.espenses = expenses;


            return View(mainPageViewModel);
        }

        public ActionResult GetExpenseReport(string criteria)
        {
            ArrayList mainrray = new ArrayList();
            ArrayList title = new ArrayList();
            title.Add("Day");
            title.Add("Expense");
            mainrray.Add(title);
            if (criteria.Equals("day"))
            {
                var expenses = _db.expenses.ToList();

                foreach (var expense in expenses)
                {
                    var arr = new ArrayList();
                    arr.Add($"{expense.date.Value.Day} {expense.date.Value.ToString("MMMM")} ");
                    arr.Add(expense.amount);
                    mainrray.Add(arr);
                }
            }

            return Json(mainrray,JsonRequestBehavior.AllowGet);
        }

        public ActionResult Transfer()
        {
            MainPageViewModel mainPageViewModel = new MainPageViewModel();
            var user = _db.USERs.FirstOrDefault();
            var accounts = _db.accounts.Where(u => u.uid == user.uid).ToList();
            mainPageViewModel.accounts = accounts;
            mainPageViewModel.user = user;
            return View(mainPageViewModel);
        }

        [HttpPost]
        public ActionResult SaveAccountDetails(accountDetail accountDetail)
        {
            int dest = int.Parse(accountDetail.destination), origin = int.Parse(accountDetail.originate);
            var acc = _db.accounts.Where(a => a.aid == dest).FirstOrDefault();
            var accO = _db.accounts.Where(a => a.aid == origin).FirstOrDefault();

            acc.balance = acc.balance + accountDetail.import;
            
            _db.Entry(acc).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();

            accountDetail.balance = acc.balance;
            accountDetail.destination = acc.ano;
            accountDetail.originate = accO.ano;
            accountDetail.aid = acc.aid;
            accountDetail.transType = true;
            _db.accountDetails.Add(accountDetail);

            _db.SaveChanges();


            accO.balance = accO.balance - accountDetail.import;
            _db.Entry(accO).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
            accountDetail.balance = accO.balance;
            accountDetail.destination = acc.ano;
            accountDetail.originate = accO.ano;
            accountDetail.aid = accO.aid;
            accountDetail.transType = false;
            _db.accountDetails.Add(accountDetail);

            _db.SaveChanges();
            
            return Json("");
        } 

        public ActionResult GetAccounDetailsOf(string type,int id)
        {
            if (type.Equals("Income"))
            {
                MainPageViewModel mainPageViewModel = new MainPageViewModel();
                mainPageViewModel.account = _db.accounts.Where(a => a.aid == id).FirstOrDefault();
                mainPageViewModel.accounts = _db.accounts.ToList();
                mainPageViewModel.user = _db.USERs.FirstOrDefault();
                mainPageViewModel.accountDetails = _db.accountDetails.Where(s => s.aid == id && s.transType == true).ToList();
                return View("Account", mainPageViewModel);
            }
            else if (type.Equals("Expense"))
            {
                MainPageViewModel mainPageViewModel = new MainPageViewModel();
                mainPageViewModel.account = _db.accounts.Where(a => a.aid == id).FirstOrDefault();
                mainPageViewModel.accounts = _db.accounts.ToList();
                mainPageViewModel.user = _db.USERs.FirstOrDefault();
                mainPageViewModel.accountDetails = _db.accountDetails.Where(s => s.aid == id && s.transType == false).ToList();
                return View("Account", mainPageViewModel);
            }
            else
            {
                MainPageViewModel mainPageViewModel = new MainPageViewModel();
                mainPageViewModel.account = _db.accounts.Where(a => a.aid == id).FirstOrDefault();
                mainPageViewModel.accounts = _db.accounts.ToList();
                mainPageViewModel.user = _db.USERs.FirstOrDefault();
                mainPageViewModel.accountDetails = _db.accountDetails.Where(s => s.aid == id).ToList();
                return View("Account", mainPageViewModel);
            }
           
        }

        public ActionResult Account(int id)
        {
            MainPageViewModel mainPageViewModel = new MainPageViewModel();
            mainPageViewModel.account =  _db.accounts.Where(a => a.aid == id).FirstOrDefault();
            mainPageViewModel.accounts = _db.accounts.ToList();
            mainPageViewModel.user = _db.USERs.FirstOrDefault();
            mainPageViewModel.accountDetails = _db.accountDetails.Where(s => s.aid == id).ToList();
            return View(mainPageViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}