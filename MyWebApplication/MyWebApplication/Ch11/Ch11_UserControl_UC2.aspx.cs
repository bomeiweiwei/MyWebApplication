using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebApplication.Ch11
{
    public partial class Ch11_UserControl_UC2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UserControl myUc = (UserControl)LoadControl("~/Ch11/Ch11_UC_UC2.ascx");
                div1.Controls.Add(myUc);
                //Page.Form.Controls.Add(myUc);//...this is gg
                myUc = (UserControl)LoadControl("UC_Folder/Ch11_UC_UC3.ascx");
                div1.Controls.Add(myUc);
                myUc = (UserControl)LoadControl("~/Ch11/UC_Folder/Ch11_UC_UC4.ascx");
                div1.Controls.Add(myUc);
            }
            catch (Exception ex)
            {
                lblErr.Text = ex.ToString();
            }
        }
    }
}