using BookStoreBLL;
using BookStoreMisc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dashboard
{
    public partial class userdetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["userid"]!=null)
            {
                int userid = int.Parse(Request["userid"]);
                if (UserInfoBLL.GetUserCountByID(userid) == 0) return;
                UserInfoModel user = new UserInfoModel();
                user = UserInfoBLL.GetUserInfoByID(userid);
                txtBalance.Text = user.balance.ToString();
                txtGender.Text = (user.gender == 1) ? "男" : "女";
                txtMail.Text = user.mail;
                txtNickName.Text = user.username;
                txtTel.Text = user.tel;
                TextRegDate.Text = user.reg_date.ToString();
            }
        }

        protected void txtuserid_TextChanged(object sender, EventArgs e)
        {
            int userid = 0;
            if (int.TryParse(txtuserid.Text,out userid))
            {
                Response.Redirect("userdetail.aspx?userid=" + txtuserid.Text);
            }
        }

    }
}