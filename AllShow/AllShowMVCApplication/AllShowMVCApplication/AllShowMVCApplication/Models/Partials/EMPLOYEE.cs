using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace AllShowMVCApplication.Models
{
    [MetadataType(typeof(EMPLOYEEMD))]
    public partial class EMPLOYEE
    {
        public class EMPLOYEEMD //:IValidatableObject
        {
            [ScaffoldColumn(false)]
            [Key]
            public int empno { get; set; }
            [Required]
            [StringLength(20)]
            [Display(Name = "員工姓名")]
            public string empname { get; set; }
            [Required]
            [StringLength(20)]
            [Display(Name = "員工帳號")]
            public string empaccount { get; set; }
            [Required]
            [StringLength(20)]
            [Display(Name = "員工密碼")]
            public string emppwd { get; set; }
            [Required]
            [StringLength(40)]
            [DataType(DataType.EmailAddress)]
            [Display(Name = "信箱")]
            public string EMPEMAIL { get; set; }
            [Required]
            [StringLength(1)]
            [Display(Name = "性別")]
            public string empsex { get; set; }
            [Required]
            [Display(Name = "生日")]
            public System.DateTime empbirth { get; set; }
            [Required]
            [StringLength(10)]
            [DataType(DataType.PhoneNumber)]
            [Display(Name = "電話")]
            public string emptel { get; set; }
            [Required]
            [Display(Name = "到職日期")]
            public System.DateTime hiredate { get; set; }
            [Display(Name = "離職日期")]
            public Nullable<System.DateTime> leavedate { get; set; }
            [StringLength(1)]
            [Display(Name = "員工帳號狀態")]
            public string empaccountstate { get; set; }
        }
    }
}