using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AllShow_WebSite.Models.member
{
    public class Member
    {
        [Key]
        public int memno { get; set; }

        [Required]
        [StringLength(60)]
        [Display(Name = "會員信箱")]
        [DataType(DataType.EmailAddress)]
        public string mememail { get; set; }

        [StringLength(100, ErrorMessage = "{0} 的長度至少必須為 {2} 個字元。", MinimumLength = 6)]
        [Display(Name = "會員密碼")]
        [DataType(DataType.Password)]
        public string mempwd { get; set; }

        [StringLength(40, ErrorMessage = "{0} 的長度至少必須為 {2} 個字元。", MinimumLength = 3)]
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
        public DateTime memcreatedate { get; set; }

        [Display(Name = "更新日期")]
        public DateTime? memupdatedate { get; set; }

        [Display(Name = "生日")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? membirth { get; set; }

        [Display(Name = "Guid碼")]
        public string memguid { get; set; }
    }
}