using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AllShowMVCApplication.Models;
using System.Data;
using System.Data.Entity;
using System.IO;

using AllShowMVCApplication.Models.shop;
using AllShowMVCApplication.Models.ViewModels;

namespace AllShowMVCApplication.Controllers
{
    public class AllShowFirmController : Controller
    {
        //
        // GET: /AllShowFirm/
        private AllShowEntities db = new AllShowEntities();
        public ActionResult Index()
        {
            if (Session["firmlogin"] == null && Session["firmName"] == null)
            {
                Session["firmlogin"] = false;
                Session["firmName"] = "";
                return RedirectToAction("FirmLogin");
            }

            if (Session["firmlogin"].Equals(true))
            {
                return View();
            }
            else
            {
               
                Session["firmName"] = "";
                return RedirectToAction("FirmLogin");
            }                       
        }

        public ActionResult HeaderEmbed()
        {
            ViewBag.FirmName = Session["firmName"].ToString();
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

        public ActionResult FirmLogin()
        {
            return View();
        }

        public ActionResult CheckFirmLogin(string shaccount, string shpwd)
        {
            if (string.IsNullOrEmpty(shaccount))
            {
                TempData["accountError"] = "帳號請勿空白";
                return RedirectToAction("FirmLogin");
            }

            if (string.IsNullOrEmpty(shpwd))
            {
                TempData["pwdError"] = "密碼請勿空白";
                return RedirectToAction("FirmLogin");
            }

            var query = (from p in db.SHOPs select p).Where(c => c.shaccount == shaccount & c.shpwd == shpwd);
            if (query.ToList().Count > 0)
            {
                SHOP shop = query.ToList().First<SHOP>();
                Session["firmlogin"] = true;
                Session["firmName"] = shop.shname;
                Session["firmno"] = shop.shno;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["shError"] = "帳號或密碼錯誤";
                return RedirectToAction("FirmLogin");
            }
        }

        public ActionResult FirmLogout()
        {
            Session.RemoveAll();
            return RedirectToAction("Index");
        }

        public ActionResult FirmRegister()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FirmRegister(SHOP shop)
        {
            List<string> ErrorMsg = new List<string>();
            
            if (ModelState.IsValid)
            {
                var query = (from p in db.SHOPs select p).Where(c => c.shaccount == shop.shaccount);
                if (query.ToList().Count > 0)
                {
                    ErrorMsg.Add("此帳號已存在");
                }
                else
                {
                    shop.shurl += shop.shaccount;
                }
                query = (from p in db.SHOPs select p).Where(c => c.shaddress == shop.shaddress);
                if (query.ToList().Count > 0)
                {
                    ErrorMsg.Add("此地址已存在");
                }
                query = (from p in db.SHOPs select p).Where(c => c.shtel == shop.shtel);
                if (query.ToList().Count > 0)
                {
                    ErrorMsg.Add("此電話已存在");
                }
                query = (from p in db.SHOPs select p).Where(c => c.shemail == shop.shemail);
                if (query.ToList().Count > 0)
                {
                    ErrorMsg.Add("此e-mail已存在");
                }
                if (ErrorMsg.Count > 0)
                {
                    TempData["ErrorMessage"] = ErrorMsg;
                    return View(shop);
                }

                db.SHOPs.Add(shop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shop);
        }

        public ActionResult FirmManageIndex()
        {
            int shno = Convert.ToInt32(Session["firmno"]);
            var query = (from p in db.SHOPs select p).Where(c => c.shno == shno );
            if (query.ToList().Count > 0)
            {
                SHOP shop = query.ToList().First<SHOP>();
                if (shop.shthepic == null)
                    shop.shthepic = "";
                if (shop.shlogopic == null)
                    shop.shlogopic = "";
                return View(shop);
            }
            else
            {
                return RedirectToAction("FirmLogin");
            }
        }

        public ActionResult FirmDataUpdate()
        {
            int shno = Convert.ToInt32(Session["firmno"]);
            var query = (from p in db.SHOPs select p).Where(c => c.shno == shno);
            if (query.ToList().Count > 0)
            {
                SHOP shop = query.ToList().First<SHOP>();
                ShopViewModel ViewModel = new ShopViewModel()
                {
                    shno = shop.shno,
                    empno = shop.empno,
                    shthepic = shop.shthepic == null ? "" : shop.shthepic,
                    shname = shop.shname,
                    shclassno = shop.shclassno,
                    shaccount = shop.shaccount,
                    shpwd = shop.shpwd,
                    shboss = shop.shboss,
                    shcontact = shop.shcontact,
                    shaddress = shop.shaddress,
                    shtel = shop.shtel,
                    shemail = shop.shemail,
                    shabout = shop.shabout,
                    shlogopic = shop.shlogopic == null ? "" : shop.shlogopic,
                    shurl = shop.shurl,
                    shadstate = shop.shadstate,
                    shadtitle = shop.shadtitle,
                    shadpic = shop.shadpic,
                    shpopshop = shop.shpopshop,
                    shcheckstate = shop.shcheckstate,
                    shstartdate = shop.shstartdate,
                    shenddate = shop.shenddate,
                    shcheckdate = shop.shcheckdate,
                    shpwdstate = shop.shpwdstate,
                    shstoprightstartdate = shop.shstoprightstartdate,
                    shstoprightenddate = shop.shstoprightenddate
                };
                ViewBag.shclassno = new SelectList(db.SHCLASSes, "shclassno", "shclassname", shop.shclassno);
                return View(ViewModel);
            }
            else
            {
                return RedirectToAction("FirmLogin");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FirmDataUpdate(ShopViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                // Use your file here
                if (ViewModel.File1 != null)
                {
                    DateTime d = DateTime.Now;
                    string filename = "pic_" + String.Format("{0:yyyyMMddHHmmss}", d).ToString() + ".jpg";
                    var path = Path.Combine(Server.MapPath("~/FileUpLoads"), filename);
                    try
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            using (FileStream filestream = new FileStream(path.ToString(), FileMode.Create))
                            {
                                ViewModel.File1.InputStream.CopyTo(memoryStream);
                                memoryStream.WriteTo(filestream);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine(ex.Message.ToString());
                    }
                    ViewModel.shthepic = path.ToString();
                }

                if (ViewModel.File2 != null)
                {
                    DateTime d = DateTime.Now;
                    string filename = "logo_"+String.Format("{0:yyyyMMddHHmmss}", d).ToString() + ".jpg";
                    var path = Path.Combine(Server.MapPath("~/FileUpLoads"), filename);
                    try
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            using (FileStream filestream = new FileStream(path.ToString(), FileMode.Create))
                            {
                                ViewModel.File2.InputStream.CopyTo(memoryStream);
                                memoryStream.WriteTo(filestream);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine(ex.Message.ToString());
                    }
                    ViewModel.shlogopic = path.ToString();
                }

                SHOP shop = new SHOP() {
                    shno = ViewModel.shno,
                    empno = ViewModel.empno,
                    shthepic = ViewModel.shthepic,
                    shname = ViewModel.shname,
                    shclassno = ViewModel.shclassno,
                    shaccount = ViewModel.shaccount,
                    shpwd = ViewModel.shpwd,
                    shboss = ViewModel.shboss,
                    shcontact = ViewModel.shcontact,
                    shaddress = ViewModel.shaddress,
                    shtel = ViewModel.shtel,
                    shemail = ViewModel.shemail,
                    shabout = ViewModel.shabout,
                    shlogopic = ViewModel.shlogopic,
                    shurl = ViewModel.shurl,
                    shadstate = ViewModel.shadstate,
                    shadtitle = ViewModel.shadtitle,
                    shadpic = ViewModel.shadpic,
                    shpopshop = ViewModel.shpopshop,
                    shcheckstate = ViewModel.shcheckstate,
                    shstartdate = ViewModel.shstartdate,
                    shenddate = ViewModel.shenddate,
                    shcheckdate = ViewModel.shcheckdate,
                    shpwdstate = ViewModel.shpwdstate,
                    shstoprightstartdate = ViewModel.shstoprightstartdate,
                    shstoprightenddate = ViewModel.shstoprightenddate
                };
                db.Entry(shop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("FirmManageIndex");
            }
            ViewBag.shclassno = new SelectList(db.SHCLASSes, "shclassno", "shclassname", ViewModel.shclassno);
            return View(ViewModel);
        }
       
        public ActionResult FirmProductManageIndex()
        {
            return View();
        }

        public ActionResult FirmAdvertiseManageIndex()
        {
            return View();
        }

        public ActionResult FirmOrderManageIndex()
        {
            return View();
        }
    }
}
