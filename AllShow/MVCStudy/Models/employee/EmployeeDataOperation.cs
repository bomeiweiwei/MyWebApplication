using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Configuration;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace MVCStudy.Models.employee
{
    public class EmployeeDataOperation : IDataOperation<EMPLOYEE>
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["AllShowConnectionString"].ConnectionString;
        public IEnumerable<EMPLOYEE> Get()
        {
            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand("Select * from EMPLOYEE");

            cmd.Connection = connection;
            connection.Open();

            IDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleResult);

            while (reader.Read())
            {
                EMPLOYEE employee = new EMPLOYEE()
                {
                    empno = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("empno"))),
                    empname = reader.GetValue(reader.GetOrdinal("empname")).ToString(),
                    empaccount = reader.GetValue(reader.GetOrdinal("empaccount")).ToString(),
                    emppwd = reader.GetValue(reader.GetOrdinal("emppwd")).ToString(),
                    EMPEMAIL = reader.GetValue(reader.GetOrdinal("EMPEMAIL")).ToString(),
                    empsex = reader.GetValue(reader.GetOrdinal("empsex")).ToString(),
                    emptel = reader.GetValue(reader.GetOrdinal("emptel")).ToString(),
                    empaccountstate = reader.GetValue(reader.GetOrdinal("empaccountstate")).ToString(),
                    empbirth = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("empbirth"))),
                    hiredate = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("hiredate"))),
                    leavedate = (reader.IsDBNull(reader.GetOrdinal("leavedate"))) ? new Nullable<DateTime>() : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("leavedate")))
                };
                yield return employee;
            }
            connection.Close();
            //throw new NotImplementedException();
        }

        public EMPLOYEE FindOne(int id)
        {
            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand("Select * from EMPLOYEE where empno=@empno");

            cmd.Connection = connection;
            cmd.Parameters.Add(new SqlParameter("@empno", id));

            connection.Open();

            IDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleResult);

            reader.Read();
            EMPLOYEE employee = new EMPLOYEE()
            {
                empno = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("empno"))),
                empname = reader.GetValue(reader.GetOrdinal("empname")).ToString(),
                empaccount = reader.GetValue(reader.GetOrdinal("empaccount")).ToString(),
                emppwd = reader.GetValue(reader.GetOrdinal("emppwd")).ToString(),
                EMPEMAIL = reader.GetValue(reader.GetOrdinal("EMPEMAIL")).ToString(),
                empsex = reader.GetValue(reader.GetOrdinal("empsex")).ToString(),
                emptel = reader.GetValue(reader.GetOrdinal("emptel")).ToString(),
                empaccountstate = reader.GetValue(reader.GetOrdinal("empaccountstate")).ToString(),
                empbirth = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("empbirth"))),
                hiredate = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("hiredate"))),
                leavedate = (reader.IsDBNull(reader.GetOrdinal("leavedate"))) ? new Nullable<DateTime>() : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("leavedate")))
            };
            connection.Close();
            return employee;
        }

        public void Create(EMPLOYEE Item)
        {
            Item.empaccountstate = "1";//Default 1
            StringBuilder sb = new StringBuilder();
            sb.Append("Insert into EMPLOYEE (");
            sb.Append("");
            sb.Append("empname,");
            sb.Append("empaccount,");
            sb.Append("emppwd,");
            sb.Append("EMPEMAIL,");
            sb.Append("empsex,");
            sb.Append("empbirth,");
            sb.Append("emptel,");
            sb.Append("hiredate,");
            sb.Append("leavedate,");
            sb.Append("empaccountstate");
            sb.Append(") values(");
            sb.Append("@empname,");
            sb.Append("@empaccount,");
            sb.Append("@emppwd,");
            sb.Append("@EMPEMAIL,");
            sb.Append("@empsex,");
            sb.Append("@empbirth,");
            sb.Append("@emptel,");
            sb.Append("@hiredate,");
            sb.Append("@empaccountstate");
            sb.Append(")");

            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand(sb.ToString());

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@empname", Item.empname));
            cmd.Parameters.Add(new SqlParameter("@empaccount", Item.empaccount));
            cmd.Parameters.Add(new SqlParameter("@emppwd", Item.emppwd));
            cmd.Parameters.Add(new SqlParameter("@EMPEMAIL", Item.EMPEMAIL));
            cmd.Parameters.Add(new SqlParameter("@empsex", Item.empsex));
            cmd.Parameters.Add(new SqlParameter("@empbirth", Item.empbirth));
            cmd.Parameters.Add(new SqlParameter("@emptel", Item.emptel));
            cmd.Parameters.Add(new SqlParameter("@hiredate", Item.hiredate));
            cmd.Parameters.Add(new SqlParameter("@empaccountstate", Item.empaccountstate));

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

        public void Update(EMPLOYEE Item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update EMPLOYEE Set ");
            sb.Append("empname=@empname, ");
            sb.Append("empaccount=@empaccount, ");
            sb.Append("emppwd=@emppwd, ");
            sb.Append("EMPEMAIL=@EMPEMAIL, ");
            sb.Append("empsex=@empsex, ");
            sb.Append("empbirth=@empbirth, ");
            sb.Append("emptel=@emptel, ");
            sb.Append("hiredate=@hiredate, ");
            sb.Append("leavedate=@leavedate, ");
            sb.Append("empaccountstate=@empaccountstate ");
            sb.Append("Where empno=@empno");

            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand(sb.ToString());

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@empno", Item.empno));
            cmd.Parameters.Add(new SqlParameter("@empname", Item.empname));
            cmd.Parameters.Add(new SqlParameter("@empaccount", Item.empaccount));
            cmd.Parameters.Add(new SqlParameter("@emppwd", Item.emppwd));
            cmd.Parameters.Add(new SqlParameter("@EMPEMAIL", Item.EMPEMAIL));
            cmd.Parameters.Add(new SqlParameter("@empsex", Item.empsex));
            cmd.Parameters.Add(new SqlParameter("@empbirth", Item.empbirth));
            cmd.Parameters.Add(new SqlParameter("@emptel", Item.emptel));
            cmd.Parameters.Add(new SqlParameter("@hiredate", Item.hiredate));
            cmd.Parameters.Add(new SqlParameter("@leavedate", Item.leavedate));
            cmd.Parameters.Add(new SqlParameter("@empaccountstate", Item.empaccountstate));

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

        public void Delete(EMPLOYEE Item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete from EMPLOYEE ");
            sb.Append("Where empno=@empno ");

            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand(sb.ToString());

            cmd.Connection = connection;

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