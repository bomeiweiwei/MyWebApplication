using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllShow.Models.employee
{
    public class Employee
    {
        public int empno { get; set; }
        public string empname { get; set; }
        public string empaccount { get; set; }
        public string emppwd { get; set; }
        public string empemill { get; set; }
        public string empsex { get; set; }
        public DateTime empbirth { get; set; }
        public string emptel { get; set; }
        public DateTime hiredate { get; set; }
        public DateTime? leavedate { get; set; }
        public string empaccountstate { get; set; }

    }
}