using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStoreUI.Controls
{
    public partial class CategoryBookRow : System.Web.UI.UserControl
    {
        public String Title { get; set; }
        public String ImageUrl { get; set; }
        public String Summary { get; set; }
        public String OriginPrice { get; set; }
        public String Publisher { get; set; }
        public String Author { get; set; }
        public Double Price { get; set; }
        public Double Stars { get; set; }
        public Int32 BookID { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtTitle_PreRender(object sender, EventArgs e)
        {
            txtTitle.Text = Title.ToString();
        }

        protected void txtSummary_PreRender(object sender, EventArgs e)
        {
            txtSummary.Text = "简介: " + Summary.Trim();
        }

        protected void imgCover_PreRender(object sender, EventArgs e)
        {
            imgCover.ImageUrl = "/public/images/cover/" + ImageUrl;
        }

        protected void txtAuthor_PreRender(object sender, EventArgs e)
        {
            txtAuthor.Text = Author;
        }

        protected void txtOriginPrice_PreRender(object sender, EventArgs e)
        {
            txtOriginPrice.Text = OriginPrice;
        }

        protected void txtPrice_PreRender(object sender, EventArgs e)
        {
            txtPrice.Text = "￥" + Price.ToString("F2");
        }

        protected void txtPublisher_PreRender(object sender, EventArgs e)
        {
            txtPublisher.Text = Publisher;
        }

        protected void txtSales_PreRender(object sender, EventArgs e)
        {
            txtSales.Text = 2.ToString();
        }

        protected void txtStars_PreRender(object sender, EventArgs e)
        {
            txtStars.Text = Stars.ToString();
        }

        protected void linkImg_PreRender(object sender, EventArgs e)
        {
            linkImg.NavigateUrl = "/details.aspx?book=" + BookID.ToString();
        }

        protected void linkMid_PreRender(object sender, EventArgs e)
        {
            linkMid.NavigateUrl = "/details.aspx?book=" + BookID.ToString();
        }
    }
}