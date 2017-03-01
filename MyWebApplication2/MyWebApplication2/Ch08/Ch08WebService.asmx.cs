using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MyWebApplication2.Ch08
{
    /// <summary>
    ///Ch08WebService 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
    [System.Web.Script.Services.ScriptService]
    public class Ch08WebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";                
        }

        [WebMethod]
        public int Compute_it(int a,int b)
        {
            return a*b;
        }

        [WebMethod]
        public DataSet Get_Data(int u_id)
        {
            DataSet ds = new DataSet();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select id,test_time,title,author from test where id=@id", conn);
            sda.SelectCommand.Parameters.AddWithValue("@id", u_id);
            sda.Fill(ds, "test");
            return ds;
        }
    }
}
