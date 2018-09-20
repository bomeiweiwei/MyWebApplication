using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AllShowMVCApplication.Models;

namespace AllShowMVCApplication.Controllers
{
    public class ShopOrderController : Controller
    {
        private AllShowEntities db = new AllShowEntities();

        //
        // GET: /ShopOrder/

        public ActionResult Index()
        {
            var shoporders = db.SHOPORDERs.Include(s => s.MEMBERLIST).Include(s => s.SHOP);
            return View(shoporders.ToList());
        }

        //
        // GET: /ShopOrder/Details/5

        public ActionResult Details(int id)
        {
            SHOPORDER shoporder = db.SHOPORDERs.Find(id);
            if (shoporder == null)
            {
                return HttpNotFound();
            }
            return View(shoporder);
        }

        //
        // GET: /ShopOrder/Create

        public ActionResult Create()
        {
            ViewBag.orderNo = new SelectList(db.MEMBERLISTs, "orderNo", "orderNo");
            ViewBag.shNo = new SelectList(db.SHOPs, "shno", "shthepic");
            return View();
        }

        //
        // POST: /ShopOrder/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SHOPORDER shoporder)
        {
            if (ModelState.IsValid)
            {
                db.SHOPORDERs.Add(shoporder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.orderNo = new SelectList(db.MEMBERLISTs, "orderNo", "orderNo", shoporder.orderNo);
            ViewBag.shNo = new SelectList(db.SHOPs, "shno", "shthepic", shoporder.shNo);
            return View(shoporder);
        }

        //
        // GET: /ShopOrder/Edit/5

        public ActionResult Edit(int id)
        {
            SHOPORDER shoporder = db.SHOPORDERs.Find(id);
            if (shoporder == null)
            {
                return HttpNotFound();
            }
            ViewBag.orderNo = new SelectList(db.MEMBERLISTs, "orderNo", "orderNo", shoporder.orderNo);
            ViewBag.shNo = new SelectList(db.SHOPs, "shno", "shthepic", shoporder.shNo);
            return View(shoporder);
        }

        //
        // POST: /ShopOrder/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SHOPORDER shoporder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shoporder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.orderNo = new SelectList(db.MEMBERLISTs, "orderNo", "orderNo", shoporder.orderNo);
            ViewBag.shNo = new SelectList(db.SHOPs, "shno", "shthepic", shoporder.shNo);
            return View(shoporder);
        }

        //
        // GET: /ShopOrder/Delete/5

        public ActionResult Delete(int id)
        {
            SHOPORDER shoporder = db.SHOPORDERs.Find(id);
            if (shoporder == null)
            {
                return HttpNotFound();
            }
            return View(shoporder);
        }

        //
        // POST: /ShopOrder/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SHOPORDER shoporder = db.SHOPORDERs.Find(id);
            db.SHOPORDERs.Remove(shoporder);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}