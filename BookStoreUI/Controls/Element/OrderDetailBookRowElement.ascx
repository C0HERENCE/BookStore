<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrderDetailBookRowElement.ascx.cs" Inherits="BookStoreUI.Controls.Element.OrderDetailBookRowElement" %>

<li class="float-right books">
    <asp:HyperLink runat="server" ID="linkdetail"  >
        <asp:Image runat="server" CssClass="img-thumbnail m-1" data-toggle="tooltip" title="Disabled tooltip"  ID="img" Width="60" Height="80" />
    </asp:HyperLink>
</li>