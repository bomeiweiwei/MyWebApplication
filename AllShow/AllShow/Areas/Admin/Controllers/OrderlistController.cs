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
    public class OrderlistController : Controller
    {
        private AllShowEntities db = new AllShowEntities();

        // GET: Admin/Orderlist
        public ActionResult Index()
        {
            var oRDERLISTs = db.ORDERLISTs.Include(o => o.PRODUCT).Include(o => o.SHOPORDER);
            return View(oRDERLISTs.ToList());
        }

        // GET: Admin/Orderlist/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDERLIST oRDERLIST = db.ORDERLISTs.Find(id);
            if (oRDERLIST == null)
            {
                return HttpNotFound();
            }
            return View(oRDERLIST);
        }

        // GET: Admin/Orderlist/Create
        public ActionResult Create()
        {
            ViewBag.proNo = new SelectList(db.PRODUCTs, "proNo", "proName");
            ViewBag.shoporderNo = new SelectList(db.SHOPORDERs, "shoporderNo", "orderState");
            return View();
        }

        // POST: Admin/Orderlist/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "shoporderNo,proNo,quantity")] ORDERLIST oRDERLIST)
        {
            if (ModelState.IsValid)
            {
                db.ORDERLISTs.Add(oRDERLIST);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.proNo = new SelectList(db.PRODUCTs, "proNo", "proName", oRDERLIST.proNo);
            ViewBag.shoporderNo = new SelectList(db.SHOPORDERs, "shoporderNo", "orderState", oRDERLIST.shoporderNo);
            return View(oRDERLIST);
        }

        // GET: Admin/Orderlist/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDERLIST oRDERLIST = db.ORDERLISTs.Find(id);
            if (oRDERLIST == null)
            {
                return HttpNotFound();
            }
            ViewBag.proNo = new SelectList(db.PRODUCTs, "proNo", "proName", oRDERLIST.proNo);
            ViewBag.shoporderNo = new SelectList(db.SHOPORDERs, "shoporderNo", "orderState", oRDERLIST.shoporderNo);
            return View(oRDERLIST);
        }

        // POST: Admin/Orderlist/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "shoporderNo,proNo,quantity")] ORDERLIST oRDERLIST)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oRDERLIST).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.proNo = new SelectList(db.PRODUCTs, "proNo", "proName", oRDERLIST.proNo);
            ViewBag.shoporderNo = new SelectList(db.SHOPORDERs, "shoporderNo", "orderState", oRDERLIST.shoporderNo);
            return View(oRDERLIST);
        }

        // GET: Admin/Orderlist/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDERLIST oRDERLIST = db.ORDERLISTs.Find(id);
            if (oRDERLIST == null)
            {
                return HttpNotFound();
            }
            return View(oRDERLIST);
        }

        // POST: Admin/Orderlist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ORDERLIST oRDERLIST = db.ORDERLISTs.Find(id);
            db.ORDERLISTs.Remove(oRDERLIST);
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
