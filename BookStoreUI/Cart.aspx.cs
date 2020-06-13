using BookStoreBLL;
using BookStoreMisc;
using BookStoreUI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStoreUI
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void list_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataRebind();
            }
        }
        CartModel GetCart()
        {
            if (Session["uid"] == null)
            {
                Response.Redirect("/login.aspx");
            }
            return CartBLL.GetUserCart((int)Session["uid"]);
        }
        void DataRebind()
        {
            if (Session["uid"] == null)
            {
                Response.Redirect("/login.aspx");
            }
            list.DataSource = GetCart().book;
            list.DataBind();
            if (ViewState["selected"]== null)
            {
                return;
            }
            foreach (ListViewDataItem item in list.Items)
            {
                CheckBox check = (CheckBox)item.FindControl("btnSelect");
                if (check!=null)
                {
                    check.Checked = ((HashSet<int>)ViewState["selected"]).Contains(int.Parse(check.Attributes["bookid"]));
                }
            }
            UpdatePrice();
        }

        void UpdatePrice()
        {
            if (ViewState["selected"] == null)
            {
                txtOrderPrice.Text = 0.ToString("F2");
                return;
            }
            CartModel cart = GetCart();
            HashSet<int> selected = (HashSet<int>)ViewState["selected"];
            double totalPrice = 0;
            foreach (BookOrderModel book in cart.book)
            {
                if (selected.Contains(book.book.id))
                {
                    totalPrice += book.book.price * book.quantity;
                }
            }
            txtOrderPrice.Text = totalPrice.ToString("F2");
        }
        protected void list_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string commandName = e.CommandName;
            string commandArguments = (string)e.CommandArgument;
            BookOrderModel c = (BookOrderModel)e.Item.DataItem;
            if (e.CommandName=="btnDelete")
            {
                int id = CartBLL.DeleteBook((int)Session["uid"], int.Parse((string)e.CommandArgument)); 
            }
            DataRebind();
        }

        protected void txtNum_TextChanged(object sender, EventArgs e)
        {
            int quantity = 0;
            if (int.TryParse(((TextBox)sender).Text, out quantity))
            {
                BookOrderModel book = new BookOrderModel();
                TextBox textBox = (TextBox)sender;
                book.book.id = int.Parse(((TextBox)sender).Attributes["bookid"]);
                book.quantity = quantity;
                CartBLL.SetBookCount(GetCart(), book);
            }
            DataRebind();
            return;
        }

        protected void btnSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (ViewState["selected"] == null)
            {
                ViewState["selected"] = new HashSet<int>();
            }
            CheckBox thisCheckBox = (CheckBox)sender;
            int bookid = int.Parse(thisCheckBox.Attributes["bookid"]);
            if (thisCheckBox.Checked)
            {
                ((HashSet<int>)ViewState["selected"]).Add(bookid);
            }
            else if(((HashSet<int>)ViewState["selected"]).Contains(bookid))
            {
                ((HashSet<int>)ViewState["selected"]).Remove(bookid);
            }
            UpdatePrice();
        }

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            if (Session["uid"] == null)
            {
                Response.Redirect("/login.aspx");
            }
            if (ViewState["selected"]==null)
            {
                return;
            }
            HashSet<int> seleted = (HashSet<int>)ViewState["selected"];
            if (seleted.Count==0)
            {
                return;
            }
            int userid = (int)Session["uid"];
            AddressModel address = AddressBLL.GetUserDefaultAddress(userid);
            if (address.id == 0)
            {
                Modal.Show(this, "你还没有收货地址,请前往个人中心添加");
                return;
            }
            CartModel cart = GetCart();

            OrderModel order = new OrderModel();
            order.address = address;
            foreach  (BookOrderModel orderBook in cart.book)
            {
                if (seleted.Contains(orderBook.book.id))
                {
                    orderBook.price = orderBook.book.price;
                    order.books.Add(orderBook);
                }
            }
            order.comment = "";
            order.dateTime = DateTime.Now;
            order.status = 0;
            order.CalculateTotalPrice();
            order.user.id = userid;
            int msg = OrderBLL.AddOrder(order);
            if (msg != -1)
            {
                foreach (BookOrderModel book in order.books)
                {
                    CartBLL.DeleteBook(userid, book.book.id);
                }
                Modal.Show(this, "下单成功，即将前往付款界面", 1000, "/placeorder.aspx?orderid=" + msg);
            }
            else
            {
                Modal.Show(this, "购买失败", 1000, HttpContext.Current.Request.Url.PathAndQuery);
            }
        }
    }
}