using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Transactions;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using MyWebApplication2.Ch07.model;

namespace MyWebApplication2.Ch07
{
    public partial class TransactionWebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString))
            {
                connection.Open();
                SqlTransaction trans = connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand();
                try
                {
                    string insert = "insert into db_user(real_name,name,password,sex,email,rank,UpdateRight,DeleteRight) values(@real_name,@name,@password,@sex,@email,@rank,'N','N')";
                    
                    cmd.Connection = connection;
                    cmd.Transaction = trans;

                    cmd.CommandText = insert;

                    string real_name = txtRealName.Text;
                    string name = txtName.Text;
                    string password = txtPassword.Text;
                    string email = txtMail.Text;
                    string sex = ddlSex.SelectedValue;
                    string rank = txtRank.Text;

                    cmd.Parameters.AddWithValue("@real_name", real_name);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@sex", sex);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@rank", rank);
                    cmd.ExecuteNonQuery();

                    real_name = txtRealName2.Text;
                    name = txtName2.Text;
                    password = txtPassword2.Text;
                    email = txtMail2.Text;
                    sex = ddlSex2.SelectedValue;
                    rank = txtRank2.Text;

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@real_name", real_name);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@sex", sex);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@rank", rank);
                    cmd.ExecuteNonQuery();

                    real_name = txtRealName3.Text;
                    name = txtName3.Text;
                    password = txtPassword3.Text;
                    email = txtMail3.Text;
                    sex = ddlSex3.SelectedValue;
                    rank = txtRank3.Text;

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@real_name", real_name);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@sex", sex);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@rank", rank);
                    cmd.ExecuteNonQuery();

                    trans.Commit();

                    Response.Write("新增成功");


                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    Response.Write(ex.Message.ToString());
                }
                finally
                {
                    cmd.Dispose();
                    trans.Dispose();
                    connection.Close();
                }              
            }
        }
    }
}