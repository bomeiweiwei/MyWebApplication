using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Collections;

namespace MyWebApplication.Ch16
{
    public partial class RequestTest2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            object myObject = this.Context.Items["myArraylist"];
            if (myObject != null)
            {
                ArrayList myArraylist = (ArrayList)myObject;
                for (int i = 0; i < 4; i++)
                {
                    Person person = (Person)myArraylist[i];
                    ContentPlaceHolder cp = this.Master.Master.FindControl("MainContent") as ContentPlaceHolder;
                    ContentPlaceHolder cp2 = cp.FindControl("ContentPlaceHolderContent") as ContentPlaceHolder;
                    Label lbl = cp2.FindControl("Label" + Convert.ToString(i + 1)) as Label;
                    //Label lbl = cp.FindControl("Label1") as Label;
                    //Label lbl = cp.FindControl("Label" + Convert.ToString(i + 1)) as Label;
                    //lbl.Text = person.Name + "," + person.Age.ToString();
                    lbl.Text = "姓名 ： " + person.Name + " , 年齡 ： " + person.Age.ToString();
                }
            }
        }
    }
}