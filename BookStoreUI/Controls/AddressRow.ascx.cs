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
    public partial class AddressRow : System.Web.UI.UserControl
    {
        public int AddressID { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void SetAddress(int id)
        {
            AddressModel address = AddressBLL.GetAddressByID(id);
            txtAdd.Text = address.add;
            txtName.Text = address.name;
            txtTel.Text = address.tel;
            txtUser.Text = address.user_id.ToString();
        }
        public void SetAddress(AddressModel address)
        {
            txtAdd.Text = address.add;
            txtName.Text = address.name;
            txtTel.Text = address.tel;
            txtUser.Text = address.user_id.ToString();
        }
    }
}