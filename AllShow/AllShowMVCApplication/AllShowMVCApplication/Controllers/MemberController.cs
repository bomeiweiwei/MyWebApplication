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
    public class MemberController : Controller
    {
        private AllShowEntities db = new AllShowEntities();

        //
        // GET: /Member/

        public ActionResult Index()
        {
            return View(db.MEMBERs.ToList());
        }

        //
        // GET: /Member/Details/5

        public ActionResult Details(int id)
        {
            MEMBER member = db.MEMBERs.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        //
        // GET: /Member/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Member/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MEMBER member)
        {
            if (ModelState.IsValid)
            {
                db.MEMBERs.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(member);
        }

        //
        // GET: /Member/Edit/5

        public ActionResult Edit(int id)
        {
            MEMBER member = db.MEMBERs.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        //
        // POST: /Member/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MEMBER member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        //
        // GET: /Member/Delete/5

        public ActionResult Delete(int id)
        {
            MEMBER member = db.MEMBERs.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        //
        // POST: /Member/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MEMBER member = db.MEMBERs.Find(id);
            db.MEMBERs.Remove(member);
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