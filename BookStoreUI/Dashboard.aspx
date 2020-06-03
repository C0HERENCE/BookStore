<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="BookStoreUI.Dashboard" %>

<%@ Register Src="Controls/Dashboard/BookManageControls/BookDataTable.ascx" TagPrefix="uc1" TagName="BookDataTable" %>
<%@ Register Src="Controls/Dashboard/BookManageControls/BookEdit.ascx" TagPrefix="uc1" TagName="BookEdit" %>
<%@ Register Src="Controls/Dashboard/BookManageControls/BookInsert.ascx" TagPrefix="uc1" TagName="BookInsert" %>
<%@ Register Src="Controls/Dashboard/BookManageControls/BookStat.ascx" TagPrefix="uc1" TagName="BookStat" %>
<%@ Register Src="Controls/Dashboard/BookManageControls/CatagoryManage.ascx" TagPrefix="uc1" TagName="CatagoryManage" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <link rel="stylesheet" href="../Public/CSS/LayUI/css/layui.css" />
</head>
<body class="layui-layout-body">
    <form id="form1" runat="server">
        <asp:Button ID="btnLogout" runat="server" Text="Button" OnClick="Logout_Click" style="display:none"/>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="layui-layout layui-layout-admin">
            <div class="layui-header">
                <%--顶栏--%>
                <div class="layui-logo">CC书店 后台管理系统</div>
                <ul class="layui-nav layui-layout-right">
                    <li class="layui-nav-item">
                        <a href="javascript:;">
                            <asp:Image ID="imgAvartar" runat="server" CssClass="layui-nav-img" />
                            <asp:Label ID="txtUname" runat="server" Text=""></asp:Label>
                        </a>
                        <dl class="layui-nav-child">
                            <dd><a href="#">基本资料</a></dd>
                            <dd><a href="#">安全设置</a></dd>
                        </dl>
                    </li>
                    <li class="layui-nav-item">
                        <a data-method="notice" id="btnLogOut" href="#" onclick="logLoutConfirm('<%=btnLogout.ClientID %>');">注销</a>
                    </li>
                </ul>
            </div>
            <%--边栏--%>
            <div class="layui-side layui-bg-black">
                <div class="layui-side-scroll">
                    <ul class="layui-nav layui-nav-tree" lay-filter="lay_sidebar">
                        <li class="layui-nav-item layui-nav-itemed"><a class="" href="javascript:;">所有商品</a>
                            <dl class="layui-nav-child">
                                <dd class="layui-this">
                                    <asp:LinkButton runat="server" ID="link11" OnClick="AllBookView_Click">图书查看</asp:LinkButton></dd>
                                <dd>
                                    <asp:LinkButton runat="server" ID="link12" OnClick="AddBookView_Click">图书入库</asp:LinkButton></dd>
                                <dd>
                                    <asp:LinkButton runat="server" ID="link13" OnClick="CatagoryEditView_Click">分类管理</asp:LinkButton></dd>
                                <dd>
                                    <asp:LinkButton runat="server" ID="link14" OnClick="SellsView_Click">统计信息</asp:LinkButton></dd>
                            </dl>
                        </li>
                        <li class="layui-nav-item"><a href="javascript:;">图书详情</a>
                            <dl class="layui-nav-child">
                                <dd>
                                    <asp:LinkButton runat="server" ID="link15" OnClick="EditBookView_Click">内容编辑</asp:LinkButton></dd>
                                <dd>
                                    <asp:LinkButton runat="server" ID="link16" OnClick="StorageView_Click">统计信息</asp:LinkButton></dd>
                            </dl>
                        </li>
                    </ul>
                </div>
            </div>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <%--主体内容--%>
                    <div class="layui-body">
                        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                            <asp:View ID="AllBookView" runat="server">
                                <uc1:BookDataTable runat="server" ID="BookDataTable" />
                            </asp:View>
                            <asp:View ID="AddBookView" runat="server">
                                <uc1:BookInsert runat="server" ID="BookInsert" />
                            </asp:View>
                            <asp:View ID="EditBookView" runat="server">
                                <uc1:BookEdit runat="server" ID="BookEdit" />
                            </asp:View>
                            <asp:View ID="CatagoryEditView" runat="server">
                                <uc1:CatagoryManage runat="server" ID="CatagoryManage3" />
                            </asp:View>
                            <asp:View ID="StorageView" runat="server">
                                <uc1:BookStat runat="server" ID="BookStat" />
                            </asp:View>
                            <asp:View ID="ProfitView" runat="server">
                                <uc1:BookStat runat="server" ID="BookStat1" />
                            </asp:View>
                            <asp:View ID="SellsView" runat="server">
                                <uc1:BookStat runat="server" ID="BookStat2" />
                            </asp:View>
                        </asp:MultiView>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="link11" EventName="Click"></asp:AsyncPostBackTrigger>
                    <asp:AsyncPostBackTrigger ControlID="link12" EventName="Click"></asp:AsyncPostBackTrigger>
                    <asp:AsyncPostBackTrigger ControlID="link13" EventName="Click"></asp:AsyncPostBackTrigger>
                    <asp:AsyncPostBackTrigger ControlID="link14" EventName="Click"></asp:AsyncPostBackTrigger>
                    <asp:AsyncPostBackTrigger ControlID="link15" EventName="Click"></asp:AsyncPostBackTrigger>
                    <asp:AsyncPostBackTrigger ControlID="link16" EventName="Click"></asp:AsyncPostBackTrigger>
                </Triggers>
            </asp:UpdatePanel>
            <%--底部--%>
            <div class="layui-footer">
                © CC书店 17信管1班10组
            </div>
        </div>
        
        <script src="../Public/JS/jquery-3.5.1.js"></script>
        <script src="../Public/CSS/LayUI/layui.all.js"></script>
        <script src="../Public/JS/Dashboard.js"></script>
    </form>
</body>
</html>
