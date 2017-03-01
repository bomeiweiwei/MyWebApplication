using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllShow.Models.advertisement
{
    public class Advertisement
    {
        public int adNo { get; set; }
        public int shNo { get; set; }
        public int empNo { get; set; }
        public string adTitle { get; set; }
        public DateTime adApplyDate{ get; set; }
        public DateTime adStartDate { get; set; }
        public double adTime{ get; set; }
        public double adPrice { get; set; }
        public string adPic { get; set; }
        public string adURL { get; set; }
        public string adCheckState { get; set; }
    }
}