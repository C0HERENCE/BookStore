using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStoreBLL;

namespace BookStoreUI.Controls
{
    public partial class WeeklyBook : System.Web.UI.UserControl
    {
        class IndexSettings
        {
            public int WeeklyBook;
            public string[] Banner;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            StreamReader responseReader = new StreamReader(Server.MapPath("~/IndexSettings.json"));
            string result = responseReader.ReadToEnd();
            IndexSettings settings = JsonConvert.DeserializeObject<IndexSettings>(result);
            var Book = BookStatBLL.GetBookByID(settings.WeeklyBook);
            txtPrice.Text = Book.price.ToString("F2");
            txtOriginPrice.Text = Book.origin_price;
            txtTitle.Text = Book.title;
            txtSummry.Text = Book.summary;
            linkDetail.NavigateUrl = "/details.aspx?book=" + Book.id.ToString();
            imgCover.ImageUrl = "/public/images/cover/" + Book.image;
        }
    }
}