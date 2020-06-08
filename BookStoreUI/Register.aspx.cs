using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStoreMisc;

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

        string msgCode="";

        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            msgCode = random.Next(0, 9999).ToString("0000");
            MailValidation.SendValidation(txtMail.Text, msgCode);
        }
    }
}