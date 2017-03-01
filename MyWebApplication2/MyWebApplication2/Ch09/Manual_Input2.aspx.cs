using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MyWebApplication2.Ch09
{
    public partial class Manual_Input2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            myDBInit();
        }

        void myDBInit()
        {
            SqlDataSource SqlDataSource1 = new SqlDataSource();
            SqlDataSource1.ConnectionString = WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString;
            SqlDataSource1.SelectCommand = "SELECT * FROM [test] order by id DESC";
            SqlDataSource1.DataSourceMode = SqlDataSourceMode.DataSet;
            DataView dv = (DataView)SqlDataSource1.Select(new DataSourceSelectArguments());
            GridView1.DataSource = dv;
            GridView1.DataBind();

            SqlDataSource1.Dispose();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection Conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString.ToString());
            DataSet ds = new DataSet();

            SqlDataAdapter u_Adapter = new SqlDataAdapter();
            u_Adapter.SelectCommand = new SqlCommand("Select * from test", Conn);
            u_Adapter.Fill(ds, "test");   //---- 這時候執行SQL指令。取出資料，放進 DataSet。

            DataRow new_row = ds.Tables["test"].NewRow();
            //-- 手動新增一行 DataRow
            new_row["class"] = ListBox1.SelectedItem.Value;
            new_row["title"] = TextBox1.Text;
            new_row["summary"] = TextBox2.Text;
            new_row["article"] = TextBox3.Text;
            new_row["author"] = TextBox4.Text;

            ds.Tables["test"].Rows.Add(new_row);  //--將新增的一行 DataRow加入 DataSet裡面


            //==事先寫好 InsertCommand =============================(start)
            u_Adapter.InsertCommand = new SqlCommand("INSERT INTO [test] ([test_time], [class], [title], [summary], [article], [author]) VALUES (getdate(), @class, @title, @summary, @article, @author)", Conn);
            //-- InsertCommand 參數 --(start)
            u_Adapter.InsertCommand.Parameters.Add("@class", SqlDbType.NVarChar, 50);
            u_Adapter.InsertCommand.Parameters["@class"].Value = ListBox1.SelectedItem.Value;

            u_Adapter.InsertCommand.Parameters.Add("@title", SqlDbType.NVarChar, 100);
            u_Adapter.InsertCommand.Parameters["@title"].Value = TextBox1.Text;

            u_Adapter.InsertCommand.Parameters.Add("@summary", SqlDbType.NVarChar, 250);
            u_Adapter.InsertCommand.Parameters["@summary"].Value = TextBox2.Text;

            u_Adapter.InsertCommand.Parameters.Add("@article", SqlDbType.NVarChar, 16);
            u_Adapter.InsertCommand.Parameters["@article"].Value = TextBox3.Text;

            u_Adapter.InsertCommand.Parameters.Add("@author", SqlDbType.NVarChar, 100);
            u_Adapter.InsertCommand.Parameters["@author"].Value = TextBox4.Text;
            //-- InsertCommand 參數 --(end)
            //=================================================(end)

            u_Adapter.Update(ds, "test");
            //---- 這時候執行SQL指令。把 DataSet裡面的新資料，回寫到資料庫！
            //---- 因為DataSet的狀態已經被改變，多了新的一列DataRow，所以會自動執行 InsertCommand


            //== 重新資料繫結，讓 GridView展示資料庫裡面的最新情況==
            myDBInit();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            myDBInit();
        }
    }
}