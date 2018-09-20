using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace AllShowMVCApplication.Models
{
    [MetadataType(typeof(MEMBERLISTMD))]
    public partial class MEMBERLIST
    {
        public class MEMBERLISTMD //:IValidatableObject
        {
            [ScaffoldColumn(false)]
            [Key]
            public int orderNo { get; set; }
            [Required]
            [Display(Name = "會員編號")]
            public int memNo { get; set; }
            [Display(Name = "會員下單日期")]
            public Nullable<System.DateTime> orderDate { get; set; }
        }
    }
}