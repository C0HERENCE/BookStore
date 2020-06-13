<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopListElement.ascx.cs" Inherits="BookStoreUI.Controls.Element.TopListElement" %>
<div class="card">
    <div class="card-header">
        <h2 class="mb-0">
            <asp:Panel ID="Panel2" runat="server" CssClass="btn text-primary btn-block text-left" type="button" data-toggle="collapse" data-target="#identify">
                    <asp:Label ID="txtClientID" runat="server" Text="txtClientID" CssClass="rank"></asp:Label>
                    <asp:Label ID="txtTitle" runat="server" Text="Label" CssClass="rank"></asp:Label>
            </asp:Panel>
        </h2>
    </div>
    <asp:Panel ID="Panel1" runat="server" CssClass="collapse" data-parent="#Toplist">
        <div class="card-body text-muted">        
            <div class="card-image">
                <asp:Image ID="imgCover" runat="server" CssClass="card-img" ImageUrl="~/UI/Public/Images/selling1.jpg" />
            </div>
            <asp:Label ID="txtSales" runat="server" Text="Label" CssClass="text-danger"></asp:Label>
            <asp:Label ID="txtSummary" runat="server" Text="Label" CssClass="text-muted text-truncate small"
                Style="display: -webkit-box; display: -moz-box; white-space: pre-wrap; -webkit-box-orient: vertical; -webkit-line-clamp: 10;" ></asp:Label>
        </div>
        <div style="width:100%;text-align:center">
            <asp:HyperLink ID="linkDetail" runat="server" Text="查看详情" CssClass="btn btn-primary btn-sm"></asp:HyperLink>
        </div>
    </asp:Panel>
</div>

