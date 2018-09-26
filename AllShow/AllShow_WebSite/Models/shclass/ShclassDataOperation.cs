using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Configuration;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace AllShow_WebSite.Models.shclass
{
    public class ShclassDataOperation : IDataOperation<Shclass>
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["AllShowConnectionString"].ConnectionString;
        public IEnumerable<Shclass> Get()
        {
            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand("Select * from SHCLASS ");

            cmd.Connection = connection;
            connection.Open();

            IDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleResult);

            while (reader.Read())
            {
                Shclass shclass = new Shclass()
                {
                    shclassno = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("shclassno"))),
                    shclassname = reader.GetValue(reader.GetOrdinal("shclassname")).ToString(),
                };
                yield return shclass;
            }
            connection.Close();
            //throw new NotImplementedException();
        }

        public Shclass FindOne(int id)
        {
            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand("Select * from SHCLASS where shclassno=@shclassno ");

            cmd.Connection = connection;
            cmd.Parameters.Add(new SqlParameter("@shclassno", id));

            connection.Open();

            IDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleResult);

            reader.Read();
            Shclass shclass = new Shclass()
            {
                shclassno = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("shclassno"))),
                shclassname = reader.GetValue(reader.GetOrdinal("shclassname")).ToString(),
            };
            connection.Close();
            return shclass;
        }

        public void Create(Shclass Item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Insert into SHCLASS ( ");
            sb.Append(" ");
            sb.Append("shclassname ");
            sb.Append(") values( ");
            sb.Append("@shclassname ");
            sb.Append(") ");

            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand(sb.ToString());

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@shclassname", Item.shclassname));

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

        public void Update(Shclass Item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update SHCLASS Set ");
            sb.Append("shclassname=@shclassname ");
            sb.Append("Where shclassno=@shclassno ");

            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand(sb.ToString());

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@shclassno", Item.shclassno));
            cmd.Parameters.Add(new SqlParameter("@shclassname", Item.shclassname));

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

        public void Delete(Shclass Item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete from SHCLASS ");
            sb.Append("Where shclassno=@shclassno ");

            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand(sb.ToString());

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@shclassno", Item.shclassno));

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