using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStoreUI
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isadmin"] != null && (bool)Session["isadmin"] == true && Session["uname"] != null)
            {
                txtUname.Text = Session["uname"].ToString();
                imgAvartar.ImageUrl = "../Public/Images/User/admin.jpg";
            }
            else
            {
                Response.Redirect("login.aspx?isadmin=true");
            }
        }

        protected void AllBookView_Click(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(AllBookView);
        }

        protected void AddBookView_Click(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(AddBookView);
        }

        protected void EditBookView_Click(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(EditBookView);
        }

        protected void CatagoryEditView_Click(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(CatagoryEditView);
        }

        protected void StorageView_Click(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(StorageView);
        }

        protected void SellsView_Click(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(SellsView);
        }

        protected void ProfitView_Click(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(ProfitView);
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session["isadmin"] = null;
            Session["uname"] = null;
            Response.Redirect("index.aspx");
        }
    }
}