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
    public class AdvertisementController : Controller
    {
        private AllShowEntities db = new AllShowEntities();

        //
        // GET: /Advertisement/

        public ActionResult Index()
        {
            var advertisements = db.ADVERTISEMENTs.Include(a => a.EMPLOYEE).Include(a => a.SHOP);
            return View(advertisements.ToList());
        }

        //
        // GET: /Advertisement/Details/5

        public ActionResult Details(int id)
        {
            ADVERTISEMENT advertisement = db.ADVERTISEMENTs.Find(id);
            if (advertisement == null)
            {
                return HttpNotFound();
            }
            return View(advertisement);
        }

        //
        // GET: /Advertisement/Create

        public ActionResult Create()
        {
            ViewBag.empNo = new SelectList(db.EMPLOYEEs, "empno", "empname");
            ViewBag.shNo = new SelectList(db.SHOPs, "shno", "shthepic");
            return View();
        }

        //
        // POST: /Advertisement/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ADVERTISEMENT advertisement)
        {
            if (ModelState.IsValid)
            {
                db.ADVERTISEMENTs.Add(advertisement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.empNo = new SelectList(db.EMPLOYEEs, "empno", "empname", advertisement.empNo);
            ViewBag.shNo = new SelectList(db.SHOPs, "shno", "shthepic", advertisement.shNo);
            return View(advertisement);
        }

        //
        // GET: /Advertisement/Edit/5

        public ActionResult Edit(int id)
        {
            ADVERTISEMENT advertisement = db.ADVERTISEMENTs.Find(id);
            if (advertisement == null)
            {
                return HttpNotFound();
            }
            ViewBag.empNo = new SelectList(db.EMPLOYEEs, "empno", "empname", advertisement.empNo);
            ViewBag.shNo = new SelectList(db.SHOPs, "shno", "shthepic", advertisement.shNo);
            return View(advertisement);
        }

        //
        // POST: /Advertisement/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ADVERTISEMENT advertisement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(advertisement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.empNo = new SelectList(db.EMPLOYEEs, "empno", "empname", advertisement.empNo);
            ViewBag.shNo = new SelectList(db.SHOPs, "shno", "shthepic", advertisement.shNo);
            return View(advertisement);
        }

        //
        // GET: /Advertisement/Delete/5

        public ActionResult Delete(int id)
        {
            ADVERTISEMENT advertisement = db.ADVERTISEMENTs.Find(id);
            if (advertisement == null)
            {
                return HttpNotFound();
            }
            return View(advertisement);
        }

        //
        // POST: /Advertisement/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ADVERTISEMENT advertisement = db.ADVERTISEMENTs.Find(id);
            db.ADVERTISEMENTs.Remove(advertisement);
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