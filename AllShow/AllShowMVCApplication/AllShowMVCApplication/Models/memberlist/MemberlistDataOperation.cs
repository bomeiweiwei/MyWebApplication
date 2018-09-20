using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Configuration;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace AllShowMVCApplication.Models.memberlist
{
    public class MemberlistDataOperation : IDataOperation<MEMBERLIST>
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["AllShowConnectionString"].ConnectionString;
        public IEnumerable<MEMBERLIST> Get()
        {
            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand("Select * from MEMBERLIST ");

            cmd.Connection = connection;
            connection.Open();

            IDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleResult);

            while (reader.Read())
            {
                MEMBERLIST memberlist = new MEMBERLIST()
                {
                    orderNo = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("orderNo"))),
                    memNo = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("memNo"))),
                    orderDate = (reader.IsDBNull(reader.GetOrdinal("orderDate"))) ? new Nullable<DateTime>() : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("orderDate")))
                };
                yield return memberlist;
            }
            connection.Close();
            //throw new NotImplementedException();
        }

        public MEMBERLIST FindOne(int id)
        {
            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand("Select * from MEMBERLIST where orderNo=@orderNo ");

            cmd.Connection = connection;
            cmd.Parameters.Add(new SqlParameter("@orderNo", id));

            connection.Open();

            IDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleResult);

            reader.Read();
            MEMBERLIST memberlist = new MEMBERLIST()
            {
                orderNo = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("orderNo"))),
                memNo = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("memNo"))),
                orderDate = (reader.IsDBNull(reader.GetOrdinal("orderDate"))) ? new Nullable<DateTime>() : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("orderDate")))
            };
            connection.Close();
            return memberlist;
        }

        public void Create(MEMBERLIST Item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Insert into MEMBERLIST ( ");
            sb.Append(" ");
            sb.Append("memNo ");            
            sb.Append(") values( ");
            sb.Append("@memNo ");            
            sb.Append(") ");

            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand(sb.ToString());

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@memNo", Item.memNo));
            
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

        public void Update(MEMBERLIST Item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update MEMBERLIST Set ");
            sb.Append("memNo=@memNo, ");
            sb.Append("orderDate=@orderDate ");
            sb.Append("Where orderNo=@orderNo");

            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand(sb.ToString());

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@orderNo", Item.orderNo));
            cmd.Parameters.Add(new SqlParameter("@memNo", Item.memNo));
            cmd.Parameters.Add(new SqlParameter("@orderDate", Item.orderDate));
            
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

        public void Delete(MEMBERLIST Item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete from MEMBERLIST ");
            sb.Append("Where orderNo=@orderNo ");

            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand(sb.ToString());

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@orderNo", Item.orderNo));

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