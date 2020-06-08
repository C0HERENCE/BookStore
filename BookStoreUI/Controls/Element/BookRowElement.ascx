<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BookRowElement.ascx.cs" Inherits="BookStoreUI.Controls.Element.BookRowElement" %>
<li class="itemInCovers">
    <div class="bookrowele">
        <div class="card shadow">
        <asp:Image ID="imgCover" runat="server" CssClass="card-img-top" ImageUrl="~/Public/Images/Cover/s1011204.jpg"/>
            <div class="card-body">
                <h5 class="card-title font-weight-bold">《
                    <asp:Label ID="txtBookTitle" runat="server" Text="bookTitle"></asp:Label>
                    》</h5>
                <div id="description">
                    <!-- 
                    <star-rating class="star card-text text-muted" v-bind:increment="0.5"
                                v-bind:max-rating="5"
                                inactive-color="gray"
                                active-color="orange"
                                v-bind:star-size="20"
                                :read-only=true
                                :rating=book.star
                                :show-rating=false>
                    </star-rating>
                        -->
                    <span class="card-text price font-weight-bold">
                        <asp:Label ID="txtPrice" runat="server" Text="txtPrice"></asp:Label>
                    </span><span class="font-weight-bold">元</span>
                </div>
                
                <button class="btn btn-primary small-btn rounded-circle" id="addcart"><span class="icon iconfont icon-gouwuche1"></span></button>
                
                <button class="btn btn-primary small-btn rounded-circle" id="quickview"><span class="icon iconfont icon-fangdajing"></span></button>

                <asp:Button ID="detail" CssClass="btn btn-primary big-btn rounded-pill" runat="server" Text="查看详情" />
            </div>
        </div>
    </div>
</li>
