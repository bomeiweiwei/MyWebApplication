using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace MVCStudy.Models
{
    [MetadataType(typeof(ANNOUNCEMENTMD))]
    public partial class ANNOUNCEMENT
    {
        public class ANNOUNCEMENTMD //:IValidatableObject
        {
            [ScaffoldColumn(false)]
            [Key]
            public int announcementno { get; set; }
            [Required]
            [Display(Name = "員工編號")]
            public int empno { get; set; }
            [Required]
            [StringLength(50)]
            [Display(Name = "公告標題")]
            public string announcementtitle { get; set; }
            [Required]
            [StringLength(50)]
            [Display(Name = "公告類型")]
            public string announcementtype { get; set; }
            [Required]
            [StringLength(2500)]
            [Display(Name = "公告內容")]
            public string announcementcontent { get; set; }
            [Required]
            [Display(Name = "建立日期")]
            public System.DateTime createdate { get; set; }
            [Display(Name = "更新日期")]
            public Nullable<System.DateTime> updatedate { get; set; }
            [Required]
            [Display(Name = "開始日期")]
            public System.DateTime startdate { get; set; }
            [Required]
            [Display(Name = "結束日期")]
            public System.DateTime enddate { get; set; }
        }
    }
}