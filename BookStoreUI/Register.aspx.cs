using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStoreUI
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('nihao')</script>");
            Panel1.Visible = false;
            Panel2.Visible = true;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('nihao')</script>");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('nihao')</script>");
        }
    }
}