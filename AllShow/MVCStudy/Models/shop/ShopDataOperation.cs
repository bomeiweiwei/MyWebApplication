using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Configuration;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace MVCStudy.Models.shop
{
    public class ShopDataOperation : IDataOperation<SHOP>
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["AllShowConnectionString"].ConnectionString;
        public IEnumerable<SHOP> Get()
        {
            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand("Select * from SHOP");

            cmd.Connection = connection;
            connection.Open();

            IDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleResult);

            while (reader.Read())
            {
                SHOP shop = new SHOP()
                {
                    shno = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("shno"))),
                    empno = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("empno"))),
                    shthepic = reader.GetValue(reader.GetOrdinal("shthepic")).ToString(),
                    shname = reader.GetValue(reader.GetOrdinal("shname")).ToString(),
                    shclassno = (reader.IsDBNull(reader.GetOrdinal("shclassno"))) ? new Nullable<int>() : Convert.ToInt32(reader.GetValue(reader.GetOrdinal("shclassno"))),
                    shaccount = reader.GetValue(reader.GetOrdinal("shaccount")).ToString(),
                    shpwd = reader.GetValue(reader.GetOrdinal("shpwd")).ToString(),
                    shboss = reader.GetValue(reader.GetOrdinal("shboss")).ToString(),
                    shcontact = reader.GetValue(reader.GetOrdinal("shcontact")).ToString(),
                    shaddress = reader.GetValue(reader.GetOrdinal("shaddress")).ToString(),
                    shtel = reader.GetValue(reader.GetOrdinal("shtel")).ToString(),
                    shemail = reader.GetValue(reader.GetOrdinal("shemail")).ToString(),
                    shabout = reader.GetValue(reader.GetOrdinal("shabout")).ToString(),
                    shlogopic = reader.GetValue(reader.GetOrdinal("shlogopic")).ToString(),
                    shurl = reader.GetValue(reader.GetOrdinal("shurl")).ToString(),
                    shadstate = reader.GetValue(reader.GetOrdinal("shadstate")).ToString(),
                    shadtitle = reader.GetValue(reader.GetOrdinal("shadtitle")).ToString(),
                    shadpic = reader.GetValue(reader.GetOrdinal("shadpic")).ToString(),
                    shpopshop = reader.GetValue(reader.GetOrdinal("shpopshop")).ToString(),
                    shcheckstate = reader.GetValue(reader.GetOrdinal("shcheckstate")).ToString(),
                    shstartdate = (reader.IsDBNull(reader.GetOrdinal("shstartdate"))) ? new Nullable<DateTime>() : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("shstartdate"))),
                    shenddate = (reader.IsDBNull(reader.GetOrdinal("shenddate"))) ? new Nullable<DateTime>() : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("shenddate"))),
                    shcheckdate = (reader.IsDBNull(reader.GetOrdinal("shcheckdate"))) ? new Nullable<DateTime>() : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("shcheckdate"))),
                    shpwdstate = reader.GetValue(reader.GetOrdinal("shpwdstate")).ToString(),
                    shstoprightstartdate = (reader.IsDBNull(reader.GetOrdinal("shstoprightstartdate"))) ? new Nullable<DateTime>() : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("shstoprightstartdate"))),
                    shstoprightenddate = (reader.IsDBNull(reader.GetOrdinal("shstoprightenddate"))) ? new Nullable<DateTime>() : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("shstoprightenddate")))
                };
                yield return shop;
            }
            connection.Close();
            //throw nNotImplementedExceptionew ();
        }

        public SHOP FindOne(int id)
        {
            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand("Select * from SHOP where shno=@shno");

            cmd.Connection = connection;
            cmd.Parameters.Add(new SqlParameter("@shno", id));

            connection.Open();

            IDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleResult);

            reader.Read();
            SHOP shop = new SHOP()
            {
                shno = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("shno"))),
                empno = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("empno"))),
                shthepic = reader.GetValue(reader.GetOrdinal("shthepic")).ToString(),
                shname = reader.GetValue(reader.GetOrdinal("shname")).ToString(),
                shclassno = (reader.IsDBNull(reader.GetOrdinal("shclassno"))) ? new Nullable<int>() : Convert.ToInt32(reader.GetValue(reader.GetOrdinal("shclassno"))),
                shaccount = reader.GetValue(reader.GetOrdinal("shaccount")).ToString(),
                shpwd = reader.GetValue(reader.GetOrdinal("shpwd")).ToString(),
                shboss = reader.GetValue(reader.GetOrdinal("shboss")).ToString(),
                shcontact = reader.GetValue(reader.GetOrdinal("shcontact")).ToString(),
                shaddress = reader.GetValue(reader.GetOrdinal("shaddress")).ToString(),
                shtel = reader.GetValue(reader.GetOrdinal("shtel")).ToString(),
                shemail = reader.GetValue(reader.GetOrdinal("shemail")).ToString(),
                shabout = reader.GetValue(reader.GetOrdinal("shabout")).ToString(),
                shlogopic = reader.GetValue(reader.GetOrdinal("shlogopic")).ToString(),
                shurl = reader.GetValue(reader.GetOrdinal("shurl")).ToString(),
                shadstate = reader.GetValue(reader.GetOrdinal("shadstate")).ToString(),
                shadtitle = reader.GetValue(reader.GetOrdinal("shadtitle")).ToString(),
                shadpic = reader.GetValue(reader.GetOrdinal("shadpic")).ToString(),
                shpopshop = reader.GetValue(reader.GetOrdinal("shpopshop")).ToString(),
                shcheckstate = reader.GetValue(reader.GetOrdinal("shcheckstate")).ToString(),
                shstartdate = (reader.IsDBNull(reader.GetOrdinal("shstartdate"))) ? new Nullable<DateTime>() : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("shstartdate"))),
                shenddate = (reader.IsDBNull(reader.GetOrdinal("shenddate"))) ? new Nullable<DateTime>() : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("shenddate"))),
                shcheckdate = (reader.IsDBNull(reader.GetOrdinal("shcheckdate"))) ? new Nullable<DateTime>() : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("shcheckdate"))),
                shpwdstate = reader.GetValue(reader.GetOrdinal("shpwdstate")).ToString(),
                shstoprightstartdate = (reader.IsDBNull(reader.GetOrdinal("shstoprightstartdate"))) ? new Nullable<DateTime>() : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("shstoprightstartdate"))),
                shstoprightenddate = (reader.IsDBNull(reader.GetOrdinal("shstoprightenddate"))) ? new Nullable<DateTime>() : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("shstoprightenddate")))
            };
            connection.Close();
            return shop;
        }

        public void Create(SHOP Item)
        {
            Item.shadstate = "0";//Default 0
            Item.shpopshop = "0";//Default 0
            Item.shcheckstate = "0";//Default 0
            Item.shpwdstate = "0";//Default 0
            StringBuilder sb = new StringBuilder();
            sb.Append("Insert into SHOP (");
            sb.Append("");
            sb.Append("empno,");
            sb.Append("shthepic,");
            sb.Append("shname,");
            sb.Append("shclassno,");
            sb.Append("shaccount,");
            sb.Append("shpwd,");
            sb.Append("shboss,");
            sb.Append("shcontact,");
            sb.Append("shaddress,");
            sb.Append("shtel,");
            sb.Append("shemail,");
            sb.Append("shabout,");
            sb.Append("shlogopic,");
            sb.Append("shurl,");
            sb.Append("shadstate,");
            sb.Append("shadtitle,");
            sb.Append("shadpic,");
            sb.Append("shpopshop,");
            sb.Append("shcheckstate,");
            sb.Append("shstartdate,");
            sb.Append("shenddate,");
            sb.Append("shcheckdate,");
            sb.Append("shpwdstate,");
            sb.Append("shstoprightstartdate,");
            sb.Append("shstoprightenddate");
            sb.Append(") values(");
            sb.Append("@empno,");
            sb.Append("@shthepic,");
            sb.Append("@shname,");
            sb.Append("@shclassno,");
            sb.Append("@shaccount,");
            sb.Append("@shpwd,");
            sb.Append("@shboss,");
            sb.Append("@shcontact,");
            sb.Append("@shaddress,");
            sb.Append("@shtel,");
            sb.Append("@shemail,");
            sb.Append("@shabout,");
            sb.Append("@shlogopic,");
            sb.Append("@shurl,");
            sb.Append("@shadstate,");
            sb.Append("@shadtitle,");
            sb.Append("@shadpic,");
            sb.Append("@shpopshop,");
            sb.Append("@shcheckstate,");
            sb.Append("@shstartdate,");
            sb.Append("@shenddate,");
            sb.Append("@shcheckdate,");
            sb.Append("@shpwdstate,");
            sb.Append("@shstoprightstartdate,");
            sb.Append("@shstoprightenddate");
            sb.Append(")");

            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand(sb.ToString());

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@empno", Item.empno));
            cmd.Parameters.Add(new SqlParameter("@shthepic", Item.shthepic));
            cmd.Parameters.Add(new SqlParameter("@shname", Item.shname));
            cmd.Parameters.Add(new SqlParameter("@shclassno", Item.shclassno));
            cmd.Parameters.Add(new SqlParameter("@shaccount", Item.shaccount));
            cmd.Parameters.Add(new SqlParameter("@shpwd", Item.shpwd));
            cmd.Parameters.Add(new SqlParameter("@shboss", Item.shboss));
            cmd.Parameters.Add(new SqlParameter("@shcontact", Item.shcontact));
            cmd.Parameters.Add(new SqlParameter("@shaddress", Item.shaddress));
            cmd.Parameters.Add(new SqlParameter("@shtel", Item.shtel));
            cmd.Parameters.Add(new SqlParameter("@shemail", Item.shemail));
            cmd.Parameters.Add(new SqlParameter("@shabout", Item.shabout));
            cmd.Parameters.Add(new SqlParameter("@shlogopic", Item.shlogopic));
            cmd.Parameters.Add(new SqlParameter("@shurl", Item.shurl));
            cmd.Parameters.Add(new SqlParameter("@shadstate", Item.shadstate));
            cmd.Parameters.Add(new SqlParameter("@shadtitle", Item.shadtitle));
            cmd.Parameters.Add(new SqlParameter("@shadpic", Item.shadpic));
            cmd.Parameters.Add(new SqlParameter("@shpopshop", Item.shpopshop));
            cmd.Parameters.Add(new SqlParameter("@shcheckstate", Item.shcheckstate));
            cmd.Parameters.Add(new SqlParameter("@shstartdate", Item.shstartdate));
            cmd.Parameters.Add(new SqlParameter("@shenddate", Item.shenddate));
            cmd.Parameters.Add(new SqlParameter("@shcheckdate", Item.shcheckdate));
            cmd.Parameters.Add(new SqlParameter("@shpwdstate", Item.shpwdstate));
            cmd.Parameters.Add(new SqlParameter("@shstoprightstartdate", Item.shstoprightstartdate));
            cmd.Parameters.Add(new SqlParameter("@shstoprightenddate", Item.shstoprightenddate));

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

        public void Update(SHOP Item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update SHOP Set ");
            sb.Append("empno=@empno,");
            sb.Append("shthepic=@shthepic,");
            sb.Append("shname=@shname,");
            sb.Append("shclassno=@shclassno,");
            sb.Append("shaccount=@shaccount,");
            sb.Append("shpwd=@shpwd,");
            sb.Append("shboss=@shboss,");
            sb.Append("shcontact=@shcontact,");
            sb.Append("shaddress=@shaddress,");
            sb.Append("shtel=@shtel,");
            sb.Append("shemail=@shemail,");
            sb.Append("shabout=@shabout,");
            sb.Append("shlogopic=@shlogopic,");
            sb.Append("shurl=@shurl,");
            sb.Append("shadstate=@shadstate,");
            sb.Append("shadtitle=@shadtitle,");
            sb.Append("shadpic=@shadpic,");
            sb.Append("shpopshop=@shpopshop,");
            sb.Append("shcheckstate=@shcheckstate,");
            sb.Append("shstartdate=@shstartdate,");
            sb.Append("shenddate=@shenddate,");
            sb.Append("shcheckdate=@shcheckdate,");
            sb.Append("shpwdstate=@shpwdstate,");
            sb.Append("shstoprightstartdate=@shstoprightstartdate,");
            sb.Append("shstoprightenddate=@shstoprightenddate");
            sb.Append("Where shno=@shno");

            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand(sb.ToString());

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@shno", Item.shno));
            cmd.Parameters.Add(new SqlParameter("@empno", Item.empno));
            cmd.Parameters.Add(new SqlParameter("@shthepic", Item.shthepic));
            cmd.Parameters.Add(new SqlParameter("@shname", Item.shname));
            cmd.Parameters.Add(new SqlParameter("@shclassno", Item.shclassno));
            cmd.Parameters.Add(new SqlParameter("@shaccount", Item.shaccount));
            cmd.Parameters.Add(new SqlParameter("@shpwd", Item.shpwd));
            cmd.Parameters.Add(new SqlParameter("@shboss", Item.shboss));
            cmd.Parameters.Add(new SqlParameter("@shcontact", Item.shcontact));
            cmd.Parameters.Add(new SqlParameter("@shaddress", Item.shaddress));
            cmd.Parameters.Add(new SqlParameter("@shtel", Item.shtel));
            cmd.Parameters.Add(new SqlParameter("@shemail", Item.shemail));
            cmd.Parameters.Add(new SqlParameter("@shabout", Item.shabout));
            cmd.Parameters.Add(new SqlParameter("@shlogopic", Item.shlogopic));
            cmd.Parameters.Add(new SqlParameter("@shurl", Item.shurl));
            cmd.Parameters.Add(new SqlParameter("@shadstate", Item.shadstate));
            cmd.Parameters.Add(new SqlParameter("@shadtitle", Item.shadtitle));
            cmd.Parameters.Add(new SqlParameter("@shadpic", Item.shadpic));
            cmd.Parameters.Add(new SqlParameter("@shpopshop", Item.shpopshop));
            cmd.Parameters.Add(new SqlParameter("@shcheckstate", Item.shcheckstate));
            cmd.Parameters.Add(new SqlParameter("@shstartdate", Item.shstartdate));
            cmd.Parameters.Add(new SqlParameter("@shenddate", Item.shenddate));
            cmd.Parameters.Add(new SqlParameter("@shcheckdate", Item.shcheckdate));
            cmd.Parameters.Add(new SqlParameter("@shpwdstate", Item.shpwdstate));
            cmd.Parameters.Add(new SqlParameter("@shstoprightstartdate", Item.shstoprightstartdate));
            cmd.Parameters.Add(new SqlParameter("@shstoprightenddate", Item.shstoprightenddate));

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

        public void Delete(SHOP Item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete from SHOP ");
            sb.Append("Where shno=@shno ");

            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand(sb.ToString());

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@shno", Item.shno));

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