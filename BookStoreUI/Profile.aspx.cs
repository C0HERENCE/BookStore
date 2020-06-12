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
                List<AddressModel> addresses = AddressBLL.GetAddressesByUserID(userid);
                foreach (AddressModel address in addresses)
                {
                    AddressRow row = (AddressRow)LoadControl("~/Controls/AddressRow.ascx");
                    row.SetAddress(address);
                    addresscontent.Controls.Add(row);
                }
            }
            catch (Exception)
            {

                Response.Redirect("/index.aspx");
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            AddressAddModal.Show(this);
        }
    }
}