﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AllShowMVCApplication.Models;

namespace AllShowMVCApplication.Controllers
{
    public class AuthorityController : Controller
    {
        private AllShowEntities db = new AllShowEntities();

        //
        // GET: /Authority/

        public ActionResult Index()
        {
            return View(db.AUTHORITies.ToList());
        }

        //
        // GET: /Authority/Details/5

        public ActionResult Details(int id, int id2)
        {
            AUTHORITY authority = db.AUTHORITies.Find(id, id2);
            if (authority == null)
            {
                return HttpNotFound();
            }
            return View(authority);
        }

        //
        // GET: /Authority/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Authority/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AUTHORITY authority)
        {
            if (ModelState.IsValid)
            {
                db.AUTHORITies.Add(authority);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(authority);
        }

        //
        // GET: /Authority/Edit/5

        public ActionResult Edit(int id, int id2)
        {
            AUTHORITY authority = db.AUTHORITies.Find(id, id2);
            if (authority == null)
            {
                return HttpNotFound();
            }
            return View(authority);
        }

        //
        // POST: /Authority/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AUTHORITY authority)
        {
            if (ModelState.IsValid)
            {
                db.Entry(authority).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(authority);
        }

        //
        // GET: /Authority/Delete/5

        public ActionResult Delete(int id, int id2)
        {
            AUTHORITY authority = db.AUTHORITies.Find(id, id2);
            if (authority == null)
            {
                return HttpNotFound();
            }
            return View(authority);
        }

        //
        // POST: /Authority/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int id2)
        {
            AUTHORITY authority = db.AUTHORITies.Find(id, id2);
            db.AUTHORITies.Remove(authority);
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