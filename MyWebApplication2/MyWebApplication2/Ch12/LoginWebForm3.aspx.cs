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
    public partial class LoginWebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string strConn = ConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString;
            string username = System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(txtAcc.Text,false);
            string password = System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(txtPass.Text, false);

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
    }
}