using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using AllShow.Models.advertisement;

namespace AllShow.Test
{
    public partial class TestWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AllShow.Models.AllShow db = new AllShow.Models.AllShow();

            IEnumerable<Advertisement> ads = db.Advertisement.Get();

            Advertisement ad = db.Advertisement.FindOne(1);

            Label1.Text = ad.adNo.ToString();
        }
    }
}