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
    public partial class SDS_SetDR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DBInit();
            }
        }

        protected void DBInit()
        {
            string queryString = "select top 5 id,test_time,title,summary from test";
            string connectionString = WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString;
            SqlDataSource sds = new SqlDataSource();
            sds.ConnectionString = connectionString;
            sds.SelectCommand = queryString;
            sds.DataSourceMode = SqlDataSourceMode.DataReader;
            DataSourceSelectArguments args = new DataSourceSelectArguments();

            IDataReader IDR = (IDataReader)sds.Select(args);

            GridView1.DataSource = IDR;
            GridView1.DataBind();

            IDR.Close();

            sds.Dispose();
        }
    }
}