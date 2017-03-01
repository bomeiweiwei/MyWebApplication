using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebApplication2.Ch08
{
    public partial class Compute_WebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Ch08WebService ws = new Ch08WebService();
            try
            {
                int answer = ws.Compute_it(Int32.Parse(txtNum1.Text), Int32.Parse(txtNum2.Text));
                lblAnswer.Text = answer.ToString();
            }
            catch (Exception)
            {
                lblAnswer.Text = "Error";
            }
            ws.Dispose();

            Ch08Service cs = new Ch08Service();
            lblMsg.Text = cs.DoWork();
        }
    }
}