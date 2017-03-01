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
    public partial class DDL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                string queryString = "select food_name,id,food_calorie from food_calorie";
                SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString);
                //Conn.Open();     //第一、連結資料庫
                SqlDataAdapter da = new SqlDataAdapter(queryString, conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "foodtest");     //第二、執行SQL指令，取出資料
                //註解：執行SQL指令之後，把資料庫撈出來的結果，交由畫面上 DropDownList控制項來呈現。
                DropDownList1.DataValueField = "id";        //在此輸入的是資料表的欄位名稱
                DropDownList1.DataTextField = "food_name";      //在此輸入的是資料表的欄位名稱
                DropDownList1.DataSource = ds.Tables["foodtest"].DefaultView;
                DropDownList1.DataBind();
                //Conn.Close();      //第四、關閉資料庫的連接與相關資源

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
                            dataTable.Columns.Add("food_name");
                            dataTable.Columns.Add("food_calorie");

                            while (reader.Read())
                            {
                                DataRow row = dataTable.NewRow();
                                row["id"] = reader["id"];
                                row["food_name"] = reader["food_name"];
                                row["food_calorie"] = reader["food_calorie"];
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
                    msg.Text = ex.Message + " ";
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string queryString = "SELECT food_calorie FROM FOOD_CALORIE WHERE id = @id";

            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString);
            SqlDataReader dr = null;
            SqlCommand cmd = new SqlCommand(queryString, conn);

            try
            {
                conn.Open();
                cmd.Parameters.AddWithValue("id", DropDownList1.SelectedValue);
                int cal = Convert.ToInt32(cmd.ExecuteScalar());
                Label1.Text = Convert.ToString(cal * Convert.ToInt32(TextBox1.Text));
            }
            catch (Exception ex)
            {
                msg.Text = ex.Message;
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


        }
    }
}