using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using MyWebApplication2.Ch04.DataSet_NorthWindTableAdapters;

namespace MyWebApplication2.Ch04
{
    public partial class ObjectDataSource2_1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Response.Write(GridView1.SelectedValue.ToString());
            Order_DetailsTableAdapter odta = new Order_DetailsTableAdapter();
            DataTable dt = odta.GetDataByOrderID(Convert.ToInt32(GridView1.SelectedValue));
            GridView2.DataSource = dt;
            GridView2.DataBind();
        }
    }
}