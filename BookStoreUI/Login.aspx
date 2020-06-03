<%@ Page Title="" Language="C#" MasterPageFile="Masters/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BookStoreUI.Login" %>

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
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="用户名/手机号/邮箱" />
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
                        <a href="#" class="btn btn-block btn-qq"><span class="icon iconfont icon-qq"></span>通过QQ登录</a>
                        <a href="#" class="btn btn-block btn-weixin"><span class="icon iconfont icon-weixin"></span>通过微信登录</a>
                    </p>

                </asp:Panel>
            </article>
        </div>
    </div>

    <div class="modal fade" id="LoginModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="LoginModalLabel">提示</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    ...
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-dismiss="modal">确定</button>
                </div>
            </div>
        </div>
    </div>
    <script>
        var showSuccess = function () {
            $('#LoginModal .modal-body').text('登录成功, 即将跳转到后台管理系统');
            $('#LoginModal').modal('show');
            setTimeout(function () {
                document.location.href = "dashboard.aspx";
            }, 1000);
        }
        var showError = function () {
            $('#LoginModal .modal-body').text('登陆失败');
            $('#LoginModal').modal('show');
        }
    </script>
</asp:Content>
