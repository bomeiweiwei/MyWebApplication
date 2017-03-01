using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MyWebApplication.Ch11
{
    public partial class Ch11_DSetRowDataBound : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) 
            {
                search(); 
            }
        }

        protected void search()
        {
            SqlConnection Conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString);
            SqlDataAdapter myAdapter;
            try
            {
                String sqlstr = "select id, real_name, sex from db_user";
                myAdapter = new SqlDataAdapter(sqlstr, Conn);

                myAdapter.Fill(ds, "test");    //---- 這時候執行SQL指令。取出資料，放進 DataSet。

                GridView1.DataSource = ds.Tables["test"].DefaultView;      //----標準寫法
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<b>Error Message----  </b>" + ex.ToString() + "<HR/>");
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            search();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            search();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                RadioButtonList rbt = (RadioButtonList)e.Row.FindControl("RadioButtonList1");

                if (rbt.Items[0].Value == ds.Tables["test"].Rows[e.Row.RowIndex]["sex"].ToString())
                {
                    rbt.Items[0].Selected = true;
                }
                else
                {
                    rbt.Items[1].Selected = true;
                }
            }
        }
    }
}