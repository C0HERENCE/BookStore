using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStoreBLL;

namespace BookStoreUI
{
    public partial class Login : System.Web.UI.Page
    {
        private bool isAdmin = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["isadmin"]=="true")
            {
                isAdmin = true;
                userpan.Visible = false;
                tips.Text = "后台管理系统";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string a = txtUsername.Text;
            string b = txtPwd.Text;
            if (LoginBBL.Login(a, b, isAdmin))
            {
                Session["isadmin"] = isAdmin;
                Session["uname"] = txtUsername.Text;
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>showSuccess();</script>");
            }
            else
            {
                Session["isadmin"] = false;
                Session["uname"] = "";
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>showError();</script>");
            }
        }
    }
}