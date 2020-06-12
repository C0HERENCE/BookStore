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
            Modal.Show(this.Page, AddressBLL.AddAdderss(address), 1000, "/profile.aspx");
        }

        public void Show(Page page)
        {
            page.ClientScript.RegisterStartupScript(page.ClientScript.GetType(), "", "<script>showAddress();</script>");
        }
    }
}