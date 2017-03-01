using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Collections;

namespace MyWebApplication.Ch16
{
    public partial class RequestTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["num1"] != null && Request["num2"] != null)
            {
                Label1.Text = Convert.ToString(Convert.ToInt32(Request["num1"]) + Convert.ToInt32(Request["num2"]));
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Ch16/RequestTest.aspx?num1=" + txtNum1.Text + "&num2=" + txtNum2.Text);
        }

       

        protected void Button2_Click(object sender, EventArgs e)
        {
            ArrayList myArraylist = new ArrayList(4);

            for (int i = 0; i < 4; i++)
            {
                Person person = new Person();

                if (i == 0)
                {
                    person.Name = "小明";
                    person.Age = 20;
                }
                else if (i == 1) {
                    person.Name = "小華";
                    person.Age = 21;
                }
                else if (i == 2)
                {
                    person.Name = "小強";
                    person.Age = 25;
                }
                else 
                {
                    person.Name = "小美";
                    person.Age = 23;
                }
                myArraylist.Add(person);
            }
            //Request["SendArray"] = pageArraylist;//Error
            //ViewState["arrlist"] = pageArraylist;
            this.Context.Items.Add("myArraylist", myArraylist);
            this.Server.Transfer("~/Ch16/RequestTest2.aspx");
        }
    }

    public class Person 
    {
        private string name;  // the name field
        private int age;

        public string Name    // the Name property
        {
            get
            {
                return name;
            }
            set 
            {
                this.name = value;
            }
        }

        public int Age    // the Age property
        {
            get
            {
                return age;
            }
            set
            {
                this.age = value;
            }
        }
    }
}