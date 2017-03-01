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
    public class AnnouncementController : Controller
    {
        private AllShowEntities db = new AllShowEntities();

        // GET: Admin/Announcement
        public ActionResult Index()
        {
            var aNNOUNCEMENTs = db.ANNOUNCEMENTs.Include(a => a.EMPLOYEE);
            return View(aNNOUNCEMENTs.ToList());
        }

        // GET: Admin/Announcement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ANNOUNCEMENT aNNOUNCEMENT = db.ANNOUNCEMENTs.Find(id);
            if (aNNOUNCEMENT == null)
            {
                return HttpNotFound();
            }
            return View(aNNOUNCEMENT);
        }

        // GET: Admin/Announcement/Create
        public ActionResult Create()
        {
            ViewBag.empno = new SelectList(db.EMPLOYEEs, "empno", "empname");
            return View();
        }

        // POST: Admin/Announcement/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "announcementno,empno,announcementtitle,announcementtype,announcementcontent,createdate,updatedate,startdate,enddate")] ANNOUNCEMENT aNNOUNCEMENT)
        {
            if (ModelState.IsValid)
            {
                db.ANNOUNCEMENTs.Add(aNNOUNCEMENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.empno = new SelectList(db.EMPLOYEEs, "empno", "empname", aNNOUNCEMENT.empno);
            return View(aNNOUNCEMENT);
        }

        // GET: Admin/Announcement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ANNOUNCEMENT aNNOUNCEMENT = db.ANNOUNCEMENTs.Find(id);
            if (aNNOUNCEMENT == null)
            {
                return HttpNotFound();
            }
            ViewBag.empno = new SelectList(db.EMPLOYEEs, "empno", "empname", aNNOUNCEMENT.empno);
            return View(aNNOUNCEMENT);
        }

        // POST: Admin/Announcement/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "announcementno,empno,announcementtitle,announcementtype,announcementcontent,createdate,updatedate,startdate,enddate")] ANNOUNCEMENT aNNOUNCEMENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aNNOUNCEMENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.empno = new SelectList(db.EMPLOYEEs, "empno", "empname", aNNOUNCEMENT.empno);
            return View(aNNOUNCEMENT);
        }

        // GET: Admin/Announcement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ANNOUNCEMENT aNNOUNCEMENT = db.ANNOUNCEMENTs.Find(id);
            if (aNNOUNCEMENT == null)
            {
                return HttpNotFound();
            }
            return View(aNNOUNCEMENT);
        }

        // POST: Admin/Announcement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ANNOUNCEMENT aNNOUNCEMENT = db.ANNOUNCEMENTs.Find(id);
            db.ANNOUNCEMENTs.Remove(aNNOUNCEMENT);
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
