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
    public partial class TransactionWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString))
                    {
                        connection.Open();

                        testDataClassesDataContext db = new testDataClassesDataContext(connection);

                        System.Data.Linq.Table<db_user> mytest = db.GetTable<db_user>();
                        #region user1
                        db_user user = new db_user
                        {
                            real_name = txtRealName.Text,
                            name = txtName.Text,
                            password = txtPassword.Text,
                            email = txtMail.Text,
                            sex = ddlSex.SelectedValue,
                            rank = Convert.ToInt32(txtRank.Text),
                            UpdateRight = 'N',
                            DeleteRight = 'N'
                        };
                        mytest.InsertOnSubmit(user);
                        #endregion
                        #region user2
                        user = new db_user
                        {
                            real_name = txtRealName2.Text,
                            name = txtName2.Text,
                            password = txtPassword2.Text,
                            email = txtMail2.Text,
                            sex = ddlSex2.SelectedValue,
                            rank = Convert.ToInt32(txtRank2.Text),
                            UpdateRight = 'N',
                            DeleteRight = 'N'
                        };
                        mytest.InsertOnSubmit(user);
                        #endregion
                        #region user3
                        user = new db_user
                        {
                            real_name = txtRealName3.Text,
                            name = txtName3.Text,
                            password = txtPassword3.Text,
                            email = txtMail3.Text,
                            sex = ddlSex3.SelectedValue,
                            rank = Convert.ToInt32(txtRank3.Text),
                            UpdateRight = 'N',
                            DeleteRight = 'N'
                        };
                        mytest.InsertOnSubmit(user);
                        #endregion

                        db.SubmitChanges();

                        connection.Close();
                    }
                    scope.Complete();
                    Response.Write("交易成功");
                }
            }
            catch (TransactionException ex)
            {
                Response.Write("交易失敗: " + ex.Message.ToString());
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }
        }
    }
}