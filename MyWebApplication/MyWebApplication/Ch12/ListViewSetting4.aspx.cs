using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Collections;

using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MyWebApplication.Ch12
{
    public partial class ListViewSetting4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                DBInit();
            }
        }

        protected void DBInit() {
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter();
            string queryString = "select top 10 * from test order by id desc";
            DataSet ds = new DataSet();

            sda.SelectCommand = new SqlCommand(
                queryString, conn);
            try
            {
                sda.Fill(ds);
                ListView1.DataSource = ds;
                ListView1.DataBind();
            }
            catch (Exception ex) {
                Response.Write("Error:"+ex.Message);
            }
        }

        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "MyDetail") 
            {
                ListView1.SelectedIndex = -1;
                DBInit();
            }
        }

        protected void ListView1_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {
            ListView1.SelectedIndex = e.NewSelectedIndex;
            DBInit();
        }

    }
}