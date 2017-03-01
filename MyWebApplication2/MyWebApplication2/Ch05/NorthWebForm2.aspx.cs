using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.Linq;

namespace MyWebApplication2.Ch05
{
    public partial class NorthWebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NorthDataClassesDataContext ncdc = new NorthDataClassesDataContext();
            GridView1.DataSource = ncdc.Products;
            GridView1.DataBind();

            Table<Products> myTest = ncdc.GetTable<Products>();
            GridView2.DataSource = myTest;
            GridView2.DataBind();

            var myQuery = from t in myTest
                          select new { t.ProductID, t.ProductName };
            GridView3.DataSource = myQuery;
            GridView3.DataBind();
            ncdc.Dispose();
        }
    }
}