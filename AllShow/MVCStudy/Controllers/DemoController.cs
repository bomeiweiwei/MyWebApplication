using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStudy.Models;

using System.Data.Entity;

using MVCStudy.Models.ViewModels;
using System.IO;

namespace MVCStudy.Controllers
{
    public class DemoController : Controller
    {
        private AllShowEntities db = new AllShowEntities();
        // GET: Demo
        public ActionResult Index()
        {
            return View();
        }

        public string ShowArr()
        {
            int[] arr = new int[] { 55, 66, 33, 44, 11 };
            string numStr = "陣列值:<br/>";
            foreach (int num in arr)
            {
                numStr += num + "<br/>";
            }

            int index = 0;
            var result = arr.OrderByDescending(m => m);
            numStr += "遞減排序 : ";
            foreach (var m in result)
            {
                numStr += m;
                index++;
                if (index <= result.Count() - 1)
                {
                    numStr += ",";
                }
            }
            numStr += "<br/>平均:"+result.Average();
            return numStr;
        }

        public string ShowImages()
        {
            string imgStr = "";
            for (int i = 0; i < 8; i++)
            {
                imgStr += String.Format("<img src='../images/{0}.jpg' width='60'>", i);
            }
            return imgStr;
        }

        public ActionResult DemoViewData()
        {
            ViewData["name"] = "Bruce";
            ViewData["data"] = "Bruce5566";
            return View();
        }

        public ActionResult DemoViewBag()
        {
            ViewBag.Name = "Bruce";
            return View();
        }

        public ActionResult DemoViewData_Model1()
        {
            ViewData["messages"] = db.Messages.ToList();
            return View();
        }

        public ActionResult DemoViewData_Model2()
        {
            var products = db.Messages.ToList();
            ViewData.Model = products;
            return View();
        }

        public ActionResult DemoViewDataModel()
        {
            return View(db.Messages.ToList());
        }

        public ActionResult DemoViewBag_Model()
        {
            ViewBag.messages = db.Messages.ToList();
            return View();
        }

        public ActionResult DemoTempData()
        {
            TempData["name"] = "Bruce";
            return View();
        }

        public ActionResult DemoData()
        {
            return View();
        }

        public ActionResult DemoRouteData(int id)
        {
            ViewBag.id = id;
            return View();
        }

        public ActionResult DemoRouteData2(int id, string name)
        {
            ViewBag.id = id;
            ViewBag.name = name;
            return View();
        }

        public ActionResult DemoForm()
        {            
            return View();
        }

        public ActionResult DemoProcessForm(string name)
        {
            ViewBag.name = name;
            return View();
        }

        public ActionResult DemoProcessFormCollection(FormCollection form)
        {
            ViewBag.Name = form["name"];
            ViewBag.Age = form["age"];
            return View();
        }

        public ActionResult DemoInput()
        {
            return View();
        }

        public ActionResult CheckInput(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                TempData["error"] = "不能為空白";
                return RedirectToAction("DemoInput");
            }

            ViewBag.name = name;
            return View();
        }

        public ActionResult DemoTempDataProduct()
        {
            var query = db.PRODUCTs;
            TempData["products"] = query.ToList();
            return Redirect("DemoTempDataToKeep");
        }

        public ActionResult DemoTempDataToKeep()
        {
            var products = TempData["products"] as List<PRODUCT>;
            var query= products.Where(c => c.shNo == 1);
            TempData["product"] = query.ToList();
            return View();
        }

        public ActionResult DemoInclude()
        {
            ViewBag.proClassNo = new SelectList(db.PRODUCTCLASSes, "proclassno", "proclassname");
            var query = db.PRODUCTs.Include(p => p.PRODUCTCLASS).Include(p => p.SHOP).Where(c => c.shNo == 1);
            return View(query.ToList());
        }

        public ActionResult DemoViewModel()
        {
            ShopProductclassViewModel spc = new ShopProductclassViewModel();
            spc.shno = 1;
            spc.Shop = db.SHOPs.ToList();
            spc.Product = db.PRODUCTs.Where(c => c.shNo == 1).ToList();
            spc.ProductClass = db.PRODUCTCLASSes.Where(c => c.shno == 1).ToList();
            return View(spc);
        }

        public ActionResult DemoFormUseModel()
        {
            ShopProductclassViewModel spc = new ShopProductclassViewModel();
            spc.Shop = db.SHOPs.ToList();
            return View(spc);
        }

        [HttpPost]
        public ActionResult DemoProcessFormUseModel(ShopProductclassViewModel spc)
        {
            spc.Shop = db.SHOPs.ToList();
            spc.Product = db.PRODUCTs.Where(c => c.shNo == spc.shno).ToList();
            spc.ProductClass = db.PRODUCTCLASSes.Where(c => c.shno == spc.shno).ToList();
            return View(spc);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}