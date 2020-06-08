<%@ Page Title="" Language="C#" MasterPageFile="Masters/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BookStoreUI.Login" %>

<%@ Register Src="~/Controls/Modal.ascx" TagPrefix="uc1" TagName="Modal" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="login">
        <div class="card bg-light">
            <article class="card-body mx-auto" style="width: 400px;">
                <h4 class="card-title mt-3 text-center">登录</h4>
                <asp:Label ID="tips" runat="server" CssClass="pb-3 mb-3 text-center" Text="开始体验CC书店" Width="100%"></asp:Label>
                <div class="form-group input-group">
                    <div class="input-group-prepend">
                        <span class="input-group-text"><span class="icon iconfont icon-yonghu"></span></span>
                    </div>
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="用户名" />
                </div>
                <div class="form-group input-group">
                    <div class="input-group-prepend">
                        <span class="input-group-text"><span class="icon iconfont icon-mima"></span></span>
                    </div>
                    <asp:TextBox ID="txtPwd" runat="server" CssClass="form-control" placeholder="密码" TextMode="Password" />
                </div>
                <div class="form-group">
                    <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary btn-block" Text="登录" OnClick="btnLogin_Click"></asp:Button>
                </div>
                <asp:Panel ID="userpan" runat="server">
                    <p class="text-center">
                        还没有账号？
                <a href="/register">去注册</a>
                    </p>
                    <p class="text-center">
                        忘记密码？
                <a href="/forget">找回账号</a>
                    </p>

                    <p class="divider-text">
                        <span class="bg-light">其他方式登录</span>
                    </p>

                    <p>
                        <a href="#" class="btn btn-block btn-qq"><span class="icon iconfont icon-qq" style="cursor:not-allowed"></span>通过QQ登录</a>
                        <a href="#" class="btn btn-block btn-weixin"><span class="icon iconfont icon-weixin" style="cursor:not-allowed"></span>通过微信登录</a>
                    </p>

                </asp:Panel>
            </article>
        </div>
    </div>
    <uc1:Modal runat="server" id="Modal" />
</asp:Content>
