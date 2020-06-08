using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStoreMisc;
using BookStoreUI.Controls.Element;

namespace BookStoreUI.Controls
{
    public partial class BookRow : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SetTitle(string txt,string subtxt)
        {
            txtName.Text = txt;
            txtSubName.Text = subtxt;
        }

        public void SetBooks(List<BookStatModel> books)
        {
            foreach (BookStatModel book in books)
            {
                BookRowElement bookControl = (BookRowElement)LoadControl("Element/BookRowElement.ascx");
                bookControl.SetBook(book);
                booksContent.Controls.Add(bookControl);
            }
        }
    }
}