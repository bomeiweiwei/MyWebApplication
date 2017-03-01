using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebApplication.Ch11
{
    public partial class Ch11_UC_UC4 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (Convert.ToInt32(RadioButtonList1.SelectedValue) == 1) {
                lblNote.Text = RadioButtonList1.SelectedValue.ToString();
            //}
        }
    }
}