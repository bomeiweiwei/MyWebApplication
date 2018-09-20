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
    public class ShClassController : Controller
    {
        private AllShowEntities db = new AllShowEntities();

        //
        // GET: /ShClass/

        public ActionResult Index()
        {
            return View(db.SHCLASSes.ToList());
        }

        //
        // GET: /ShClass/Details/5

        public ActionResult Details(int id)
        {
            SHCLASS shclass = db.SHCLASSes.Find(id);
            if (shclass == null)
            {
                return HttpNotFound();
            }
            return View(shclass);
        }

        //
        // GET: /ShClass/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ShClass/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SHCLASS shclass)
        {
            if (ModelState.IsValid)
            {
                db.SHCLASSes.Add(shclass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shclass);
        }

        //
        // GET: /ShClass/Edit/5

        public ActionResult Edit(int id)
        {
            SHCLASS shclass = db.SHCLASSes.Find(id);
            if (shclass == null)
            {
                return HttpNotFound();
            }
            return View(shclass);
        }

        //
        // POST: /ShClass/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SHCLASS shclass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shclass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shclass);
        }

        //
        // GET: /ShClass/Delete/5

        public ActionResult Delete(int id)
        {
            SHCLASS shclass = db.SHCLASSes.Find(id);
            if (shclass == null)
            {
                return HttpNotFound();
            }
            return View(shclass);
        }

        //
        // POST: /ShClass/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SHCLASS shclass = db.SHCLASSes.Find(id);
            db.SHCLASSes.Remove(shclass);
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