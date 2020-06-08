using System;
using System.Web.UI;

namespace BookStoreUI.Controls
{
    public partial class Modal : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Show(Page page, string message)
        {
            page.ClientScript.RegisterStartupScript(page.ClientScript.GetType(), "", "<script>showModal('" + message + "');</script>");
        }

        public void Show(Page page, string message, int time, string path)
        {
            page.ClientScript.RegisterStartupScript(page.ClientScript.GetType(), "", "<script>showModal('" + message + "');setTimeout(function(){document.location.href='" + path + "';}," + time + ");</script>");
        }
    }
}