using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using AllShow_WebSite.Models;
using AllShow_WebSite.Models.ViewModels;
using PagedList;

namespace AllShow_WebSite.Controllers
{
    public class ShClassShopController : Controller
    {
        int pageSize = 5;
        // GET: ShClassShop
        public ActionResult Index(int shclassno = 1, int page = 1)
        {
            AllShow db = new AllShow();
            int currentPage = page < 1 ? 1 : page;
            ViewBag.shclassno = shclassno;

            var shopsResult = db.GetShop.Get().Where(m => m.shclassno == shclassno).OrderBy(m => m.shno).ToList().ToPagedList(currentPage, pageSize);

            ViewBag.shclassName = db.GetShclass.Get().Where(m => m.shclassno == shclassno).FirstOrDefault().shclassname;
            ShClassShopViewModel shClassShop = new ShClassShopViewModel()
            {
                shClasses = db.GetShclass.Get().OrderBy(m => m.shclassno).ToList(),
                shops = shopsResult,
                SHOPs = shopsResult
            };

            return View(shClassShop);
        }
    }
}