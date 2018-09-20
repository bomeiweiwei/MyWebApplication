using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AllShowMVCApplication.Models;

namespace AllShowMVCApplication.Controllers
{
    public class ShopController : Controller
    {
        private AllShowEntities db = new AllShowEntities();

        //
        // GET: /Shop/

        public ActionResult Index()
        {
            var shops = db.SHOPs.Include(s => s.EMPLOYEE).Include(s => s.SHCLASS);
            return View(shops.ToList());
        }

        //
        // GET: /Shop/Details/5

        public ActionResult Details(int id)
        {
            SHOP shop = db.SHOPs.Find(id);
            if (shop == null)
            {
                return HttpNotFound();
            }
            return View(shop);
        }

        //
        // GET: /Shop/Create

        public ActionResult Create()
        {
            ViewBag.empno = new SelectList(db.EMPLOYEEs, "empno", "empname");
            ViewBag.shclassno = new SelectList(db.SHCLASSes, "shclassno", "shclassname");
            return View();
        }

        //
        // POST: /Shop/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SHOP shop)
        {
            if (ModelState.IsValid)
            {
                db.SHOPs.Add(shop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.empno = new SelectList(db.EMPLOYEEs, "empno", "empname", shop.empno);
            ViewBag.shclassno = new SelectList(db.SHCLASSes, "shclassno", "shclassname", shop.shclassno);
            return View(shop);
        }

        //
        // GET: /Shop/Edit/5

        public ActionResult Edit(int id)
        {
            SHOP shop = db.SHOPs.Find(id);
            if (shop == null)
            {
                return HttpNotFound();
            }
            ViewBag.empno = new SelectList(db.EMPLOYEEs, "empno", "empname", shop.empno);
            ViewBag.shclassno = new SelectList(db.SHCLASSes, "shclassno", "shclassname", shop.shclassno);
            return View(shop);
        }

        //
        // POST: /Shop/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SHOP shop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.empno = new SelectList(db.EMPLOYEEs, "empno", "empname", shop.empno);
            ViewBag.shclassno = new SelectList(db.SHCLASSes, "shclassno", "shclassname", shop.shclassno);
            return View(shop);
        }

        //
        // GET: /Shop/Delete/5

        public ActionResult Delete(int id)
        {
            SHOP shop = db.SHOPs.Find(id);
            if (shop == null)
            {
                return HttpNotFound();
            }
            return View(shop);
        }

        //
        // POST: /Shop/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SHOP shop = db.SHOPs.Find(id);
            db.SHOPs.Remove(shop);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}