using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqStudyConsoleApplication
{
    class Student
    {
        public string ID{get;set;}
        public string name { get; set; }
        public string Location { get; set; }
        public static List<Student> GetStudents()
        {
            //List<Student> list = new List<Student>
            //{
            //    new Student(){ID="001",name="XXXX"},
            //    new Student(){ID="002",name="OOOO"},
            //    new Student(){ID="003",name="QQQQ"},
            //};
            //return list;

            return new List<Student>(new[]{
            new Student(){ID="001",name="XXXX"},
            new Student(){ID="002",name="OOOO"},
            new Student(){ID="003",name="QQQQ"}
            });
        }

        public static List<Student> GetStudents2()
        {
            List<Student> list = new List<Student>
            {
                new Student(){ID="001",name="小王",Location="A"},
                new Student(){ID="002",name="小明",Location="B"},
                new Student(){ID="003",name="小楊",Location="B"},
                new Student(){ID="004",name="小強",Location="C"},
                new Student(){ID="005",name="小玉",Location="D"},
                new Student(){ID="006",name="小孫",Location="C"},
                new Student(){ID="007",name="小美",Location="A"},
                new Student(){ID="008",name="小張",Location="D"},
                new Student(){ID="009",name="小花",Location="A"}
            };
            return list;            
        }
    }
}
