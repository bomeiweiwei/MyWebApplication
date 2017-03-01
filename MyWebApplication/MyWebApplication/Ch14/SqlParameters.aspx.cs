using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace MyWebApplication.Ch14
{
    public partial class SqlParameters : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 
            
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DBInit(TextBox1.Text);
        }

        protected void DBInit(string id)
        {
            string queryString = "select top 5 id,test_time,title,summary from test where id=@id";
            string connectionString = WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString;
            SqlDataSource sds = new SqlDataSource();
            sds.ConnectionString = connectionString;
            sds.SelectCommand = queryString;
            sds.DataSourceMode = SqlDataSourceMode.DataSet;
            DataSourceSelectArguments args = new DataSourceSelectArguments();

            sds.SelectParameters.Clear();
            sds.SelectParameters.Add("id", id);

            DataView dv = new DataView();
            dv = (DataView)sds.Select(args);

            GridView1.DataSource = dv;
            GridView1.DataBind();

            sds.Dispose();
        }
    }
}