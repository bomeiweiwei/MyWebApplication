using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace MVCStudy.Models
{
    [MetadataType(typeof(MEMBERMD))]
    public partial class MEMBER
    {
        public class MEMBERMD //:IValidatableObject
        {
            [ScaffoldColumn(false)]
            [Key]
            public int memno { get; set; }
            [Required]
            [StringLength(60)]
            [DataType(DataType.EmailAddress)]
            [Display(Name = "信箱")]
            public string mememail { get; set; }
            [Required]
            [StringLength(20,
                ErrorMessage = "請輸入正確密碼")]
            [Display(Name = "會員密碼")]
            public string mempwd { get; set; }
            [StringLength(40)]
            [Display(Name = "會員暱稱")]
            public string memdiminutive { get; set; }
            [Required]
            [StringLength(40)]
            [Display(Name = "會員姓名")]
            public string memname { get; set; }
            [Required]
            [StringLength(1)]
            [Display(Name = "性別")]
            public string memsex { get; set; }
            [Required]
            [StringLength(10)]
            [Display(Name = "電話")]
            [DataType(DataType.PhoneNumber)]
            public string memtel { get; set; }
            [Required]
            [StringLength(80)]
            [Display(Name = "地址")]
            public string memaddress { get; set; }
            [StringLength(200)]
            [Display(Name = "照片")]
            public string mempic { get; set; }
            [StringLength(1)]
            [Display(Name = "會員帳號狀態")]
            public string memaccountstate { get; set; }
            [Required]
            [StringLength(5)]
            [Display(Name = "會員驗證碼")]
            public string memchecknumber { get; set; }
            [Required]
            [Display(Name = "建立日期")]
            public System.DateTime memcreatedate { get; set; }
            [Display(Name = "更新日期")]
            public Nullable<System.DateTime> memupdatedate { get; set; }
            [Display(Name = "生日")]
            public Nullable<System.DateTime> membirth { get; set; }           
        }
    }
}