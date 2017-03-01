using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebApplication.Ch10
{
    public partial class Ch10_GridViewEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //第一次執行網頁
                lblIndex.Text = lblRowCommand.Text = lblRowIndex.Text = lblSelectDKey.Text = lblSelectValue.Text = "";
                Session["member"] = "Mark";                
            }
            else
            {

            }
            lblMember.Text = Convert.ToString(Session["member"]);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblIndex.Text = "GridView1.SelectedIndex=" + Convert.ToString(GridView1.SelectedIndex);
            lblRowIndex.Text = "GridView1.SelectedRow.RowIndex=" + Convert.ToString(GridView1.SelectedRow.RowIndex);
            lblSelectValue.Text = "GridView1.SelectedValue=" + Convert.ToString(GridView1.SelectedValue);
            lblSelectDKey.Text = "GridView1.SelectedDataKey=" + Convert.ToString(GridView1.SelectedDataKey.Value);
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridView1.SelectedIndex = e.NewSelectedIndex;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int pk_index = Convert.ToInt32(e.CommandArgument);
            lblRowCommand.Text = "GridView1_RowCommand : " + Convert.ToString(GridView1.DataKeys[pk_index].Value);

            if (e.CommandName == "Cancel_Select") {
                GridView1.SelectedIndex = -1;
            }
        }
    }
}