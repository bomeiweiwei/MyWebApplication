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
    public class OrderListController : Controller
    {
        private AllShowEntities db = new AllShowEntities();

        //
        // GET: /OrderList/

        public ActionResult Index()
        {
            var orderlists = db.ORDERLISTs.Include(o => o.PRODUCT).Include(o => o.SHOPORDER);
            return View(orderlists.ToList());
        }

        //
        // GET: /OrderList/Details/5

        public ActionResult Details(int id, int id2)
        {
            ORDERLIST orderlist = db.ORDERLISTs.Find(id, id2);
            if (orderlist == null)
            {
                return HttpNotFound();
            }
            return View(orderlist);
        }

        //
        // GET: /OrderList/Create

        public ActionResult Create()
        {
            ViewBag.proNo = new SelectList(db.PRODUCTs, "proNo", "proName");
            ViewBag.shoporderNo = new SelectList(db.SHOPORDERs, "shoporderNo", "orderState");
            return View();
        }

        //
        // POST: /OrderList/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ORDERLIST orderlist)
        {
            if (ModelState.IsValid)
            {
                db.ORDERLISTs.Add(orderlist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.proNo = new SelectList(db.PRODUCTs, "proNo", "proName", orderlist.proNo);
            ViewBag.shoporderNo = new SelectList(db.SHOPORDERs, "shoporderNo", "orderState", orderlist.shoporderNo);
            return View(orderlist);
        }

        //
        // GET: /OrderList/Edit/5

        public ActionResult Edit(int id, int id2)
        {
            ORDERLIST orderlist = db.ORDERLISTs.Find(id, id2);
            if (orderlist == null)
            {
                return HttpNotFound();
            }
            ViewBag.proNo = new SelectList(db.PRODUCTs, "proNo", "proName", orderlist.proNo);
            ViewBag.shoporderNo = new SelectList(db.SHOPORDERs, "shoporderNo", "orderState", orderlist.shoporderNo);
            return View(orderlist);
        }

        //
        // POST: /OrderList/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ORDERLIST orderlist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderlist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.proNo = new SelectList(db.PRODUCTs, "proNo", "proName", orderlist.proNo);
            ViewBag.shoporderNo = new SelectList(db.SHOPORDERs, "shoporderNo", "orderState", orderlist.shoporderNo);
            return View(orderlist);
        }

        //
        // GET: /OrderList/Delete/5

        public ActionResult Delete(int id, int id2)
        {
            ORDERLIST orderlist = db.ORDERLISTs.Find(id, id2);
            if (orderlist == null)
            {
                return HttpNotFound();
            }
            return View(orderlist);
        }

        //
        // POST: /OrderList/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int id2)
        {
            ORDERLIST orderlist = db.ORDERLISTs.Find(id, id2);
            db.ORDERLISTs.Remove(orderlist);
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