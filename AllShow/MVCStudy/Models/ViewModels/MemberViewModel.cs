using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCStudy.Models.ViewModels
{
    public class MemberViewModel : MEMBER
    {
        public HttpPostedFileBase File { get; set; }
    }
}