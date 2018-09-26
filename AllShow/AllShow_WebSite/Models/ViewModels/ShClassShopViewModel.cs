using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PagedList;
using AllShow_WebSite.Models.shclass;
using AllShow_WebSite.Models.shop;

namespace AllShow_WebSite.Models.ViewModels
{
    public class ShClassShopViewModel
    {       
        public IEnumerable<Shclass> shClasses { get; set; }
        public IEnumerable<Shop> shops { get; set; }

        //public PagedList.IPagedList<SHCLASS> SHCLASSes { get; set; }
        public PagedList.IPagedList<Shop> SHOPs { get; set; }
    }
}