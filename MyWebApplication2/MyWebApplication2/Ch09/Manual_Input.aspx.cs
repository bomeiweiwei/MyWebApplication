using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;  
using System.Data; 

namespace MyWebApplication2.Ch09
{
    public partial class Manual_Input : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            myDBInit();
        }

        void myDBInit()
        {
            SqlDataSource SqlDataSource1 = new SqlDataSource();
            SqlDataSource1.ConnectionString = WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString;
            SqlDataSource1.SelectCommand = "SELECT * FROM [test] order by id DESC";
            SqlDataSource1.DataSourceMode = SqlDataSourceMode.DataSet;
            DataView dv = (DataView)SqlDataSource1.Select(new DataSourceSelectArguments());
            GridView1.DataSource = dv;
            GridView1.DataBind();

            SqlDataSource1.Dispose();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlDataSource SqlDataSource2 = new SqlDataSource();
            SqlDataSource2.ConnectionString = WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString;
            SqlDataSource2.InsertCommand = "Insert into test(title,test_time,class,summary,article,author) values(@title,@test_time,@class,@summary,@article,@author)";
            SqlDataSource2.InsertParameters.Add("title",TextBox1.Text);
            SqlDataSource2.InsertParameters.Add("test_time",DateTime.Now.ToShortDateString());
            SqlDataSource2.InsertParameters.Add("class",ListBox1.SelectedItem.Value);
            SqlDataSource2.InsertParameters.Add("summary",TextBox2.Text);
            SqlDataSource2.InsertParameters.Add("article",TextBox3.Text);
            SqlDataSource2.InsertParameters.Add("author", TextBox4.Text);
            int aff_row = SqlDataSource2.Insert();
            if (aff_row == 0)
                Response.Write("資料新增失敗！");
            else
                Response.Write("資料新增成功！");
            myDBInit(); 
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            myDBInit();  
        }
    }
}