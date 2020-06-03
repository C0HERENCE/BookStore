<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WeeklyBook.ascx.cs" Inherits="BookStoreUI.Controls.WeeklyBook" %>

<div class="card mb-3" style="max-width: 100%;margin-top:3rem">
    <div class="row no-gutters">
        <div class="col-md-4">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/UI/Public/Images/selling1.jpg" CssClass="card-img"/>
        </div>
        <div class="col-md-8">
            <div class="card-body">
                <h5 class="card-title">
                <span class="iconfont icon-open-book-"></span>本周推荐</h5>
                <h2 class="card-title">{{week.title}}</h2>
                <p class="text-muted">{{week.desc}}</p>
                <span class="text-muted"><del>{{week.price}}元</del></span>
                <span class="badge badge-pill badge-success">60% off</span>
                <span class="text-danger" style="font-size:2rem">
                    <asp:Label ID="Label1" runat="server" Text="{{week.price*0.4}}"></asp:Label>元
                </span>
                <a class="btn float-right btn-primary" href="details.html">查看详情</a>
            </div>
        </div>
    </div>
</div>