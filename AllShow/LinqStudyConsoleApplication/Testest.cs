using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinqStudyConsoleApplication
{
    [Table("test")]
    class Testest
    {
        [Key]
        public int id { get; set; }
        public DateTime test_time { get; set; }
        public string @class { get; set; }
        public string title { get; set; }
        public string summary { get; set; }
        public string article { get; set; }
        public string author { get; set; }
        public int hit_no { get; set; }
        public int get_no { get; set; }
        public int email_no { get; set; }
        public string approved { get; set; }
    }
}
