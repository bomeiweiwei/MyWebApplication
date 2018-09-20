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
    public class ProductClassController : Controller
    {
        private AllShowEntities db = new AllShowEntities();

        //
        // GET: /ProductClass/

        public ActionResult Index()
        {
            var productclasses = db.PRODUCTCLASSes.Include(p => p.SHOP);
            return View(productclasses.ToList());
        }

        //
        // GET: /ProductClass/Details/5

        public ActionResult Details(int id)
        {
            PRODUCTCLASS productclass = db.PRODUCTCLASSes.Find(id);
            if (productclass == null)
            {
                return HttpNotFound();
            }
            return View(productclass);
        }

        //
        // GET: /ProductClass/Create

        public ActionResult Create()
        {
            ViewBag.shno = new SelectList(db.SHOPs, "shno", "shthepic");
            return View();
        }

        //
        // POST: /ProductClass/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PRODUCTCLASS productclass)
        {
            if (ModelState.IsValid)
            {
                db.PRODUCTCLASSes.Add(productclass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.shno = new SelectList(db.SHOPs, "shno", "shthepic", productclass.shno);
            return View(productclass);
        }

        //
        // GET: /ProductClass/Edit/5

        public ActionResult Edit(int id)
        {
            PRODUCTCLASS productclass = db.PRODUCTCLASSes.Find(id);
            if (productclass == null)
            {
                return HttpNotFound();
            }
            ViewBag.shno = new SelectList(db.SHOPs, "shno", "shthepic", productclass.shno);
            return View(productclass);
        }

        //
        // POST: /ProductClass/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PRODUCTCLASS productclass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productclass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.shno = new SelectList(db.SHOPs, "shno", "shthepic", productclass.shno);
            return View(productclass);
        }

        //
        // GET: /ProductClass/Delete/5

        public ActionResult Delete(int id)
        {
            PRODUCTCLASS productclass = db.PRODUCTCLASSes.Find(id);
            if (productclass == null)
            {
                return HttpNotFound();
            }
            return View(productclass);
        }

        //
        // POST: /ProductClass/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRODUCTCLASS productclass = db.PRODUCTCLASSes.Find(id);
            db.PRODUCTCLASSes.Remove(productclass);
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