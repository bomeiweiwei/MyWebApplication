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
    public class ShopController : Controller
    {
        private AllShowEntities db = new AllShowEntities();

        // GET: Admin/Shop
        public ActionResult Index()
        {
            var sHOPs = db.SHOPs.Include(s => s.EMPLOYEE).Include(s => s.SHCLASS);
            return View(sHOPs.ToList());
        }

        // GET: Admin/Shop/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHOP sHOP = db.SHOPs.Find(id);
            if (sHOP == null)
            {
                return HttpNotFound();
            }
            return View(sHOP);
        }

        // GET: Admin/Shop/Create
        public ActionResult Create()
        {
            ViewBag.empno = new SelectList(db.EMPLOYEEs, "empno", "empname");
            ViewBag.shclassno = new SelectList(db.SHCLASSes, "shclassno", "shclassname");
            return View();
        }

        // POST: Admin/Shop/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "shno,empno,shthepic,shname,shclassno,shaccount,shpwd,shboss,shcontact,shaddress,shtel,shemail,shabout,shlogopic,shurl,shadstate,shadtitle,shadpic,shpopshop,shcheckstate,shstartdate,shenddate,shcheckdate,shpwdstate,shstoprightstartdate,shstoprightenddate")] SHOP sHOP)
        {
            if (ModelState.IsValid)
            {
                db.SHOPs.Add(sHOP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.empno = new SelectList(db.EMPLOYEEs, "empno", "empname", sHOP.empno);
            ViewBag.shclassno = new SelectList(db.SHCLASSes, "shclassno", "shclassname", sHOP.shclassno);
            return View(sHOP);
        }

        // GET: Admin/Shop/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHOP sHOP = db.SHOPs.Find(id);
            if (sHOP == null)
            {
                return HttpNotFound();
            }
            ViewBag.empno = new SelectList(db.EMPLOYEEs, "empno", "empname", sHOP.empno);
            ViewBag.shclassno = new SelectList(db.SHCLASSes, "shclassno", "shclassname", sHOP.shclassno);
            return View(sHOP);
        }

        // POST: Admin/Shop/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "shno,empno,shthepic,shname,shclassno,shaccount,shpwd,shboss,shcontact,shaddress,shtel,shemail,shabout,shlogopic,shurl,shadstate,shadtitle,shadpic,shpopshop,shcheckstate,shstartdate,shenddate,shcheckdate,shpwdstate,shstoprightstartdate,shstoprightenddate")] SHOP sHOP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sHOP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.empno = new SelectList(db.EMPLOYEEs, "empno", "empname", sHOP.empno);
            ViewBag.shclassno = new SelectList(db.SHCLASSes, "shclassno", "shclassname", sHOP.shclassno);
            return View(sHOP);
        }

        // GET: Admin/Shop/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHOP sHOP = db.SHOPs.Find(id);
            if (sHOP == null)
            {
                return HttpNotFound();
            }
            return View(sHOP);
        }

        // POST: Admin/Shop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SHOP sHOP = db.SHOPs.Find(id);
            db.SHOPs.Remove(sHOP);
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
