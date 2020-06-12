using BookStoreMisc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStoreBLL;
using BookStoreUI.Controls.Element;

namespace BookStoreUI.Controls
{
    public partial class OrderDetailBookRow : System.Web.UI.UserControl
    {
        public OrderModel OrderInThisControl { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtID_PreRender(object sender, EventArgs e)
        {
            txtID.Text = OrderInThisControl.id.ToString();
        }

        protected void txtTime_PreRender(object sender, EventArgs e)
        {
            txtTime.Text = OrderInThisControl.dateTime.ToString();
        }

        protected void txtTotal_PreRender(object sender, EventArgs e)
        {
            txtTotal.Text = OrderInThisControl.totalPrice.ToString("F2");
        }

        protected void linkDetail_PreRender(object sender, EventArgs e)
        {
            if (OrderInThisControl.status==OrderStatus.UnPaid)
            {
                linkDetail.Text = "继续订单";
                linkDetail.NavigateUrl = "/placeorder.aspx?orderid=" + OrderInThisControl.id.ToString();
            }
            else
            {
                linkDetail.Text = "查看详情";
                linkDetail.NavigateUrl = "/orderdetail.aspx?orderid=" + OrderInThisControl.id.ToString();
            }
        }

        protected void linkCancel_PreRender(object sender, EventArgs e)
        {
            
        }

        protected void linkDelete_PreRender(object sender, EventArgs e)
        {

        }

        protected void Unnamed_PreRender(object sender, EventArgs e)
        {

        }

        protected void progress_PreRender(object sender, EventArgs e)
        {
            switch (OrderInThisControl.status)
            {
                case OrderStatus.UnPaid:
                progress.Attributes["style"] = "width:0%";
                    break;
                case OrderStatus.Process:
                progress.Attributes["style"] = "width:30%";
                    break;
                case OrderStatus.Dispatching:
                progress.Attributes["style"] = "width:60%";
                    break;
                case OrderStatus.Complete:
                progress.Attributes["style"] = "width:100%";
                    break;
                case OrderStatus.Cancel:
                progress.Attributes["style"] = "width:0%;";
                    break;
                case OrderStatus.Closed:
                progress.Attributes["style"] = "width:0%";
                    break;
                default:
                progress.Attributes["style"] = "width:0%";
                    break;
            }
        }

        protected void holder_PreRender(object sender, EventArgs e)
        {
            foreach (BookOrderModel book in OrderInThisControl.books)
            {
                OrderDetailBookRowElement bookRowElement = (OrderDetailBookRowElement)LoadControl("~/Controls/Element/OrderDetailBookRowElement.ascx");
                bookRowElement.SetBook(book);
                holder.Controls.Add(bookRowElement);
            }
        }

        protected void linkCancel_Click(object sender, EventArgs e)
        {

        }
    }
}