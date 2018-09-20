using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MVCStudy.Models;

namespace MVCStudy.Controllers
{
    public class EmployeeController : Controller
    {
        //AllShowDbContext db = new AllShowDbContext();
        AllShowEntities db = new AllShowEntities();

        // GET: Employee
        public ActionResult Index()
        {
            //var emps = db.Emps.ToList();
            var emps = db.EMPLOYEEs.ToList();
            List<MVCStudy.Models.employee.Employee> empList = new List<Models.employee.Employee>();

            foreach (var emp in emps)
            {
                MVCStudy.Models.employee.Employee e = new Models.employee.Employee();
                e.empno = emp.empno;
                e.empaccount = emp.empaccount;
                e.emppwd = emp.emppwd;
                e.empname = emp.empname;
                e.EMPEMAIL = emp.EMPEMAIL;
                e.empsex = emp.empsex;
                e.empbirth = emp.empbirth;
                e.emptel = emp.emptel;
                e.hiredate = emp.hiredate;
                e.leavedate = emp.leavedate;
                e.empaccountstate = emp.empaccountstate;

                empList.Add(e);
            }

            //return View(emps);
            return View(empList);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(MVCStudy.Models.employee.Employee emp)
        {
            if (ModelState.IsValid)
            {
                EMPLOYEE employee = new EMPLOYEE()
                {
                    empaccount = emp.empaccount,
                    emppwd = emp.emppwd,
                    empname = emp.empname,
                    EMPEMAIL = emp.EMPEMAIL,
                    empsex = emp.empsex,
                    empbirth = emp.empbirth,
                    emptel = emp.emptel,
                    hiredate = emp.hiredate,
                    leavedate = emp.leavedate,
                    empaccountstate = emp.empaccountstate
                };

                db.EMPLOYEEs.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emp);
        }

        public ActionResult EmpIndex()
        {
            return View(db.EMPLOYEEs.ToList());
        }

        public ActionResult EmpCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EmpCreate(EMPLOYEE employee)
        {
            if (ModelState.IsValid)
            {
                db.EMPLOYEEs.Add(employee);
                db.SaveChanges();
                return RedirectToAction("EmpIndex");
            }

            return View(employee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}