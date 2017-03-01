using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MyWebApplication2.Ch08
{
    // 注意: 您可以使用 [重構] 功能表上的 [重新命名] 命令同時變更程式碼、svc 和組態檔中的類別名稱 "Ch08Service"。
    // 注意: 若要啟動 WCF 測試用戶端以便測試此服務，請在 [方案總管] 中選取 Ch08Service.svc 或 Ch08Service.svc.cs，然後開始偵錯。
    public class Ch08Service : ICh08Service
    {
        public string DoWork()
        {
            return "Hello World!!";
        }

        public DataSet Get_Data(int u_id)
        {
            DataSet ds = new DataSet();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString);
            //SqlDataAdapter sda = new SqlDataAdapter("select id,test_time,title,author from test where id=@id", conn);
            //sda.SelectCommand.Parameters.AddWithValue("@id", u_id);
            SqlDataAdapter sda = new SqlDataAdapter("select id,test_time,title,author from test", conn);
            //sda.SelectCommand.Parameters.AddWithValue("@id", u_id);
            sda.Fill(ds, "test");
            return ds;
        }
    }
}
