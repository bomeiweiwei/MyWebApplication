using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllShowMVCApplication.Models.ViewModels
{
    public class ShClassAdvAnnViewModel
    {
        private string _adtitle = "";

        private string _announcementtitle = "";
        private string _announcementcontent = "";

        public string adTitle
        {
            get { return _adtitle; }
            set
            {
                if (value.Length > 20)
                {
                    _adtitle = value.Substring(0, 20);
                    _adtitle += "...";
                }
                else
                {
                    _adtitle = value;
                }
            }
        }
        public string adURL { get; set; }

        public string announcementtitle
        {
            get { return _announcementtitle; }
            set
            {
                if (value.Length > 20)
                {
                    _announcementtitle = value.Substring(0, 20);
                    _announcementtitle += "...";
                }
                else
                {
                    _announcementtitle = value;
                }
            }
        }
        public string announcementcontent
        {
            get { return _announcementcontent; }
            set
            {
                if (value.Length > 30)
                {
                    _announcementcontent = value.Substring(0, 30);
                    _announcementcontent += "...";
                }
                else
                {
                    _announcementcontent = value;
                }
            }
        }

        public IEnumerable<SHCLASS> shClasses { get; set; }
        public IEnumerable<ADVERTISEMENT> advertisements { get; set; }
        public IEnumerable<ANNOUNCEMENT> announcements { get; set; }
    }
}