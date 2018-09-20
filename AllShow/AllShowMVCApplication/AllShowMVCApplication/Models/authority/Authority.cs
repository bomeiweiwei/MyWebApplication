using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllShowMVCApplication.Models.authority
{
    [Table("AUTHORITY")]
    public class Authority
    {
        [Key]
        [Column(Order = 0)]
        public int Authorityno { get; set; }
        [Key]
        [Column(Order = 1)]
        public int Empno { get; set; }
    }
}