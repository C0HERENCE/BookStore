<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryBookRow.ascx.cs" Inherits="BookStoreUI.Controls.CategoryBookRow" %>
<div class="bookdetailrow row shadow p-2 mb-3 bg-white rounded">
    <div class="col-lg-3">
        <asp:HyperLink ID="linkImg" runat="server" OnPreRender="linkImg_PreRender">
            <asp:Image ID="imgCover" runat="server" Width="100%" CssClass="img-thumbnail" OnPreRender="imgCover_PreRender" />
        </asp:HyperLink>
    </div>
    <div class="col-lg-7">
        <asp:HyperLink ID="linkMid" runat="server" CssClass="text-decoration-none" OnPreRender="linkMid_PreRender">

            <p class="h4">
                《<asp:Label ID="txtTitle" runat="server" Text="TITLE" CssClass="font-weight-bold" OnPreRender="txtTitle_PreRender"></asp:Label>》
            </p>
            <p class="text-muted">
                作者：
            <asp:Label ID="txtAuthor" runat="server" Text="余华 莎士比亚" OnPreRender="txtAuthor_PreRender"></asp:Label>
                出版社：
            <asp:Label ID="txtPublisher" runat="server" Text="温州大学出版社" OnPreRender="txtPublisher_PreRender"></asp:Label>
            </p>
            <p class="text-muted text-truncate">
                <small>
                    <asp:Label ID="txtSummary" runat="server" Text="..."
                        Style="display: -webkit-box; display: -moz-box; white-space: pre-wrap; -webkit-box-orient: vertical; -webkit-line-clamp: 7;" OnPreRender="txtSummary_PreRender"></asp:Label>
                </small>
            </p>

        </asp:HyperLink>
    </div>
    <div class="col-lg-2">
        <p class="text-muted mb-0">
            <h3>
                <span><del><small>
                    <asp:Label ID="txtOriginPrice" runat="server" Text="32" CssClass="text-muted" Font-Size="Smaller" OnPreRender="txtOriginPrice_PreRender"></asp:Label></small></del></span>
                <asp:Label ID="txtPrice" runat="server" Text="332" class="text-primary font-weight-bold" OnPreRender="txtPrice_PreRender"></asp:Label>
            </h3>
        </p>
        <p>
        </p>
        <p>
            <asp:Label ID="txtStars" runat="server" Text="3.6" OnPreRender="txtStars_PreRender"></asp:Label>/5.0
        </p>
        <p class="text-muted">
            <asp:Label ID="txtSales" runat="server" Text="总销量：332" OnPreRender="txtSales_PreRender"></asp:Label>
        </p>
        <div style="text-align: center;">
            <asp:LinkButton ID="btnDetail" runat="server" class="btn btn-primary big-btn rounded-pill mb-2" Style="width: 6rem;">
                <span class="icon iconfont icon-fangdajing float-left"></span>
                详情
            </asp:LinkButton>
            <asp:LinkButton ID="btnAddCart" runat="server" class="btn btn-primary big-btn rounded-pill mb-2" Style="width: 6rem;">
                <span class="icon iconfont icon-gouwuche1 float-left"></span>
                购物车
            </asp:LinkButton>
        </div>
    </div>
</div>
