using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebApplication.Ch01_II
{
    public partial class Ch01MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Image ImageTest
        {
            get { return Image1; }
            set { Image1 = value; }
        }
    }
}