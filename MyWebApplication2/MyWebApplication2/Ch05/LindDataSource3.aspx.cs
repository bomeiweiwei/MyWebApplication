using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;

namespace MyWebApplication2.Ch05
{
    public partial class LindDataSource3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MDDataClassesDataContext db = new MDDataClassesDataContext();

            Table<test> myTest = db.GetTable<test>();

            var myQuery = from t in myTest select new { t.id, t.title };
            GridView1.DataSource = myQuery;

            GridView1.DataBind();
            db.Dispose();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MDDataClassesDataContext db = new MDDataClassesDataContext();

            Table<test> myTest = db.GetTable<test>();

            var myQuery = from t in myTest
                        where t.title.Contains(TextBox1.Text)
                        select new { t.id, t.title };

            GridView1.DataSource = myQuery;
            GridView1.DataBind();
        }
    }
}