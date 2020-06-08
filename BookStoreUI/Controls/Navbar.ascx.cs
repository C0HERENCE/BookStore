using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStoreMisc;
using BookStoreBLL;
using BookStoreUI.Controls.Element;

namespace BookStoreUI.Controls
{
    public partial class Navbar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SetLinks(List<CategoryModel> categories)
        {
            int limit = 4;
            int i = 0;
            foreach (CategoryModel category in categories)
            {
                if (i> limit)
                {
                    HyperLink link = new HyperLink();
                    link.CssClass = "dropdown-item";
                    link.Text = category.name;
                    link.NavigateUrl = "category.aspx?category=" + category.id;
                    content2.Controls.Add(link);
                }
                else
                {
                    NavBarElement element = (NavBarElement)LoadControl("~/Controls/Element/NavBarElement.ascx");
                    element.SetLink(category);
                    content.Controls.Add(element);
                }
                i++;
            }
        }
    }
}