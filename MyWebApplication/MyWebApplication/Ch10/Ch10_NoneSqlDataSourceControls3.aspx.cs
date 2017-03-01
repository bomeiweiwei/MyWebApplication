using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MyWebApplication.Ch10
{
    public partial class Ch10_NoneSqlDataSourceControl3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //第一次執行網頁
                myDBInit();
            }
            else
            {

            }
        }

        protected void myDBInit()
        {
            SqlDataSource sds = new SqlDataSource();
            sds.ConnectionString = WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString;
            sds.SelectCommand = "SELECT [id], [title], [summary], [test_time] FROM [test]";
            sds.DataSourceMode = SqlDataSourceMode.DataSet;
            DataSourceSelectArguments args = new DataSourceSelectArguments();
            DataView dv = (DataView)sds.Select(args);
            GridView1.DataSource = dv;
            GridView1.DataBind();
            sds.Dispose();
        }
        //分頁
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            myDBInit();
        }
        //編輯
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            myDBInit();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            myDBInit();
        }
        //更新
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        { 
            //...

            GridView1.EditIndex = -1;
            myDBInit();
        }
        //刪除
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //...

            myDBInit();
        }


    }
}