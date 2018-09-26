using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Configuration;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace AllShow_WebSite.Models.member
{
    public class MemberDataOperation : IDataOperation<Member>
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["AllShowConnectionString"].ConnectionString;
        public IEnumerable<Member> Get()
        {
            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand("Select * from MEMBER ");

            cmd.Connection = connection;
            connection.Open();

            IDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleResult);

            while (reader.Read())
            {
                Member member = new Member()
                {
                    memno = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("memno"))),
                    mememail = reader.GetValue(reader.GetOrdinal("mememail")).ToString(),
                    mempwd = reader.GetValue(reader.GetOrdinal("mempwd")).ToString(),
                    memdiminutive = reader.GetValue(reader.GetOrdinal("memdiminutive")).ToString(),
                    memname = reader.GetValue(reader.GetOrdinal("memname")).ToString(),
                    memsex = reader.GetValue(reader.GetOrdinal("memsex")).ToString(),
                    memtel = reader.GetValue(reader.GetOrdinal("memtel")).ToString(),
                    memaddress = reader.GetValue(reader.GetOrdinal("memaddress")).ToString(),
                    mempic = reader.GetValue(reader.GetOrdinal("mempic")).ToString(),
                    memaccountstate = reader.GetValue(reader.GetOrdinal("memaccountstate")).ToString(),
                    memchecknumber = reader.GetValue(reader.GetOrdinal("memchecknumber")).ToString(),
                    memcreatedate = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("memcreatedate"))),
                    memupdatedate = (reader.IsDBNull(reader.GetOrdinal("memupdatedate"))) ? new Nullable<DateTime>() : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("memupdatedate"))),
                    membirth = (reader.IsDBNull(reader.GetOrdinal("membirth"))) ? new Nullable<DateTime>() : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("membirth"))),
                    memguid= reader.GetValue(reader.GetOrdinal("memguid")).ToString()
                };
                yield return member;
            }
            connection.Close();
            //throw new NotImplementedException();
        }

        public Member FindOne(int id)
        {
            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand("Select * from MEMBER where memno=@memno");

            cmd.Connection = connection;
            cmd.Parameters.Add(new SqlParameter("@memno", id));

            connection.Open();

            IDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleResult);

            reader.Read();
            Member member = new Member()
            {
                memno = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("memno"))),
                mememail = reader.GetValue(reader.GetOrdinal("mememail")).ToString(),
                mempwd = reader.GetValue(reader.GetOrdinal("mempwd")).ToString(),
                memdiminutive = reader.GetValue(reader.GetOrdinal("memdiminutive")).ToString(),
                memname = reader.GetValue(reader.GetOrdinal("memname")).ToString(),
                memsex = reader.GetValue(reader.GetOrdinal("memsex")).ToString(),
                memtel = reader.GetValue(reader.GetOrdinal("memtel")).ToString(),
                memaddress = reader.GetValue(reader.GetOrdinal("memaddress")).ToString(),
                mempic = reader.GetValue(reader.GetOrdinal("mempic")).ToString(),
                memaccountstate = reader.GetValue(reader.GetOrdinal("memaccountstate")).ToString(),
                memchecknumber = reader.GetValue(reader.GetOrdinal("memchecknumber")).ToString(),
                memcreatedate = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("memcreatedate"))),
                memupdatedate = (reader.IsDBNull(reader.GetOrdinal("memupdatedate"))) ? new Nullable<DateTime>() : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("memupdatedate"))),
                membirth = (reader.IsDBNull(reader.GetOrdinal("membirth"))) ? new Nullable<DateTime>() : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("membirth"))),
                memguid = reader.GetValue(reader.GetOrdinal("memguid")).ToString()
            };
            connection.Close();
            return member;
        }

        public void Create(Member Item)
        {
            Item.memsex = "0";//Default 0
            Item.memaccountstate = "0";//Default 0
            StringBuilder sb = new StringBuilder();
            sb.Append("Insert into MEMBER (");
            sb.Append("");
            sb.Append("mememail,");
            sb.Append("mempwd,");
            //sb.Append("memdiminutive,");
            sb.Append("memname,");
            sb.Append("memsex,");
            sb.Append("memtel,");
            sb.Append("memaddress,");
            //sb.Append("mempic,");
            sb.Append("memaccountstate,");
            sb.Append("memchecknumber,");
            sb.Append("memcreatedate,");
            //sb.Append("memupdatedate,");
            //sb.Append("membirth,");
            sb.Append("memguid");
            sb.Append(") values(");
            sb.Append("@mememail,");
            sb.Append("@mempwd,");
            //sb.Append("@memdiminutive,");
            sb.Append("@memname,");
            sb.Append("@memsex,");
            sb.Append("@memtel,");
            sb.Append("@memaddress,");
            //sb.Append("@mempic,");
            sb.Append("@memaccountstate,");
            sb.Append("@memchecknumber,");
            sb.Append("@memcreatedate,");
            //sb.Append("@memupdatedate,");
            //sb.Append("@membirth,");
            sb.Append("@memguid");
            sb.Append(")");

            Guid userGuid = System.Guid.NewGuid();
            if (!Get().Where(m => m.memguid == userGuid.ToString()).Any())
            {
                byte[] dataAndGuid = ASCIIEncoding.ASCII.GetBytes(Item.mempwd + userGuid.ToString());
                SHA512 sha512 = new SHA512CryptoServiceProvider();
                string resultSha512 = Convert.ToBase64String(sha512.ComputeHash(dataAndGuid));

                IDbConnection connection = new SqlConnection(this.connectionString);
                IDbCommand cmd = new SqlCommand(sb.ToString());

                cmd.Connection = connection;

                cmd.Parameters.Add(new SqlParameter("@mememail", Item.mememail));
                cmd.Parameters.Add(new SqlParameter("@mempwd", resultSha512));
                //cmd.Parameters.Add(new SqlParameter("@memdiminutive", Item.memdiminutive == null ? (object)DBNull.Value : Item.memdiminutive));
                cmd.Parameters.Add(new SqlParameter("@memname", Item.memname));
                cmd.Parameters.Add(new SqlParameter("@memsex", Item.memsex));
                cmd.Parameters.Add(new SqlParameter("@memtel", Item.memtel == null ? "09-" : Item.memtel));
                cmd.Parameters.Add(new SqlParameter("@memaddress", Item.memaddress == null ? "Taiwan" : Item.memaddress));
                //cmd.Parameters.Add(new SqlParameter("@mempic", Item.mempic == null ? (object)DBNull.Value : Item.mempic));
                cmd.Parameters.Add(new SqlParameter("@memaccountstate", Item.memaccountstate));
                cmd.Parameters.Add(new SqlParameter("@memchecknumber", Item.memchecknumber == null ? "6666" : Item.memchecknumber));
                cmd.Parameters.Add(new SqlParameter("@memcreatedate", DateTime.Now));
                //cmd.Parameters.Add(new SqlParameter("@memupdatedate", Item.memupdatedate));
                //cmd.Parameters.Add(new SqlParameter("@membirth", Item.membirth));
                cmd.Parameters.Add(new SqlParameter("@memguid", userGuid.ToString()));

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
                finally
                {
                    connection.Close();
                }
            }
            //throw new NotImplementedException();
        }

        public void Update(Member Item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update MEMBER Set ");
            sb.Append("mememail=@mememail,");
            sb.Append("mempwd=@mempwd,");
            sb.Append("memdiminutive=@memdiminutive,");
            sb.Append("memname=@memname,");
            sb.Append("memsex=@memsex,");
            sb.Append("memtel=@memtel,");
            sb.Append("memaddress=@memaddress,");
            sb.Append("mempic=@mempic,");
            sb.Append("memaccountstate=@memaccountstate,");
            sb.Append("memchecknumber=@memchecknumber,");
            sb.Append("memcreatedate=@memcreatedate,");
            sb.Append("memupdatedate=@memupdatedate,");
            sb.Append("membirth=@membirth,");
            sb.Append("memguid=@memguid ");
            sb.Append("Where memno=@memno");

            byte[] dataAndGuid = ASCIIEncoding.ASCII.GetBytes(Item.mempwd + Item.memguid.ToString());
            SHA512 sha512 = new SHA512CryptoServiceProvider();
            string resultSha512 = Convert.ToBase64String(sha512.ComputeHash(dataAndGuid));

            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand(sb.ToString());

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@memno", Item.memno));
            cmd.Parameters.Add(new SqlParameter("@mememail", Item.mememail));
            cmd.Parameters.Add(new SqlParameter("@mempwd", resultSha512));
            cmd.Parameters.Add(new SqlParameter("@memdiminutive", (object)Item.memdiminutive ?? DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@memname", Item.memname));
            cmd.Parameters.Add(new SqlParameter("@memsex", Item.memsex));
            cmd.Parameters.Add(new SqlParameter("@memtel", Item.memtel));
            cmd.Parameters.Add(new SqlParameter("@memaddress", Item.memaddress));
            cmd.Parameters.Add(new SqlParameter("@mempic", (object)Item.mempic ?? DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@memaccountstate", Item.memaccountstate));
            cmd.Parameters.Add(new SqlParameter("@memchecknumber", Item.memchecknumber));
            cmd.Parameters.Add(new SqlParameter("@memcreatedate", Item.memcreatedate));
            cmd.Parameters.Add(new SqlParameter("@memupdatedate", DateTime.Now));
            cmd.Parameters.Add(new SqlParameter("@membirth", (object)Item.membirth ?? DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@memguid", Item.memguid));

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            finally
            {
                connection.Close();
            }

            //throw new NotImplementedException();
        }

        public void Delete(Member Item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete from MEMBER ");
            sb.Append("Where memno=@memno ");

            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand(sb.ToString());

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@memno", Item.memno));

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