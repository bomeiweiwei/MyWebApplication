using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace AllShowMVCApplication.Models
{
    [MetadataType(typeof(AUTHORITYFUNCTIONMD))]
    public partial class AUTHORITYFUNCTION
    {
        public class AUTHORITYFUNCTIONMD //:IValidatableObject
        {
            [ScaffoldColumn(false)]
            [Key]
            public int authorityno { get; set; }            
            [Required]
            [StringLength(40)]
            [Display(Name = "權限功能名稱")]
            public string authorityname { get; set; }
        }
    }
}