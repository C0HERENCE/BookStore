using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStoreUI.Controls
{
    public partial class WelcomeHeader : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uname"] != null)
            {
                string greatting="你好";
                string username = (string)Session["uname"];
                var timenow = DateTime.Now;
                if (timenow.Hour>=14&&timenow.Hour<18)
                {
                    greatting = "下午好，";
                }
                else if((timenow.Hour >= 18 && timenow.Hour < 24) || (timenow.Hour >=0 && timenow.Hour<5))
                {
                    greatting = "晚上好，";
                }
                else if (timenow.Hour<=10 && timenow.Hour>=5)
                {
                    greatting = "早上好，";
                }
                else if (timenow.Hour>10 && timenow.Hour<14)
                {
                    greatting = "中午好，";
                }
                else
                {
                    greatting = "上午好，";
                }
                txtGreeting.Text = greatting + username;
                Panel1.Visible = false;
            }
        }
    }
}