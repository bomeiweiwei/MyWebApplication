using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Configuration;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace AllShowMVCApplication.Models.authority
{
    public class AuthorityDataOperation : IDataOperation<AUTHORITY>
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["AllShowConnectionString"].ConnectionString;
        public IEnumerable<AUTHORITY> Get()
        {
            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand("Select * from Authority");

            cmd.Connection = connection;
            connection.Open();

            IDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleResult);

            while (reader.Read())
            {
                AUTHORITY authority = new AUTHORITY()
                {
                    authorityno = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("authorityno"))),
                    empno = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("empno")))
                };
                yield return authority;
            }
            connection.Close();
            //throw new NotImplementedException();
        }

        public AUTHORITY FindOne(int id)
        {
            return null;
        }

        public AUTHORITY FindOne(int id,int id2)
        {
            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand("Select * from Authority where authorityno=@authorityno and empno=@empno ");

            cmd.Connection = connection;
            cmd.Parameters.Add(new SqlParameter("@authorityno", id));
            cmd.Parameters.Add(new SqlParameter("@empno", id2));

            connection.Open();

            IDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleResult);

            reader.Read();
            AUTHORITY authority = new AUTHORITY()
            {
                authorityno = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("authorityno"))),
                empno = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("empno")))
            };
            connection.Close();
            return authority;
        }

        public void Create(AUTHORITY Item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Insert into Authority (");
            sb.Append("");
            sb.Append("authorityno,");
            sb.Append("empno");           
            sb.Append(") values(");
            sb.Append("@authorityno,");
            sb.Append("@empno");          
            sb.Append(")");

            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand(sb.ToString());

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@authorityno", Item.authorityno));
            cmd.Parameters.Add(new SqlParameter("@empno", Item.empno));           

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

        public void Update(AUTHORITY Item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update Authority Set ");
            sb.Append("authorityno=@authorityno, ");
            sb.Append("empno=@empno ");
            sb.Append("Where authorityno=@authorityno1 and empno=@empno1 ");

            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand(sb.ToString());

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@authorityno", Item.authorityno));
            cmd.Parameters.Add(new SqlParameter("@authorityno1", Item.authorityno));
            cmd.Parameters.Add(new SqlParameter("@empno", Item.empno));
            cmd.Parameters.Add(new SqlParameter("@empno1", Item.empno));

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

        public void Delete(AUTHORITY Item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete from Authority ");
            sb.Append("Where authorityno=@authorityno and empno=@empno ");

            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand(sb.ToString());

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@authorityno", Item.authorityno));
            cmd.Parameters.Add(new SqlParameter("@empno", Item.empno));

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