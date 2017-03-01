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
    public class AuthorityfunctionController : Controller
    {
        private AllShowEntities db = new AllShowEntities();

        // GET: Admin/Authorityfunction
        public ActionResult Index()
        {
            return View(db.AUTHORITYFUNCTIONs.ToList());
        }

        // GET: Admin/Authorityfunction/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AUTHORITYFUNCTION aUTHORITYFUNCTION = db.AUTHORITYFUNCTIONs.Find(id);
            if (aUTHORITYFUNCTION == null)
            {
                return HttpNotFound();
            }
            return View(aUTHORITYFUNCTION);
        }

        // GET: Admin/Authorityfunction/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Authorityfunction/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "authorityno,authorityname")] AUTHORITYFUNCTION aUTHORITYFUNCTION)
        {
            if (ModelState.IsValid)
            {
                db.AUTHORITYFUNCTIONs.Add(aUTHORITYFUNCTION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aUTHORITYFUNCTION);
        }

        // GET: Admin/Authorityfunction/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AUTHORITYFUNCTION aUTHORITYFUNCTION = db.AUTHORITYFUNCTIONs.Find(id);
            if (aUTHORITYFUNCTION == null)
            {
                return HttpNotFound();
            }
            return View(aUTHORITYFUNCTION);
        }

        // POST: Admin/Authorityfunction/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "authorityno,authorityname")] AUTHORITYFUNCTION aUTHORITYFUNCTION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aUTHORITYFUNCTION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aUTHORITYFUNCTION);
        }

        // GET: Admin/Authorityfunction/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AUTHORITYFUNCTION aUTHORITYFUNCTION = db.AUTHORITYFUNCTIONs.Find(id);
            if (aUTHORITYFUNCTION == null)
            {
                return HttpNotFound();
            }
            return View(aUTHORITYFUNCTION);
        }

        // POST: Admin/Authorityfunction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AUTHORITYFUNCTION aUTHORITYFUNCTION = db.AUTHORITYFUNCTIONs.Find(id);
            db.AUTHORITYFUNCTIONs.Remove(aUTHORITYFUNCTION);
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
