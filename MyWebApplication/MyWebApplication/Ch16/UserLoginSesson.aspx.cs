using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace MyWebApplication.Ch16
{
    public partial class UserLoginSesson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] != null)
            {
                if (Convert.ToString(Session["Login"]) == "OK")
                {
                    PanelShow.Visible = true;
                    PanelLogin.Visible = false;
                    lblUserName.Text = Convert.ToString(Session["usr_Name"]);
                    lblPassword.Text = "*****";//Convert.ToString(Session["usr_password"]);
                }
                else
                {
                    PanelShow.Visible = false;
                    PanelLogin.Visible = true;
                    lblUserName.Text = "";
                    lblPassword.Text = "";
                }
            }
            else
            {
                PanelShow.Visible = false;
                PanelLogin.Visible = true;
                lblUserName.Text = "";
                lblPassword.Text = "";
            }
        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            if (checkUser2(txtUserName.Text.ToString(), txtPassword.Text.ToString()))
            {
                //lblMsg.Text = "使用者登入成功";
            }
            else
            {
                //lblMsg.Text = "使用者登入失敗";
            }
            Response.Redirect("~/Ch16/UserLoginSesson.aspx");
        }

        private bool checkUser(string usr_name, string password)
        {
            /*
             4.1    使用 SQLCommand.Parameters.Add 方法 
                    cmd.Parameters.Add("@myregion", SqlDbType.NVarChar); 
                    cmd.Parameters["@myregion"].Value = textBox1.Text;
             4.2 使用 SQLCommand.Parameters.AddWithValue 方法 
                    cmd.Parameters.AddWithValue("@myregion", textBox1.Text);
     
             4.3 使用 SQLCommand.Parameters.Add 方法加入 SQLParameters 類別 
                    cmd.Parameters.Add(new SqlParameter("@myregion", textBox1.Text));
             
             */
            string queryString = " select * from db_user where name=@id and password=@password ";
            string connectionString = WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataReader reader;
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@id", usr_name);
                command.Parameters.AddWithValue("@password", password);

                try
                {
                    connection.Open();
                    reader = command.ExecuteReader();
                    if (!reader.Read())
                    {
                        command.Cancel();
                        reader.Close();
                        return false;
                        //Response.End();
                    }
                    else
                    {
                        Session["usr_Name"] = reader["name"];
                        Session["usr_password"] = reader["password"];
                        Session["Login"] = "OK";
                        command.Cancel();
                        reader.Close();
                        return true;
                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return false;
        }

        private bool checkUser2(string usr_name, string password)
        {
            /*
             4.1    使用 SQLCommand.Parameters.Add 方法 
                    cmd.Parameters.Add("@myregion", SqlDbType.NVarChar); 
                    cmd.Parameters["@myregion"].Value = textBox1.Text;
             4.2 使用 SQLCommand.Parameters.AddWithValue 方法 
                    cmd.Parameters.AddWithValue("@myregion", textBox1.Text);
     
             4.3 使用 SQLCommand.Parameters.Add 方法加入 SQLParameters 類別 
                    cmd.Parameters.Add(new SqlParameter("@myregion", textBox1.Text));
             
             */
            string queryString = " select * from db_user where name=@id and password=@password ";
            string connectionString = WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataReader reader;
                SqlCommand command = new SqlCommand(queryString, connection);
                //command.Parameters.AddWithValue("@id", usr_name);
                command.Parameters.Add("@id", SqlDbType.NVarChar);
                command.Parameters["@id"].Value = usr_name;
                //command.Parameters.AddWithValue("@password", password);
                command.Parameters.Add("@password", SqlDbType.NVarChar);
                command.Parameters["@password"].Value = password;

                try
                {
                    connection.Open();
                    reader = command.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        command.Cancel();
                        reader.Close();
                        return false;
                        //Response.End();
                    }
                    else
                    {
                        reader.Read();
                        Session["usr_Name"] = reader["name"];
                        Session["usr_password"] = reader["password"];
                        Session["Login"] = "OK";
                        command.Cancel();
                        reader.Close();
                        return true;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return false;
        }

        protected void btn_Logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Ch16/UserLoginSesson.aspx");
        }
    }
}