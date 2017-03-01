using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;

namespace MyWebApplication2.Ch05
{
    public partial class LindDataSource2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MDDataClassesDataContext db = new MDDataClassesDataContext();            
            //GridView2.DataSource = db.test;

            Table<test> myTest = db.GetTable<test>();
            //GridView2.DataSource = myTest;

            var myQuery = from t in myTest select new { t.id, t.title };
            GridView2.DataSource = myQuery;

            GridView2.DataBind();

            db.Dispose();
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            MDDataClassesDataContext db = new MDDataClassesDataContext();
            Table<test> myTest = db.GetTable<test>();

            int page = e.NewPageIndex;
            //==========================================================
            GridView2.PageIndex = page;
            var myQuery = from t in myTest select new { t.id, t.title };
            GridView2.DataSource = myQuery;
            GridView2.DataBind();
            //==========================================================
            var result = (from C in myTest
                          orderby C.id
                          select new { C.id, C.title }).Skip(page * 10).Take(10);
            GridView3.DataSource = result;
            GridView3.DataBind();
            //==========================================================
        }
    }
}