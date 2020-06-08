using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStoreBLL;

namespace BookStoreUI
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BookRow.SetTitle("Biaoti", "di");
            BookRow.SetBooks(BookStatBLL.GetNewestBooks(5));
            BookRow1.SetTitle("Biaoti", "di");
            BookRow2.SetTitle("Biaoti", "di");
        }
    }
}