using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

//using MyWebApplication2.Ch04;

namespace MyWebApplication2.Ch04
{
    public class EmployeeLogic
    {
        private static string getEmployeeDataByKey = "select FirstName,LastName,Title,TitleOfCourtesy,ReportsTo from employees where employeeid=@empid";
        private static string getAllEmployeeData = "select EmployeeID,FirstName,LastName,Title,TitleOfCourtesy,ReportsTo from employees";

        public int insert(NorthWindEmployee nwe)
        { return 0; }

        public int update(NorthWindEmployee nwe)
        { return 0; }

        public int delete(object anID)
        { return 0; }

        public NorthWindEmployee findByPrimaryKey(object anID)
        {
            NorthWindEmployee nwe = new NorthWindEmployee();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString);
            SqlDataReader dr = null;

            SqlCommand cmd = new SqlCommand(getEmployeeDataByKey, connection);
            cmd.Parameters.Add(new SqlParameter("@empid", SqlDbType.Int)).Value = Int32.Parse(anID.ToString());

            try
            {
                connection.Open();
                dr = cmd.ExecuteReader();
                if (dr != null && dr.Read())
                {
                    nwe.EmployeeID = anID;
                    nwe.FirstName = dr["FirstName"].ToString();
                    nwe.LastName = dr["LastName"].ToString();
                    nwe.Title = dr["Title"].ToString();
                    nwe.Courtesy = dr["TitleOfCourtesy"].ToString();
                    if (!dr.IsDBNull(4))
                    {
                        nwe.Supervisor = dr.GetInt32(4);
                    }
                }
                else
                {
                    throw new NorthWindDataException("資料未載入");
                }
            }
            catch (Exception) { }
            finally
            {
                try
                {
                    if (dr != null)
                        dr.Close();
                    connection.Close();
                }
                catch (SqlException)
                {
                    throw;
                }
            }
            return nwe;
        }

        public static ICollection getAll()
        {
            SqlDataSource sds = new SqlDataSource(ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString, getAllEmployeeData);
            ArrayList al = new ArrayList();
            try
            {
                IEnumerable emps = sds.Select(DataSourceSelectArguments.Empty);

                foreach (DataRowView row in emps)
                {
                    NorthWindEmployee nwe = new NorthWindEmployee();
                    nwe.EmployeeID = row["EmployeeID"].ToString();
                    nwe.FirstName = row["FirstName"].ToString();
                    nwe.LastName = row["LastName"].ToString();
                    nwe.Title = row["Title"].ToString();
                    nwe.Courtesy = row["TitleOfCourtesy"].ToString();
                    try
                    {
                        nwe.Supervisor = Convert.ToInt32(row["ReportsTo"].ToString());
                    }
                    catch (Exception)
                    {
                        nwe.Supervisor = 0;
                    }
                    al.Add(nwe);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                sds.Dispose();
            }
            return al;
        }
    }

    internal class NorthWindDataException : Exception {
        public NorthWindDataException(string msg) : base(msg) { }
    }
}