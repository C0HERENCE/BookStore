using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStoreMisc;

namespace BookStoreUI.Controls.Element
{
    public partial class OrderDetailBookRowElement : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        internal void SetBook(BookOrderModel book)
        {
            linkdetail.NavigateUrl = "/details.aspx?book=" + book.book.id;
            img.Attributes["title"] = book.book.title;
            img.ImageUrl = "/public/images/cover/" + book.book.image;
        }
    }
}