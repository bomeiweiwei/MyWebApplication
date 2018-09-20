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
    public class AuthorityFunctionController : Controller
    {
        private AllShowEntities db = new AllShowEntities();

        //
        // GET: /AuthorityFunction/

        public ActionResult Index()
        {
            return View(db.AUTHORITYFUNCTIONs.ToList());
        }

        //
        // GET: /AuthorityFunction/Details/5

        public ActionResult Details(int id)
        {
            AUTHORITYFUNCTION authorityfunction = db.AUTHORITYFUNCTIONs.Find(id);
            if (authorityfunction == null)
            {
                return HttpNotFound();
            }
            return View(authorityfunction);
        }

        //
        // GET: /AuthorityFunction/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /AuthorityFunction/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AUTHORITYFUNCTION authorityfunction)
        {
            if (ModelState.IsValid)
            {
                db.AUTHORITYFUNCTIONs.Add(authorityfunction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(authorityfunction);
        }

        //
        // GET: /AuthorityFunction/Edit/5

        public ActionResult Edit(int id)
        {
            AUTHORITYFUNCTION authorityfunction = db.AUTHORITYFUNCTIONs.Find(id);
            if (authorityfunction == null)
            {
                return HttpNotFound();
            }
            return View(authorityfunction);
        }

        //
        // POST: /AuthorityFunction/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AUTHORITYFUNCTION authorityfunction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(authorityfunction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(authorityfunction);
        }

        //
        // GET: /AuthorityFunction/Delete/5

        public ActionResult Delete(int id)
        {
            AUTHORITYFUNCTION authorityfunction = db.AUTHORITYFUNCTIONs.Find(id);
            if (authorityfunction == null)
            {
                return HttpNotFound();
            }
            return View(authorityfunction);
        }

        //
        // POST: /AuthorityFunction/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AUTHORITYFUNCTION authorityfunction = db.AUTHORITYFUNCTIONs.Find(id);
            db.AUTHORITYFUNCTIONs.Remove(authorityfunction);
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