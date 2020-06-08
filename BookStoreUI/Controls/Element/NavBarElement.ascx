<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavBarElement.ascx.cs" Inherits="BookStoreUI.Controls.Element.NavBarElement" %>
<li class="nav-item">
    <asp:HyperLink ID="Link" runat="server"
        CssClass="nav-link"
        NavigateUrl="category.aspx?category="
        Text=""></asp:HyperLink>
</li>