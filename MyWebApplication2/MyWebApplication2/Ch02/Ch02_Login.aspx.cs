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

namespace MyWebApplication2.Ch02
{
    public partial class Ch02_Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            Login Login1 = (Login)LoginView1.FindControl("Login1");
            Label lblErrMsg = (Label)LoginView1.FindControl("lblErrMsg");

            string user = Login1.UserName.Trim();
            string pssword = Login1.Password.Trim();
            if (e.Authenticated == false)
            {
                if (chkLogin(user, pssword))
                {
                    //取得或設定在登入嘗試成功時顯示給使用者之頁面的 URL。
                    Login1.DestinationPageUrl = "~/Ch02/LoginResult.aspx";
                    //將已驗證的使用者重新導向回到原來要求的 URL 或預設 URL。
                    FormsAuthentication.RedirectFromLoginPage(Login1.UserName, true);
                    //已經過驗證
                    e.Authenticated = true;
                    Session["UserId"] = "user";
                    Session["IsLogin"] = "OK";
                }
                else
                {
                    e.Authenticated = false;
                    Session["UserId"] = "";
                    Session["IsLogin"] = "NG";
                    //將瀏覽器重新導向至包含指定查詢字串的登入 URL。
                    //FormsAuthentication.RedirectToLoginPage(Login1.UserName);
                }

            }
        }

        private bool chkLogin(string username, string password)
        {
            string strConn = ConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString;

            SqlConnection sqlConn = new SqlConnection(strConn);
            String strSQL = "select * from db_user where name =" + username + "and password =" + password;
            SqlDataReader dr = null;
            SqlCommand command = new SqlCommand(strSQL, sqlConn);
            try
            {
                sqlConn.Open();
                dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
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