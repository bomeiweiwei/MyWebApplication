using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebApplication.Ch11
{
    public partial class Ch11_JavaScript : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                e.Row.Attributes.Add("OnMouseover", "this.style.backgroundColor='#E3EAEB'");
                e.Row.Attributes.Add("OnMouseout", "this.style.backgroundColor='#FFFFFF'");
            }
        }
    }
}