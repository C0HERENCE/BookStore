<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WeeklyBook.ascx.cs" Inherits="BookStoreUI.Controls.WeeklyBook" %>

<div class="card mb-3" style="max-width: 100%;margin-top:3rem">
    <div class="row no-gutters">
        <div class="col-md-3">
            <asp:Image ID="imgCover" runat="server" ImageUrl="~/UI/Public/Images/selling1.jpg" CssClass="card-img img-thumbnail" Width="100%"/>
        </div>
        <div class="col-md-8">
            <div class="card-body">
                <h5 class="card-title">
                <span class="iconfont icon-open-book-"></span>本周推荐</h5>
                <h2 class="card-title">
                    <asp:Label ID="txtTitle" runat="server" 
                        Text="Label"></asp:Label>
                </h2>
                <p class="text-muted">
                    <asp:Label ID="txtSummry" runat="server" Text="Label" CssClass="text-muted text-truncate small"
                    Style="display: -webkit-box; display: -moz-box; white-space: pre-wrap; -webkit-box-orient: vertical; -webkit-line-clamp: 10;"></asp:Label>
                </p>
                <span class="text-muted"><del>
                    <asp:Label ID="txtOriginPrice" runat="server" Text="txtOriginPrice"></asp:Label>元</del></span>
                <span class="badge badge-pill badge-success">60% off</span>
                <span class="text-danger" style="font-size:2rem">
                    <asp:Label ID="txtPrice" runat="server" Text="300"></asp:Label>元
                </span>
                <asp:hyperlink ID="linkDetail" runat="server" cssclass="btn float-right btn-primary">查看详情</asp:hyperlink>
            </div>
        </div>
    </div>
</div>