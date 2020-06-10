using BookStoreMisc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStoreUI.Controls.Element
{
    public partial class NavBarElement : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SetLink(CategoryModel catagory)
        {
            Link.NavigateUrl = "/category.aspx?category=" + catagory.id.ToString();
            Link.Text = catagory.name;
        }
    }
}