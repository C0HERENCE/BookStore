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
            LatestBooksRow.SetTitle("最近更新", "Latest Books");
            LatestBooksRow.SetBooks(BookStatBLL.GetNewestBooks(5));
            BestSellersRow.SetTitle("当前热销", "Current Bestsellers");
            BestSellersRow.SetBooks(BookStatBLL.GetHighestStarsBooks(5));
            TopRatedBooksRow.SetTitle("评分最高","Top Rated Books");
            TopRatedBooksRow.SetBooks(BookStatBLL.GetHighestStarsBooks(5));
        }
    }
}