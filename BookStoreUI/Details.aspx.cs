using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStoreBLL;
using BookStoreMisc;

namespace BookStoreUI
{
    public partial class Details : System.Web.UI.Page
    {
        protected BookStatModel BookOnThisPage;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["book"] == null)
            {
                Response.Redirect("/index.aspx");
                return;
            }
            int bookid = -1;
            try
            {
                bookid = int.Parse(Request["book"]);
            }
            catch (Exception)
            {
                Response.Redirect("/index.aspx");
                return;
            }
            BookStatModel x = BookStatBLL.GetBookByID(bookid);
            BookOnThisPage = x;
            if (x.id == -1)
            {
                Response.Redirect("/index.aspx");
                return;
            }
            txtAuthor.Text = x.author;
            if (x.origintitle.Trim() != "")
            {
                txtOriginTitle.Text = x.origintitle;
            }
            else
            {
                txtOriginTitle.Visible = false;
            }
            txtPrice.Text = "￥" + x.price.ToString("F2");
            txtStars.Text = x.stars.ToString() + "/5";
            txtSummary.Text = x.summary;
            txtTitle.Text = x.title;
            tdAuthor.Text = x.author;
            tdISBN.Text = x.isbn;
            tdPages.Text = x.pages;
            tdPrice.Text = x.origin_price;
            tdPublisher.Text = x.publisher;
            tdTitle.Text = x.title;
            tdPubdate.Text = x.pubdate;
            imgCover.ImageUrl = "/public/images/cover/" + x.image;
            tabCatalog.Text = x.catalog;
            tabSummary.Text = x.summary;
            if (x.stock == 0)
            {
                btnBuy.Enabled = false;
            }
            if (x.onsale == 0)
            {
                btnBuy.Enabled = false;
            }
            txtStock.Text = "剩余" + x.stock.ToString() + "本";
        }

        protected void btnBuy_Click(object sender, EventArgs e)
        {
            if (Session["uid"] == null)
            {
                Response.Redirect("/login.aspx");
            }
            int userid = (int)Session["uid"];
            AddressModel address = AddressBLL.GetUserDefaultAddress(userid);
            if (address.id == 0)
            {
                Modal.Show(this, "你还没有收货地址,请前往个人中心添加");
                return;
            }


            OrderModel order = new OrderModel();
            order.address = address;
            BookOrderModel bookOrder = new BookOrderModel();
            bookOrder.amount = int.Parse(txtNum.Text);
            bookOrder.price = BookOnThisPage.price;
            bookOrder.book = BookOnThisPage;
            order.books = new List<BookOrderModel>() { bookOrder };
            order.comment = "";
            order.dateTime = DateTime.Now;
            order.status = 0;
            order.CalculateTotalPrice();
            order.user.id = userid;
            int msg = OrderBLL.AddOrder(order);
            if (msg!=-1)
            {
                Modal.Show(this, "下单成功，即将前往付款界面", 1000, "/placeorder.aspx?orderid=" + msg);
            }
            else
            {
                Modal.Show(this, "购买失败", 1000, HttpContext.Current.Request.Url.PathAndQuery);
            }
        }
    }
}