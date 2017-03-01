using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebApplication.Ch16
{
    public partial class OnlinePeopleNum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("網站目前的線上人數--- " + Application["UsersOnline"]);
        }
    }
}