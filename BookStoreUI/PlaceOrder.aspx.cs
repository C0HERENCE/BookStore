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
    public partial class PlaceOrder : System.Web.UI.Page
    {
        public double OrderPrice = 0;
        public double ExtraPrice = 0;
        public double OffPrice = 0;
        public double TotalPrice = 0;
        public OrderModel OrderOnThisPage;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"]==null || Request["orderid"] == null)
            {
                Response.Redirect("/login.aspx");
            }
            
            
            int OrderID = int.Parse(Request["orderid"]);
            OrderOnThisPage = OrderBLL.GetOrderByID(OrderID);
            if (OrderOnThisPage.status != OrderStatus.UnPaid)
            {
                Response.Redirect("/login.aspx");
            }

            if ((int)Session["uid"] != OrderOnThisPage.user.id) 
            {
                Response.Redirect("/login.aspx");
            }
            AddressRowManage.SetAddress(OrderOnThisPage.address);
            List<AddressModel> AddressModels = AddressBLL.GetAddressesByUserID(OrderOnThisPage.user.id);
            foreach (AddressModel Address in AddressModels)
            {
                AddressRow addressRow = (AddressRow)LoadControl("/Controls/AddressRow.ascx");
                addressRow.SetAddress(Address);
                addressRow.Click += AddressRow_Click;
                AddressHolder.Controls.Add(addressRow);
            }
            if (!IsPostBack) // 需要修改的值
            {
                txtComment.Text = OrderOnThisPage.comment;
                txtStatus.Text = OrderOnThisPage.GetStatusString();
            }
           
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
            // 创建控件
            orderBookContent.Controls.Clear();
            foreach (BookOrderModel bookOrder in OrderOnThisPage.books)
            {
                OrderBookRow bookRow = (OrderBookRow)LoadControl("~/Controls/OrderBookRow.ascx");
                bookRow.SetBook(bookOrder, OrderOnThisPage);
                orderBookContent.Controls.Add(bookRow);
                bookRow.txtNum.TextChanged += TxtNum_TextChanged;
            }

        }

        private void AddressRow_Click(object sender, EventArgs e)
        {
            AddressRow address = (AddressRow)sender;
            OrderBLL.SetOrderAddress(OrderOnThisPage.id, address.AddressInThisControl.id);
            Response.Redirect(HttpContext.Current.Request.Url.PathAndQuery);
        }

        private void TxtNum_TextChanged(object sender, EventArgs e)
        {
            string a=  ((TextBox)sender).Text;
            OrderPrice = OrderOnThisPage.CalculateTotalPrice();
            OrderBLL.SetOrderTotalPrice(OrderOnThisPage);
            txtOrderPrice.Text = OrderPrice.ToString("F2");
            ExtraPrice = 0;
            txtExtraPrice.Text = ExtraPrice.ToString("F2");
            OffPrice = 0;
            txtOffPrice.Text = OffPrice.ToString("F2");
            TotalPrice = OrderPrice + ExtraPrice - OffPrice;
            txtTotalPrice.Text = TotalPrice.ToString("F2");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            OrderBLL.SetOrderStatus(OrderOnThisPage.id, OrderStatus.Cancel);
            btnCheck.Enabled = false;
            Modal.Show(this, "订单已取消", 1000, "/orderdetail.aspx?orderid=" + OrderOnThisPage.id);
        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
           
            foreach (BookOrderModel book in OrderOnThisPage.books)
            {
                if (book.quantity > book.book.stock)
                {
                    Modal.Show(this, "无法购买：《" + book.book.title + "》的库存量不足");
                    return;
                }
                if (book.book.onsale == 0)
                {
                    Modal.Show(this, "无法购买：" + book.book.title + "已经下架");
                    return;
                }
            }
            if (OrderOnThisPage.user.balance < OrderOnThisPage.totalPrice)
            {
                Modal.Show(this, "无法购买：余额不足");
                return;
            }

            OrderBLL.SetOrderStatus(OrderOnThisPage.id, OrderStatus.Process);
            btnCancel.Enabled = false;

            foreach (BookOrderModel book in OrderOnThisPage.books)
            {
                book.book.stock -= book.quantity;
                BookStatBLL.SetBook(book.book);
            }
            OrderOnThisPage.user.balance -= OrderOnThisPage.totalPrice;
            UserInfoBLL.SetNewInfo(OrderOnThisPage.user);
            Modal.Show(this, "支付成功", 1000, "/orderdetail.aspx?orderid=" + OrderOnThisPage.id);
        }

        protected void txtComment_TextChanged(object sender, EventArgs e)
        {
            OrderBLL.SetOrderComment(OrderOnThisPage.id, txtComment.Text);
        }
    }
}