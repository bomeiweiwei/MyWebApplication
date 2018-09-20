using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using AllShowMVCApplication.Models;
using AllShowMVCApplication.Models.shop;

using System.Web.Services;
using System.Web.Mvc;

namespace AllShowMVCApplication.MyWebFunction
{
    public partial class ShopWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        // this will allow Web Service to be called from script, using ASP.NET AJAX or direct from javascipt .
        [System.Web.Script.Services.ScriptMethod]
        public static string[] LocalWS(String Msg)
        {
            string[] arr = new string[] { Msg + ":Vivek", Msg + ":Santosh" };
            return arr;
        }

        [WebMethod]
        public string GetDataUnique(string id, string colName, string value)
        {
            string sflag = "true";
            ShopDataOperation _shop = new ShopDataOperation();
            SHOP shop = _shop.FindOne(Convert.ToInt32(id));

            List<SHOP> shopList = _shop.Get().ToList();
            shopList.Remove(shop);

            foreach (SHOP sh in shopList)
            {
                if (colName.Equals("shaddress"))
                {
                    if (value.Equals(sh.shaddress))
                        sflag = "false";
                }
                else if (colName.Equals("shtel"))
                {
                    if (value.Equals(sh.shtel))
                        sflag = "false";
                }
                else if (colName.Equals("shemail"))
                {
                    if (value.Equals(sh.shemail))
                        sflag = "false";
                }
                else if (colName.Equals("shurl"))
                {
                    if (value.Equals(sh.shurl))
                        sflag = "false";
                }
            }
            return sflag;
        }
    }
}