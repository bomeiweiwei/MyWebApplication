using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Configuration;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace AllShowMVCApplication.Models.productclass
{
    public class ProductclassDataOperation : IDataOperation<PRODUCTCLASS>
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["AllShowConnectionString"].ConnectionString;
        public IEnumerable<PRODUCTCLASS> Get()
        {
            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand("Select * from PRODUCTCLASS ");

            cmd.Connection = connection;
            connection.Open();

            IDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleResult);

            while (reader.Read())
            {
                PRODUCTCLASS productclass = new PRODUCTCLASS()
                {
                    proclassno = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("proclassno"))),
                    shno = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("shno"))),
                    proclassname = reader.GetValue(reader.GetOrdinal("proclassname")).ToString()                    
                };
                yield return productclass;
            }
            connection.Close();
            //throw new NotImplementedException();
        }

        public PRODUCTCLASS FindOne(int id)
        {
            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand("Select * from PRODUCTCLASS where proclassno=@proclassno ");

            cmd.Connection = connection;
            cmd.Parameters.Add(new SqlParameter("@proclassno", id));

            connection.Open();

            IDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleResult);

            reader.Read();
            PRODUCTCLASS productclass = new PRODUCTCLASS()
            {
                proclassno = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("proclassno"))),
                shno = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("shno"))),
                proclassname = reader.GetValue(reader.GetOrdinal("proclassname")).ToString()
            };
            connection.Close();
            return productclass;
        }

        public void Create(PRODUCTCLASS Item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Insert into PRODUCTCLASS ( ");
            sb.Append(" ");
            sb.Append("shno, ");
            sb.Append("proclassname ");           
            sb.Append(") values( ");
            sb.Append("@shno, ");
            sb.Append("@proclassname "); 
            sb.Append(") ");

            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand(sb.ToString());

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@shno", Item.shno));
            cmd.Parameters.Add(new SqlParameter("@proclassname", Item.proclassname));

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

        public void Update(PRODUCTCLASS Item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update PRODUCTCLASS Set ");
            sb.Append("shno=@shno, ");
            sb.Append("proclassname=@proclassname ");
            sb.Append("Where proclassno=@proclassno ");

            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand(sb.ToString());

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@proclassno", Item.proclassno));
            cmd.Parameters.Add(new SqlParameter("@shno", Item.shno));
            cmd.Parameters.Add(new SqlParameter("@proclassname", Item.proclassname));

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

        public void Delete(PRODUCTCLASS Item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete from PRODUCTCLASS ");
            sb.Append("Where proclassno=@proclassno ");

            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand(sb.ToString());

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@proclassno", Item.proclassno));

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