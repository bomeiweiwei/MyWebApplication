using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllShowMVCApplication.Models
{
    [MetadataType(typeof(ORDERLISTMD))]
    public partial class ORDERLIST
    {
        public class ORDERLISTMD //:IValidatableObject
        {
            [ScaffoldColumn(false)]
            [Key]
            [Column(Order = 0)]
            public int shoporderNo { get; set; }
            
            [Key]
            [Column(Order = 1)]
            public int proNo { get; set; }
            
            [Required]
            [Display(Name = "數量")]
            public double quantity { get; set; }
        }
    }
}