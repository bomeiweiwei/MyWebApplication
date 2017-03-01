using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace MyWebApplication.Ch09
{
    public partial class Ch09_DataBind : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            SqlConnection conn = new SqlConnection("server=MSI\\SQLEXPRESS2012;Initial Catalog=test;User ID=dbtest;Password=dbtest0000");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT [title], [summary], [article], [author], [hit_no] FROM [test] WHERE ([id] = @id)", conn);
            cmd.Parameters.AddWithValue("id", gv.SelectedValue);
            SqlDataReader dr = cmd.ExecuteReader();

            FormView1.DataSource = dr;
            FormView1.DataBind();
        }
    }
}