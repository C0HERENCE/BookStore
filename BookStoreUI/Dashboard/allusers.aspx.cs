using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dashboard
{
    public partial class allusers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(GridView1.ClientID+"xxxxxxxxxxxx");
            List<int> ss = new List<int>();
            ss.Add(2);
            ss.Add(3);
            GridView1.DataSource = ss;
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a = 2;
        }
    }
}