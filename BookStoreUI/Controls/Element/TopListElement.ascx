<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopListElement.ascx.cs" Inherits="BookStoreUI.Controls.Element.TopListElement" %>
<div class="card">
    <div class="card-header">
        <h2 class="mb-0">
            <asp:Panel ID="Panel2" runat="server" CssClass="btn text-primary btn-block text-left" type="button" data-toggle="collapse" data-target="#identify">
                    <asp:Label ID="Label1" runat="server" Text="Label" CssClass="rank"></asp:Label>
                    <asp:Label ID="Label2" runat="server" Text="Label" CssClass="rank"></asp:Label>
            </asp:Panel>
        </h2>
    </div>
    <asp:Panel ID="Panel1" runat="server" CssClass="collapse" data-parent="#Toplist">
        <div class="card-body text-muted">        
            <div class="card-image">
                <asp:Image ID="Image1" runat="server" CssClass="card-img" ImageUrl="~/UI/Public/Images/selling1.jpg" />
            </div>
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        </div>
        <div style="width:100%;text-align:center">
            <asp:Button ID="Button1" runat="server" Text="查看详情" CssClass="btn btn-primary btn-sm"/>
        </div>
    </asp:Panel>
</div>

