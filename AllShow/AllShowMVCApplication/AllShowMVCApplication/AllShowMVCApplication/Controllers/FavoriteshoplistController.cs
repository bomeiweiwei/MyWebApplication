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
    public class FavoriteshoplistController : Controller
    {
        private AllShowEntities db = new AllShowEntities();

        //
        // GET: /Favoriteshoplist/

        public ActionResult Index()
        {
            return View(db.FAVORITESHOPLISTs.ToList());
        }

        //
        // GET: /Favoriteshoplist/Details/5

        public ActionResult Details(int id, int id2)
        {
            FAVORITESHOPLIST favoriteshoplist = db.FAVORITESHOPLISTs.Find(id, id2);
            if (favoriteshoplist == null)
            {
                return HttpNotFound();
            }
            return View(favoriteshoplist);
        }

        //
        // GET: /Favoriteshoplist/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Favoriteshoplist/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FAVORITESHOPLIST favoriteshoplist)
        {
            if (ModelState.IsValid)
            {
                db.FAVORITESHOPLISTs.Add(favoriteshoplist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(favoriteshoplist);
        }

        //
        // GET: /Favoriteshoplist/Edit/5

        public ActionResult Edit(int id, int id2)
        {
            FAVORITESHOPLIST favoriteshoplist = db.FAVORITESHOPLISTs.Find(id, id2);
            if (favoriteshoplist == null)
            {
                return HttpNotFound();
            }
            return View(favoriteshoplist);
        }

        //
        // POST: /Favoriteshoplist/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FAVORITESHOPLIST favoriteshoplist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(favoriteshoplist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(favoriteshoplist);
        }

        //
        // GET: /Favoriteshoplist/Delete/5

        public ActionResult Delete(int id, int id2)
        {
            FAVORITESHOPLIST favoriteshoplist = db.FAVORITESHOPLISTs.Find(id, id2);
            if (favoriteshoplist == null)
            {
                return HttpNotFound();
            }
            return View(favoriteshoplist);
        }

        //
        // POST: /Favoriteshoplist/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int id2)
        {
            FAVORITESHOPLIST favoriteshoplist = db.FAVORITESHOPLISTs.Find(id, id2);
            db.FAVORITESHOPLISTs.Remove(favoriteshoplist);
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