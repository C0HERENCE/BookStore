<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/SB_Master.Master" AutoEventWireup="true" CodeBehind="allorders.aspx.cs" Inherits="Dashboard.allorders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    订单管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
    <script>
        $('[href="allorders.aspx"]').addClass('active').parent().parent().collapse('show').parent().addClass('active')
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="StylePlaceHolder" runat="server">
    
</asp:Content>