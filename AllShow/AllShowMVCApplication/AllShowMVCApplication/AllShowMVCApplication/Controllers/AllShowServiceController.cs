using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllShowMVCApplication.Controllers
{
    public class AllShowServiceController : Controller
    {
        //
        // GET: /AllShowService/

        public ActionResult Index()
        {
            return View();
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

            return View("~/Views/AllShow/HeaderEmbed.cshtml");
        }

        public ActionResult NavEmbed()
        {
            return View("~/Views/AllShow/NavEmbed.cshtml");
        }

        public ActionResult FooterEmbed()
        {
            return View("~/Views/AllShow/FooterEmbed.cshtml");
        }

    }
}
