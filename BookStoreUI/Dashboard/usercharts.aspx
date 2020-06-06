<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/SB_Master.Master" AutoEventWireup="true" CodeBehind="usercharts.aspx.cs" Inherits="Dashboard.usercharts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    用户图表
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
    <script>
        $('[href="usercharts.aspx"]').parent().addClass('active');
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="StylePlaceHolder" runat="server">
    
</asp:Content>