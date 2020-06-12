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
    public partial class OrderBookRow : System.Web.UI.UserControl
    {
        public int BookID { get; set; }
        public int TotalPrice { get; set; }

        protected BookStatModel Book { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (BookID != -1)
                {
                    SetBook(BookID);
                }
            }
        }

        public void SetBook(int id)
        {
            Book = BookStatBLL.GetBookByID(id);
            linkDetail.Text = Book.title;
            linkDetail.PostBackUrl = "/details.aspx?book=" + Book.id;
            imgCover.ImageUrl = "/public/images/cover/" + Book.image;
            txtCategory.Text = Book.category;
            //txtPrice.Text = Book.price.ToString;
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}