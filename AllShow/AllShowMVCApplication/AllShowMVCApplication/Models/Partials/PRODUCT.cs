using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace AllShowMVCApplication.Models
{
    [MetadataType(typeof(PRODUCTMD))]
    public partial class PRODUCT
    {
        public class PRODUCTMD //:IValidatableObject
        {
            [ScaffoldColumn(false)]
            [Key]
            public int proNo { get; set; }
            [Required]
            [Display(Name = "商店編號")]
            public int shNo { get; set; }
            [Required]
            [Display(Name = "商品類別編號")]
            public int proClassNo { get; set; }
            [Required]
            [StringLength(50)]
            [Display(Name = "商品名稱")]
            public string proName { get; set; }
            [Required]
            [Display(Name = "商品單價金額")]
            public double proPrice { get; set; }
            [StringLength(400)]
            [Display(Name = "商品敘述")]
            public string proStatement { get; set; }
            [StringLength(1)]
            [Display(Name = "商品狀態")]
            public string proState { get; set; }
            [StringLength(200)]
            [Display(Name = "商品照片1")]
            public string proPic1 { get; set; }
            [StringLength(200)]
            [Display(Name = "商品照片2")]
            public string proPic2 { get; set; }
            [StringLength(200)]
            [Display(Name = "商品照片3")]
            public string proPic3 { get; set; }
            [Display(Name = "商品新增日期")]
            public Nullable<System.DateTime> proCreateDate { get; set; }
            [Display(Name = "商品更新日期")]
            public Nullable<System.DateTime> proUpdateDate { get; set; }
            [Display(Name = "商品下架日期")]
            public Nullable<System.DateTime> ProOffShelfDate { get; set; }
            [StringLength(1)]
            [Display(Name = "熱門商品")]
            public string proPop { get; set; }
        }
    }
}