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
        public Double TotalPrice { get; set; }
        public OrderModel OrderOnThisPage { get; set; }
        public BookOrderModel BookOrderInThisControl { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void SetBook(BookOrderModel bookOrder, OrderModel order)
        {
            BookOrderInThisControl = bookOrder;
            OrderOnThisPage = order;
            linkDetail.Text = bookOrder.book.title;
            linkDetail.PostBackUrl = "/details.aspx?book=" + bookOrder.book.id;
            imgCover.ImageUrl = "/public/images/cover/" + bookOrder.book.image;
            txtCategory.Text = bookOrder.book.category;
            txtNum.Text = bookOrder.quantity.ToString();
            txtPrice.Text = bookOrder.price.ToString("F2");
            TotalPrice = bookOrder.quantity * bookOrder.book.price;
            txtTotal.Text = TotalPrice.ToString("F2");
        }

        public void SetReadOnly()
        {
            txtNum.Attributes["type"] = "button";
            txtNum.CssClass = "btn btn-link text-decoration-none text-dark";
            txtNum.ReadOnly = true;
        }

        public void SetBookAmount()
        {
        }

        protected void txtNum_Unload(object sender, EventArgs e)
        {
            string x = txtNum.Text;
        }

        protected void txtNum_TextChanged(object sender, EventArgs e)
        {
            BookOrderInThisControl.quantity = int.Parse(txtNum.Text);
            OrderBLL.SetBookQuantity(BookOrderInThisControl, OrderOnThisPage);
            txtNum.Text = BookOrderInThisControl.quantity.ToString();
            TotalPrice = BookOrderInThisControl.quantity * BookOrderInThisControl.price;
            txtTotal.Text = TotalPrice.ToString("F2");
        }
    }
}