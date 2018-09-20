using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using AllShowMVCApplication.Models;
using AllShowMVCApplication.Models.shop;

using System.Web.Mvc;

namespace AllShowMVCApplication.MyWebService
{
    /// <summary>
    ///ShopWebService 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
    [System.Web.Script.Services.ScriptService]
    public class ShopWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World!!";
        }

        [WebMethod]
        public bool GetDataUnique(string id, string colName, string value)
        {
            bool sflag = true;
            ShopDataOperation _shop = new ShopDataOperation();
            //SHOP shop = _shop.FindOne(Convert.ToInt32(id));

            //List<SHOP> shopList = _shop.Get().ToList();
            //shopList.Remove(shop);

            var shopList = from p in _shop.Get() where !(new int?[] { Convert.ToInt32(id) }).Contains(p.shno) select p;

            foreach (SHOP sh in shopList)
            {
                if (colName.Equals("shaddress"))
                {
                    if (value.Equals(sh.shaddress))
                        sflag = false;
                }
                else if (colName.Equals("shtel"))
                {
                    if (value.Equals(sh.shtel))
                        sflag = false;
                }
                else if (colName.Equals("shemail"))
                {
                    if (value.Equals(sh.shemail))
                        sflag = false;
                }
                else if (colName.Equals("shurl"))
                {
                    if (value.Equals(sh.shurl))
                        sflag = false;
                }
            }
            return sflag;
        }
    }
}
