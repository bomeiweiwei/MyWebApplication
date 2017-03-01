using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebApplication.Ch14
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Button1.Attributes["onclick"] = "javascript:show_calendar('" + txtTestDate.ClientID + "','','','CY/MM/DD');";
            }
            if (Page.PreviousPage != null)
            {
                Label1.Text = "Page.PreviousPage != null";
                txtTestDate2.Text = PreviousPage.my_Calendar.SelectedDate.ToString();
            }
            else
            {
                Label1.Text = "Page.PreviousPage = null";
            }
        }
    }
}