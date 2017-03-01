using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllShow.Models.member
{
    public class Member
    {
        public int memno { get; set; }
        public string mememail { get; set; }
        public string mempwd { get; set; }
        public string memdiminutive { get; set; }
        public string memname { get; set; }
        public string memsex { get; set; }
        public string memtel { get; set; }
        public string memaddress { get; set; }
        public string mempic { get; set; }
        public string memaccountstate { get; set; }
        public string memchecknumber { get; set; }
        public DateTime memcreatedate { get; set; }
        public DateTime? memupdatedate { get; set; }
        public DateTime? membirth { get; set; }
    }
}