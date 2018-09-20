using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MVCStudy.Models
{
    [MetadataType(typeof(SHOPMD))]
    public partial class SHOP
    {
        public class SHOPMD //:IValidatableObject
        {
            [ScaffoldColumn(false)]
            [Key]
            public int shno { get; set; }

            [Required]
            [Display(Name = "審查人員編號")]
            public int empno { get; set; }

            [StringLength(200)]
            [Display(Name = "佈景主題圖示")]
            public string shthepic { get; set; }

            [Required]
            [StringLength(20)]
            [Display(Name = "商店名稱")]
            public string shname { get; set; }

            [Display(Name = "商店類別編號")]
            public Nullable<int> shclassno { get; set; }

            [Required]
            [StringLength(20)]
            [Display(Name = "廠商帳號")]
            public string shaccount { get; set; }

            [Required]
            [StringLength(20)]
            [Display(Name = "廠商密碼")]
            public string shpwd { get; set; }

            [Required]
            [StringLength(10)]
            [Display(Name = "負責人")]            
            public string shboss { get; set; }

            [Required]
            [StringLength(10)]
            [Display(Name = "聯絡人")]
            public string shcontact { get; set; }

            [Required]
            [StringLength(30)]
            [Display(Name = "地址")]
            public string shaddress { get; set; }

            [Required]
            [StringLength(10)]
            [DataType(DataType.PhoneNumber)]
            [Display(Name = "廠商電話")]
            public string shtel { get; set; }

            [Required]
            [StringLength(30)]
            [DataType(DataType.EmailAddress)]
            [Display(Name = "聯絡人信箱")]
            public string shemail { get; set; }

            [StringLength(300)]
            [Display(Name = "關於我們")]
            public string shabout { get; set; }

            [StringLength(200)]
            [Display(Name = "LOGO圖片")]
            public string shlogopic { get; set; }

            [Required]
            [StringLength(50)]
            [Display(Name = "商店URL")]
            public string shurl { get; set; }

            [StringLength(1)]
            [Display(Name = "店內廣告狀態")]
            public string shadstate { get; set; }

            [StringLength(20)]
            [Display(Name = "店內廣告標題")]
            public string shadtitle { get; set; }

            [StringLength(200)]
            [Display(Name = "店內廣告圖片")]
            public string shadpic { get; set; }

            [StringLength(1)]
            [Display(Name = "熱門商店")]
            public string shpopshop { get; set; }

            [StringLength(1)]
            [Display(Name = "審核狀態")]
            public string shcheckstate { get; set; }

            [Display(Name = "商店營業日期")]
            public Nullable<System.DateTime> shstartdate { get; set; }

            [Display(Name = "商店結束日期")]
            public Nullable<System.DateTime> shenddate { get; set; }

            [Display(Name = "審核通過日期")]
            public Nullable<System.DateTime> shcheckdate { get; set; }

            [Display(Name = "廠商帳號狀態")]
            public string shpwdstate { get; set; }

            [Display(Name = "停權起始日")]
            public Nullable<System.DateTime> shstoprightstartdate { get; set; }

            [Display(Name = "停權截止日")]
            public Nullable<System.DateTime> shstoprightenddate { get; set; }

            //[JsonIgnore()] // 需引用 using Newtonsoft.Json;
            //public virtual ICollection<PRODUCT> PRODUCT { get; set; }
        }
    }
}