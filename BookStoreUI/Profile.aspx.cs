using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStoreBLL;
using BookStoreMisc;
using BookStoreUI.Controls;

namespace BookStoreUI
{
    public partial class Profile : System.Web.UI.Page
    {
        public UserInfoModel UserOnThisPage;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] == null)
            {
                Response.Redirect("/login.aspx");
            }
            int userid = 0;
            try
            {
                userid = (int)Session["uid"];
                UserOnThisPage = UserInfoBLL.GetUserInfoByID(userid);
                txtUserName.Text = UserOnThisPage.username + "的个人中心";
                txtRegDate.Text = UserOnThisPage.reg_date.ToShortDateString();
                txtMail.Text = UserOnThisPage.mail;
                txtLatestDate.Text = "昨天";

                if (!IsPostBack)
                {
                    ReloadInfo();
                }
                List<AddressModel> addresses = AddressBLL.GetAddressesByUserID(userid);
                foreach (AddressModel address in addresses)
                {
                    AddressRow row = (AddressRow)LoadControl("~/Controls/AddressRow.ascx");
                    row.SetAddress(address);
                    row.Click += Row_Click;
                    addresscontent.Controls.Add(row);
                }
                txtAddressNum.Text = AddressBLL.GetAddressNumByUserID(UserOnThisPage.id).ToString();
            }
            catch (Exception err)
            {
                string x = err.Message;
                
                Response.Redirect("/index.aspx");
            }
        }

        private void Row_Click(object sender, EventArgs e)
        {
            AddressRow row = (AddressRow)sender;
            AddressAddModal.ShowModify(this, row.AddressInThisControl);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (AddressBLL.GetAddressNumByUserID(UserOnThisPage.id)>=5)
            {
                Modal.Show(this, "收货地址数量已达上限");
                return;
            }
            AddressAddModal.ShowAdd(this);
        }

        public void ReloadInfo()
        {
            txtNickName.Text = UserOnThisPage.username;
            txtTel.Text = UserOnThisPage.tel;
            txtBalance.Text = UserOnThisPage.balance.ToString("F2");
            btnGender.Items[0].Selected = UserOnThisPage.gender == 1;
            btnGender.Items[1].Selected = UserOnThisPage.gender == 0;
        }

        protected void btnPwd_Click(object sender, EventArgs e)
        {
            string orgin = txtOriginPwd.Text;
            if (MD5Encrypt.GetMD5(orgin) != UserOnThisPage.password)
            {
                Modal.Show(this, "原密码错误");
                return;
            }
            string newpwd = MD5Encrypt.GetMD5(txtNewPwd.Text);
            UserOnThisPage.password = newpwd;
            Modal.Show(this, UserInfoBLL.SetNewPassword(UserOnThisPage));
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            UserOnThisPage.tel = txtTel.Text;
            UserOnThisPage.gender = int.Parse(btnGender.SelectedValue);
            UserOnThisPage.balance = Double.Parse(txtBalance.Text);
            Modal.Show(this, UserInfoBLL.SetNewInfo(UserOnThisPage));
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ReloadInfo();
        }
    }
}