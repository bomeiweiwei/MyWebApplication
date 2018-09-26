using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using AllShow_WebSite.Models;
using AllShow_WebSite.Models.shop;
using AllShow_WebSite.Models.productclass;
using AllShow_WebSite.Models.product;
using AllShow_WebSite.Models.ViewModels;
using PagedList;

namespace AllShow_WebSite.Controllers
{
    public class ProductClassController : Controller
    {
        int pageSize = 5;
        // GET: ProductClass
        public ActionResult Index(int shno = 1, int proclassno = 1, int page = 1)
        {
            AllShow db = new AllShow();
            int currentPage = page < 1 ? 1 : page;
            ViewBag.proclssno = proclassno;

            Shop shop= db.GetShop.FindOne(shno);

            ViewBag.shName = shop.shname;
            ViewBag.shno = shop.shno;
            ViewBag.shclassno = shop.shclassno;

            ProductClassProductViewModel pcpv = new ProductClassProductViewModel();

            var productClassResult = db.GetProductclass.Get().Where(m => m.shno == shno).OrderBy(m => m.proclassno).ToList();

            bool check = db.GetProductclass.Get().Where(m => m.shno == shno).Where(m => m.proclassno == proclassno).Any();
            if (check)
            {
                var productResult = db.GetProduct.Get().Where(m => m.shNo == shno).Where(m => m.proClassNo == proclassno).OrderByDescending(m => m.proNo).ToList().ToPagedList(currentPage, pageSize);
                pcpv.productClasses = productClassResult;
                pcpv.products = productResult;
                pcpv.PRODUCTs = productResult;
            }
            else
            {
                Productclass productclass = db.GetProductclass.Get().Where(m => m.shno == shno).OrderBy(m => m.proclassno).FirstOrDefault();

                int defaultClassNo = productclass != null ? productclass.proclassno : 1;

                var productResult = db.GetProduct.Get().Where(m => m.shNo == shno).Where(m => m.proClassNo == defaultClassNo).OrderByDescending(m => m.proNo).ToList().ToPagedList(currentPage, pageSize);
                pcpv.productClasses = productClassResult;
                pcpv.products = productResult;
                pcpv.PRODUCTs = productResult;
            }
            
            return View(pcpv);
        }
    }
}