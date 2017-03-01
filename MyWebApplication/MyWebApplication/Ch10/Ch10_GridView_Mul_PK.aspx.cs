using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace MyWebApplication.Ch10
{
    public partial class Ch10_GridView_Mul_PK : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //第一次執行網頁
                lblIndex.Text = lblRowCommand.Text = lblRowIndex.Text = lblSelectDKey.Text = lblSelectValue.Text = "";
                lbllblSelectDKeyPK1.Text = lbllblSelectDKeyPK2.Text = "";
                Session["member"] = "Mark";               
            }
            else
            {

            }
            lblMember.Text = Convert.ToString(Session["member"]);
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridView1.SelectedIndex = e.NewSelectedIndex;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblIndex.Text = "GridView1.SelectedIndex=" + Convert.ToString(GridView1.SelectedIndex);
            lblRowIndex.Text = "GridView1.SelectedRow.RowIndex=" + Convert.ToString(GridView1.SelectedRow.RowIndex);
            lblSelectValue.Text = "GridView1.SelectedValue=" + Convert.ToString(GridView1.SelectedValue);
            lblSelectDKey.Text = "GridView1.SelectedDataKey=" + Convert.ToString(GridView1.SelectedDataKey.Value);
            lbllblSelectDKeyPK1.Text = "GridView1.SelectedDataKeyPK1=" + Convert.ToString(GridView1.SelectedDataKey.Values[0]);
            lbllblSelectDKeyPK2.Text = "GridView1.SelectedDataKeyPK2=" + Convert.ToString(GridView1.SelectedDataKey.Values[1]);

            GridView gv = (GridView)sender;
            SqlConnection conn = new SqlConnection("server=MSI\\SQLEXPRESS2012;Initial Catalog=test;User ID=dbtest;Password=dbtest0000");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT [title], [summary], [article], [author], [hit_no] FROM [test] WHERE ([id] = @id) AND ([title] = @title)", conn);
            cmd.Parameters.AddWithValue("id", gv.SelectedDataKey.Values[0]);
            cmd.Parameters.AddWithValue("title", gv.SelectedDataKey.Values[1]);
            SqlDataReader dr = cmd.ExecuteReader();

            GridView2.DataSource = dr;
            GridView2.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int pk_index = Convert.ToInt32(e.CommandArgument);
            lblRowCommand.Text = "GridView1_RowCommand : " + Convert.ToString(GridView1.DataKeys[pk_index].Value);

            if (e.CommandName == "Cancel_Select")
            {
                GridView1.SelectedIndex = -1;
            }
        }
    }
}