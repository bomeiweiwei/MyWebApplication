using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using MyWebApplication;

namespace MyWebApplication
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // 應用程式啟動時執行的程式碼
            AuthConfig.RegisterOpenAuth();

            Application["UsersOnline"] = 0;
        }

        void Application_End(object sender, EventArgs e)
        {
            //  應用程式關閉時執行的程式碼

        }

        void Application_Error(object sender, EventArgs e)
        {
            // 發生未處理錯誤時執行的程式碼
            if (Server.GetLastError().GetType().ToString() == "System.Web.HttpRequestValidationException")
            {
                Response.Write("HttpRequestValidationException");
            }

            Server.ClearError(); 
        }

        void Session_Start(object sender, EventArgs e)
        {
            Session.Timeout = 1;
            Application.Lock();
            Application["UsersOnline"] = Convert.ToUInt32(Application["UsersOnline"]) + 1;
            Application.UnLock();
        }

        void Session_End(object sender, EventArgs e)
        {
            Application.Lock();
            Application["UsersOnline"] = Convert.ToUInt32(Application["UsersOnline"]) - 1;
            Application.UnLock();
        }
    }
}
