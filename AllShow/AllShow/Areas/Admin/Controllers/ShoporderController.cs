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
    public class ShoporderController : Controller
    {
        private AllShowEntities db = new AllShowEntities();

        // GET: Admin/Shoporder
        public ActionResult Index()
        {
            var sHOPORDERs = db.SHOPORDERs.Include(s => s.MEMBERLIST).Include(s => s.SHOP);
            return View(sHOPORDERs.ToList());
        }

        // GET: Admin/Shoporder/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHOPORDER sHOPORDER = db.SHOPORDERs.Find(id);
            if (sHOPORDER == null)
            {
                return HttpNotFound();
            }
            return View(sHOPORDER);
        }

        // GET: Admin/Shoporder/Create
        public ActionResult Create()
        {
            ViewBag.orderNo = new SelectList(db.MEMBERLISTs, "orderNo", "orderNo");
            ViewBag.shNo = new SelectList(db.SHOPs, "shno", "shthepic");
            return View();
        }

        // POST: Admin/Shoporder/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "shoporderNo,orderNo,shNo,orderPrice,referredToDate,transactionDate,orderState,recipientName,recipientTel,recipientAddress,payType")] SHOPORDER sHOPORDER)
        {
            if (ModelState.IsValid)
            {
                db.SHOPORDERs.Add(sHOPORDER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.orderNo = new SelectList(db.MEMBERLISTs, "orderNo", "orderNo", sHOPORDER.orderNo);
            ViewBag.shNo = new SelectList(db.SHOPs, "shno", "shthepic", sHOPORDER.shNo);
            return View(sHOPORDER);
        }

        // GET: Admin/Shoporder/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHOPORDER sHOPORDER = db.SHOPORDERs.Find(id);
            if (sHOPORDER == null)
            {
                return HttpNotFound();
            }
            ViewBag.orderNo = new SelectList(db.MEMBERLISTs, "orderNo", "orderNo", sHOPORDER.orderNo);
            ViewBag.shNo = new SelectList(db.SHOPs, "shno", "shthepic", sHOPORDER.shNo);
            return View(sHOPORDER);
        }

        // POST: Admin/Shoporder/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "shoporderNo,orderNo,shNo,orderPrice,referredToDate,transactionDate,orderState,recipientName,recipientTel,recipientAddress,payType")] SHOPORDER sHOPORDER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sHOPORDER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.orderNo = new SelectList(db.MEMBERLISTs, "orderNo", "orderNo", sHOPORDER.orderNo);
            ViewBag.shNo = new SelectList(db.SHOPs, "shno", "shthepic", sHOPORDER.shNo);
            return View(sHOPORDER);
        }

        // GET: Admin/Shoporder/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHOPORDER sHOPORDER = db.SHOPORDERs.Find(id);
            if (sHOPORDER == null)
            {
                return HttpNotFound();
            }
            return View(sHOPORDER);
        }

        // POST: Admin/Shoporder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SHOPORDER sHOPORDER = db.SHOPORDERs.Find(id);
            db.SHOPORDERs.Remove(sHOPORDER);
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
