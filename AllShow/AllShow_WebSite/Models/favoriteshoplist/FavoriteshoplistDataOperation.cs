using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Configuration;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace AllShow_WebSite.Models.favoriteshoplist
{
    public class FavoriteshoplistDataOperation : IDataOperation<Favoriteshoplist>
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["AllShowConnectionString"].ConnectionString;
        public IEnumerable<Favoriteshoplist> Get()
        {
            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand("Select * from Favoriteshoplist");

            cmd.Connection = connection;
            connection.Open();

            IDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleResult);

            while (reader.Read())
            {
                Favoriteshoplist favoriteshoplist = new Favoriteshoplist()
                {
                    memNo = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("memNo"))),
                    shNo = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("shNo")))
                };
                yield return favoriteshoplist;
            }
            connection.Close();
            //throw new NotImplementedException();
        }

        public Favoriteshoplist FindOne(int id)
        {
            return null;
        }

        public Favoriteshoplist FindOne(int id, int id2)
        {
            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand("Select * from Favoriteshoplist where memNo=@memNo and shNo=@shNo ");

            cmd.Connection = connection;
            cmd.Parameters.Add(new SqlParameter("@memNo", id));
            cmd.Parameters.Add(new SqlParameter("@shNo", id2));

            connection.Open();

            IDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleResult);

            reader.Read();
            Favoriteshoplist favoriteshoplist = new Favoriteshoplist()
            {
                memNo = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("memNo"))),
                shNo = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("shNo")))
            };
            connection.Close();
            return favoriteshoplist;
        }

        public void Create(Favoriteshoplist Item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Insert into Favoriteshoplist ( ");
            sb.Append(" ");
            sb.Append("memNo, ");
            sb.Append("shNo ");
            sb.Append(") values( ");
            sb.Append("@memNo, ");
            sb.Append("@shNo ");
            sb.Append(") ");

            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand(sb.ToString());

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@memNo", Item.memNo));
            cmd.Parameters.Add(new SqlParameter("@shNo", Item.shNo));

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

        public void Update(Favoriteshoplist Item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update Favoriteshoplist Set ");
            sb.Append("memNo=@memNo, ");
            sb.Append("shNo=@shNo ");
            sb.Append("where memNo=@memNo1 and shNo=@shNo1 ");

            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand(sb.ToString());

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@memNo", Item.memNo));
            cmd.Parameters.Add(new SqlParameter("@memNo1", Item.memNo));
            cmd.Parameters.Add(new SqlParameter("@shNo", Item.shNo));
            cmd.Parameters.Add(new SqlParameter("@shNo1", Item.shNo));

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

        public void Delete(Favoriteshoplist Item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete from Favoriteshoplist ");
            sb.Append("where memNo=@memNo and shNo=@shNo ");

            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand(sb.ToString());

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@memNo", Item.memNo));
            cmd.Parameters.Add(new SqlParameter("@shNo", Item.shNo));

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