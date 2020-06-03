<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WelcomeHeader.ascx.cs" Inherits="BookStoreUI.Controls.WelcomeHeader" %>


<div class="jumbotron" style="margin-bottom: 0px;">
    <div class="container">
        <h2 class="display-4"><asp:Label ID="Label1" runat="server" Text="欢迎来到CC书店！"></asp:Label>
        </h2>
        <asp:Panel ID="Panel1" runat="server">
            <p class="lead">
                CC书店注重推广阅读、激发创意、深耕文化、提升心灵。</p>
            <hr class="my-4">
            <p>
                现在加入，立刻开始体验CC书店</p>
            <a class="btn btn-primary btn-lg" href="register.aspx" role="button">注册一个新账号</a>
            <a class="btn btn-info btn-lg" href="login.aspx" role="button">已有帐号，登录</a>
        </asp:Panel>
    </div>
</div>