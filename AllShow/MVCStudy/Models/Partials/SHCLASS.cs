using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace MVCStudy.Models
{
    [MetadataType(typeof(SHCLASSMD))]
    public partial class SHCLASS
    {
        public class SHCLASSMD //:IValidatableObject
        {
            [ScaffoldColumn(false)]
            [Key]
            public int shclassno { get; set; }            
            [Required]
            [StringLength(20)]
            [Display(Name = "商店類別名稱")]
            public string shclassname { get; set; }
        }
    }
}