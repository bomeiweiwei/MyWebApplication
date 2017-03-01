using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;

namespace MyWebApplication2.Ch12
{
    public partial class LoginWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string strConn = ConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString;
            string username = txtAcc.Text;
            string password = txtPass.Text;

            bool check = check_Parameters(username, password);
            if (check)
            {
                SqlConnection sqlConn = new SqlConnection(strConn);
                String strSQL = "select * from db_user where name =@username and password =@password";
                SqlDataReader dr = null;
                SqlCommand command = new SqlCommand(strSQL, sqlConn);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                try
                {
                    sqlConn.Open();
                    dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        Label1.Text = "find";
                    }
                    else
                    {
                        Label1.Text = "not find";
                    }
                }
                catch (Exception ex)
                {
                    Label1.Text = ex.Message.ToString();
                }
                finally
                {
                    if (dr != null)
                    {
                        command.Cancel();
                        dr.Close();
                    }
                    if (sqlConn.State == ConnectionState.Open)
                    {
                        sqlConn.Close();
                    }
                }
            }
            else
            {
                Label1.Text = "Injection";
            }
        }

        private bool check_Parameters(string param1, string param2)
        {
            bool check = true;
            string[] dangerousWords = { "or", "1=1", "1 = 1", "--", "'" };
            for (int i = 0; i < dangerousWords.Length; i++)
            {
                if (param1.IndexOf(dangerousWords[i], 0) != -1)
                {
                    check = false;
                    break;
                }
                if (param2.IndexOf(dangerousWords[i], 0) != -1)
                {
                    check = false;
                    break;
                }
            }
            return check;
        }
    }
}