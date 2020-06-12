using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStoreMisc;
using BookStoreBLL;

namespace BookStoreUI.Controls
{
    public partial class AddressRow : UserControl
    {
        public AddressModel AddressInThisControl { get; set; }

        public event EventHandler Click;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void SetAddress(AddressModel address)
        {
            AddressInThisControl = address;
            txtAdd.Text = address.add;
            txtName.Text = address.name;
            txtTel.Text = address.tel;
            txtNO.Text = address.id.ToString();
            if (address.isdefault == 1)
            {
                txtIsDefault.Text = "默认收货地址";
            }
        }

        protected void linkaddress_Click(object sender, EventArgs e)
        {
            Click(this, e);
        }
    }
}