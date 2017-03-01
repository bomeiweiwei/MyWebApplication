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
    public class ProductController : Controller
    {
        private AllShowEntities db = new AllShowEntities();

        // GET: Admin/Product
        public ActionResult Index()
        {
            var pRODUCTs = db.PRODUCTs.Include(p => p.PRODUCTCLASS).Include(p => p.SHOP);
            return View(pRODUCTs.ToList());
        }

        // GET: Admin/Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCTs.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT);
        }

        // GET: Admin/Product/Create
        public ActionResult Create()
        {
            ViewBag.proClassNo = new SelectList(db.PRODUCTCLASSes, "proclassno", "proclassname");
            ViewBag.shNo = new SelectList(db.SHOPs, "shno", "shthepic");
            return View();
        }

        // POST: Admin/Product/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "proNo,shNo,proClassNo,proName,proPrice,proStatement,proState,proPic1,proPic2,proPic3,proCreateDate,proUpdateDate,ProOffShelfDate,proPop")] PRODUCT pRODUCT)
        {
            if (ModelState.IsValid)
            {
                db.PRODUCTs.Add(pRODUCT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.proClassNo = new SelectList(db.PRODUCTCLASSes, "proclassno", "proclassname", pRODUCT.proClassNo);
            ViewBag.shNo = new SelectList(db.SHOPs, "shno", "shthepic", pRODUCT.shNo);
            return View(pRODUCT);
        }

        // GET: Admin/Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCTs.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            ViewBag.proClassNo = new SelectList(db.PRODUCTCLASSes, "proclassno", "proclassname", pRODUCT.proClassNo);
            ViewBag.shNo = new SelectList(db.SHOPs, "shno", "shthepic", pRODUCT.shNo);
            return View(pRODUCT);
        }

        // POST: Admin/Product/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "proNo,shNo,proClassNo,proName,proPrice,proStatement,proState,proPic1,proPic2,proPic3,proCreateDate,proUpdateDate,ProOffShelfDate,proPop")] PRODUCT pRODUCT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUCT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.proClassNo = new SelectList(db.PRODUCTCLASSes, "proclassno", "proclassname", pRODUCT.proClassNo);
            ViewBag.shNo = new SelectList(db.SHOPs, "shno", "shthepic", pRODUCT.shNo);
            return View(pRODUCT);
        }

        // GET: Admin/Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCTs.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT);
        }

        // POST: Admin/Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRODUCT pRODUCT = db.PRODUCTs.Find(id);
            db.PRODUCTs.Remove(pRODUCT);
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
