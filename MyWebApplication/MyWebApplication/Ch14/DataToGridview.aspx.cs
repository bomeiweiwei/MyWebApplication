using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace MyWebApplication.Ch14
{
    public partial class DataToGridview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DBInit();
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
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Columns.Add("id");
                        dataTable.Columns.Add("test_time");
                        dataTable.Columns.Add("title");
                        dataTable.Columns.Add("summary");

                        while (reader.Read())
                        {
                            DataRow row = dataTable.NewRow();
                            row["id"] = reader["id"];
                            row["test_time"] = reader["test_time"];
                            row["title"] = reader["title"];
                            row["summary"] = reader["summary"];
                            dataTable.Rows.Add(row);
                        }
                        GridView1.DataSource = dataTable;
                        GridView1.DataBind();

                        command.Cancel();
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                msg.Text += "G1:" + ex.Message + " ";
            }
            //=============================================================================
            //=============================================================================
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString);
            SqlDataReader dr = null;
            SqlCommand cmd = new SqlCommand(queryString, conn);

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("id");
                dataTable.Columns.Add("test_time");
                dataTable.Columns.Add("title");
                dataTable.Columns.Add("summary");

                while (dr.Read())
                {
                    DataRow row = dataTable.NewRow();
                    row["id"] = dr["id"];
                    row["test_time"] = dr["test_time"];
                    row["title"] = dr["title"];
                    row["summary"] = dr["summary"];
                    dataTable.Rows.Add(row);
                }
                GridView2.DataSource = dataTable;
                GridView2.DataBind();
            }
            catch (Exception ex)
            {
                msg.Text += " G2:" + ex.Message + " ";
            }
            finally
            {
                if (dr != null)
                {
                    cmd.Cancel();
                    dr.Close();
                }
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            //=============================================================================
        }
    }
}