using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AllShow.Models.edmx;

namespace AllShow.Areas.Admin.Controllers
{
    public class MemberlistController : Controller
    {
        private AllShowEntities db = new AllShowEntities();

        // GET: Admin/Memberlist
        public ActionResult Index()
        {
            var mEMBERLISTs = db.MEMBERLISTs.Include(m => m.MEMBER);
            return View(mEMBERLISTs.ToList());
        }

        // GET: Admin/Memberlist/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEMBERLIST mEMBERLIST = db.MEMBERLISTs.Find(id);
            if (mEMBERLIST == null)
            {
                return HttpNotFound();
            }
            return View(mEMBERLIST);
        }

        // GET: Admin/Memberlist/Create
        public ActionResult Create()
        {
            ViewBag.memNo = new SelectList(db.MEMBERs, "memno", "mememail");
            return View();
        }

        // POST: Admin/Memberlist/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "orderNo,memNo,orderDate")] MEMBERLIST mEMBERLIST)
        {
            if (ModelState.IsValid)
            {
                db.MEMBERLISTs.Add(mEMBERLIST);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.memNo = new SelectList(db.MEMBERs, "memno", "mememail", mEMBERLIST.memNo);
            return View(mEMBERLIST);
        }

        // GET: Admin/Memberlist/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEMBERLIST mEMBERLIST = db.MEMBERLISTs.Find(id);
            if (mEMBERLIST == null)
            {
                return HttpNotFound();
            }
            ViewBag.memNo = new SelectList(db.MEMBERs, "memno", "mememail", mEMBERLIST.memNo);
            return View(mEMBERLIST);
        }

        // POST: Admin/Memberlist/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "orderNo,memNo,orderDate")] MEMBERLIST mEMBERLIST)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mEMBERLIST).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.memNo = new SelectList(db.MEMBERs, "memno", "mememail", mEMBERLIST.memNo);
            return View(mEMBERLIST);
        }

        // GET: Admin/Memberlist/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEMBERLIST mEMBERLIST = db.MEMBERLISTs.Find(id);
            if (mEMBERLIST == null)
            {
                return HttpNotFound();
            }
            return View(mEMBERLIST);
        }

        // POST: Admin/Memberlist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MEMBERLIST mEMBERLIST = db.MEMBERLISTs.Find(id);
            db.MEMBERLISTs.Remove(mEMBERLIST);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
