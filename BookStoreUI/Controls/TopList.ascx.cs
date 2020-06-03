using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BookStoreUI.Controls.Element;
using BookStoreMisc;

namespace BookStoreUI.Controls
{
    public partial class TopList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BookModel[] books = new BookModel[5];
            foreach (BookModel book in books)
            {
                TopListElement control = (TopListElement)LoadControl("~/Controls/Element/TopListElement.ascx");
                
                Panel1.Controls.Add(control);
                control.SetParent(Panel1.ClientID);
                control.SetBook(book);
            }
        }
    }
}