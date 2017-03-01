using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebApplication2.Ch08
{
    public partial class GetDataWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Ch08Service wcf = new Ch08Service();
            GridView1.DataSource = wcf.Get_Data(1);
            GridView1.DataBind();
        }
    }
}