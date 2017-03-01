using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Linq.Mapping;

namespace LinqStudyConsoleApplication
{
    [Table(Name = "student_test")]
    class Student_Test
    {
        [Column]
        public int id { get; set; }
        [Column]
        public string name { get; set; }
        [Column]
        public string student_id { get; set; }
        [Column]
        public string city { get; set; }
        [Column]
        public int chinese { get; set; }
        [Column]
        public int math { get; set; }
    }
}
