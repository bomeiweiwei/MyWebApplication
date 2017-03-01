using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace MyWebApplication.Ch11
{
    public partial class Ch11_Excel2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //***************************************************************************
            //*** for Exporting to a Excel file
            HSSFWorkbook workbook = new HSSFWorkbook();


            //== 新增試算表 Sheet名稱。使用 NPOI.SS.UserModel命名空間。(v.1.2.4版）
            ISheet u_sheet = (ISheet)workbook.CreateSheet("My Sheet_124");
            //***************************************************************************

            short s1 = 50;
            short s2 = 48;

            //== 建立儲存格樣式（底色）。v.1.2.4版 =============================(start)
            HSSFCellStyle style1 = (HSSFCellStyle)workbook.CreateCellStyle();
            style1.FillForegroundColor = s1;//NPOI.HSSF.Util.HSSFColor.BLUE.index2;  //==藍色底的儲存格
            style1.FillPattern = FillPatternType.SOLID_FOREGROUND;  //==底圖（紋路）

            HSSFCellStyle style2 = (HSSFCellStyle)workbook.CreateCellStyle();
            style2.FillForegroundColor = s2;//NPOI.HSSF.Util.HSSFColor.YELLOW.index2;  //==黃色底的儲存格
            //style2.FillPattern = FillPatternType.SQUARES;  //==底圖（紋路）
            style2.FillPattern = FillPatternType.SOLID_FOREGROUND;

            //=======微軟SDK文件的範本=======
            SqlConnection Conn = new SqlConnection();
            //----上面已經事先寫好 Imports System.Web.Configuration ----
            Conn.ConnectionString = WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString;
            //----(連結資料庫)----

            SqlDataReader dr = null;
            SqlCommand cmd = new SqlCommand("select id, test_time, summary, author from test", Conn);

            try
            {
                Conn.Open();   //---- 這時候才連結DB
                dr = cmd.ExecuteReader();  //---- 這時候執行SQL指令，取出資料

                //===============================================(start)
                //== 利用迴圈，把資料寫入 Excel各個儲存格裡面。
                int k = 0;

                while (dr.Read())
                {
                    //**** v.1.2.4版在此有很大的改變！！！請看 http://tonyqus.sinaapp.com/archives/73 
                    //**** 先建好一列（Row），才能去作格子（Cell）
                    IRow u_Row = u_sheet.CreateRow(k);

                    for (int i = 0; i < dr.FieldCount; i++)
                    {   //-- FieldCount是指 DataReader每一列紀錄裡面，有幾個欄位。

                        
                        if (k % 2 == 0 && i == 0)
                        {
                            HSSFCell cell = (HSSFCell)u_Row.CreateCell(i);
                            cell.CellStyle = style1;
                            cell.SetCellValue(dr.GetValue(i).ToString());  //== 插入資料值。
                        }
                        else if (k % 2 == 1 && i == 0)
                        {
                            HSSFCell cell = (HSSFCell)u_Row.CreateCell(i);
                            cell.CellStyle = style2;
                            cell.SetCellValue(dr.GetValue(i).ToString());  //== 插入資料值。
                        }
                        else
                        {
                            //**********************************************************(start)
                            //**** v.1.2.4版在此有很大的改變！！！請看 http://tonyqus.sinaapp.com/archives/73  
                            u_Row.CreateCell(i).SetCellValue(dr.GetValue(i).ToString());  //== .CreateCell() 可設定為同一列(Row)的 [第幾個格子]
                            //**********************************************************(end)
                        }
                        //XXXXX 以下用法，在 v1.2.4版會有 Bug，只能列出每一列的「最後一格」的資料！！XXXXXXXXXX
                        //== 避免這樣的錯誤，請看 http://tonyqus.sinaapp.com/archives/73
                        //    u_sheet.CreateRow(k).CreateCell(i).SetCellValue(dr.GetValue(i).ToString());  //*** for Exporting to a Excel file (v.1.2.1版，正常)
                    }
                    k++;
                }
                //===============================================(end)
            }
            catch (Exception ex)   //---- 如果程式有錯誤或是例外狀況，將執行這一段
            {
                Response.Write("<b>Error Message----  </b>" + ex.ToString() + "<hr />");
            }
            finally
            {
                if (dr != null)
                {
                    cmd.Cancel();  //----關閉DataReader之前，一定要先「取消」SqlCommand
                    dr.Close();
                }
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                    Conn.Dispose();  //---- 一開始宣告有用到 New的,最後必須以 .Dispose()結束
                }
            }

            //***************************************************************************
            //*** for Exporting to a Excel file
            MemoryStream ms = new MemoryStream();  //==需要 System.IO命名空間
            workbook.Write(ms);

            //== Excel檔名，請寫在最後面 filename的地方
            string Excel_ShortTime = DateTime.Now.ToShortDateString() + "_" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            Response.AppendHeader("Content-Disposition", "attachment;filename=test_file_" + Excel_ShortTime + ".xls");
            Response.BinaryWrite(ms.ToArray());

            //== 釋放資源
            workbook = null;   //== C#為 null
            ms.Close();
            ms.Dispose();
        }
    }
}