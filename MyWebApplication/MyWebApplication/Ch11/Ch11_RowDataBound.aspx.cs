using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebApplication.Ch11
{
    public partial class Ch11_RowDataBound : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[2].Text = "姓名";
                e.Row.Cells[3].Text = "學號";
                e.Row.Cells[4].Text = "國文";
                e.Row.Cells[5].Text = "英文";
            }
            if (e.Row.RowType == DataControlRowType.DataRow) {
                if (Convert.ToInt32(e.Row.Cells[4].Text) < 60) {
                    e.Row.Cells[4].ForeColor = System.Drawing.Color.Red;
                    e.Row.Cells[4].Font.Bold = true;
                }
                if (Convert.ToInt32(e.Row.Cells[5].Text) < 60)
                {
                    e.Row.Cells[5].ForeColor = System.Drawing.Color.Red;
                    e.Row.Cells[5].Font.Bold = true;
                }

                e.Row.Attributes.Add("OnMouseover", "this.style.backgroundColor='#E3EAEB'");
                e.Row.Attributes.Add("OnMouseout", "this.style.backgroundColor='#FFFFFF'");
            }
        }
    }
}