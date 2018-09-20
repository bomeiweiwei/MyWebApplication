using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllShowMVCApplication.Models.favoriteshoplist
{
    [Table("FAVORITESHOPLIST")]
    public class Favoriteshoplist
    {
        [Key]
        [Column(Order = 0)]
        public int memNo{get;set;}
        [Key]
        [Column(Order = 1)]
        public int shNo { get; set; }	
    }
}