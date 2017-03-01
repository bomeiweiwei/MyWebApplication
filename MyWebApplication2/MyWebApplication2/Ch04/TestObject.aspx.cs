using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MyWebApplication2.Ch04.DataSet_TestTableAdapters;

namespace MyWebApplication2.Ch04
{
    public partial class TestObject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductsTableAdapter pta = new ProductsTableAdapter();
            Label1.Text = Convert.ToString(pta.Products_Count());

            OrdersTableAdapter ota = new OrdersTableAdapter();
            Label2.Text = Convert.ToString(ota.Orders_Count());
        }
    }
}