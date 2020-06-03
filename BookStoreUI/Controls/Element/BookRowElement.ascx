<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BookRowElement.ascx.cs" Inherits="BookStoreUI.Controls.Element.BookRowElement" %>
<div class="bookrowele">
    <div class="card shadow">
        <asp:Image ID="Image1" runat="server" CssClass="card-img-top" ImageUrl="~/UI/Public/Images/selling1.jpg"/>
        <div class="card-body">
            <h5 class="card-title font-weight-bold">《{{book.title}}》</h5>
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
                <span class="card-text price font-weight-bold">{{book.price}}</span><span class="font-weight-bold">元</span>
            </div>
                
            <button class="btn btn-primary small-btn rounded-circle" id="addcart"><span class="icon iconfont icon-gouwuche1"></span></button>
                
            <button class="btn btn-primary small-btn rounded-circle" id="quickview"><span class="icon iconfont icon-fangdajing"></span></button>
                
            <a class="btn btn-primary big-btn rounded-pill" id="detail" href="details.html">查看详情</a>
        </div>
    </div>
</div>