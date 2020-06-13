<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/SB_Master.Master" AutoEventWireup="true" CodeBehind="bookstock.aspx.cs" Inherits="Dashboard.bookstock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    商品库存、售价和状态管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="row">
        <div class="col-xl-3 col-md-6 mb-4">
            <div class="card border-left-primary shadow h-100 py-2">
                <div class="card-body">
                    <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">正在销售的图书</div>
                            <div class="h5 mb-0 font-weight-bold text-gray-800">
                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
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
                    <h6 class="m-0 font-weight-bold text-primary">图书数据</h6>
                </div>
                <div class="card-body">
                    <div class="form-row">
                        <div class="col">
                            <asp:TextBox ID="txtID" runat="server" AutoPostBack="true" AutoComplete="off"
                                placeholder="输入图书ID"
                                OnTextChanged="txtID_TextChanged"
                                CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col">
                            <asp:TextBox ID="txtKeyword" runat="server" AutoPostBack="true" AutoComplete="off"
                                placeholder="输入关键词(标题，ISBN，作者，出版社，分类)"
                                OnTextChanged="txtKeyword_TextChanged"
                                CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <asp:GridView ID="BookTable" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
                        CssClass="table table-bordered dataTable"
                        OnRowDataBound="BookTable_RowDataBound"
                        AllowPaging="True" PageSize="10"
                        Width="100%"
                        OnPageIndexChanging="BookTable_PageIndexChanging"
                        OnRowCancelingEdit="BookTable_RowCancelingEdit"
                        OnRowEditing="BookTable_RowEditing"
                        OnRowUpdating="BookTable_RowUpdating"
                        OnRowCommand="BookTable_RowCommand">
                        <PagerSettings PageButtonCount="10" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="btnSelect" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="onsale" HeaderText="状态" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" />
                            <asp:BoundField DataField="id" HeaderText="编号" ReadOnly="true" />
                            <asp:HyperLinkField DataTextField="title" HeaderText="书名"
                                DataNavigateUrlFields="id"
                                DataNavigateUrlFormatString="/dashboard/bookdetail.aspx?bookid={0}" />
                            <asp:BoundField DataField="author" HeaderText="作者" ReadOnly="true" />
                            <asp:BoundField DataField="publisher" HeaderText="出版社" ReadOnly="true" />
                            <asp:BoundField DataField="category" HeaderText="分类" ReadOnly="true" />
                            <asp:BoundField DataField="price" HeaderText="售价" />
                            <asp:BoundField DataField="stock" HeaderText="库存" />
                            <asp:TemplateField HeaderText="管理">
                                <ItemTemplate>
                                    <asp:Button ID="btnBan" runat="server" CommandName="BanBook" CommandArgument='<%#Eval("id") %>' CssClass="btn btn-sm btn-warning" Text="编辑中" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField HeaderText="修改" ButtonType="Button" EditText="修改" ControlStyle-CssClass="btn btn-primary btn-sm" ShowEditButton="true" />
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
                    <asp:Button ID="btnBatchEnable" runat="server" Text="批量上架" OnClick="btnBatchEnable_Click" CssClass="btn btn-success" />
                    <asp:Button ID="btnBatchBan" runat="server" Text="批量停售" OnClick="btnBatchBan_Click" CssClass="btn btn-danger" />
                    <p />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
    <script>
        $('[href="bookstock.aspx"]').addClass('active').parent().parent().collapse('show').parent().addClass('active')
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="StylePlaceHolder" runat="server">

    <style type="text/css">
        .Hide {
            display: none;
        }
    </style>
</asp:Content>
