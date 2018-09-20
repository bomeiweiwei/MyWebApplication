using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllShowMVCApplication.Models.ViewModels
{
    public class PersonViewModel
    {
        public AllShowMVCApplication.Models.Person.Person Man { get; set; }
        public AllShowMVCApplication.Models.Person.Person Woman { get; set; }
    }
}