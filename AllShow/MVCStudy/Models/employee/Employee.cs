using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCStudy.Models.employee
{
    public class Employee
    {
        [Key]
        [DisplayName("員工編號")]
        public int empno { get; set; }

        [DisplayName("員工姓名")]
        [Required(ErrorMessage = "員工姓名不可空白")]
        [StringLength(20, ErrorMessage = "必須為3-20字元", MinimumLength = 3)]
        public string empname { get; set; }

        [DisplayName("員工帳號")]
        [Required(ErrorMessage = "員工帳號不可空白")]
        [StringLength(20, ErrorMessage = "必須為3-20字元", MinimumLength = 3)]
        public string empaccount { get; set; }

        [DisplayName("員工密碼")]
        [Required(ErrorMessage = "員工密碼不可空白")]
        public string emppwd { get; set; }

        [DisplayName("信箱")]
        [Required(ErrorMessage = "信箱不可空白")]
        [EmailAddress(ErrorMessage = "E-Mail格式有誤")]
        public string EMPEMAIL { get; set; }

        [DisplayName("性別")]
        [Required(ErrorMessage = "性別不可空白")]
        public string empsex { get; set; }

        [DisplayName("生日")]
        [Required(ErrorMessage = "生日不可空白")]
        [DataType(DataType.Date)]
        public DateTime empbirth { get; set; }

        [DisplayName("電話")]
        [Required(ErrorMessage = "電話不可空白")]
        public string emptel { get; set; }

        [DisplayName("到職日期")]
        [Required(ErrorMessage = "到職日期不可空白")]
        [DataType(DataType.Date, ErrorMessage = "時間格式錯誤")]
        public DateTime hiredate { get; set; }

        [DisplayName("離職日期")]
        [DataType(DataType.Date, ErrorMessage = "時間格式錯誤")]
        public DateTime? leavedate { get; set; }

        [DisplayName("員工帳號狀態")]
        [Required(ErrorMessage = "員工帳號狀態不可空白")]
        public string empaccountstate { get; set; }

        
    }
}