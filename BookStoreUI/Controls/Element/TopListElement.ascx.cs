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

        public void SetBook(BookInfoModel book)
        {
            Label1.Text = Panel1.ClientID;
            Label2.Text = "Bookname";
            Label3.Text = "descdescdescdescdescdescdescdescdescdescdescdesc";
            Image1.ImageUrl = "~/UI/Public/Images/selling1.jpg";
            //Page.RegisterStartupScript("script", "<script> document.getElementById('identify').setAttribute('id', 'abc');</script>");
            //Page.RegisterStartupScript("script", "<script> alert('3');</script>");
            Panel2.Attributes["data-target"] ="#" + Panel1.ClientID;
            //Panel1.CssClass += " show";
        }

        public void SetParent(string parent)
        {
            Panel1.Attributes["data-parent"] = "#" +parent;
        }
    }
}