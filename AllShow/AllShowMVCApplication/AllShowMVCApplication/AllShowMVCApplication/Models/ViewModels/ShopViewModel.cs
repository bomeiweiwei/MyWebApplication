using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllShowMVCApplication.Models.ViewModels
{
    public class ShopViewModel:SHOP
    {
        public HttpPostedFileBase File1 { get; set; }
        public HttpPostedFileBase File2 { get; set; }
    }

    public class ShopDDLViewModel
    {
        //DropDownList===
        public SHOP Shop { get; set; }
        public IEnumerable<SelectListItem> EmployeeList { get; set; }
        public IEnumerable<SelectListItem> ShClassList { get; set; }
        //DropDownList===
    }
}