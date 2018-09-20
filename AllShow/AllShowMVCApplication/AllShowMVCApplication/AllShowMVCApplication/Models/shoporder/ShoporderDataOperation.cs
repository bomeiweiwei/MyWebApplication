using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Configuration;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace AllShowMVCApplication.Models.shoporder
{
    public class ShoporderDataOperation : IDataOperation<SHOPORDER>
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["AllShowConnectionString"].ConnectionString;
        public IEnumerable<SHOPORDER> Get()
        {
            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand("Select * from SHOPORDER");

            cmd.Connection = connection;
            connection.Open();

            IDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleResult);

            while (reader.Read())
            {
                SHOPORDER shoporder = new SHOPORDER()
                {
                    shoporderNo = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("shoporderNo"))),
                    orderNo = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("orderNo"))),
                    shNo = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("shNo"))),
                    orderPrice = Convert.ToDouble(reader.GetValue(reader.GetOrdinal("orderPrice"))),
                    referredToDate = (reader.IsDBNull(reader.GetOrdinal("referredToDate"))) ? new Nullable<DateTime>() : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("referredToDate"))),
                    transactionDate = (reader.IsDBNull(reader.GetOrdinal("transactionDate"))) ? new Nullable<DateTime>() : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("transactionDate"))),
                    orderState = reader.GetValue(reader.GetOrdinal("orderState")).ToString(),
                    recipientName = reader.GetValue(reader.GetOrdinal("recipientName")).ToString(),
                    recipientTel = reader.GetValue(reader.GetOrdinal("recipientTel")).ToString(),
                    recipientAddress = reader.GetValue(reader.GetOrdinal("recipientAddress")).ToString(),
                    payType = reader.GetValue(reader.GetOrdinal("payType")).ToString()
                };
                yield return shoporder;
            }
            connection.Close();
            //throw new NotImplementedException();
        }

        public SHOPORDER FindOne(int id)
        {
            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand("Select * from SHOPORDER where shoporderNo=@shoporderNo");

            cmd.Connection = connection;
            cmd.Parameters.Add(new SqlParameter("@shoporderNo", id));

            connection.Open();

            IDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleResult);

            reader.Read();
            SHOPORDER shoporder = new SHOPORDER()
            {
                shoporderNo = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("shoporderNo"))),
                orderNo = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("orderNo"))),
                shNo = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("shNo"))),
                orderPrice = Convert.ToDouble(reader.GetValue(reader.GetOrdinal("orderPrice"))),
                referredToDate = (reader.IsDBNull(reader.GetOrdinal("referredToDate"))) ? new Nullable<DateTime>() : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("referredToDate"))),
                transactionDate = (reader.IsDBNull(reader.GetOrdinal("transactionDate"))) ? new Nullable<DateTime>() : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("transactionDate"))),
                orderState = reader.GetValue(reader.GetOrdinal("orderState")).ToString(),
                recipientName = reader.GetValue(reader.GetOrdinal("recipientName")).ToString(),
                recipientTel = reader.GetValue(reader.GetOrdinal("recipientTel")).ToString(),
                recipientAddress = reader.GetValue(reader.GetOrdinal("recipientAddress")).ToString(),
                payType = reader.GetValue(reader.GetOrdinal("payType")).ToString()
            };
            connection.Close();
            return shoporder;
        }

        public void Create(SHOPORDER Item)
        {
            Item.orderState = "0";//Default 0
            Item.payType = "2";
            StringBuilder sb = new StringBuilder();
            sb.Append("Insert into SHOPORDER (");
            sb.Append("");
            sb.Append("orderNo");
            sb.Append("shNo");
            sb.Append("orderPrice");
            sb.Append("referredToDate");
            sb.Append("transactionDate");
            sb.Append("orderState");
            sb.Append("recipientName");
            sb.Append("recipientTel");
            sb.Append("recipientAddress");
            sb.Append("payType");
            sb.Append(") values(");
            sb.Append("@orderNo");
            sb.Append("@shNo");
            sb.Append("@orderPrice");
            sb.Append("@referredToDate");
            sb.Append("@transactionDate");
            sb.Append("@orderState");
            sb.Append("@recipientName");
            sb.Append("@recipientTel");
            sb.Append("@recipientAddress");
            sb.Append("@payType");
            sb.Append(")");

            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand(sb.ToString());

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@orderNo", Item.orderNo));
            cmd.Parameters.Add(new SqlParameter("@shNo", Item.shNo));
            cmd.Parameters.Add(new SqlParameter("@orderPrice", Item.orderPrice));
            cmd.Parameters.Add(new SqlParameter("@referredToDate", Item.referredToDate));
            cmd.Parameters.Add(new SqlParameter("@transactionDate", Item.transactionDate));
            cmd.Parameters.Add(new SqlParameter("@orderState", Item.orderState));
            cmd.Parameters.Add(new SqlParameter("@recipientName", Item.recipientTel));
            cmd.Parameters.Add(new SqlParameter("@recipientTel", Item.recipientTel));
            cmd.Parameters.Add(new SqlParameter("@recipientAddress", Item.recipientAddress));
            cmd.Parameters.Add(new SqlParameter("@payType", Item.payType));

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
            }
            //throw new NotImplementedException();
        }

        public void Update(SHOPORDER Item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update SHOPORDER Set ");
            sb.Append("orderNo=@orderNo");
            sb.Append("shNo=@shNo");
            sb.Append("orderPrice=@orderPrice");
            sb.Append("referredToDate=@referredToDate");
            sb.Append("transactionDate=@transactionDate");
            sb.Append("orderState=@orderState");
            sb.Append("recipientName=@recipientName");
            sb.Append("recipientTel=@recipientTel");
            sb.Append("recipientAddress=@recipientAddress");
            sb.Append("payType=@payType");
            sb.Append("Where shoporderNo=@shoporderNo");

            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand(sb.ToString());

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@shoporderNo", Item.shoporderNo));
            cmd.Parameters.Add(new SqlParameter("@orderNo", Item.orderNo));
            cmd.Parameters.Add(new SqlParameter("@shNo", Item.shNo));
            cmd.Parameters.Add(new SqlParameter("@orderPrice", Item.orderPrice));
            cmd.Parameters.Add(new SqlParameter("@referredToDate", Item.referredToDate));
            cmd.Parameters.Add(new SqlParameter("@transactionDate", Item.transactionDate));
            cmd.Parameters.Add(new SqlParameter("@orderState", Item.orderState));
            cmd.Parameters.Add(new SqlParameter("@recipientName", Item.recipientTel));
            cmd.Parameters.Add(new SqlParameter("@recipientTel", Item.recipientTel));
            cmd.Parameters.Add(new SqlParameter("@recipientAddress", Item.recipientAddress));
            cmd.Parameters.Add(new SqlParameter("@payType", Item.payType));

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
            }
            //throw new NotImplementedException();
        }
        public void Delete(SHOPORDER Item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete from SHOPORDER ");
            sb.Append("Where shoporderNo=@shoporderNo ");

            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand(sb.ToString());

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@shoporderNo", Item.shoporderNo));

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
            }
            //throw new NotImplementedException();
        }
    }
}