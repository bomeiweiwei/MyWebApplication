using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Configuration;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace AllShow_WebSite.Models.announcement
{
    public class AnnouncementDataOperation : IDataOperation<Announcement>
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["AllShowConnectionString"].ConnectionString;
        public IEnumerable<Announcement> Get()
        {
            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand("Select * from ANNOUNCEMENT");

            cmd.Connection = connection;
            connection.Open();

            IDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleResult);

            while (reader.Read())
            {
                Announcement announcement = new Announcement()
                {
                    announcementno = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("announcementno"))),
                    empno = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("empno"))),
                    announcementtitle = reader.GetValue(reader.GetOrdinal("announcementtitle")).ToString(),
                    announcementtype = reader.GetValue(reader.GetOrdinal("announcementtype")).ToString(),
                    announcementcontent = reader.GetValue(reader.GetOrdinal("announcementcontent")).ToString(),
                    createdate = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("createdate"))),
                    updatedate = (reader.IsDBNull(reader.GetOrdinal("updatedate"))) ? new Nullable<DateTime>() : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("updatedate"))),
                    startdate = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("startdate"))),
                    enddate = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("enddate"))),
                };
                yield return announcement;
            }
            connection.Close();
            //throw new NotImplementedException();
        }

        public Announcement FindOne(int id)
        {
            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand("Select * from ANNOUNCEMENT where announcementno=@announcementno");

            cmd.Connection = connection;
            cmd.Parameters.Add(new SqlParameter("@announcementno", id));

            connection.Open();

            IDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleResult);

            reader.Read();
            Announcement announcement = new Announcement()
            {
                announcementno = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("announcementno"))),
                empno = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("empno"))),
                announcementtitle = reader.GetValue(reader.GetOrdinal("announcementtitle")).ToString(),
                announcementtype = reader.GetValue(reader.GetOrdinal("announcementtype")).ToString(),
                announcementcontent = reader.GetValue(reader.GetOrdinal("announcementcontent")).ToString(),
                createdate = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("createdate"))),
                updatedate = (reader.IsDBNull(reader.GetOrdinal("updatedate"))) ? new Nullable<DateTime>() : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("updatedate"))),
                startdate = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("startdate"))),
                enddate = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("enddate"))),
            };
            connection.Close();
            return announcement;
        }

        public void Create(Announcement Item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Insert into ANNOUNCEMENT ( ");
            sb.Append(" ");
            sb.Append("empno, ");
            sb.Append("announcementtitle, ");
            sb.Append("announcementtype, ");
            sb.Append("announcementcontent, ");
            sb.Append("createdate, ");
            sb.Append("startdate, ");
            sb.Append("enddate ");
            sb.Append(") values( ");
            sb.Append("@empno, ");
            sb.Append("@announcementtitle, ");
            sb.Append("@announcementtype, ");
            sb.Append("@announcementcontent, ");
            sb.Append("@createdate, ");
            sb.Append("@startdate, ");
            sb.Append("@enddate ");
            sb.Append(") ");

            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand(sb.ToString());

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@empno", Item.empno));
            cmd.Parameters.Add(new SqlParameter("@announcementtitle", Item.announcementtitle));
            cmd.Parameters.Add(new SqlParameter("@announcementtype", Item.announcementtype));
            cmd.Parameters.Add(new SqlParameter("@announcementcontent", Item.announcementcontent));
            cmd.Parameters.Add(new SqlParameter("@createdate", Item.createdate));
            cmd.Parameters.Add(new SqlParameter("@startdate", Item.startdate));
            cmd.Parameters.Add(new SqlParameter("@enddate", Item.enddate));

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

        public void Update(Announcement Item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update ANNOUNCEMENT Set ");
            sb.Append("empno=@empno, ");
            sb.Append("announcementtitle=@announcementtitle, ");
            sb.Append("announcementtype=@announcementtype, ");
            sb.Append("announcementcontent=@announcementcontent, ");
            sb.Append("createdate=@createdate, ");
            sb.Append("startdate=@startdate, ");
            sb.Append("enddate=@enddate ");
            sb.Append("Where announcementno=@announcementno ");

            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand(sb.ToString());

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@announcementno", Item.announcementno));
            cmd.Parameters.Add(new SqlParameter("@empno", Item.empno));
            cmd.Parameters.Add(new SqlParameter("@announcementtitle", Item.announcementtitle));
            cmd.Parameters.Add(new SqlParameter("@announcementtype", Item.announcementtype));
            cmd.Parameters.Add(new SqlParameter("@announcementcontent", Item.announcementcontent));
            cmd.Parameters.Add(new SqlParameter("@createdate", Item.createdate));
            cmd.Parameters.Add(new SqlParameter("@startdate", Item.startdate));
            cmd.Parameters.Add(new SqlParameter("@enddate", Item.enddate));

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

        public void Delete(Announcement Item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete from ANNOUNCEMENT ");
            sb.Append("Where announcementno=@announcementno ");

            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand(sb.ToString());

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@announcementno", Item.announcementno));

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