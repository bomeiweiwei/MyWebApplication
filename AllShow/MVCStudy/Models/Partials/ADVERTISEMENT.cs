using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace MVCStudy.Models
{
    [MetadataType(typeof(ADVERTISEMENTMD))]
    public partial class ADVERTISEMENT
    {
        public class ADVERTISEMENTMD //:IValidatableObject
        {
            [ScaffoldColumn(false)]
            [Key]
            public int adNo { get; set; }
            [Required]
            [Display(Name = "商店編號")]
            public int shNo { get; set; }
            [Required]
            [Display(Name = "審查人員編號")]
            public int empNo { get; set; }
            [Required]
            [StringLength(100)]
            [Display(Name = "廣告標題")]
            public string adTitle { get; set; }
            [Required]
            [Display(Name = "申請日期")]
            public System.DateTime adApplyDate { get; set; }
            [Required]
            [Display(Name = "開始日期")]
            public System.DateTime adStartDate { get; set; }
            [Required]
            [Display(Name = "廣告有限時效")]
            public double adTime { get; set; }
            [Required]
            [Display(Name = "廣告費用金額")]
            public double adPrice { get; set; }
            [StringLength(200)]
            [Display(Name = "圖片")]
            public string adPic { get; set; }
            [Required]
            [StringLength(200)]
            [Display(Name = "連結網址")]
            public string adURL { get; set; }
            [StringLength(10)]
            [Display(Name = "廣告審核狀態")]
            public string adCheckState { get; set; }
        }
    }
}