using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStoreUI.Controls.Element
{
    public partial class BookRowElement : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        internal void SetBook(BookStoreMisc.BookStatModel book)
        {
            imgCover.ImageUrl = "/Public/Images/Cover/" + book.image;
            txtBookTitle.Text = book.title;
            txtPrice.Text = book.price.ToString();
            linkDetail.NavigateUrl = "/details.aspx?book=" + book.id.ToString();
        }
    }
}