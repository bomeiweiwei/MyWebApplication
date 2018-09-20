using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AllShowMVCApplication.Models;
using System.Data.Entity;

using AllShowMVCApplication.Models.ViewModels;

namespace AllShowMVCApplication.Controllers
{
    public class DemoController : Controller
    {
        //
        // GET: /Demo/
        private AllShowEntities db = new AllShowEntities();
        public ActionResult Index()
        {
            ViewData["Message"] = "Hello World";
            return View();
        }

        public ActionResult RedirectWithQueryString()
        {
            return View();
        }

        public ActionResult DemoQueryString(int id, string val)
        {
            ViewBag.id = id;
            ViewBag.val = val;
            return View();
        }

        public ActionResult BasicModelBiding(string name)
        {
            ViewBag.Name = name;
            return View();
        }

        public ActionResult DemoFormCollection(FormCollection form)
        {           
            return View();
        }

        public ActionResult ProcessForm(FormCollection form)
        {
            ViewBag.Name = form["name"];
            ViewBag.Age = form["age"];
            return View();
        }

        public ActionResult PersonModelBinding(AllShowMVCApplication.Models.Person.Person person)
        {
            return View(person);
        }

        public ActionResult MultiPersonModelBinding(AllShowMVCApplication.Models.Person.Person man, AllShowMVCApplication.Models.Person.Person woman)
        {
            ViewBag.ManName = man.Name;
            ViewBag.ManAge = man.Age;

            ViewBag.WomanName = woman.Name;
            ViewBag.WomanAge = woman.Age;

            return View();
        }

        public ActionResult ViewModelBinding()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ViewModelBinding(AllShowMVCApplication.Models.ViewModels.PersonViewModel person)
        {
            return View("ShowViewModelBinding", person);
        }

        public ActionResult SendList()
        {
            using (AllShowEntities context = new AllShowEntities())
            {
                var query = context.PRODUCTs.Where(c => c.shNo == 1);
                ViewBag.products = query.ToList();
                return View();
            }
        }

        public ActionResult DemoInput()
        {
            return View();
        }

        public ActionResult CheckForm(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                TempData["Error"] = "請勿空白";
                return RedirectToAction("DemoInput");
            }

            ViewBag.Name = name;
            return View();
        }

        public ActionResult DemoTempDataProduct()
        {
            using (AllShowEntities context = new AllShowEntities())
            {
                var query = context.PRODUCTs.Where(c => c.shNo == 1);
                TempData["products"] = query.ToList();
                return Redirect("DemoTempDataToKeep");
            }
        }

        public ActionResult DemoTempDataToKeep()
        {
            return View();
        }

        public ActionResult DemoInclude()
        {
            ViewBag.proClassNo = new SelectList(db.PRODUCTCLASSes, "proclassno", "proclassname");
            ViewBag.shNo = db.SHOPs.ToList();// new SelectList(db.SHOPs, "shno", "shname");
            var query = db.PRODUCTs.Include(p => p.PRODUCTCLASS).Include(p => p.SHOP).Where(c => c.shNo == 1);
            return View(query.ToList());
        }

        public ActionResult DemoViewModel()
        {
            return View(
                new AllShowMVCApplication.Models.ViewModels.MemberProductViewModel()
                {
                    MemName="傑糯米林",
                    ProName = "JAVA是簡單的",
                    products=(from p in db.PRODUCTs select p).Take(10).ToList(),
                    members = (from q in db.MEMBERs select q).Take(10).ToList()
                });
        }

        public ActionResult RazorTest()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult ActionTest1()
        {
            return PartialView(db.SHCLASSes.ToList());
        }

        [ChildActionOnly]
        public ActionResult ActionTest2()
        {
            return View(db.SHCLASSes.ToList());
        }

        public ActionResult ControlsTest()
        {
            var shops = db.SHOPs.ToList();
            List<SelectListItem> items = new List<SelectListItem>();
            List<SelectListItem> items2 = new List<SelectListItem>();
            foreach (var shop in shops)
            {
                items.Add(new SelectListItem()
                {
                    Text = shop.shname,
                    Value = shop.shno.ToString()
                });
                items2.Add(new SelectListItem()
                {
                    Text = shop.shname,
                    Value = shop.shno.ToString(),
                    Selected=shop.shno.Equals(3)
                });
            }

            var query = db.SHOPs.Where(c => c.shno == 5);
            SHOP _shop = query.ToList().First<SHOP>();
            var Employees = db.EMPLOYEEs.ToList();
            var ShClasses = db.SHCLASSes.ToList();

            SelectList EmployeeselectList = new SelectList(Employees, "empno", "empname", _shop.empno);
            SelectList ShClassselectList = new SelectList(ShClasses, "shclassno", "shclassname", _shop.shclassno);

            ViewBag.ShopsDDL = items;
            ViewBag.ShopsDDL2 = items2;
            ViewBag.ShopsDDL3 = new SelectList(db.SHOPs, "shno", "shname");
            ViewBag.ShopsDDL4 = new SelectList(db.SHOPs, "shno", "shname", 3);
            ViewBag.shopViewModel = new ShopDDLViewModel()
            {
                Shop = _shop,
                EmployeeList = EmployeeselectList,
                ShClassList = ShClassselectList
            };

            return View(db.Messages.ToList());
        }

        public ActionResult Time()
        {
            var time = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            return Content(time);
        }

        public ActionResult ShopGetAll()
        {
            AllShow db = new AllShow();
            IEnumerable<SHOP> shops = db.GetShop.Get();
            return View(shops.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
