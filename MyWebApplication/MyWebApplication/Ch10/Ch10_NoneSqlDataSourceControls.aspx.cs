using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MyWebApplication.Ch10
{
    public partial class Ch10_NoneSqlDataSourceControls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //第一次執行網頁
                Session["member"] = "Mark";
                SqlConnection Conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString);
                SqlDataAdapter da = new SqlDataAdapter("SELECT [id], [title], [summary], [test_time] FROM [test]", Conn);
                DataSet ds = new DataSet();
                try
                {
                    da.Fill(ds, "myTable");
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    lblErr.Text = ex.Message.ToString();
                }
                finally
                {

                }
            }
            else
            {

            }
            lblMember.Text = Convert.ToString(Session["member"]);
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection Conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT [title], [summary], [article], [author], [hit_no] FROM [test] WHERE ([id] = @id )", Conn);
            da.SelectCommand.Parameters.AddWithValue("@id", Convert.ToInt32(GridView1.SelectedValue));
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds, "myTable");
                GridView2.DataSource = ds;
                GridView2.DataBind();
            }
            catch (Exception ex)
            {
                lblErr.Text = ex.Message.ToString();
            }
            finally
            {

            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}