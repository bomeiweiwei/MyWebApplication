using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MVCStudy.Models;
using System.IO;
using PagedList;
using System.Net;

namespace MVCStudy.Controllers
{
    public class MemberController : Controller
    {
        AllShowEntities db = new AllShowEntities();

        // GET: Member
        public ActionResult Index(int page = 1)
        {
            int pagesize = 5;
            int pagecurrent = page < 1 ? 1 : page;
            var mems = db.MEMBERs.OrderBy(m => m.memno).ToList();

            var pagedlist = mems.ToPagedList(pagecurrent, pagesize);
            //return View(mems);
            return View(pagedlist);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string mememail, string mempwd, string memdiminutive, string memname, string memsex, string memtel, string memaddress, string memaccountstate, string memchecknumber,DateTime memcreatedate, DateTime memupdatedate, DateTime membirth, HttpPostedFileBase file)
        {
            MEMBER member = new MEMBER();
            member.mememail = mememail;
            member.mempwd = mempwd;
            member.memdiminutive = memdiminutive;
            member.memname = memname;
            member.memsex = memsex;
            member.memtel = memtel;
            member.memaddress = memaddress;

            if (file != null)
            {
                if (file.ContentLength > 0)
                {
                    DateTime d = DateTime.Now;
                    string filename = String.Format("{0:yyyyMMddHHmmss}", d).ToString() + ".jpg";
                    var path = Path.Combine(Server.MapPath("~/images/FileUpLoads"), filename);
                    file.SaveAs(path);

                    member.mempic = "FileUpLoads/" + filename;
                }
            }

            member.memaccountstate = memaccountstate;
            member.memchecknumber = memchecknumber;
            member.memcreatedate = memcreatedate;
            member.memupdatedate = memupdatedate;
            member.membirth = membirth;

            db.MEMBERs.Add(member);
            db.SaveChanges();
            return RedirectToAction("Index");           
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var member = db.MEMBERs.Where(m => m.memno == id).FirstOrDefault();

            if (member == null)
            {
                return HttpNotFound();
            }

            db.MEMBERs.Remove(member);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var member = db.MEMBERs.Where(m => m.memno == id).FirstOrDefault();

            if (member == null)
            {
                return HttpNotFound();
            }

            return View(member);
        }

        [HttpPost]
        public ActionResult Edit(int memno, string mememail, string mempwd, string memdiminutive, string memname, string memsex, string memtel, string memaddress,string mempic, string memaccountstate, string memchecknumber, DateTime memcreatedate, DateTime memupdatedate, DateTime membirth, HttpPostedFileBase file)
        {
            var member = db.MEMBERs.Where(m => m.memno == memno).FirstOrDefault();
            member.mememail = mememail;
            member.mempwd = mempwd;
            member.memdiminutive = memdiminutive;
            member.memname = memname;
            member.memsex = memsex;
            member.memtel = memtel;
            member.memaddress = memaddress;

            if (file != null)
            {
                if (file.ContentLength > 0)
                {
                    DateTime d = DateTime.Now;
                    string filename = String.Format("{0:yyyyMMddHHmmss}", d).ToString() + ".jpg";
                    var path = Path.Combine(Server.MapPath("~/images/FileUpLoads"), filename);
                    file.SaveAs(path);

                    member.mempic = "FileUpLoads/" + filename;
                }
            }
            else
                member.mempic = mempic;

            member.memaccountstate = memaccountstate;
            member.memchecknumber = memchecknumber;
            member.memcreatedate = memcreatedate;
            member.memupdatedate = DateTime.Now;
            member.membirth = membirth;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var member = db.MEMBERs.Where(m => m.memno == id).FirstOrDefault();

            if (member == null)
            {
                return HttpNotFound();
            }

            return View(member);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}