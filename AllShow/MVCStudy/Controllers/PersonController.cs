using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MVCStudy.Models.Person;
//using MVCStudy.Models;
using PagedList;

namespace MVCStudy.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index(int page = 1)
        {
            int pageSize = 3;
            int pagecurrent = page < 1 ? 1 : page;

            string[] id = new string[] { "M01", "M02", "M03", "M04", "M05" };
            string[] name = new string[] { "織田信長", "柴田勝家", "前田利家", "羽柴秀吉", "明智光秀" };
            int[] age = new int[] { 15, 31, 20, 38, 44 };
            string[] imgName = new string[] { "1.jpg", "2.jpg", "3.jpg", "4.jpg", "5.jpg" };
            //string[] history = new string[] { };

            List<Person> people = new List<Person>();
            for (int i = 0; i < id.Length; i++)
            {
                Person person = new Person
                {
                    ID = id[i],
                    Name=name[i],
                    Age=age[i],
                    ImgName=imgName[i]
                };
                people.Add(person);
            }

            var pagelist = people.ToPagedList(pagecurrent, pageSize);
           
            return View(pagelist);
        }
    }
}