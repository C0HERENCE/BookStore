using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStoreBLL;
using BookStoreDAL;
using BookStoreMisc;

namespace Dashboard
{
    public partial class bookstock : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUserInfo();
            }
        }
        private void BindUserInfo()
        {
            string sql = "select * from bookstat_full";
            BookTable.DataSource = SqlHelper.ExecuteDataTable(sql);
            BookTable.DataBind();
            btnAll.Checked = false;
            txtID.Text = "";
            txtKeyword.Text = "";
            Label1.Text = BookStatBLL.GetBookOnSaleCount().ToString();
        }

        protected void BookTable_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (BookTable.EditIndex != -1)
            {
                return;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[1].Text.Trim() == "1")
                {
                    ((Button)e.Row.Cells[9].FindControl("btnBan")).Text = "在售";
                    ((Button)e.Row.Cells[9].FindControl("btnBan")).CssClass = "btn btn-sm btn-success";
                }
                else
                {
                    ((Button)e.Row.Cells[9].FindControl("btnBan")).Text = "已停售";
                    ((Button)e.Row.Cells[9].FindControl("btnBan")).CssClass = "btn btn-sm btn-danger";
                }
                e.Row.Cells[7].Text = double.Parse(e.Row.Cells[7].Text).ToString("F2");
            }
        }

        protected void BookTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BookTable.PageIndex = e.NewPageIndex;
            btnAll.Checked = false;
            BindUserInfo();
        }

        protected void BookTable_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (BookTable.EditIndex != -1)
            {
                return;
            }
            if (e.CommandName == "BanBook")
            {
                int bookid = int.Parse((string)e.CommandArgument);
                BookStatModel book = BookStatBLL.GetBookByID(bookid);
                BookStatBLL.SetBookOnSale(bookid, book.onsale == 1 ? 0 : 1);
                BindUserInfo();
            }
        }

        protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            BookTable.PageSize = int.Parse(ddlPage.SelectedValue);
            BindUserInfo();
        }

        protected void btnBatchBan_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            foreach (GridViewRow row in BookTable.Rows)
            {
                if (((CheckBox)row.Cells[0].FindControl("btnSelect")).Checked)
                {
                    BookStatModel book = BookStatBLL.GetBookByID((int)BookTable.DataKeys[row.RowIndex].Value);
                    BookStatBLL.SetBookOnSale(book.id, 0);
                }
            }
            BindUserInfo();
        }

        protected void btnBatchEnable_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            foreach (GridViewRow row in BookTable.Rows)
            {
                if (((CheckBox)row.Cells[0].FindControl("btnSelect")).Checked)
                {
                    BookStatModel book = BookStatBLL.GetBookByID((int)BookTable.DataKeys[row.RowIndex].Value);
                    BookStatBLL.SetBookOnSale(book.id, 1);
                }
            }
            BindUserInfo();
        }

        protected void txtID_TextChanged(object sender, EventArgs e)
        {
            int bookid = 0;
            if (int.TryParse(txtID.Text, out bookid))
            {
                txtKeyword.Text = "";
                string sql = "select * from bookstat_full where id=@bookid";
                BookTable.DataSource = SqlHelper.ExecuteDataTable(sql, new SqlParameter[] {
                new SqlParameter("bookid",bookid)
            });
                BookTable.DataBind();
                btnAll.Checked = false;
            }
            else
            {
                txtID.Text = "";
                BindUserInfo();
            }
        }

        protected void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            txtID.Text = "";
            string sql = "select * from bookstat_full where title like @keyword or category like @keyword or isbn like @keyword or author like @keyword or publisher like @keyword";
            BookTable.DataSource = SqlHelper.ExecuteDataTable(sql, new SqlParameter[] {
                new SqlParameter("keyword","%" + txtKeyword.Text + "%")
            });
            BookTable.DataBind();
            btnAll.Checked = false;
        }

        protected void btnAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in BookTable.Rows)
            {
                ((CheckBox)row.Cells[0].FindControl("btnSelect")).Checked = btnAll.Checked;
            }
        }

        protected void BookTable_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            BookTable.EditIndex = -1;
            BindUserInfo();
        }

        protected void BookTable_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string idStr = BookTable.DataKeys[e.NewEditIndex].Value.ToString();
            BookTable.EditIndex = e.NewEditIndex;
            BindUserInfo();
        }

        protected void BookTable_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int bookid = (int)BookTable.DataKeys[e.RowIndex].Value;
            BookStatModel book = BookStatBLL.GetBookByID(bookid);
            ;
            int newStock = 0;
            if (int.TryParse(e.NewValues["stock"].ToString(), out newStock))
            {
                book.stock = newStock;
                BookStatBLL.SetBook(book);
            }
            double newPrice = 0;
            if (double.TryParse(e.NewValues["price"].ToString(), out newPrice))
            {
                book.price = newPrice;
                BookStatBLL.SetBook(book);
            }

            BookTable.EditIndex = -1;
            BindUserInfo();
        }
    }
}