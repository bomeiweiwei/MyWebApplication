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
    public class FavoriteshoplistController : Controller
    {
        private AllShowEntities db = new AllShowEntities();

        // GET: Admin/Favoriteshoplist
        public ActionResult Index()
        {
            var fAVORITESHOPLISTs = db.FAVORITESHOPLISTs.Include(f => f.MEMBER).Include(f => f.SHOP);
            return View(fAVORITESHOPLISTs.ToList());
        }

        // GET: Admin/Favoriteshoplist/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAVORITESHOPLIST fAVORITESHOPLIST = db.FAVORITESHOPLISTs.Find(id);
            if (fAVORITESHOPLIST == null)
            {
                return HttpNotFound();
            }
            return View(fAVORITESHOPLIST);
        }

        // GET: Admin/Favoriteshoplist/Create
        public ActionResult Create()
        {
            ViewBag.memNo = new SelectList(db.MEMBERs, "memno", "mememail");
            ViewBag.shNo = new SelectList(db.SHOPs, "shno", "shthepic");
            return View();
        }

        // POST: Admin/Favoriteshoplist/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "memNo,shNo,note")] FAVORITESHOPLIST fAVORITESHOPLIST)
        {
            if (ModelState.IsValid)
            {
                db.FAVORITESHOPLISTs.Add(fAVORITESHOPLIST);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.memNo = new SelectList(db.MEMBERs, "memno", "mememail", fAVORITESHOPLIST.memNo);
            ViewBag.shNo = new SelectList(db.SHOPs, "shno", "shthepic", fAVORITESHOPLIST.shNo);
            return View(fAVORITESHOPLIST);
        }

        // GET: Admin/Favoriteshoplist/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAVORITESHOPLIST fAVORITESHOPLIST = db.FAVORITESHOPLISTs.Find(id);
            if (fAVORITESHOPLIST == null)
            {
                return HttpNotFound();
            }
            ViewBag.memNo = new SelectList(db.MEMBERs, "memno", "mememail", fAVORITESHOPLIST.memNo);
            ViewBag.shNo = new SelectList(db.SHOPs, "shno", "shthepic", fAVORITESHOPLIST.shNo);
            return View(fAVORITESHOPLIST);
        }

        // POST: Admin/Favoriteshoplist/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "memNo,shNo,note")] FAVORITESHOPLIST fAVORITESHOPLIST)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fAVORITESHOPLIST).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.memNo = new SelectList(db.MEMBERs, "memno", "mememail", fAVORITESHOPLIST.memNo);
            ViewBag.shNo = new SelectList(db.SHOPs, "shno", "shthepic", fAVORITESHOPLIST.shNo);
            return View(fAVORITESHOPLIST);
        }

        // GET: Admin/Favoriteshoplist/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAVORITESHOPLIST fAVORITESHOPLIST = db.FAVORITESHOPLISTs.Find(id);
            if (fAVORITESHOPLIST == null)
            {
                return HttpNotFound();
            }
            return View(fAVORITESHOPLIST);
        }

        // POST: Admin/Favoriteshoplist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FAVORITESHOPLIST fAVORITESHOPLIST = db.FAVORITESHOPLISTs.Find(id);
            db.FAVORITESHOPLISTs.Remove(fAVORITESHOPLIST);
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
