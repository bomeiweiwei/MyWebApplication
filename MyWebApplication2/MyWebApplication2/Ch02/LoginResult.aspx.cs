using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Security;

namespace MyWebApplication2.Ch02
{
    public partial class LoginResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.User.Identity.IsAuthenticated == false)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            else
            {
                //Label1.Text = Page.User.Identity.Name.ToString();
            }
        }
    }
}