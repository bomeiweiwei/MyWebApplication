using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MVCStudy.Models;

namespace MVCStudy.Controllers
{
    public class SimpleMessageController : Controller
    {
        AllShowEntities db = new AllShowEntities();

        // GET: SimpleMessage
        public ActionResult Index()
        {
            var messages = db.Messages.ToList();
            return View(messages);
        }

        public ActionResult Create()
        {
            ViewBag.Title = "新增訊息";
            return View();
        }

        [HttpPost]
        public ActionResult Create(string Subject,string Content,string author,string e_mail)
        {
            Message message = new Message
            {
                Subject = Subject,
                Content = Content,
                author = author,
                PostDateTime = DateTime.Now,
                e_mail = e_mail
            };

            db.Messages.Add(message);
            db.SaveChanges();
            ViewBag.Result = "新增完成";
            return View();
        }

        public ActionResult Create2()
        {
            ViewBag.Title = "新增訊息";
            return View();
        }

        [HttpPost]
        public ActionResult Create2(Message message)
        {
            message.PostDateTime = DateTime.Now;

            db.Messages.Add(message);
            db.SaveChanges();
            ViewBag.Result = "新增完成";
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