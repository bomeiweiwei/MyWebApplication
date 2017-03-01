using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Configuration;
using MyWebApplication2.Ch04.DataSet_NorthWindTableAdapters;

namespace MyWebApplication2.Ch04
{
    public partial class ObjectDataSource2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                OrdersTableAdapter testAdapters=new OrdersTableAdapter();
                lblCount.Text = Convert.ToString(testAdapters.Orders_count());
            }
        }
    }
}