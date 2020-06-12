using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStoreBLL;
using BookStoreMisc;
using BookStoreUI.Controls;

namespace BookStoreUI
{
    public partial class OrderDetail : System.Web.UI.Page
    {
        public double OrderPrice = 0;
        public double ExtraPrice = 0;
        public double OffPrice = 0;
        public double TotalPrice = 0;
        public OrderModel OrderOnThisPage;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] == null || Request["orderid"] == null)
            {
                Response.Redirect("/login.aspx");
            }


            int OrderID = int.Parse(Request["orderid"]);
            OrderOnThisPage = OrderBLL.GetOrderByID(OrderID);
            if (OrderOnThisPage.status == OrderStatus.UnPaid)
            {
                Response.Redirect("/login.aspx");
            }

            if ((int)Session["uid"] != OrderOnThisPage.user.id)
            {
                Response.Redirect("/login.aspx");
            }
            AddressRowManage.SetAddress(OrderOnThisPage.address);
            txtComment.Text = OrderOnThisPage.comment;
            txtStatus.Text = OrderOnThisPage.GetStatusString();
            
            // 基本信息
            txtDateTime.Text = OrderOnThisPage.dateTime.ToString();
            txtOrderID.Text = OrderOnThisPage.id.ToString();
            txtUserID.Text = OrderOnThisPage.user.id.ToString();
            // 价格信息
            OrderPrice = OrderOnThisPage.CalculateTotalPrice();
            OrderBLL.SetOrderTotalPrice(OrderOnThisPage);
            txtOrderPrice.Text = OrderPrice.ToString("F2");
            ExtraPrice = 0;
            txtExtraPrice.Text = ExtraPrice.ToString("F2");
            OffPrice = 0;
            txtOffPrice.Text = OffPrice.ToString("F2");
            TotalPrice = OrderPrice + ExtraPrice - OffPrice;
            txtTotalPrice.Text = TotalPrice.ToString("F2");
            AddressRowManage.Click += AddressRowManage_Click;
            // 创建控件
            orderBookContent.Controls.Clear();
            foreach (BookOrderModel bookOrder in OrderOnThisPage.books)
            {
                OrderBookRow bookRow = (OrderBookRow)LoadControl("~/Controls/OrderBookRow.ascx");
                bookRow.SetBook(bookOrder, OrderOnThisPage);
                bookRow.SetReadOnly();
                orderBookContent.Controls.Add(bookRow);
                bookRow.txtNum.TextChanged += TxtNum_TextChanged; ;
            }
        }

        private void AddressRowManage_Click(object sender, EventArgs e)
        {
            return;
        }

        private void TxtNum_TextChanged(object sender, EventArgs e)
        {
            return;
        }

        private void AddressRow_Click(object sender, EventArgs e)
        {
            return;
        }
    }
}