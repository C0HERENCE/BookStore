<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/SB_Master.Master" AutoEventWireup="true" CodeBehind="orderdetail.aspx.cs" Inherits="Dashboard.orderdetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    订单详情
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
    <script>
        $('[href="orderdetail.aspx"]').addClass('active').parent().parent().collapse('show').parent().addClass('active')
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="StylePlaceHolder" runat="server">
    
</asp:Content>