using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MVCStudy.Models;

namespace MVCStudy.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {
            AllShow db = new AllShow();

            IEnumerable<SHOP> shops = db.GetShop.Get();
            return View(shops);
        }
    }
}