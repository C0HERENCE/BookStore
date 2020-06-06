<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/SB_Master.Master" AutoEventWireup="true" CodeBehind="alltags.aspx.cs" Inherits="Dashboard.alltags" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    标签和分类
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
    <script>
        $('[href="alltags.aspx"]').addClass('active').parent().parent().collapse('show').parent().addClass('active')
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="StylePlaceHolder" runat="server">
    
</asp:Content>