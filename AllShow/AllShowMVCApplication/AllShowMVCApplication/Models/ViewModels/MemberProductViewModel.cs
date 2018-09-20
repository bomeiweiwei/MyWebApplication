using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AllShowMVCApplication.Models;

namespace AllShowMVCApplication.Models.ViewModels
{
    public class MemberProductViewModel
    {
        public string MemName { get; set; }
        public string ProName { get; set; }
        public IEnumerable<PRODUCT> products { get; set; }
        public IEnumerable<MEMBER> members { get; set; }
    }
}