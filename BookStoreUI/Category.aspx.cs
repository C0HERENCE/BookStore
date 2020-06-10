using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStoreUI.Controls;
using BookStoreBLL;

namespace BookStoreUI
{
    public partial class Category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["category"] == null)
            {
                Response.Redirect("/index.aspx");
            }
            else
            {

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void list_PreRender(object sender, EventArgs e)
        {
            BindData();
        }

        protected void BindData()
        {
            if (Request["category"] != null)
            {
                list.DataSource = BookInfoBLL.GetAllBookOfCategory(int.Parse(Request["category"]));
                list.DataBind();
            }
        }

        protected void pager_PreRender(object sender, EventArgs e)
        {
            // BindData();
        }
    }
}