using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PagedList;
using AllShow_WebSite.Models.productclass;
using AllShow_WebSite.Models.product;

namespace AllShow_WebSite.Models.ViewModels
{
    public class ProductClassProductViewModel
    {
        public IEnumerable<Productclass> productClasses { get; set; }
        public IEnumerable<Product> products { get; set; }

        public PagedList.IPagedList<Product> PRODUCTs { get; set; }
    }
}