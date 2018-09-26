using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllShow_WebSite.Models.shoporder
{
    public class Shoporder
    {
        public int shoporderNo { get; set; }
        public int orderNo { get; set; }
        public int shNo { get; set; }
        public double orderPrice{ get; set; }
        public DateTime? referredToDate { get; set; }
        public DateTime? transactionDate { get; set; }
        public string orderState { get; set; }
        public string recipientName { get; set; }
        public string recipientTel { get; set; }
        public string recipientAddress { get; set; }
        public string payType { get; set; }
    }
}