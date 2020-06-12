using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStoreBLL;
using BookStoreMisc;

namespace BookStoreUI.Controls
{
    public partial class AddressAddModal : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (txtAddressID.Text != "0")
            {
                AddressInThisControl = AddressBLL.GetAddressByID(int.Parse(txtAddressID.Text));
            }
        }
        protected void Add_Click(object sender, EventArgs e)
        {
            if (Session["uid"] == null)
            {
                return;
            }
            int userid = (int)Session["uid"];
            AddressModel address = new AddressModel();
            address.add = txtAdd.Text;
            address.name = txtName.Text;
            address.tel = txtTel.Text;
            address.user_id = userid;
            int currentcount = AddressBLL.GetAddressNumByUserID(userid);
            if (currentcount == 0)
            {
                address.isdefault = 1;
            }
            Modal.Show(this.Page, AddressBLL.AddAdderss(address), 1000, "/profile.aspx");
        }
        public void ShowModify(Page page, AddressModel address)
        {
            AddressInThisControl = address;
            txtAddressID.Text = address.id.ToString();
            Add.Visible = false;
            Default.Visible = true;
            Delete.Visible = true;
            Modify.Visible = true;
            txtTitle.Text = "编辑收货地址";
            txtAdd.Text = address.add;
            txtName.Text = address.name;
            txtTel.Text = address.tel;
            if (address.isdefault == 1)
            {
                Default.Text = "已是默认收货地址";
            }
            else
            {
                Default.Text = "设为默认收货地址";
            }
            page.ClientScript.RegisterStartupScript(page.ClientScript.GetType(), "", "<script>showAddress();</script>");
        }

        public AddressModel AddressInThisControl;
        protected void Modify_Click(object sender, EventArgs e)
        {
            if (Session["uid"] == null)
            {
                return;
            }
            int userid = (int)Session["uid"];
            AddressInThisControl.add = txtAdd.Text;
            AddressInThisControl.name = txtName.Text;
            AddressInThisControl.tel = txtTel.Text;
            AddressInThisControl.user_id = userid;
            Modal.Show(this.Page, AddressBLL.UpdateAddress(AddressInThisControl), 1000, "/profile.aspx");
        }
        protected void Default_Click(object sender, EventArgs e)
        {
            Modal.Show(this.Page, AddressBLL.SetDefaultAddress(AddressInThisControl), 1000, "/profile.aspx");
        }

        public void ShowAdd(Page page)
        {
            Add.Visible = true;
            Modify.Visible = false;
            Default.Visible = false;
            Delete.Visible = false;
            txtTitle.Text = "新增收货地址";
            page.ClientScript.RegisterStartupScript(page.ClientScript.GetType(), "", "<script>showAddress();</script>");
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            if (Session["uid"] == null)
            {
                return;
            }
            int userid = (int)Session["uid"];
            Modal.Show(this.Page, AddressBLL.DisableAddress(AddressInThisControl.id), 1000, "/profile.aspx");
            List<AddressModel> addresses = AddressBLL.GetAddressesByUserID(userid);
            if (addresses.Count > 0)
            {
                AddressBLL.SetDefaultAddress(addresses.First());
            }
        }
    }
}