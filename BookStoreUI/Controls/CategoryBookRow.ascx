<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryBookRow.ascx.cs" Inherits="BookStoreUI.Controls.CategoryBookRow" %>
<div class="bookdetailrow row">
        <div class="col-lg-3">
            <asp:Image ID="imgCover" runat="server" />
        </div>
        <div class="col-lg-9">
            <p class="h4"> 
                <asp:Label ID="txtTitle" runat="server" Text="TITLE"></asp:Label>
            </p>
<%--            <star-rating class="star text-muted" v-bind:increment="0.5"
                v-bind:max-rating="5"
                inactive-color="gray"
                active-color="orange"
                v-bind:star-size="20"
                :read-only=true
                :rating=book.star
                :show-rating=false>
            </star-rating>--%>
            <p class="text-muted">
                <asp:Label ID="txtSummary" runat="server" Text="SUMMARY"></asp:Label>
            </p>
            <asp:LinkButton ID="btnAddCart" runat="server" class="btn btn-primary big-btn rounded-pill">
                <span class="icon iconfont icon-gouwuche1"></span>
                加入购物车
            </asp:LinkButton>
            <asp:LinkButton ID="btnDetail" runat="server" class="btn btn-primary big-btn rounded-pill" >
                <span class="icon iconfont icon-fangdajing"></span>
                查看详情
            </asp:LinkButton>
        </div>
    </div>