using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStoreMisc;
using BookStoreBLL;

namespace Dashboard
{
    public partial class allauthors : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label1.Text = AuthorBLL.GetAuthorCount().ToString();
                Label2.Text = PublisherBLL.GetPublisherCount().ToString();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            PublisherModel publisher = new PublisherModel(TextBox3.Text);
            Response.Write(PublisherBLL.AddPublisher(publisher));
            Label2.Text = PublisherBLL.GetPublisherCount().ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            AuthorModel author = new AuthorModel(TextBox1.Text, TextBox2.Text);
            Response.Write(AuthorBLL.AddAuthor(author));
            Label1.Text = AuthorBLL.GetAuthorCount().ToString();
        }
    }
}