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
    public class AnnouncementController : Controller
    {
        private AllShowEntities db = new AllShowEntities();

        //
        // GET: /Announcement/

        public ActionResult Index()
        {
            var announcements = db.ANNOUNCEMENTs.Include(a => a.EMPLOYEE);
            return View(announcements.ToList());
        }

        //
        // GET: /Announcement/Details/5

        public ActionResult Details(int id )
        {
            ANNOUNCEMENT announcement = db.ANNOUNCEMENTs.Find(id);
            if (announcement == null)
            {
                return HttpNotFound();
            }
            return View(announcement);
        }

        //
        // GET: /Announcement/Create

        public ActionResult Create()
        {
            ViewBag.empno = new SelectList(db.EMPLOYEEs, "empno", "empname");
            return View();
        }

        //
        // POST: /Announcement/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ANNOUNCEMENT announcement)
        {
            if (ModelState.IsValid)
            {
                db.ANNOUNCEMENTs.Add(announcement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.empno = new SelectList(db.EMPLOYEEs, "empno", "empname", announcement.empno);
            return View(announcement);
        }

        //
        // GET: /Announcement/Edit/5

        public ActionResult Edit(int id )
        {
            ANNOUNCEMENT announcement = db.ANNOUNCEMENTs.Find(id);
            if (announcement == null)
            {
                return HttpNotFound();
            }
            ViewBag.empno = new SelectList(db.EMPLOYEEs, "empno", "empname", announcement.empno);
            return View(announcement);
        }

        //
        // POST: /Announcement/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ANNOUNCEMENT announcement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(announcement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.empno = new SelectList(db.EMPLOYEEs, "empno", "empname", announcement.empno);
            return View(announcement);
        }

        //
        // GET: /Announcement/Delete/5

        public ActionResult Delete(int id )
        {
            ANNOUNCEMENT announcement = db.ANNOUNCEMENTs.Find(id);
            if (announcement == null)
            {
                return HttpNotFound();
            }
            return View(announcement);
        }

        //
        // POST: /Announcement/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ANNOUNCEMENT announcement = db.ANNOUNCEMENTs.Find(id);
            db.ANNOUNCEMENTs.Remove(announcement);
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