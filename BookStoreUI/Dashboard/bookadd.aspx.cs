using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStoreBLL;
using BookStoreMisc;

namespace Dashboard
{
    public partial class bookadd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList1.DataSource = CategoryBLL.GetCategoryDictByRole(0);
                DropDownList1.DataValueField = "key";
                DropDownList1.DataTextField = "value";
                DropDownList1.DataBind();
                DropDownList1_SelectedIndexChanged(null, null);
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.DataSource = CategoryBLL.GetCategoryDictByRole(int.Parse(DropDownList1.SelectedValue));
            DropDownList2.DataValueField = "key";
            DropDownList2.DataTextField = "value";
            DropDownList2.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("bookadd.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            BookInfoModel book = new BookInfoModel();
            book.author_id = int.Parse(txtauthorid.Text);
            book.catalog = txtcatalog.Text;
            book.category_id = int.Parse(DropDownList2.SelectedValue);
            book.image = "";
            book.isbn = txtisbn.Text;
            book.origintitle = txtorigin.Text;
            book.pages = txtpages.Text;
            book.price = txtprice.Text;
            book.pubdate = txtpubdate.Text;
            book.publisher_id = int.Parse(txtpublisherid.Text);
            book.subtitle = txtsub.Text;
            book.summary = txtsummary.Text;
            book.title = txttitle.Text;
            string msg = BookInfoBLL.AddBook(book);
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>showModal('"+ msg + "');</script>");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("bookstock.aspx");
        }
    }
}