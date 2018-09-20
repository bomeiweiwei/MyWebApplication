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
    public class ProductController : Controller
    {
        private AllShowEntities db = new AllShowEntities();

        //
        // GET: /Product/

        public ActionResult Index()
        {
            var products = db.PRODUCTs.Include(p => p.PRODUCTCLASS).Include(p => p.SHOP);
            return View(products.ToList());
        }

        //
        // GET: /Product/Details/5

        public ActionResult Details(int id)
        {
            PRODUCT product = db.PRODUCTs.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // GET: /Product/Create

        public ActionResult Create()
        {
            ViewBag.proClassNo = new SelectList(db.PRODUCTCLASSes, "proclassno", "proclassname");
            ViewBag.shNo = new SelectList(db.SHOPs, "shno", "shthepic");
            return View();
        }

        //
        // POST: /Product/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PRODUCT product)
        {
            if (ModelState.IsValid)
            {
                db.PRODUCTs.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.proClassNo = new SelectList(db.PRODUCTCLASSes, "proclassno", "proclassname", product.proClassNo);
            ViewBag.shNo = new SelectList(db.SHOPs, "shno", "shthepic", product.shNo);
            return View(product);
        }

        //
        // GET: /Product/Edit/5

        public ActionResult Edit(int id)
        {
            PRODUCT product = db.PRODUCTs.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.proClassNo = new SelectList(db.PRODUCTCLASSes, "proclassno", "proclassname", product.proClassNo);
            ViewBag.shNo = new SelectList(db.SHOPs, "shno", "shthepic", product.shNo);
            return View(product);
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PRODUCT product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.proClassNo = new SelectList(db.PRODUCTCLASSes, "proclassno", "proclassname", product.proClassNo);
            ViewBag.shNo = new SelectList(db.SHOPs, "shno", "shthepic", product.shNo);
            return View(product);
        }

        //
        // GET: /Product/Delete/5

        public ActionResult Delete(int id)
        {
            PRODUCT product = db.PRODUCTs.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // POST: /Product/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRODUCT product = db.PRODUCTs.Find(id);
            db.PRODUCTs.Remove(product);
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