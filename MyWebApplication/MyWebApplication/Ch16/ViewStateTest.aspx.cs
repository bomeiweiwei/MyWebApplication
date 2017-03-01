using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Collections;

namespace MyWebApplication.Ch16
{
    public partial class ViewStateTest : System.Web.UI.Page
    {
        private ArrayList pageArraylist;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewState["arrlist"] != null)
            {
                System.Diagnostics.Debug.WriteLine("19");
                pageArraylist = (ArrayList)ViewState["arrlist"];
                ddl_GetArrayList.Items.Clear();
                ddl_GetArrayList.DataSource = pageArraylist;
                ddl_GetArrayList.DataBind();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("27");
                pageArraylist = new ArrayList(4);
                pageArraylist.Add("選項一");
                pageArraylist.Add("選項二");
                pageArraylist.Add("選項三");
                pageArraylist.Add("選項四");

                ViewState["arrlist"] = pageArraylist;
            }
        }

        protected void btn_SetArrayList_Click(object sender, EventArgs e)
        {
            //pageArraylist = new ArrayList(4);
            //pageArraylist.Add("選項一");
            //pageArraylist.Add("選項二");
            //pageArraylist.Add("選項三");
            //pageArraylist.Add("選項四");

            //ViewState["arrlist"] = pageArraylist;

        }
    }
}