using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Configuration;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace AllShow_WebSite.Models.advertisement
{
    public class AdvertisementDataOperation:IDataOperation<Advertisement>
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["AllShowConnectionString"].ConnectionString;
        public IEnumerable<Advertisement> Get()
        {
            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand("Select * from ADVERTISEMENT");

            cmd.Connection = connection;
            connection.Open();

            IDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleResult);

            while (reader.Read())
            {
                Advertisement advertisement = new Advertisement()
                {
                    adNo = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("adNo"))),
                    shNo = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("shNo"))),
                    empNo = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("empNo"))),
                    adTitle = reader.GetValue(reader.GetOrdinal("adTitle")).ToString(),
                    adApplyDate = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("adApplyDate"))),
                    adStartDate = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("adStartDate"))),
                    adTime = Convert.ToDouble(reader.GetValue(reader.GetOrdinal("adTime"))),
                    adPrice = Convert.ToDouble(reader.GetValue(reader.GetOrdinal("adPrice"))),
                    adPic = reader.GetValue(reader.GetOrdinal("adPic")).ToString(),
                    adURL = reader.GetValue(reader.GetOrdinal("adURL")).ToString(),
                    adCheckState = reader.GetValue(reader.GetOrdinal("adCheckState")).ToString()
                };
                yield return advertisement;
            }
            connection.Close();
            //throw new NotImplementedException();
        }

        public Advertisement FindOne(int id)
        {
            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand("Select * from ADVERTISEMENT where adNo=@adNo");

            cmd.Connection = connection;
            cmd.Parameters.Add(new SqlParameter("@adNo", id));

            connection.Open();

            IDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleResult);

            reader.Read();
            Advertisement advertisement = new Advertisement()
            {
                adNo = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("adNo"))),
                shNo = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("shNo"))),
                empNo = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("empNo"))),
                adTitle = reader.GetValue(reader.GetOrdinal("adTitle")).ToString(),
                adApplyDate = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("adApplyDate"))),
                adStartDate = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("adStartDate"))),
                adTime = Convert.ToDouble(reader.GetValue(reader.GetOrdinal("adTime"))),
                adPrice = Convert.ToDouble(reader.GetValue(reader.GetOrdinal("adPrice"))),
                adPic = reader.GetValue(reader.GetOrdinal("adPic")).ToString(),
                adURL = reader.GetValue(reader.GetOrdinal("adURL")).ToString(),
                adCheckState = reader.GetValue(reader.GetOrdinal("adCheckState")).ToString()
            };
            connection.Close();
            return advertisement;
        }

        public void Create(Advertisement Item)
        {
            Item.adCheckState = "0";//Default 0
            StringBuilder sb = new StringBuilder();
            sb.Append("Insert into ADVERTISEMENT (");
            sb.Append("");
            sb.Append("shNo,");
            sb.Append("empNo,");
            sb.Append("adTitle,");
            sb.Append("adApplyDate,");
            sb.Append("adStartDate,");
            sb.Append("adTime,");
            sb.Append("adPrice,");
            sb.Append("adPic,");
            sb.Append("adURL,");
            sb.Append("adCheckState");
            sb.Append(") values(");
            sb.Append("@shNo,");
            sb.Append("@empNo,");
            sb.Append("@adTitle,");
            sb.Append("@adApplyDate,");
            sb.Append("@adStartDate,");
            sb.Append("@adTime,");
            sb.Append("@adPrice,");
            sb.Append("@adPic,");
            sb.Append("@adURL,");
            sb.Append("@adCheckState");
            sb.Append(")");

            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand(sb.ToString());

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@shNo", Item.shNo));
            cmd.Parameters.Add(new SqlParameter("@empNo", Item.empNo));
            cmd.Parameters.Add(new SqlParameter("@adTitle", Item.adTitle));
            cmd.Parameters.Add(new SqlParameter("@adApplyDate", Item.adApplyDate));
            cmd.Parameters.Add(new SqlParameter("@adStartDate", Item.adStartDate));
            cmd.Parameters.Add(new SqlParameter("@adTime", Item.adTime));
            cmd.Parameters.Add(new SqlParameter("@adPrice", Item.adPrice));
            cmd.Parameters.Add(new SqlParameter("@adPic", Item.adPic));
            cmd.Parameters.Add(new SqlParameter("@adURL", Item.adURL));
            cmd.Parameters.Add(new SqlParameter("@adCheckState", Item.adCheckState));

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

        public void Update(Advertisement Item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update ADVERTISEMENT Set ");
            sb.Append("shNo=@shNo, ");
            sb.Append("empNo=@empNo, ");
            sb.Append("adTitle=@adTitle, ");
            sb.Append("adApplyDate=@adApplyDate, ");
            sb.Append("adStartDate=@adStartDate, ");
            sb.Append("adTime=@adTime, ");
            sb.Append("adPrice=@adPrice, ");
            sb.Append("adPic=@adPic, ");
            sb.Append("adURL=@adURL, ");
            sb.Append("adCheckState=@adCheckState ");
            sb.Append("Where adNo=@adNo ");

            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand(sb.ToString());

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@adNo", Item.adNo));
            cmd.Parameters.Add(new SqlParameter("@shNo", Item.shNo));
            cmd.Parameters.Add(new SqlParameter("@empNo", Item.empNo));
            cmd.Parameters.Add(new SqlParameter("@adTitle", Item.adTitle));
            cmd.Parameters.Add(new SqlParameter("@adApplyDate", Item.adApplyDate));
            cmd.Parameters.Add(new SqlParameter("@adStartDate", Item.adStartDate));
            cmd.Parameters.Add(new SqlParameter("@adTime", Item.adTime));
            cmd.Parameters.Add(new SqlParameter("@adPrice", Item.adPrice));
            cmd.Parameters.Add(new SqlParameter("@adPic", Item.adPic));
            cmd.Parameters.Add(new SqlParameter("@adURL", Item.adURL));
            cmd.Parameters.Add(new SqlParameter("@adCheckState", Item.adCheckState));

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

        public void Delete(Advertisement Item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete from ADVERTISEMENT ");
            sb.Append("Where adNo=@adNo ");

            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand(sb.ToString());

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@adNo", Item.adNo));

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