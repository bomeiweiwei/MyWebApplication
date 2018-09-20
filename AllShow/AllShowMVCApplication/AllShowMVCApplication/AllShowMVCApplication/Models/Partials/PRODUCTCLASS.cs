using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace AllShowMVCApplication.Models
{
    [MetadataType(typeof(PRODUCTCLASSMD))]
    public partial class PRODUCTCLASS
    {
        public class PRODUCTCLASSMD //:IValidatableObject
        {
            [ScaffoldColumn(false)]
            [Key]
            public int proclassno { get; set; }
            [Required]
            [Display(Name = "商店編號")]
            public int shno { get; set; }
            [Required]
            [Display(Name = "商品類別名稱")]
            [StringLength(20)]
            public string proclassname { get; set; }
        }
    }
}