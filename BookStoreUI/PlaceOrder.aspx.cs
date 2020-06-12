using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStoreBLL;

namespace BookStoreUI
{
    public partial class PlaceOrder : System.Web.UI.Page
    {
        public int OrderPrice = 0;
        public int ExtraPrice = 0;
        public int OffPrice = 0;
        public int TotalPrice = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
            if (IsPostBack)
            {
                //OrderPrice = OrderBookRow.TextBox1.Text;
                TotalPrice = OrderPrice + ExtraPrice - OffPrice;
                txtTotalPrice.Text = OrderBookRow.txtNum.Text;
            }
        }

        protected void list_PreRender(object sender, EventArgs e)
        {
            
        }

        protected void BindData()
        {
            if (Request["book"] != null) // 立即结算
            {
                int id = int.Parse(Request["book"]);
                OrderBookRow.BookID = id;
                OrderBookRow.SetBook(id);
            }
            else if (Request["book[]"] !=null ) // 购物车结算
            {
                OrderBookRow.Visible = false;
                list.DataSource = BookInfoBLL.GetAllBookOfCategory(int.Parse(Request["book[]"]));
                list.DataBind();
            }
        }
    }
}