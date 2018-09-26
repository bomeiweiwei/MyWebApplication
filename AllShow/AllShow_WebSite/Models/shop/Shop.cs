using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllShow_WebSite.Models.shop
{
    public class Shop
    {
        public int shno { get; set; }
        public int empno { get; set; }
        public string shthepic { get; set; }
        public string shname { get; set; }
        public int? shclassno { get; set; }
        public string shaccount { get; set; }
        public string shpwd { get; set; }
        public string shboss { get; set; }
        public string shcontact { get; set; }
        public string shaddress { get; set; }
        public string shtel { get; set; }
        public string shemail { get; set; }
        public string shabout { get; set; }
        public string shlogopic { get; set; }
        public string shurl { get; set; }
        public string shadstate { get; set; }
        public string shadtitle { get; set; }
        public string shadpic { get; set; }
        public string shpopshop { get; set; }
        public string shcheckstate { get; set; }
        public DateTime? shstartdate { get; set; }
        public DateTime? shenddate { get; set; }
        public DateTime? shcheckdate { get; set; }
        public string shpwdstate { get; set; }
        public DateTime? shstoprightstartdate { get; set; }
        public DateTime? shstoprightenddate { get; set; }
    }
}