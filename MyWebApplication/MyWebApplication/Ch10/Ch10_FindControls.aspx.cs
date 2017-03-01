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
    public partial class Ch10_FindControls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //第一次執行網頁
                Label lbl = (Label)GridView1.Rows[0].FindControl("Label1");
                Response.Write(lbl.Text);//真珠草萃取物可以治療肝炎 韓國技轉錦鴻

                //SqlConnection Conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString);
                //SqlDataAdapter da = new SqlDataAdapter("SELECT [id], [title], [summary], [test_time] FROM [test]", Conn);
                //DataSet ds = new DataSet();
                //try
                //{
                //    da.Fill(ds, "myTable");
                //    GridView1.DataSource = ds;
                //    GridView1.DataBind();
                //}
                //catch (Exception ex)
                //{
                //    lblErr.Text = ex.Message.ToString();
                //}
                //finally
                //{

                //}
            }
            else
            {

            }
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Response.Write("PK:" + GridView1.DataKeys[e.NewSelectedIndex].Value.ToString() + "<br />");

            Label lbl = (Label)GridView1.Rows[e.NewSelectedIndex].FindControl("Label1");
            Response.Write(lbl.Text);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)GridView1.Rows[i].FindControl("chkID");
                if (chk.Checked)
                {
                    Label lbl1 = (Label)GridView1.Rows[i].FindControl("lblID");//id
                    Label lbl2 = (Label)GridView1.Rows[i].FindControl("Label1");//title
                    Response.Write(lbl1.Text + "," + lbl2.Text + "<br />");
                }
            }
        }

      
    }
}