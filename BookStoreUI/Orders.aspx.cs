using BookStoreBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStoreUI
{
    public partial class Orders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void list_PreRender(object sender, EventArgs e)
        {
            if (Session["uid"] == null)
            {
                Response.Redirect("/login.aspx");
            }
            list.DataSource = OrderBLL.GetOrdersByUserID((int)Session["uid"]);
            list.DataBind();
        }
    }
}