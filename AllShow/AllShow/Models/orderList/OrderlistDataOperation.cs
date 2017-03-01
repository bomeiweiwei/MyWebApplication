using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Configuration;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace AllShow.Models.orderList
{
    public class OrderlistDataOperation : IDataOperation<Orderlist>
    {
        //private string connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private string connectionString = WebConfigurationManager.ConnectionStrings["AllShowConnectionString"].ConnectionString;
        public IEnumerable<Orderlist> Get()
        {
            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand("Select * from ORDERLIST");

            cmd.Connection = connection;
            connection.Open();

            IDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleResult);

            while (reader.Read())
            {
                Orderlist orderlist = new Orderlist()
                {
                    shoporderNo = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("shoporderNo"))),
                    proNo = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("proNo"))),
                    quantity = Convert.ToDouble(reader.GetValue(reader.GetOrdinal("quantity")))
                };
                yield return orderlist;
            }
            connection.Close();
            //throw new NotImplementedException();
        }

        public Orderlist FindOne(int id)
        {
            return null;
        }

        public Orderlist FindOne(int id, int id2)
        {
            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand("Select * from ORDERLIST where shoporderNo=@shoporderNo and proNo=@proNo ");

            cmd.Connection = connection;
            cmd.Parameters.Add(new SqlParameter("@shoporderNo", id));
            cmd.Parameters.Add(new SqlParameter("@proNo", id2));

            connection.Open();

            IDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleResult);

            reader.Read();
            Orderlist orderlist = new Orderlist()
            {
                shoporderNo = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("shoporderNo"))),
                proNo = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("proNo"))),
                quantity = Convert.ToDouble(reader.GetValue(reader.GetOrdinal("quantity")))
            };
            connection.Close();
            return orderlist;
        }

        public void Create(Orderlist Item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Insert into ORDERLIST (");
            sb.Append("");
            sb.Append("shoporderNo, ");
            sb.Append("proNo, ");
            sb.Append("quantity ");
            sb.Append(") values(");
            sb.Append("@shoporderNo,");
            sb.Append("@proNo,");
            sb.Append("@quantity");
            sb.Append(")");

            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand(sb.ToString());

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@shoporderNo", Item.shoporderNo));
            cmd.Parameters.Add(new SqlParameter("@proNo", Item.proNo));
            cmd.Parameters.Add(new SqlParameter("@quantity", Item.quantity));

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

        public void Update(Orderlist Item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update ORDERLIST Set ");
            sb.Append("quantity=@quantity ");
            sb.Append("where shoporderNo=@shoporderNo and proNo=@proNo ");

            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand(sb.ToString());

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@shoporderNo", Item.shoporderNo));
            cmd.Parameters.Add(new SqlParameter("@proNo", Item.proNo));
            cmd.Parameters.Add(new SqlParameter("@quantity", Item.quantity));

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

        public void Delete(Orderlist Item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete from ORDERLIST ");
            sb.Append("where shoporderNo=@shoporderNo and proNo=@proNo ");

            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand(sb.ToString());

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@shoporderNo", Item.shoporderNo));
            cmd.Parameters.Add(new SqlParameter("@proNo", Item.proNo));

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