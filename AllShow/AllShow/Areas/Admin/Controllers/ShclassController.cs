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
    public class ShclassController : Controller
    {
        private AllShowEntities db = new AllShowEntities();

        // GET: Admin/Shclass
        public ActionResult Index()
        {
            return View(db.SHCLASSes.ToList());
        }

        // GET: Admin/Shclass/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHCLASS sHCLASS = db.SHCLASSes.Find(id);
            if (sHCLASS == null)
            {
                return HttpNotFound();
            }
            return View(sHCLASS);
        }

        // GET: Admin/Shclass/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Shclass/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "shclassno,shclassname")] SHCLASS sHCLASS)
        {
            if (ModelState.IsValid)
            {
                db.SHCLASSes.Add(sHCLASS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sHCLASS);
        }

        // GET: Admin/Shclass/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHCLASS sHCLASS = db.SHCLASSes.Find(id);
            if (sHCLASS == null)
            {
                return HttpNotFound();
            }
            return View(sHCLASS);
        }

        // POST: Admin/Shclass/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "shclassno,shclassname")] SHCLASS sHCLASS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sHCLASS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sHCLASS);
        }

        // GET: Admin/Shclass/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHCLASS sHCLASS = db.SHCLASSes.Find(id);
            if (sHCLASS == null)
            {
                return HttpNotFound();
            }
            return View(sHCLASS);
        }

        // POST: Admin/Shclass/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SHCLASS sHCLASS = db.SHCLASSes.Find(id);
            db.SHCLASSes.Remove(sHCLASS);
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
