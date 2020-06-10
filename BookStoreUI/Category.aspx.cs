using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStoreUI.Controls;

namespace BookStoreUI
{
    public partial class Category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["category"]==null)
            {
                Response.Redirect("/index.aspx");
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    CategoryBookRow bookRow = (CategoryBookRow)LoadControl("~/Controls/CategoryBookRow.ascx");

                    contentholder.Controls.Add(bookRow);
                }
            }
        }
    }
}