using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebApplication2.Ch05
{
    public partial class LinqDataSourceBookSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<BookSample> getList = BookSample.BookList();
            var titles = from b in getList
                         select b.Title;

            GridView1.DataSource = titles;
            GridView1.DataBind();

            //titles = from b in getList
            //         select new { title=b.Title};
        }
    }
}