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
    public class MemberListController : Controller
    {
        private AllShowEntities db = new AllShowEntities();

        //
        // GET: /MemberList/

        public ActionResult Index()
        {
            var memberlists = db.MEMBERLISTs.Include(m => m.MEMBER);
            return View(memberlists.ToList());
        }

        //
        // GET: /MemberList/Details/5

        public ActionResult Details(int id)
        {
            MEMBERLIST memberlist = db.MEMBERLISTs.Find(id);
            if (memberlist == null)
            {
                return HttpNotFound();
            }
            return View(memberlist);
        }

        //
        // GET: /MemberList/Create

        public ActionResult Create()
        {
            ViewBag.memNo = new SelectList(db.MEMBERs, "memno", "mememail");
            return View();
        }

        //
        // POST: /MemberList/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MEMBERLIST memberlist)
        {
            if (ModelState.IsValid)
            {
                db.MEMBERLISTs.Add(memberlist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.memNo = new SelectList(db.MEMBERs, "memno", "mememail", memberlist.memNo);
            return View(memberlist);
        }

        //
        // GET: /MemberList/Edit/5

        public ActionResult Edit(int id)
        {
            MEMBERLIST memberlist = db.MEMBERLISTs.Find(id);
            if (memberlist == null)
            {
                return HttpNotFound();
            }
            ViewBag.memNo = new SelectList(db.MEMBERs, "memno", "mememail", memberlist.memNo);
            return View(memberlist);
        }

        //
        // POST: /MemberList/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MEMBERLIST memberlist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(memberlist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.memNo = new SelectList(db.MEMBERs, "memno", "mememail", memberlist.memNo);
            return View(memberlist);
        }

        //
        // GET: /MemberList/Delete/5

        public ActionResult Delete(int id)
        {
            MEMBERLIST memberlist = db.MEMBERLISTs.Find(id);
            if (memberlist == null)
            {
                return HttpNotFound();
            }
            return View(memberlist);
        }

        //
        // POST: /MemberList/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MEMBERLIST memberlist = db.MEMBERLISTs.Find(id);
            db.MEMBERLISTs.Remove(memberlist);
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