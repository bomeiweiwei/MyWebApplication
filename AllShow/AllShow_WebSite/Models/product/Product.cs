using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllShow_WebSite.Models.product
{
    public class Product
    {
        public int proNo { get; set; }
        public int shNo { get; set; }
        public int proClassNo { get; set; }
        public string proName { get; set; }
        public double proPrice { get; set; }
        public string proStatement { get; set; }
        public string proState { get; set; }
        public string proPic1 { get; set; }
        public string proPic2 { get; set; }
        public string proPic3 { get; set; }
        public DateTime? proCreateDate { get; set; }
        public DateTime? proUpdateDate { get; set; }
        public DateTime? proOffShelfDate { get; set; }
        public string proPop { get; set; }
    }
}