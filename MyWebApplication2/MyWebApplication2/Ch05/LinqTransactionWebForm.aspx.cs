using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MyWebApplication2.Ch05
{
    public partial class LinqTransactionWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            string real_name = txtName.Text;
            string name = txtName2.Text;
            string password = txtPassword.Text;
            string email = txtMail.Text;
            string sex = ddlSex.SelectedValue;

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    string insert = "insert into db_user(real_name,name,password,sex,email,rank,UpdateRight,DeleteRight) values(@real_name,@name,@password,@sex,@email,1,'N','N')";
                    using (SqlCommand cmd = new SqlCommand(insert,conn))
                    {
                        cmd.Transaction = trans;

                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@real_name", real_name);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@sex", sex);
                        cmd.Parameters.AddWithValue("@email", email);

                        cmd.ExecuteNonQuery();
                        trans.Commit();

                        lblInsertMsg.Text = "新增成功";
                    }

                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message.ToString());
                    lblInsertMsg.Text = "新增失敗";
                }
            }
        }

        protected void btn_Submit2_Click(object sender, EventArgs e)
        {
            string real_name = txtName.Text;
            string name = txtName2.Text;
            string password = txtPassword.Text;
            string email = txtMail.Text;
            string sex = ddlSex.SelectedValue;

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString))
            {
                conn.Open();
                //SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    Test_UserDataClassesDataContext db = new Test_UserDataClassesDataContext(conn);

                    db.Transaction = conn.BeginTransaction();

                    db_user user = new db_user
                    {
                        real_name = real_name,
                        name=name,
                        password=password,
                        email=email,
                        sex=sex,
                        rank=1,
                        UpdateRight='N',
                        DeleteRight='N'
                    };

                    db.db_user.InsertOnSubmit(user);

                    db.SubmitChanges();
                    db.Transaction.Commit();

                    lblInsertMsg.Text = "新增成功";
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message.ToString());
                    lblInsertMsg.Text = "新增失敗";
                }
            }

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString))
            {
                conn.Open();
                try
                {
                    Test_UserDataClassesDataContext db = new Test_UserDataClassesDataContext(conn);
                    System.Data.Linq.Table<db_user> mytest = db.GetTable<db_user>();

                    db.Transaction = conn.BeginTransaction();

                    db_user user = new db_user
                    {
                        real_name = real_name + "copy",
                        name = name + "copy",
                        password = password,
                        email = email,
                        sex = sex,
                        rank = 1,
                        UpdateRight = 'N',
                        DeleteRight = 'N'
                    };

                    mytest.InsertOnSubmit(user);

                    db.SubmitChanges();
                    db.Transaction.Commit();

                    lblInsertMsg.Text = "新增成功";
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message.ToString());
                    lblInsertMsg.Text = "新增失敗";
                }
            }
        }

        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            string data = txtDelete.Text;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString))
            {
                conn.Open();
                //SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    Test_UserDataClassesDataContext db = new Test_UserDataClassesDataContext(conn);

                    db.Transaction = conn.BeginTransaction();

                    var query = from t in db.db_user
                                where t.real_name == data
                                select t;

                    foreach (db_user user in query)
                    {
                        db.db_user.DeleteOnSubmit(user);
                    }

                    db.SubmitChanges();
                    db.Transaction.Commit();

                    lblDelete.Text = "刪除成功";
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message.ToString());
                    lblDelete.Text = "刪除失敗";
                }
            }
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            string name = TxtSearchName.Text;
            string email = txtUpdate.Text;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString))
            {
                conn.Open();
                //SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    Test_UserDataClassesDataContext db = new Test_UserDataClassesDataContext(conn);

                    db.Transaction = conn.BeginTransaction();

                    db_user query = (from t in db.db_user
                                where t.real_name == name
                                select t).First();

                    query.email = email;

                    db.SubmitChanges();
                    db.Transaction.Commit();

                    lblUpdate.Text = "更新成功";
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message.ToString());
                    lblUpdate.Text = "更新失敗";
                }
            }
        }

    }
}