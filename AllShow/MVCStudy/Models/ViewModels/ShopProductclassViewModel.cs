using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCStudy.Models.ViewModels
{
    public class ShopProductclassViewModel
    {      
        public int shno { get; set; }
        public IEnumerable<SHOP> Shop { get; set; }
        public IEnumerable<PRODUCT> Product { get; set; }
        public IEnumerable<PRODUCTCLASS> ProductClass { get; set; }
    }
}