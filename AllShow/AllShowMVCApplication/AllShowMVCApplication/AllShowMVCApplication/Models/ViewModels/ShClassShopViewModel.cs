using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllShowMVCApplication.Models.ViewModels
{
    public class ShClassShopViewModel
    {
        public IEnumerable<SHCLASS> shClasses { get; set; }
        public IEnumerable<SHOP> shops { get; set; }
    }
}