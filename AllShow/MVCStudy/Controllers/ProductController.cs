using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MVCStudy.Models;

namespace MVCStudy.Controllers
{
    public class ProductController : Controller
    {
        AllShowEntities db = new AllShowEntities();
        // GET: Product
        public ActionResult Index()
        {
            //ViewBag.shopNo = new SelectList(db.SHOPs, "shno", "shname");
            //ViewBag.proClassNo = new SelectList(db.PRODUCTCLASSes, "proclassno", "proclassname");
            var shops = db.SHOPs;
            List<SelectListItem> shopItems = new List<SelectListItem>();
            foreach (var shop in shops)
            {
                shopItems.Add(new SelectListItem()
                {
                    Text = shop.shname,
                    Value = shop.shno.ToString(),
                    Selected = shop.shno.Equals(1)
                });
            }

            var proclasses = db.PRODUCTCLASSes.Where(m => m.shno == 1);
            List<SelectListItem> proclassItems = new List<SelectListItem>();
            foreach (var proclass in proclasses)
            {
                proclassItems.Add(new SelectListItem()
                {
                    Text = proclass.proclassname,
                    Value = proclass.proclassno.ToString(),
                    
                });
            }
            ViewBag.shops = shopItems;
            ViewBag.proClasses = proclassItems;

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}