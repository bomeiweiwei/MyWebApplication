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
    public class AuthorityController : Controller
    {
        private AllShowEntities db = new AllShowEntities();

        // GET: Admin/Authority
        public ActionResult Index()
        {
            var aUTHORITies = db.AUTHORITies.Include(a => a.AUTHORITYFUNCTION).Include(a => a.EMPLOYEE);
            return View(aUTHORITies.ToList());
        }

        // GET: Admin/Authority/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AUTHORITY aUTHORITY = db.AUTHORITies.Find(id);
            if (aUTHORITY == null)
            {
                return HttpNotFound();
            }
            return View(aUTHORITY);
        }

        // GET: Admin/Authority/Create
        public ActionResult Create()
        {
            ViewBag.authorityno = new SelectList(db.AUTHORITYFUNCTIONs, "authorityno", "authorityname");
            ViewBag.empno = new SelectList(db.EMPLOYEEs, "empno", "empname");
            return View();
        }

        // POST: Admin/Authority/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "authorityno,empno,note")] AUTHORITY aUTHORITY)
        {
            if (ModelState.IsValid)
            {
                db.AUTHORITies.Add(aUTHORITY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.authorityno = new SelectList(db.AUTHORITYFUNCTIONs, "authorityno", "authorityname", aUTHORITY.authorityno);
            ViewBag.empno = new SelectList(db.EMPLOYEEs, "empno", "empname", aUTHORITY.empno);
            return View(aUTHORITY);
        }

        // GET: Admin/Authority/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AUTHORITY aUTHORITY = db.AUTHORITies.Find(id);
            if (aUTHORITY == null)
            {
                return HttpNotFound();
            }
            ViewBag.authorityno = new SelectList(db.AUTHORITYFUNCTIONs, "authorityno", "authorityname", aUTHORITY.authorityno);
            ViewBag.empno = new SelectList(db.EMPLOYEEs, "empno", "empname", aUTHORITY.empno);
            return View(aUTHORITY);
        }

        // POST: Admin/Authority/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "authorityno,empno,note")] AUTHORITY aUTHORITY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aUTHORITY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.authorityno = new SelectList(db.AUTHORITYFUNCTIONs, "authorityno", "authorityname", aUTHORITY.authorityno);
            ViewBag.empno = new SelectList(db.EMPLOYEEs, "empno", "empname", aUTHORITY.empno);
            return View(aUTHORITY);
        }

        // GET: Admin/Authority/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AUTHORITY aUTHORITY = db.AUTHORITies.Find(id);
            if (aUTHORITY == null)
            {
                return HttpNotFound();
            }
            return View(aUTHORITY);
        }

        // POST: Admin/Authority/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AUTHORITY aUTHORITY = db.AUTHORITies.Find(id);
            db.AUTHORITies.Remove(aUTHORITY);
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
