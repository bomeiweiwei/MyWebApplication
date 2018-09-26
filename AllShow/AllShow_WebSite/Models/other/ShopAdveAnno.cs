using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllShow_WebSite.Models.other
{
    public class ShopAdvertise
    {
        private string _adtitle = "";

        public string aditle
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

        public string shName { get; set; }
        public int shNo { get; set; }
    }

    public class Announce
    {
        private string _announcementtitle = "";
        private string _announcementcontent = "";
        public string announcementtype { get; set; }

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
    }
}