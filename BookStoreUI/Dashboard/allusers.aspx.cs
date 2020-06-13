using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStoreDAL;
using BookStoreBLL;
using BookStoreMisc;
using System.Data.SqlClient;

namespace Dashboard
{
    public partial class allusers : System.Web.UI.Page
    {
        private void BindUserInfo()
        {
            string sql = "select row_number() over(order by id) rownum, id,username, reg_date,gender,mail,tel,enabled,balance from userinfo where role=0";
            UserTable.DataSource = SqlHelper.ExecuteDataTable(sql);
            UserTable.DataBind();
            btnAll.Checked = false;

            string sql2 = "select count(*) from userinfo where role=0 and enabled=1";
            Label2.Text = SqlHelper.ExecuteScalar(sql2).ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) BindUserInfo();
        }

        protected void UserTable_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[7].Text.Trim() == "1")
                {
                    e.Row.Cells[7].Text = "使用中";
                    e.Row.Cells[7].CssClass = "text-success";
                    ((Button)e.Row.Cells[9].FindControl("btnBan")).Text = "使用中";
                    ((Button)e.Row.Cells[9].FindControl("btnBan")).CssClass = "btn btn-sm btn-success";
                }              
                else
                {              
                    e.Row.Cells[7].Text = "已封禁";
                    e.Row.Cells[7].CssClass = "text-danger";
                    ((Button)e.Row.Cells[9].FindControl("btnBan")).Text = "已封禁";
                    ((Button)e.Row.Cells[9].FindControl("btnBan")).CssClass = "btn btn-sm btn-danger";
                }
                e.Row.Cells[8].Text = double.Parse(e.Row.Cells[8].Text).ToString("F2");
            }
        }

        protected void btnAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in UserTable.Rows)
            {
                ((CheckBox)row.Cells[0].FindControl("btnSelect")).Checked = btnAll.Checked;
            }
        }

        protected void btnBatchBan_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            foreach (GridViewRow row in UserTable.Rows)
            {
                if (((CheckBox)row.Cells[0].FindControl("btnSelect")).Checked)
                {
                    UserInfoModel user = UserInfoBLL.GetUserInfoByID((int)UserTable.DataKeys[row.RowIndex].Value);
                    user.enabled = btn.Text == "批量封禁" ? 0 : 1;
                    UserInfoBLL.SetNewInfo(user);
                }
            }
            BindUserInfo();
        }

        protected void UserTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            UserTable.PageIndex = e.NewPageIndex;
            btnAll.Checked = false;
            BindUserInfo();
        }

        protected void UserTable_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ss = 3;
        }

        protected void UserTable_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName=="BanUser")
            {
                int userid = int.Parse((string)e.CommandArgument);
                UserInfoModel user = UserInfoBLL.GetUserInfoByID(userid);
                user.enabled = user.enabled == 1 ? 0 : 1;
                UserInfoBLL.SetNewInfo(user);
                BindUserInfo();
            }
        }

        protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserTable.PageSize = int.Parse(ddlPage.SelectedValue);
            BindUserInfo();
        }

        protected void txtID_TextChanged(object sender, EventArgs e)
        {
            int userid = 0;
            if (int.TryParse(txtID.Text,out userid))
            {
                txtKeyword.Text = "";
                string sql = "select row_number() over(order by id) rownum, id,username, reg_date,gender,mail,tel,enabled,balance from userinfo where role=0 and id=@userid";
                UserTable.DataSource = SqlHelper.ExecuteDataTable(sql, new SqlParameter[] {
                new SqlParameter("userid",userid)
            });
                UserTable.DataBind();
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
            string sql = "select row_number() over(order by id) rownum, id,username, reg_date,gender,mail,tel,enabled,balance from userinfo where role=0 and username like @keyword or mail like @keyword or tel like @keyword";
            UserTable.DataSource = SqlHelper.ExecuteDataTable(sql, new SqlParameter[] {
                new SqlParameter("keyword","%" + txtKeyword.Text + "%")
            });
            UserTable.DataBind();
            btnAll.Checked = false;
        }
    }
}