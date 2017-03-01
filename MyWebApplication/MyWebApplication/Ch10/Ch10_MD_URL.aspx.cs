using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebApplication.Ch10
{
    public partial class Ch10_MD_URL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //第一次執行網頁
                Label1.Visible = Label2.Visible = false;
                GridView1.DataSourceID = "SqlDataSource1";
            }
            else
            {

            }
        }
    }
}