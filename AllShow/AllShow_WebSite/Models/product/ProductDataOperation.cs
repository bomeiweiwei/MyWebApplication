using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Configuration;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace AllShow_WebSite.Models.product
{
    public class ProductDataOperation : IDataOperation<Product>
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["AllShowConnectionString"].ConnectionString;
        public IEnumerable<Product> Get()
        {
            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand("Select * from PRODUCT");

            cmd.Connection = connection;
            connection.Open();

            IDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleResult);

            while (reader.Read())
            {
                Product product = new Product()
                {
                    proNo = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("proNo"))),
                    shNo = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("shNo"))),
                    proClassNo = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("proClassNo"))),
                    proName = reader.GetValue(reader.GetOrdinal("proName")).ToString(),
                    proPrice = Convert.ToDouble(reader.GetValue(reader.GetOrdinal("proPrice"))),
                    proStatement = reader.GetValue(reader.GetOrdinal("proStatement")).ToString(),
                    proState = reader.GetValue(reader.GetOrdinal("proState")).ToString(),
                    proPic1 = reader.GetValue(reader.GetOrdinal("proPic1")).ToString(),
                    proPic2 = reader.GetValue(reader.GetOrdinal("proPic2")).ToString(),
                    proPic3 = reader.GetValue(reader.GetOrdinal("proPic3")).ToString(),
                    proCreateDate = (reader.IsDBNull(reader.GetOrdinal("proCreateDate"))) ? new Nullable<DateTime>() : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("proCreateDate"))),
                    proUpdateDate = (reader.IsDBNull(reader.GetOrdinal("proUpdateDate"))) ? new Nullable<DateTime>() : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("proUpdateDate"))),
                    proOffShelfDate = (reader.IsDBNull(reader.GetOrdinal("ProOffShelfDate"))) ? new Nullable<DateTime>() : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("ProOffShelfDate"))),
                    proPop = reader.GetValue(reader.GetOrdinal("proPop")).ToString()
                };
                yield return product;
            }
            connection.Close();
            //throw new NotImplementedException();
        }

        public Product FindOne(int id)
        {
            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand("Select * from PRODUCT where proNo=@proNo");

            cmd.Connection = connection;
            cmd.Parameters.Add(new SqlParameter("@proNo", id));

            connection.Open();

            IDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleResult);

            reader.Read();
            Product product = new Product()
            {
                proNo = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("proNo"))),
                shNo = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("shNo"))),
                proClassNo = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("proClassNo"))),
                proName = reader.GetValue(reader.GetOrdinal("proName")).ToString(),
                proPrice = Convert.ToDouble(reader.GetValue(reader.GetOrdinal("proPrice"))),
                proStatement = reader.GetValue(reader.GetOrdinal("proStatement")).ToString(),
                proState = reader.GetValue(reader.GetOrdinal("proState")).ToString(),
                proPic1 = reader.GetValue(reader.GetOrdinal("proPic1")).ToString(),
                proPic2 = reader.GetValue(reader.GetOrdinal("proPic2")).ToString(),
                proPic3 = reader.GetValue(reader.GetOrdinal("proPic3")).ToString(),
                proCreateDate = (reader.IsDBNull(reader.GetOrdinal("proCreateDate"))) ? new Nullable<DateTime>() : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("proCreateDate"))),
                proUpdateDate = (reader.IsDBNull(reader.GetOrdinal("proUpdateDate"))) ? new Nullable<DateTime>() : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("proUpdateDate"))),
                proOffShelfDate = (reader.IsDBNull(reader.GetOrdinal("ProOffShelfDate"))) ? new Nullable<DateTime>() : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("ProOffShelfDate"))),
                proPop = reader.GetValue(reader.GetOrdinal("proPop")).ToString()
            };
            connection.Close();
            return product;
        }

        public void Create(Product Item)
        {
            Item.proState = "1";//Default 1
            Item.proPop = "1";//Default 1
            StringBuilder sb = new StringBuilder();
            sb.Append("Insert into PRODUCT (");
            sb.Append("");
            sb.Append("shNo,");
            sb.Append("proClassNo,");
            sb.Append("proName,");
            sb.Append("proPrice,");
            sb.Append("proStatement,");
            sb.Append("proState,");
            sb.Append("proPic1,");
            sb.Append("proPic2,");
            sb.Append("proPic3,");
            sb.Append("proCreateDate,");
            sb.Append("proUpdateDate,");
            sb.Append("ProOffShelfDate,");
            sb.Append("proPop");
            sb.Append(") values(");
            sb.Append("@shNo,");
            sb.Append("@proClassNo,");
            sb.Append("@proName,");
            sb.Append("@proPrice,");
            sb.Append("@proStatement,");
            sb.Append("@proState,");
            sb.Append("@proPic1,");
            sb.Append("@proPic2,");
            sb.Append("@proPic3,");
            sb.Append("@proCreateDate,");
            sb.Append("@proUpdateDate,");
            sb.Append("@ProOffShelfDate,");
            sb.Append("@proPop");
            sb.Append(")");

            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand(sb.ToString());

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@shNo", Item.shNo));
            cmd.Parameters.Add(new SqlParameter("@proClassNo", Item.proClassNo));
            cmd.Parameters.Add(new SqlParameter("@proName", Item.proName));
            cmd.Parameters.Add(new SqlParameter("@proPrice", Item.proPrice));
            cmd.Parameters.Add(new SqlParameter("@proStatement", Item.proStatement));
            cmd.Parameters.Add(new SqlParameter("@proState", Item.proState));
            cmd.Parameters.Add(new SqlParameter("@proPic1", Item.proPic1));
            cmd.Parameters.Add(new SqlParameter("@proPic2", Item.proPic2));
            cmd.Parameters.Add(new SqlParameter("@proPic3", Item.proPic3));
            cmd.Parameters.Add(new SqlParameter("@proCreateDate", Item.proCreateDate));
            cmd.Parameters.Add(new SqlParameter("@proUpdateDate", Item.proUpdateDate));
            cmd.Parameters.Add(new SqlParameter("@ProOffShelfDate", Item.proOffShelfDate));
            cmd.Parameters.Add(new SqlParameter("@proPop", Item.proPop));

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

        public void Update(Product Item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update PRODUCT Set ");
            sb.Append("shNo=@shNo,");
            sb.Append("proClassNo=@proClassNo,");
            sb.Append("proName=@proName,");
            sb.Append("proPrice=@proPrice,");
            sb.Append("proStatement=@proStatement,");
            sb.Append("proState=@proState,");
            sb.Append("proPic1=@proPic1,");
            sb.Append("proPic2=@proPic2,");
            sb.Append("proPic3=@proPic3,");
            sb.Append("proCreateDate=@proCreateDate,");
            sb.Append("proUpdateDate=@proUpdateDate,");
            sb.Append("ProOffShelfDate=@ProOffShelfDate,");
            sb.Append("proPop=@proPop ");
            sb.Append("Where proNo=@proNo");

            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand(sb.ToString());

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@proNo", Item.proNo));
            cmd.Parameters.Add(new SqlParameter("@shNo", Item.shNo));
            cmd.Parameters.Add(new SqlParameter("@proClassNo", Item.proClassNo));
            cmd.Parameters.Add(new SqlParameter("@proName", Item.proName));
            cmd.Parameters.Add(new SqlParameter("@proPrice", Item.proPrice));
            cmd.Parameters.Add(new SqlParameter("@proStatement", Item.proStatement));
            cmd.Parameters.Add(new SqlParameter("@proState", Item.proState));
            cmd.Parameters.Add(new SqlParameter("@proPic1", Item.proPic1));
            cmd.Parameters.Add(new SqlParameter("@proPic2", Item.proPic2));
            cmd.Parameters.Add(new SqlParameter("@proPic3", Item.proPic3));
            cmd.Parameters.Add(new SqlParameter("@proCreateDate", Item.proCreateDate));
            cmd.Parameters.Add(new SqlParameter("@proUpdateDate", Item.proUpdateDate));
            cmd.Parameters.Add(new SqlParameter("@ProOffShelfDate", Item.proOffShelfDate));
            cmd.Parameters.Add(new SqlParameter("@proPop", Item.proPop));

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

        public void Delete(Product Item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete from PRODUCT ");
            sb.Append("Where proNo=@proNo ");

            IDbConnection connection = new SqlConnection(this.connectionString);
            IDbCommand cmd = new SqlCommand(sb.ToString());

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@proNo", Item.proNo));

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