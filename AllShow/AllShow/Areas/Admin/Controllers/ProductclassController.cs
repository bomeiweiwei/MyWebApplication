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
    public class ProductclassController : Controller
    {
        private AllShowEntities db = new AllShowEntities();

        // GET: Admin/Productclass
        public ActionResult Index()
        {
            var pRODUCTCLASSes = db.PRODUCTCLASSes.Include(p => p.SHOP);
            return View(pRODUCTCLASSes.ToList());
        }

        // GET: Admin/Productclass/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTCLASS pRODUCTCLASS = db.PRODUCTCLASSes.Find(id);
            if (pRODUCTCLASS == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTCLASS);
        }

        // GET: Admin/Productclass/Create
        public ActionResult Create()
        {
            ViewBag.shno = new SelectList(db.SHOPs, "shno", "shthepic");
            return View();
        }

        // POST: Admin/Productclass/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "proclassno,shno,proclassname")] PRODUCTCLASS pRODUCTCLASS)
        {
            if (ModelState.IsValid)
            {
                db.PRODUCTCLASSes.Add(pRODUCTCLASS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.shno = new SelectList(db.SHOPs, "shno", "shthepic", pRODUCTCLASS.shno);
            return View(pRODUCTCLASS);
        }

        // GET: Admin/Productclass/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTCLASS pRODUCTCLASS = db.PRODUCTCLASSes.Find(id);
            if (pRODUCTCLASS == null)
            {
                return HttpNotFound();
            }
            ViewBag.shno = new SelectList(db.SHOPs, "shno", "shthepic", pRODUCTCLASS.shno);
            return View(pRODUCTCLASS);
        }

        // POST: Admin/Productclass/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "proclassno,shno,proclassname")] PRODUCTCLASS pRODUCTCLASS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUCTCLASS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.shno = new SelectList(db.SHOPs, "shno", "shthepic", pRODUCTCLASS.shno);
            return View(pRODUCTCLASS);
        }

        // GET: Admin/Productclass/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTCLASS pRODUCTCLASS = db.PRODUCTCLASSes.Find(id);
            if (pRODUCTCLASS == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTCLASS);
        }

        // POST: Admin/Productclass/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRODUCTCLASS pRODUCTCLASS = db.PRODUCTCLASSes.Find(id);
            db.PRODUCTCLASSes.Remove(pRODUCTCLASS);
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
