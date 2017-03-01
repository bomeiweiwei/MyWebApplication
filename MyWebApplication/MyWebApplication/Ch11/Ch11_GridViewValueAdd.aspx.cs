using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebApplication.Ch11
{
    public partial class Ch11_GridViewValueAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "myInsert") 
            {
                GridView1.DataSourceID = null;
            }
        }

        protected void SqlDataSource1_Inserted(object sender, SqlDataSourceStatusEventArgs e)
        {
            
        }

        protected void SqlDataSource2_Inserted(object sender, SqlDataSourceStatusEventArgs e)
        {
            GridView1.DataSourceID = "SqlDataSource1";
        }

        protected void SqlDataSource2_Inserting(object sender, SqlDataSourceCommandEventArgs e)
        {
            //int i = 0;
        }

    }
}