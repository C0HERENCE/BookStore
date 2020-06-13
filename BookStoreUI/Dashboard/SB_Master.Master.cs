using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dashboard
{
    public partial class SB_Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnquit_Click(object sender, EventArgs e)
        {
            Session["uid"] = null;
            Session["uname"] = null;
            Session["isadmin"] = null;
            Response.Redirect("/Index.aspx");
        }
    }
}