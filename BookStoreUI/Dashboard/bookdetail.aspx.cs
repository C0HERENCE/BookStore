using BookStoreBLL;
using BookStoreMisc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dashboard
{
    public partial class bookdetail : System.Web.UI.Page
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
                if (Request["bookid"] != null)
                {
                    int bookid = int.Parse(Request["bookid"]);
                    if (BookStatBLL.GetBookCountByID(bookid) == 0) return;
                    BookStatModel book = new BookStatModel();
                    book = BookStatBLL.GetBookByID(bookid);
                    txtauthorid.Text = book.author_id.ToString();

                    txtcatalog.Text = book.catalog;
                    txtisbn.Text = book.isbn;
                    txtorigin.Text = book.origintitle;
                    txtOriginPrice.Text = book.origin_price;
                    txtpages.Text = book.pages;
                    txtPrice.Text = book.price.ToString();
                    txtpubdate.Text = book.pubdate;
                    txtpublisherid.Text = book.publisher_id.ToString();

                    txtStock.Text = book.stock.ToString();
                    txtsub.Text = book.subtitle;
                    txtsummary.Text = book.summary;
                    txttitle.Text = book.title;
                    if (book.onsale == 1)
                    {
                        btnBan.CssClass = "btn btn-danger";
                        btnBan.Text = "下架该图书";
                    }
                    else
                    {
                        btnBan.Text = "上架该图书";
                        btnBan.CssClass = "btn btn-success";
                    }

                    DropDownList1.SelectedValue = CategoryBLL.GetCategoryParent(book.category_id).ToString();
                    DropDownList1_SelectedIndexChanged(null, null);
                    DropDownList2.SelectedValue = book.category_id.ToString();
                }
            }
        }

        protected void btnSubmmit_Click(object sender, EventArgs e)
        {
            if (Request["bookid"] != null)
            {
                BookInfoModel book = new BookInfoModel();
                book.id = int.Parse(Request["bookid"]);
                book.title = txttitle.Text;
                book.origintitle = txtorigin.Text;
                book.subtitle = txtsub.Text;
                book.category_id = int.Parse(DropDownList2.SelectedValue);
                book.author_id = int.Parse(txtauthorid.Text);
                book.publisher_id = int.Parse(txtpublisherid.Text);
                book.isbn = txtisbn.Text;
                book.pubdate = txtpubdate.Text;
                book.pages = txtpages.Text;
                book.price = txtOriginPrice.Text;
                BookInfoBLL.SetBook(book);
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            if (Request["bookid"] != null)
            {
                Response.Redirect("bookdetail.aspx?bookid=" + Request["bookid"]);
            }
        }

        protected void btnBan_Click(object sender, EventArgs e)
        {
            if (Request["bookid"] != null)
            {
                BookStatModel book = BookStatBLL.GetBookByID(int.Parse(Request["bookid"]));
                BookStatBLL.SetBookOnSale(book.id, book.onsale == 0 ? 1 : 0);
                Response.Redirect("bookdetail.aspx?bookid=" + Request["bookid"]);
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.DataSource = CategoryBLL.GetCategoryDictByRole(int.Parse(DropDownList1.SelectedValue));
            DropDownList2.DataValueField = "key";
            DropDownList2.DataTextField = "value";
            DropDownList2.DataBind();
        }
        
        protected void btnCheck_Click(object sender, EventArgs e)
        {
            int bookid = 0;
            if (int.TryParse(txtbookid.Text, out bookid))
            {
                Response.Redirect("bookdetail.aspx?bookid=" + txtbookid.Text);
            }
        }

        protected void btnSubmmit2_Click(object sender, EventArgs e)
        {
            if (Request["bookid"] != null)
            {
                BookStatModel book = BookStatBLL.GetBookByID(int.Parse(Request["bookid"]));
                book.stock = int.Parse(txtStock.Text);
                book.price = double.Parse(txtPrice.Text);
                BookStatBLL.SetBook(book);
                Response.Redirect("bookdetail.aspx?bookid=" + Request["bookid"]);
            }
            
        }
    }
}