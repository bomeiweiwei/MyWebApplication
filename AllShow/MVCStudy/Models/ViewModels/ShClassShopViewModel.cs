using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PagedList;

namespace MVCStudy.Models.ViewModels
{
    public class ShClassShopViewModel
    {
        public IEnumerable<SHCLASS> shClasses { get; set; }
        public IEnumerable<SHOP> shops { get; set; }

        //public PagedList.IPagedList<SHCLASS> SHCLASSes { get; set; }
        public PagedList.IPagedList<SHOP> SHOPs { get; set; }
    }
}