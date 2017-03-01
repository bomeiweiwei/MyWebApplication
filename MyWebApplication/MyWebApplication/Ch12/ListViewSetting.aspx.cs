using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebApplication.Ch12
{
    public partial class ListViewSetting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "MyDetail") {
                ListView1.SelectedIndex = -1;
            }
        }

        protected void ListView1_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            ListView1.EditIndex = e.NewEditIndex;
        }

        protected void ListView1_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            ListView1.EditIndex = -1;
        }
    }
}