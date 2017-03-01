using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

using System.Text;

namespace MyWebApplication.Ch14
{
    public partial class DataToGridview2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DBInit();
            }
        }

        protected void DBInit()
        {
            string queryString = "select top 5 id,test_time,title,summary from test";
            string connectionString = WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString;

            //=============================================================================
            try
            {
                using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString))
                {
                    //SqlCommand command = new SqlCommand(queryString, connection);
                    //connection.Open();
                    //using (SqlDataReader reader = command.ExecuteReader())
                    //{
                    //    DataTable dataTable = new DataTable();
                    //    dataTable.Columns.Add("id");
                    //    dataTable.Columns.Add("test_time");
                    //    dataTable.Columns.Add("title");
                    //    dataTable.Columns.Add("summary");

                    //    while (reader.Read())
                    //    {
                    //        DataRow row = dataTable.NewRow();
                    //        row["id"] = reader["id"];
                    //        row["test_time"] = reader["test_time"];
                    //        row["title"] = reader["title"];
                    //        row["summary"] = reader["summary"];
                    //        dataTable.Rows.Add(row);
                    //    }
                    //    GridView1.DataSource = dataTable;
                    //    GridView1.DataBind();

                    //    command.Cancel();
                    //    reader.Close();
                    //}
                    SqlDataAdapter sda = null;
                    sda = new SqlDataAdapter(queryString, connection);

                    DataSet ds1 = new DataSet();
                    sda.Fill(ds1, "xxxTest1");

                    DataTable dataTable1 = new DataTable();
                    dataTable1 = ds1.Tables["xxxTest1"];

                    GridView1.DataSource = dataTable1;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                msg.Text += "G1:" + ex.Message + " ";
            }
            //=============================================================================
            //=============================================================================
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString);
            //SqlDataReader dr = null;
            //SqlCommand cmd = new SqlCommand(queryString, conn);
            SqlDataAdapter myAdapter = null;
            try
            {
                //conn.Open();
                //dr = cmd.ExecuteReader();
                myAdapter = new SqlDataAdapter(queryString, conn);
                DataSet ds2 = new DataSet();

                myAdapter.Fill(ds2, "xxxTest2");

                DataTable dataTable2 = new DataTable();
                //dataTable.Columns.Add("id");
                //dataTable.Columns.Add("test_time");
                //dataTable.Columns.Add("title");
                //dataTable.Columns.Add("summary");

                //while (dr.Read())
                //{
                //    DataRow row = dataTable.NewRow();
                //    row["id"] = dr["id"];
                //    row["test_time"] = dr["test_time"];
                //    row["title"] = dr["title"];
                //    row["summary"] = dr["summary"];
                //    dataTable.Rows.Add(row);
                //}
                dataTable2 = ds2.Tables["xxxTest2"];

                GridView2.DataSource = dataTable2;
                GridView2.DataBind();
            }
            catch (Exception ex)
            {
                msg.Text += " G2:" + ex.Message + " ";
            }
            finally
            {
                //if (dr != null)
                //{
                //    cmd.Cancel();
                //    dr.Close();
                //}
                //if (conn.State == ConnectionState.Open)
                //{
                //    conn.Close();
                //    conn.Dispose();
                //}
            }
            //=============================================================================
            //=============================================================================
            SqlConnection conn3 = new SqlConnection(WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString);
            SqlDataAdapter myAdapter3 = null;
            try
            {
                myAdapter3 = new SqlDataAdapter(queryString, conn3);
                DataSet ds3 = new DataSet();

                myAdapter.Fill(ds3, "xxxTest3");

                DataTable dataTable3 = new DataTable();
                dataTable3 = ds3.Tables["xxxTest3"];

                StringBuilder sb = new StringBuilder();
                sb.Append("<table border='1'><tr><td>ID</td><td>時間</td><td>標題</td><td>Summary</td></tr>");
                for (int i = 0; i < dataTable3.Rows.Count; i++)
                {
                    sb.Append("<tr>");
                    sb.Append("<td>" + dataTable3.Rows[i]["id"] + "</td>");
                    sb.Append("<td>" + dataTable3.Rows[i]["test_time"] + "</td>");
                    sb.Append("<td>" + dataTable3.Rows[i]["title"] + "</td>");
                    sb.Append("<td>" + dataTable3.Rows[i]["summary"] + "</td>");
                    sb.Append("</tr>");
                }
                sb.Append("</table>");
                Literal1.Text = sb.ToString();
            }
            catch (Exception ex)
            {
                msg.Text += " G3:" + ex.Message + " ";
            }
            //=============================================================================
        }
    }
}