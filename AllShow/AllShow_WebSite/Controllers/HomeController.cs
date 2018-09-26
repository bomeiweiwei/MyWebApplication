using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using AllShow_WebSite.Models;
using AllShow_WebSite.Models.other;
using AllShow_WebSite.Models.shop;

namespace AllShow_WebSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            AllShow db = new AllShow();
            var advertisements=db.GetAdvertisement.Get().Take(3).OrderByDescending(x => x.adNo).ToList();//廣告取出3項
            var announcements = db.GetAnnouncement.Get().Take(3).OrderByDescending(x => x.announcementno).ToList();//公告取出3項
            var shclasses = db.GetShclass.Get().OrderBy(x => x.shclassno);//商店類別

            List<ShopAdvertise> shopAdvertises = new List<ShopAdvertise>();//將廣告資料重新封裝丟置前端
            foreach (var item in advertisements)
            {
                Shop shop = db.GetShop.Get().Where(m => m.shno == item.shNo).FirstOrDefault();
                ShopAdvertise shopAdvertise = new ShopAdvertise();
                shopAdvertise.aditle = item.adTitle;//字串縮減
                shopAdvertise.shName = shop != null ? shop.shname : "";
                shopAdvertise.shNo = shop != null ? shop.shno : 1;
                shopAdvertises.Add(shopAdvertise);
            }

            List<Announce> announces = new List<Announce>();//將公告資料重新封裝丟置前端
            foreach (var item in announcements)
            {
                Announce announce = new Announce();
                announce.announcementtype = item.announcementtype;
                announce.announcementtitle = item.announcementtitle;//字串縮減
                announce.announcementcontent = item.announcementcontent;//字串縮減
                announces.Add(announce);
            }

            ViewBag.advertise = shopAdvertises;
            ViewBag.announce = announces;

            return View(shclasses);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}