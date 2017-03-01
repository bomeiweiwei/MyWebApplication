using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebApplication.Ch01_II
{
    public partial class MasterPageTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Show_Click(object sender, EventArgs e)
        {
            //Image img = (Image)this.Master.FindControl("Image1");
            ContentPlaceHolder cp = this.Master.Master.FindControl("MainContent") as ContentPlaceHolder;
            Image img = cp.FindControl("Image1") as Image;
            img.Visible = true;
        }

        protected void btn_hidden_Click(object sender, EventArgs e)
        {
            //Image img = (Image)this.Master.FindControl("Image1");
            ContentPlaceHolder cp = this.Master.Master.FindControl("MainContent") as ContentPlaceHolder;
            Image img = cp.FindControl("Image1") as Image;
            img.Visible = false;
        }

        protected void btn_Show2_Click(object sender, EventArgs e)
        {
            ContentPlaceHolder cp = this.Master.Master.FindControl("MainContent") as ContentPlaceHolder;
            for (int i = 1; i < 4; i++)
            {
                TextBox txt = cp.FindControl("txt_input" + i) as TextBox;
                Label1.Text += txt.Text;
            }
        }

        protected void btn_Show2_Click1(object sender, EventArgs e)
        {
            Image img = this.Master.ImageTest;
            img.Visible = true;
        }

        protected void btn_hidden2_Click(object sender, EventArgs e)
        {
            Image img = this.Master.ImageTest;
            img.Visible = false;
        }
    }
}