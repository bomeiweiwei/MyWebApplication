using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebApplication.Ch09
{
    public partial class Ch09_SearchEngine : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //第一次執行網頁
            }
            else
            {
                
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {            
            GridView1.DataSourceID = "SqlDataSource1";
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridView2.DataSourceID = "SqlDataSource2";
        }
    }
}