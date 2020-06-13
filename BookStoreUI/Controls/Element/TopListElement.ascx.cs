using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BookStoreMisc;
using System.Text;

namespace BookStoreUI.Controls.Element
{
    public partial class TopListElement : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void SetBook(BookStatModel book,int rank,int sales)
        {
            txtClientID.Text = rank.ToString();
            txtTitle.Text = book.title;
            txtSales.Text = "总销量:" + sales.ToString();
            txtSummary.Text = book.summary;
            imgCover.ImageUrl = "/public/images/cover/" + book.image;
            Panel2.Attributes["data-target"] ="#" + Panel1.ClientID;
            linkDetail.NavigateUrl = "/details.aspx?book=" + book.id.ToString();
        }

        public void SetParent(string parent)
        {
            Panel1.Attributes["data-parent"] = "#" +parent;
        }
    }
}