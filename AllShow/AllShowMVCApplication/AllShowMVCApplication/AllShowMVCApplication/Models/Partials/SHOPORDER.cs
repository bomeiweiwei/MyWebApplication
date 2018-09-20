using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace AllShowMVCApplication.Models
{
    [MetadataType(typeof(SHOPORDERMD))]
    public partial class SHOPORDER
    {
        public class SHOPORDERMD //:IValidatableObject
        {
            [ScaffoldColumn(false)]
            [Key]
            public int shoporderNo { get; set; }
            
            [Required]
            [Display(Name = "訂單編號")]
            public int orderNo { get; set; }
            
            [Required]
            [Display(Name = "商店編號")]
            public int shNo { get; set; }
            
            [Required]
            [Display(Name = "訂單金額")]
            public double orderPrice { get; set; }
            
            [Display(Name = "轉交訂單日期")]
            public Nullable<System.DateTime> referredToDate { get; set; }
            
            [Display(Name = "出貨日期")]
            public Nullable<System.DateTime> transactionDate { get; set; }
            
            [StringLength(1)]
            [Display(Name = "訂單狀態")]
            public string orderState { get; set; }
            
            [Required]
            [StringLength(20)]
            [Display(Name = "收貨人姓名")]
            public string recipientName { get; set; }
            
            [DataType(DataType.PhoneNumber)]
            [StringLength(10)]
            [Display(Name = "收貨人電話")]
            public string recipientTel { get; set; }
            
            [StringLength(50)]
            [Display(Name = "收貨人地址")]
            public string recipientAddress { get; set; }
            
            [StringLength(1)]
            [Display(Name = "付款方式")]
            public string payType { get; set; }
        }
    }
}