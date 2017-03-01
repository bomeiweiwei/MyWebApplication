using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MyWebApplication.Ch10
{
    public partial class Ch10_NoneSqlDataSourceControls2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //第一次執行網頁
                //---------------------------
                Session["Page"] = "0";
                Session["select_ID"] = "-1"; 
                //---------------------------
                SqlConnection Conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString);
                SqlDataAdapter da = new SqlDataAdapter("SELECT [id], [title], [summary], [test_time] FROM [test]", Conn);
                DataSet ds = new DataSet();
                try
                {
                    da.Fill(ds, "myTable");
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    lblErr.Text = "1." + ex.Message.ToString();
                }
                finally
                {

                }
            }
            else
            {
                lblSuccess.Text = "";
                lblErr.Text = "";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                Label lbl1 = (Label)GridView1.Rows[i].FindControl("lblID");//id
                Label lbl2 = (Label)GridView1.Rows[i].FindControl("lblTitle");//title
                CheckBox chk = (CheckBox)GridView1.Rows[i].FindControl("chkID");//checkbox
                if (chk.Checked)
                {

                    if (Session["select_ID"].ToString() == "-1")
                    {
                        Session["select_ID"] = "";
                    }

                    if (Session["select_ID"].ToString().IndexOf(lbl1.Text, 0) == -1)
                    {
                        Session["select_ID"] = Session["select_ID"].ToString() + lbl1.Text + ",";
                    }
                    //Response.Write(lbl1.Text + "," + lbl2.Text + "<br />");
                }
                else
                {
                    if (Session["select_ID"].ToString() != "-1")
                    {
                        if (Session["select_ID"].ToString().IndexOf(lbl1.Text, 0) >= 0)
                        {
                            string strRemoveID = lbl1.Text + ",";
                            Session["select_ID"] = Session["select_ID"].ToString().Replace(strRemoveID, "");
                        }
                    }
                    if (Session["select_ID"].ToString().Equals(""))
                    {
                        Session["select_ID"] = "-1";
                    }
                }
            }
            if (Session["select_ID"].ToString().Equals ("-1"))
            {
                Response.Write("Session無存放任何選擇");
            }
            else {
                Response.Write("Session=" + Session["select_ID"].ToString());
            }
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //點選數字進入
            //checkbox check--------------------------------------------------------------
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                Label lbl1 = (Label)GridView1.Rows[i].FindControl("lblID");//id
                CheckBox chk = (CheckBox)GridView1.Rows[i].FindControl("chkID");//checkbox
                if (chk.Checked)
                {
                    if (Session["select_ID"].ToString() == "-1")
                    {
                        Session["select_ID"] = "";
                    }

                    if (Session["select_ID"].ToString().IndexOf(lbl1.Text, 0) == -1)
                    {
                        Session["select_ID"] = Session["select_ID"].ToString() + lbl1.Text + ",";
                    }
                }
                else
                {
                    if (Session["select_ID"].ToString() != "-1")
                    {
                        if (Session["select_ID"].ToString().IndexOf(lbl1.Text, 0) >= 0)
                        {
                            string strRemoveID = lbl1.Text + ",";
                            Session["select_ID"] = Session["select_ID"].ToString().Replace(strRemoveID, "");
                        }
                    }
                    if (Session["select_ID"].ToString().Equals("")) {
                        Session["select_ID"] = "-1"; 
                    }
                }
            }
            //checkbox check--------------------------------------------------------------
            GridView1.PageIndex = e.NewPageIndex;

            GridView1.DataSource = GetSource();
            GridView1.DataBind();
        }

        private DataSet GetSource() {
            SqlConnection Conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT [id], [title], [summary], [test_time] FROM [test]", Conn);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds, "myTable");
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                lblErr.Text = "2." + ex.Message.ToString();
            }
            finally
            {

            }
            return ds;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label lbl1 = (Label)e.Row.FindControl("lblID");//id
            CheckBox chk = (CheckBox)e.Row.FindControl("chkID");//checkbox
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (lbl1 != null && chk != null)
                        if (Session["select_ID"].ToString().IndexOf(lbl1.Text, 0) >= 0)
                        {
                            chk.Checked = true;
                        }
                        else
                        {
                            chk.Checked = false;
                        }
                }
            }
            catch (Exception ex)
            {
                lblErr.Text = "3." + ex.Message.ToString();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GridView1.EditIndex = GridView1.SelectedIndex;
            
            //GridView1.DataSource = GetSource();
            //GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;

            GridView1.DataSource = GetSource();
            GridView1.DataBind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1.DataSource = GetSource();
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Cancel_Select") {
                GridView1.SelectedIndex = -1;
            }
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            lblPager.Text = "頁數 : " + (GridView1.PageIndex+1).ToString() + "/" + GridView1.PageCount.ToString();
            GridViewRow pagerRow = GridView1.TopPagerRow;
            DropDownList ddl = (DropDownList)pagerRow.FindControl("DropDownList1");
            if (ddl != null) {
                for (int i = 0; i < GridView1.PageCount; i++) {
                    int pNum = i + 1;
                    ListItem li = new ListItem(pNum.ToString());
                    if (i == GridView1.PageIndex)
                        li.Selected = true;
                    ddl.Items.Add(li);
                }
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //點選DropDownList進入
            GridViewRow pagerRow = GridView1.TopPagerRow;
            DropDownList ddl = (DropDownList)pagerRow.FindControl("DropDownList1");
            GridView1.PageIndex = ddl.SelectedIndex;

            GridView1.DataSource = GetSource();
            GridView1.DataBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Calendar calTestTime = (Calendar)GridView1.Rows[e.RowIndex].FindControl("calTestTime");//.Cells[4].Controls[0];
            TextBox txtUpTitle = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtUpTitle");//.Cells[5].Controls[0];
            TextBox txtUpSummary = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtUpSummary");//.Cells[6].Controls[0];
            try
            {
                int index = (int)GridView1.DataKeys[e.RowIndex].Value;
                int _index = e.RowIndex;

                int upNum = 0;

                upNum = UpdateData1(calTestTime.SelectedDate, txtUpTitle.Text, txtUpSummary.Text, index);
                //upNum = UpdateData2(calTestTime.SelectedDate, txtUpTitle.Text, txtUpSummary.Text, _index);

                if (upNum > 0)
                {
                    lblSuccess.Text = "更新成功";
                }
                else
                {
                    lblErr.Text = "更新失敗";
                }

                GridView1.EditIndex = -1;

                GridView1.DataSource = GetSource();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                lblErr.Text = "4." + ex.Message.ToString();
            }
        }

        private int UpdateData1(DateTime time, string title, string summary,int index) {
            int upNum = 0;
            try
            {
                SqlConnection Conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString);
                SqlDataAdapter da = new SqlDataAdapter();
                da.UpdateCommand = new SqlCommand("UPDATE [test] SET [test_time] = @test_time, [title] = @title, [summary] = @summary WHERE [id] = @id", Conn);

                da.UpdateCommand.Parameters.Add("@test_time", SqlDbType.DateTime);
                da.UpdateCommand.Parameters["@test_time"].Value = time;

                da.UpdateCommand.Parameters.Add("@title", SqlDbType.VarChar,50);
                da.UpdateCommand.Parameters["@title"].Value = title;

                da.UpdateCommand.Parameters.Add("@summary", SqlDbType.VarChar, 50);
                da.UpdateCommand.Parameters["@summary"].Value = summary;

                da.UpdateCommand.Parameters.Add("@id", SqlDbType.Int,4);
                da.UpdateCommand.Parameters["@id"].Value = index;

                Conn.Open();
                upNum = da.UpdateCommand.ExecuteNonQuery();
                da.Dispose();
            }
            catch (Exception ex) {
                lblErr.Text = "5." + ex.Message.ToString();
            }
            return upNum;
        }

        private int UpdateData2(DateTime time, string title, string summary,int index)
        {
            int upNum = 0;
            try
            {
                DataSet ds = new DataSet();
                SqlConnection Conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString);
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = new SqlCommand("select * from test", Conn);
                da.Fill(ds, "test");

                ds.Tables["test"].Rows[index]["test_time"] = time.ToString();
                ds.Tables["test"].Rows[index]["title"] = title;
                ds.Tables["test"].Rows[index]["summary"] = summary;

                upNum=da.Update(ds, "test");
            }
            catch (Exception ex) {
                lblErr.Text = "6." + ex.Message.ToString();
            }
            return upNum;
        }

        protected void calTestTime_SelectionChanged(object sender, EventArgs e)
        {
            Calendar cal = (Calendar)sender;
            //Response.Write(cal.SelectedDate.ToString());
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int upNum = 0;
            try
            {
                SqlConnection Conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString);
                SqlDataAdapter da = new SqlDataAdapter();
                da.DeleteCommand = new SqlCommand("delete from test where id=@id", Conn);

                da.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 4);
                da.DeleteCommand.Parameters["@id"].Value = (int)GridView1.DataKeys[e.RowIndex].Value;
                //Conn.Open();
                //upNum=da.DeleteCommand.ExecuteNonQuery();
                //da.Dispose();

                DataSet ds = new DataSet();
                da.SelectCommand = new SqlCommand("select * from test",Conn);
                da.Fill(ds, "test");
                ds.Tables["test"].Rows[e.RowIndex].Delete();

                upNum=da.Update(ds, "test");

                GridView1.DataSource = GetSource();
                GridView1.DataBind();
            }
            catch (Exception ex) {
                lblErr.Text = "7."+ex.Message.ToString();
            }
            if (upNum > 0)
            {
                lblSuccess.Text = "刪除成功";
            }
            else
            {
                lblErr.Text = "刪除失敗";
            }
        }
    }
}