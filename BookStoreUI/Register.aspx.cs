using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStoreMisc;
using BookStoreBLL;
using System.Threading;

namespace BookStoreUI
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void NextStep_Click(object sender, EventArgs e)
        {
            if (Session["msgCode"] == null)
            {
                Modal.Show(this, "验证码未发送");
                txtMailReg.Text = "";
                return;
            }
            if (txtCode.Text == Session["msgCode"].ToString())
            {
                panelStep1.Visible = false;
                panelStep2.Visible = true;
                Session["msgCode"] = null;
            }
            else
            {
                Modal.Show(this, "验证码输入错误");
            }
        }

        protected void Reg_Click(object sender, EventArgs e)
        {
            UserInfoModel user = new UserInfoModel();
            user.username = txtUserName.Text;
            user.password = txtPwd.Text;
            user.mail = txtMailReg.Text;
            user.role = 0;
            string msg = UserInfoBLL.AddUser(user);
            if (msg=="注册成功")
            {
                Modal.Show(this, msg, 3000, "login.aspx");
                return;
            }
            Modal.Show(this, msg);
        }
        
        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            if (UserInfoBLL.GetUserCountByMail(txtMail.Text) == 1)
            {
                Modal.Show(this, "该邮箱已被注册");
                return;
            };
            Random random = new Random();
            string msgCode = random.Next(0, 999999).ToString("000000");
            Session["msgCode"] = msgCode;
            txtMailReg.Text = txtMail.Text;
            if (MailValidation.SendValidation(txtMail.Text, msgCode))
            {
                Modal.Show(this, "验证码发送成功");
            }
            else
            {
                Modal.Show(this, "验证码发送失败，请联系管理员");
            }
        }
    }
}