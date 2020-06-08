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
            string msg = UserInfoBLL.GetUserCountByNameAndPwd(txtUsername.Text, txtPwd.Text, isAdmin);
            if (msg == "登录成功")
            {
                Session["isadmin"] = isAdmin;
                Session["uname"] = txtUsername.Text;
                Session["uid"] = UserInfoBLL.GetIDByName(txtUsername.Text);
                if (isAdmin)
                {
                    Modal.Show(this, "登录成功，即将跳转到管理面板", 1000, "dashboard/index.aspx");
                }
                else
                {
                    Modal.Show(this, "登录成功，即将跳转到首页", 1000, "index.aspx");
                }
            }
            else
            {
                Session["isadmin"] = null;
                Session["uname"] = null;
                Session["uid"] = null;
                Modal.Show(this, msg);
            }
        }
    }
}