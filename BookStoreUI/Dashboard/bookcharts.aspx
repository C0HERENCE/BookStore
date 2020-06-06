<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/SB_Master.Master" AutoEventWireup="true" CodeBehind="bookcharts.aspx.cs" Inherits="Dashboard.bookcharts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    商品图表
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
    <script>
            $('[href="bookcharts.aspx"]').parent().addClass('active');
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="StylePlaceHolder" runat="server">

</asp:Content>