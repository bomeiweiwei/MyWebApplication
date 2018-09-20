using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AllShowMVCApplication.Models;
using System.Data;
using System.Data.Entity;
using System.IO;

using AllShowMVCApplication.Models.ViewModels;

namespace AllShowMVCApplication.Controllers
{
    public class AllShowMemberController : Controller
    {
        //
        // GET: /AllShowMember/
        private AllShowEntities db = new AllShowEntities();
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

        public ActionResult UserLogin(string mememail)
        {
            ViewBag.Mail = mememail;
            return View();
        }

        public ActionResult CheckUserLogin(string mememail, string mempwd)
        {
            if (string.IsNullOrEmpty(mememail))
            {
                TempData["mailError"] = "帳號請勿空白";
                return RedirectToAction("UserLogin");
            }

            if (string.IsNullOrEmpty(mempwd))
            {
                TempData["pwdError"] = "密碼請勿空白";
                return RedirectToAction("UserLogin", new { mememail = mememail });
            }

            var query = (from p in db.MEMBERs select p).Where(c => c.mememail == mememail & c.mempwd == mempwd);
            if (query.ToList().Count > 0)
            {
                MEMBER member = query.ToList().First<MEMBER>();
                Session["login"] = true;
                Session["memName"] = member.memname;
                Session["memno"] = member.memno;
                return RedirectToAction("Index", "AllShow");
            }
            else
            {
                TempData["memError"] = "帳號或密碼錯誤";
                return RedirectToAction("UserLogin", new { mememail = mememail });
            }
        }

        public ActionResult UserLogout()
        {
            Session.RemoveAll();
            return RedirectToAction("Index", "AllShow");
        }

        public ActionResult UserRegister()
        {
            ViewBag.Title = "會員註冊";
            return View();
        }

        public ActionResult UserRegister2()
        {
            MemberViewModel viewmodel = new MemberViewModel();
            ViewBag.Title = "會員註冊";
            return View(viewmodel);
        }
      
        [HttpPost]
        public ActionResult CheckUserRegister(string memEmail, string memPwd, string memPwdConfirmed, string memDiminutive,
            string memName, string memSex, string memBirth, string memTel, string memAddress, string memCheckNumber,
            HttpPostedFileBase file)
        {
            List<string> ErrorMessage = new List<string>();
            if (string.IsNullOrEmpty(memEmail))
            {
                ErrorMessage.Add("信箱請勿空白");
            }
            else
            {
                var query = (from p in db.MEMBERs select p).Where(c => c.mememail == memEmail);
                if (query.ToList().Count > 0)
                {
                    ErrorMessage.Add("信箱已經被使用，請重新填寫");
                }

                if (memEmail.IndexOf("@", 0) < 0)
                {
                    ErrorMessage.Add("請填入正確信箱格式，如:xxx@gmail.com");
                } 
            }

            if (string.IsNullOrEmpty(memPwd) || string.IsNullOrEmpty(memPwdConfirmed))
            {
                ErrorMessage.Add("請填入正確密碼");
            }
            else
            {
                if (!memPwd.Equals(memPwdConfirmed))
                    ErrorMessage.Add("請填入正確密碼");
            }

            if (string.IsNullOrEmpty(memName))
            {
                ErrorMessage.Add("請填入會員姓名");
            }

            if (string.IsNullOrEmpty(memBirth))
            {
                ErrorMessage.Add("請填入生日");
            }

            if (string.IsNullOrEmpty(memTel))
            {
                ErrorMessage.Add("請填入電話");
            }

            if (string.IsNullOrEmpty(memAddress))
            {
                ErrorMessage.Add("請填入地址");
            }

            if (ErrorMessage.Count > 0)
            {
                TempData["ErrorMessage"] = ErrorMessage;
                return RedirectToAction("UserRegister");
            }
            else
            {
                MEMBER member = new MEMBER() {
                mememail=memEmail,
                mempwd=memPwd,
                memdiminutive=memDiminutive,
                memname=memName,
                memsex=memSex,
                membirth=Convert.ToDateTime(memBirth),
                memtel=memTel,
                memaddress=memAddress,
                memchecknumber=memCheckNumber,
                memcreatedate=DateTime.Now,
                memaccountstate="0"
                };
                if (file != null)
                {
                    if (file.ContentLength > 0)
                    {
                        DateTime d=DateTime.Now;
                        string filename = String.Format("{0:yyyyMMddHHmmss}", d).ToString()+".jpg";
                        var path = Path.Combine(Server.MapPath("~/FileUpLoads"), filename);
                        file.SaveAs(path);

                        member.mempic = path.ToString();
                    }
                }
                try
                {
                    db.MEMBERs.Add(member);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message.ToString());
                }
            }

            return RedirectToAction("Index", "AllShow");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckUserRegister2(MemberViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                // Use your file here
                if (viewmodel.File != null)
                {
                    DateTime d = DateTime.Now;
                    string filename = String.Format("{0:yyyyMMddHHmmss}", d).ToString() + ".jpg";
                    var path = Path.Combine(Server.MapPath("~/FileUpLoads"), filename);
                    try
                    {                       
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            using (FileStream filestream = new FileStream(path.ToString(), FileMode.Create))
                            {
                                viewmodel.File.InputStream.CopyTo(memoryStream);
                                memoryStream.WriteTo(filestream);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine(ex.Message.ToString());
                    }
                    viewmodel.mempic = path.ToString();
                }

                MEMBER member = new MEMBER()
                {
                    mememail = viewmodel.mememail,
                    mempwd = viewmodel.mempwd,
                    memdiminutive = viewmodel.memdiminutive,
                    memname = viewmodel.memname,
                    memsex = viewmodel.memsex,
                    membirth = Convert.ToDateTime(viewmodel.membirth),
                    memtel = viewmodel.memtel,
                    memaddress = viewmodel.memaddress,
                    mempic = viewmodel.mempic,
                    memchecknumber = viewmodel.memchecknumber,
                    memcreatedate = DateTime.Now,
                    memaccountstate = "0"
                };
                db.MEMBERs.Add(member);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "AllShow");
        }

        public ActionResult UserDataUpdate()
        {
            int memno = Convert.ToInt32(Session["memno"].ToString());
            var query = (from p in db.MEMBERs select p).Where(c => c.memno == memno);
            if (query.ToList().Count > 0)
            {
                MEMBER member = query.ToList().First<MEMBER>();
                MemberViewModel ViewModel = new MemberViewModel()
                {
                    memno = member.memno,
                    mememail = member.mememail,
                    mempwd = member.mempwd,
                    memdiminutive = member.memdiminutive,
                    memname = member.memname,
                    memsex = member.memsex,
                    membirth = member.membirth,
                    memtel = member.memtel,
                    memaddress = member.memaddress,
                    mempic = member.mempic == null ? "" : member.mempic,
                    memchecknumber = member.memchecknumber,
                    memcreatedate = member.memcreatedate,
                    memupdatedate = member.memupdatedate,
                    memaccountstate = member.memaccountstate
                };

                return View(ViewModel);
            }
            else {
                return RedirectToAction("UserLogout", "AllShowMember");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckUserDataUpdate(MemberViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                // Use your file here
                if (viewmodel.File != null)
                {
                    DateTime d = DateTime.Now;
                    string filename = String.Format("{0:yyyyMMddHHmmss}", d).ToString() + ".jpg";
                    var path = Path.Combine(Server.MapPath("~/FileUpLoads"), filename);
                    try
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            using (FileStream filestream = new FileStream(path.ToString(), FileMode.Create))
                            {
                                viewmodel.File.InputStream.CopyTo(memoryStream);
                                memoryStream.WriteTo(filestream);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine(ex.Message.ToString());
                    }
                    viewmodel.mempic = path.ToString();
                }

                MEMBER member = new MEMBER()
                {
                    memno = viewmodel.memno,
                    mememail = viewmodel.mememail,
                    mempwd = viewmodel.mempwd,
                    memdiminutive = viewmodel.memdiminutive,
                    memname = viewmodel.memname,
                    memsex = viewmodel.memsex,
                    membirth = Convert.ToDateTime(viewmodel.membirth),
                    memtel = viewmodel.memtel,
                    memaddress = viewmodel.memaddress,
                    mempic = viewmodel.mempic,
                    memchecknumber = viewmodel.memchecknumber,
                    memcreatedate = viewmodel.memcreatedate,
                    memaccountstate = viewmodel.memaccountstate,
                    memupdatedate = DateTime.Now
                };

                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","AllShow");
            }
            else
            {
                return RedirectToAction("UserDataUpdate");
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
