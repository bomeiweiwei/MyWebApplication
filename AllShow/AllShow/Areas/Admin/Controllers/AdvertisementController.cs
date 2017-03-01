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
    public class AdvertisementController : Controller
    {
        private AllShowEntities db = new AllShowEntities();

        // GET: Admin/Advertisement
        public ActionResult Index()
        {
            var aDVERTISEMENTs = db.ADVERTISEMENTs.Include(a => a.EMPLOYEE).Include(a => a.SHOP);
            return View(aDVERTISEMENTs.ToList());
        }

        // GET: Admin/Advertisement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADVERTISEMENT aDVERTISEMENT = db.ADVERTISEMENTs.Find(id);
            if (aDVERTISEMENT == null)
            {
                return HttpNotFound();
            }
            return View(aDVERTISEMENT);
        }

        // GET: Admin/Advertisement/Create
        public ActionResult Create()
        {
            ViewBag.empNo = new SelectList(db.EMPLOYEEs, "empno", "empname");
            ViewBag.shNo = new SelectList(db.SHOPs, "shno", "shthepic");
            return View();
        }

        // POST: Admin/Advertisement/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "adNo,shNo,empNo,adTitle,adApplyDate,adStartDate,adTime,adPrice,adPic,adURL,adCheckState")] ADVERTISEMENT aDVERTISEMENT)
        {
            if (ModelState.IsValid)
            {
                db.ADVERTISEMENTs.Add(aDVERTISEMENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.empNo = new SelectList(db.EMPLOYEEs, "empno", "empname", aDVERTISEMENT.empNo);
            ViewBag.shNo = new SelectList(db.SHOPs, "shno", "shthepic", aDVERTISEMENT.shNo);
            return View(aDVERTISEMENT);
        }

        // GET: Admin/Advertisement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADVERTISEMENT aDVERTISEMENT = db.ADVERTISEMENTs.Find(id);
            if (aDVERTISEMENT == null)
            {
                return HttpNotFound();
            }
            ViewBag.empNo = new SelectList(db.EMPLOYEEs, "empno", "empname", aDVERTISEMENT.empNo);
            ViewBag.shNo = new SelectList(db.SHOPs, "shno", "shthepic", aDVERTISEMENT.shNo);
            return View(aDVERTISEMENT);
        }

        // POST: Admin/Advertisement/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "adNo,shNo,empNo,adTitle,adApplyDate,adStartDate,adTime,adPrice,adPic,adURL,adCheckState")] ADVERTISEMENT aDVERTISEMENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aDVERTISEMENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.empNo = new SelectList(db.EMPLOYEEs, "empno", "empname", aDVERTISEMENT.empNo);
            ViewBag.shNo = new SelectList(db.SHOPs, "shno", "shthepic", aDVERTISEMENT.shNo);
            return View(aDVERTISEMENT);
        }

        // GET: Admin/Advertisement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADVERTISEMENT aDVERTISEMENT = db.ADVERTISEMENTs.Find(id);
            if (aDVERTISEMENT == null)
            {
                return HttpNotFound();
            }
            return View(aDVERTISEMENT);
        }

        // POST: Admin/Advertisement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ADVERTISEMENT aDVERTISEMENT = db.ADVERTISEMENTs.Find(id);
            db.ADVERTISEMENTs.Remove(aDVERTISEMENT);
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
