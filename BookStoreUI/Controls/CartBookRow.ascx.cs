using BookStoreMisc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStoreUI.Controls
{
    public partial class CartBookRow : System.Web.UI.UserControl
    {
        public BookOrderModel BookOrderInThisControl { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtNum_TextChanged(object sender, EventArgs e)
        {

        }

        protected void imgCover_PreRender(object sender, EventArgs e)
        {
            imgCover.ImageUrl = "/public/images/cover/" + BookOrderInThisControl.book.image;
        }

        protected void txtCategory_PreRender(object sender, EventArgs e)
        {
            txtCategory.Text = BookOrderInThisControl.book.category;
        }

        protected void txtPrice_PreRender(object sender, EventArgs e)
        {
            txtPrice.Text = BookOrderInThisControl.book.price.ToString("F2");
        }

        protected void txtNum_PreRender(object sender, EventArgs e)
        {
            txtNum.Text = BookOrderInThisControl.quantity.ToString();
        }

        protected void linkDetail_PreRender(object sender, EventArgs e)
        {
            linkDetail.Text = BookOrderInThisControl.book.title;
            linkDetail.NavigateUrl = "/details.aspx?book=" + BookOrderInThisControl.book.id.ToString();
        }
    }
}