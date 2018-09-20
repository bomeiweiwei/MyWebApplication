using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MVCStudy.Models;
using MVCStudy.Models.ViewModels;
using PagedList;
using System.IO;
using System.Data.Entity;

namespace MVCStudy.Controllers
{
    public class ShClassShopController : Controller
    {
        AllShowEntities db = new AllShowEntities();
        int pageSize = 5;

        // GET: ShClassShop
        public ActionResult Index(int shclassno = 1,int page = 1)
        {           
            int currentPage = page < 1 ? 1 : page;
            ViewBag.shclassno = shclassno;

            var shopsResult = db.SHOPs.Where(m => m.shclassno == shclassno).OrderBy(m => m.shno).ToList().ToPagedList(currentPage, pageSize);

            ViewBag.shclassName = db.SHCLASSes.Where(m => m.shclassno == shclassno).FirstOrDefault().shclassname;
            ShClassShopViewModel shClassShop = new ShClassShopViewModel()
            {
                shClasses = db.SHCLASSes.OrderBy(m => m.shclassno).ToList(),
                shops = shopsResult,//db.SHOPs.Where(m => m.shclassno == shclassno).ToList()
                SHOPs= shopsResult
            };
            
            return View(shClassShop);
        }

        public ActionResult Create()
        {
            var emps = db.EMPLOYEEs;
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var emp in emps)
            {
                items.Add(new SelectListItem()
                {
                    Text = emp.empname,
                    Value = emp.empno.ToString(),
                    Selected = emp.empno.Equals(1)
                });
            }

            ViewBag.empList = items;//new SelectList(db.EMPLOYEEs, "empno", "empname");
            return View(db.SHCLASSes.ToList());
        }

        [HttpPost]
        public ActionResult Create(SHOP shop, HttpPostedFileBase file)
        {
            try
            {
                if (file != null)
                {
                    if (file.ContentLength > 0)
                    {
                        DateTime d = DateTime.Now;
                        string filename = String.Format("{0:yyyyMMddHHmmss}", d).ToString() + ".jpg";
                        var path = Path.Combine(Server.MapPath("~/images/FileUpLoads"), filename);
                        file.SaveAs(path);

                        shop.shlogopic = "FileUpLoads/" + filename;
                    }
                }

                db.SHOPs.Add(shop);
                db.SaveChanges();
                return RedirectToAction("Index", new { shclassno = shop.shclassno });
            }
            catch (Exception)
            { }
            return View(shop);
        }

        public ActionResult Delete(int shno)
        {
            var shop = db.SHOPs.Where(m => m.shno == shno).FirstOrDefault();
            db.SHOPs.Remove(shop);
            db.SaveChanges();
            return RedirectToAction("Index", new { shclassno = shop.shclassno });
        }

        public ActionResult Edit(int shno)
        {
            var shop = db.SHOPs.Where(m => m.shno == shno).FirstOrDefault();
            ViewBag.empno = new SelectList(db.EMPLOYEEs, "empno", "empname", shop.empno);
            ViewBag.shclassno = new SelectList(db.SHCLASSes, "shclassno", "shclassname", shop.shclassno);
            return View(shop); 
        }

        [HttpPost]
        public ActionResult Edit(SHOP shop, HttpPostedFileBase file)
        {
            ViewBag.empno = new SelectList(db.EMPLOYEEs, "empno", "empname", shop.empno);
            ViewBag.shclassno = new SelectList(db.SHCLASSes, "shclassno", "shclassname", shop.shclassno);
            if (shop.shpwd == null)
            {
                ViewBag.ErrMsg = "請填密碼";
                return View(shop);
            }
            else if (ModelState.IsValid)
            {
                db.Entry(shop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { shclassno = shop.shclassno });
            }
            return View(shop);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}