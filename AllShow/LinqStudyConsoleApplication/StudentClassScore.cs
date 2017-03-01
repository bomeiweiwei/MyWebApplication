using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqStudyConsoleApplication
{
    class StudentClassScore
    {
        public string SID { get; set; }
        public string ClassName { get; set; }
        public int? Score { get; set; }
        public StudentClassScore()
        {
            SID = "";
            ClassName = "";
            Score = 0;
        }
    }
}
