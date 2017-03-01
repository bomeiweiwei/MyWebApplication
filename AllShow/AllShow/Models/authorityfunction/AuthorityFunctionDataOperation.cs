﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Configuration;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace AllShow.Models.authorityfunction
{
    public class AuthorityFunctionDataOperation : IDataOperation<AuthorityFunction>
    {
        //private string connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private string connectionString = WebConfigurationManager.ConnectionStrings["AllShowConnectionString"].ConnectionString;
        public IEnumerable<AuthorityFunction> Get()
        {
            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand("Select * from AUTHORITYFUNCTION ");

            cmd.Connection = connection;
            connection.Open();

            IDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleResult);

            while (reader.Read())
            {
                AuthorityFunction authorityfunction = new AuthorityFunction()
                {
                    authorityno = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("authorityno"))),
                    authorityname = reader.GetValue(reader.GetOrdinal("authorityname")).ToString()
                };
                yield return authorityfunction;
            }
            connection.Close();
            //throw new NotImplementedException();
        }

        public AuthorityFunction FindOne(int id)
        {
            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand("Select * from AUTHORITYFUNCTION where authorityno=@authorityno ");

            cmd.Connection = connection;
            cmd.Parameters.Add(new SqlParameter("@authorityno", id));

            connection.Open();

            IDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleResult);

            reader.Read();
            AuthorityFunction authorityfunction = new AuthorityFunction()
            {
                authorityno = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("authorityno"))),
                authorityname = reader.GetValue(reader.GetOrdinal("authorityname")).ToString(),
            };
            connection.Close();
            return authorityfunction;
        }

        public void Create(AuthorityFunction Item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Insert into AUTHORITYFUNCTION ( ");
            sb.Append("authorityname ");
            sb.Append(") values( ");
            sb.Append("@authorityname ");
            sb.Append(") ");

            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand(sb.ToString());

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@authorityname", Item.authorityname));

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

        public void Update(AuthorityFunction Item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update AUTHORITYFUNCTION Set ");
            sb.Append("authorityname=@authorityname ");
            sb.Append("Where authorityno=@authorityno ");

            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand(sb.ToString());

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@authorityno", Item.authorityno));
            cmd.Parameters.Add(new SqlParameter("@authorityname", Item.authorityname));

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
        public void Delete(AuthorityFunction Item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete from AUTHORITYFUNCTION ");
            sb.Append("Where authorityno=@authorityno ");

            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand(sb.ToString());

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@authorityno", Item.authorityno));

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