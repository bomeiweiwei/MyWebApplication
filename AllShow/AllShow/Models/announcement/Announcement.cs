using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllShow.Models.announcement
{
    public class Announcement
    {
        public int announcementno { get; set; }
        public int empno { get; set; }
        public string announcementtitle { get; set; }
        public string announcementtype { get; set; }
        public string announcementcontent { get; set; }
        public DateTime createdate { get; set; }
        public DateTime? updatedate { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }

    }
}