<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BookRowElement.ascx.cs" Inherits="BookStoreUI.Controls.Element.BookRowElement" %>
<li class="itemInCovers">
    <div class="bookrowele">
        <div class="card shadow">
        <asp:Image ID="imgCover" runat="server" CssClass="card-img-top" Height="250" ImageUrl="~/Public/Images/Cover/s1011204.jpg"/>
            <div class="card-body">
                <h5 class="card-title font-weight-bold">
                    <asp:Label ID="txtBookTitle" runat="server" Text="bookTitle" CssClass="d-inline-block text-truncate"></asp:Label>
                    </h5>
                <div id="description">
                    <span class="card-text price font-weight-bold">
                        <asp:Label ID="txtPrice" runat="server" Text="txtPrice"></asp:Label>
                    </span><span class="font-weight-bold">元</span>
                </div>
                <asp:HyperLink ID="linkDetail" CssClass="btn btn-primary big-btn rounded-pill" runat="server" Text="查看详情" runat="server" />
            </div>
        </div>
    </div>
</li>
