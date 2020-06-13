<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/SB_Master.Master" AutoEventWireup="true" CodeBehind="allusers.aspx.cs" Inherits="Dashboard.allusers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    用户管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="row">
        <div class="col-xl-3 col-md-6 mb-4">
            <div class="card border-left-info shadow h-100 py-2">
                <div class="card-body">
                    <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-info text-uppercase mb-1">用户总数</div>
                            <div class="h5 mb-0 font-weight-bold text-gray-800">
                                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-calendar fa-2x text-gray-300"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-12">
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">用户数据</h6>
            </div>
            <div class="card-body">
                <div class="form-row">
                    <div class="col">
                        <asp:TextBox ID="txtID" runat="server" AutoPostBack="true" AutoComplete="off"
                            placeholder="输入用户ID"
                            OnTextChanged="txtID_TextChanged"
                            CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col">
                        <asp:TextBox ID="txtKeyword" runat="server" AutoPostBack="true" AutoComplete="off"
                            placeholder="输入关键词(用户名，邮箱，手机号)"
                            OnTextChanged="txtKeyword_TextChanged"
                            CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <asp:GridView ID="UserTable" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
                    CssClass="table table-bordered dataTable"
                    OnRowDataBound="UserTable_RowDataBound"
                    AllowPaging="True" PageSize="10"
                    Width="100%"
                    OnPageIndexChanging="UserTable_PageIndexChanging"
                    OnRowCommand="UserTable_RowCommand">
                    <PagerSettings PageButtonCount="10" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="btnSelect" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="rownum" HeaderText="行号" ReadOnly="true" />
                        <asp:BoundField DataField="id" HeaderText="编号" ReadOnly="true" Visible="true" />
                        <asp:HyperLinkField DataTextField="username" HeaderText="用户名"
                            DataNavigateUrlFields="id"
                            DataNavigateUrlFormatString="/dashboard/UserDetail.aspx?userid={0}" />
                        <asp:BoundField DataField="gender" HeaderText="性别" ReadOnly="true" />
                        <asp:BoundField DataField="mail" HeaderText="邮箱" ReadOnly="true" />
                        <asp:BoundField DataField="tel" HeaderText="手机" ReadOnly="true" />
                        <asp:BoundField DataField="enabled" HeaderText="状态" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />
                        <asp:BoundField DataField="balance" HeaderText="余额" ReadOnly="true" />
                        <asp:TemplateField HeaderText="管理">
                            <ItemTemplate>
                                <asp:Button ID="btnBan" runat="server" CommandName="BanUser" CommandArgument='<%#Eval("id") %>' Text="...." />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <p />
                <asp:CheckBox ID="btnAll" runat="server" Text="全选"
                    OnCheckedChanged="btnAll_CheckedChanged" AutoPostBack="true" />
                每页显示
        <asp:DropDownList runat="server" ID="ddlPage" AutoPostBack="true" OnSelectedIndexChanged="ddlPage_SelectedIndexChanged">
            <asp:ListItem Text="5" Value="5"></asp:ListItem>
            <asp:ListItem Text="10" Value="10" Selected="True"></asp:ListItem>
            <asp:ListItem Text="20" Value="20"></asp:ListItem>
            <asp:ListItem Text="50" Value="50"></asp:ListItem>
            <asp:ListItem Text="100" Value="100"></asp:ListItem>
        </asp:DropDownList>
                <asp:Button ID="btnBatchEnable" runat="server" Text="批量解封" OnClick="btnBatchBan_Click" CssClass="btn btn-success" />
                <asp:Button ID="btnBatchBan" runat="server" Text="批量封禁" OnClick="btnBatchBan_Click" CssClass="btn btn-danger" />
                <p />
            </div>
        </div>
    </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
    <script type="text/javascript">
        $('[href="allusers.aspx"]').addClass('active').parent().parent().collapse('show').parent().addClass('active')
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="StylePlaceHolder" runat="server">
    <style type="text/css">
        .Hide {
            display: none;
        }
    </style>
</asp:Content>
