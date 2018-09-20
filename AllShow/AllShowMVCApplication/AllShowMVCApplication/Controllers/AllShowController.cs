using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AllShowMVCApplication.Models;
using System.Data.Entity;

using AllShowMVCApplication.Models.ViewModels;

namespace AllShowMVCApplication.Controllers
{
    public class AllShowController : Controller
    {
        //
        // GET: /AllShow/
        private AllShowEntities db = new AllShowEntities();
        public ActionResult Index()
        {
            ShClassAdvAnnViewModel viewModel = new ShClassAdvAnnViewModel();
            viewModel.shClasses = (from p in db.SHCLASSes select p).OrderBy(x => x.shclassno).ToList();
            viewModel.advertisements = (from q in db.ADVERTISEMENTs select q).Take(5).OrderByDescending(x=>x.adNo).ToList();
            viewModel.announcements = (from r in db.ANNOUNCEMENTs select r).Take(3).OrderByDescending(x => x.announcementno).ToList();
            foreach (var item in viewModel.advertisements)
            {
                viewModel.adTitle = item.adTitle;
                item.adTitle = viewModel.adTitle;
            }
            foreach (var item in viewModel.announcements)
            {
                viewModel.announcementtitle = item.announcementtitle;
                item.announcementtitle = viewModel.announcementtitle;
            }
            foreach (var item in viewModel.announcements)
            {
                viewModel.announcementcontent = item.announcementcontent;
                item.announcementcontent = viewModel.announcementcontent;
            }

            return View(viewModel);
            //return View(
            //   new ShClassAdvAnnViewModel()
            //   {
            //       shClasses = (from p in db.SHCLASSes select p).ToList(),
            //       advertisements = (from q in db.ADVERTISEMENTs select q).Take(5).ToList(),
            //       announcements = (from r in db.ANNOUNCEMENTs select r).Take(5).ToList()
            //   });
        }

        public ActionResult HeaderEmbed()
        {
            if (Session["login"] == null && Session["memName"] == null)
            {
                Session["login"] = false;
                Session["memName"] = "";
            }

            if (Session["login"].Equals(true))
            {
                ViewBag.MemName = Session["memName"].ToString();
            }
            else
            {
                ViewBag.MemName = "";
                Session["memName"] = "";
            }

            return View();
        }

        public ActionResult NavEmbed()
        {
            return View();
        }

        public ActionResult FooterEmbed()
        {
            return View();
        }

        public ActionResult ShClass(string val)
        {
            int shclassno = Convert.ToInt32(val);
            var query = (from p in db.SHCLASSes select p).Where(c => c.shclassno == shclassno);

            string shclassname = query.ToList().First<SHCLASS>().shclassname;
            ViewBag.ShClassName = shclassname;

            ShClassShopViewModel viewModel = new ShClassShopViewModel();
            viewModel.shClasses = (from p in db.SHCLASSes select p).OrderBy(x => x.shclassno).ToList();
            viewModel.shops = (from p in db.SHOPs select p).Where(c => c.shclassno == shclassno).OrderBy(x => x.shno).ToList();
            return View(viewModel);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
