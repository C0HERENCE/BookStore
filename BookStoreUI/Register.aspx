<%@ Page Title="" Language="C#" MasterPageFile="Masters/Main.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="BookStoreUI.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel1" runat="server" CssClass="register1">
    <div class="card bg-light">
        <article class="card-body mx-auto" style="width: 400px;">
            <h4 class="card-title mt-3 text-center">创建一个新账户</h4>
            <p class="text-center">开始体验CC书店</p>
            <p>
                <a href="#" class="btn btn-block btn-qq"> <span class="icon iconfont icon-qq"></span>通过QQ注册</a>
                <a href="#" class="btn btn-block btn-weixin"> <span class="icon iconfont icon-weixin"></span>通过微信注册</a>
            </p>
            <p class="divider-text">
                <span class="bg-light">或通过邮箱注册</span>
            </p>


            <div class="form-group input-group">
                <div class="input-group-prepend">
                    <span class="input-group-text"> <span class="icon iconfont icon-shouji"></span></span>
                </div>
                <asp:TextBox ID="TextBox1" runat="server" Text="" CssClass="form-control"  placeholder="邮箱地址"></asp:TextBox>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="邮箱地址不能为空" ControlToValidate="Label1"></asp:RequiredFieldValidator>--%>
                <asp:Button ID="Button1" runat="server" Text="发送验证码" CssClass="btn btn-primary" OnClick="Button1_Click"/>
            </div>
            <div class="form-group input-group">
                <div class="input-group-prepend">
                    <span class="input-group-text"><span class="icon iconfont icon-mima"></span> </span>
                </div>
                <asp:TextBox ID="TextBox2" runat="server" Text="" CssClass="form-control"  placeholder="输入6位验证码"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:button runat="server" type="submit" class="btn btn-primary btn-block" Text="下一步" OnClick="Unnamed2_Click"></asp:button>
            </div>
          
            <p class="text-center">已有账号？
                <a href="login.aspx">去登录</a>
            </p>

        </article> 
    </div>
</asp:Panel>

<asp:Panel ID="Panel2" runat="server" CssClass="register2" Visible="false">
    <div class="card bg-light">
        <article class="card-body mx-auto" style="width: 400px;">
            <h4 class="card-title mt-3 text-center">创建一个新账户</h4>
            <p class="divider-text">
                <span class="bg-light">完善以下信息</span>
            </p>

            <div class="form-group input-group">
                <div class="input-group-prepend">
                    <span class="input-group-text"><span class="icon iconfont icon-yonghu"></span> </span>
                </div>
                <asp:TextBox ID="TextBox3" runat="server" placeholder="用户名" CssClass="form-control"></asp:TextBox>
            </div> <!-- form-group// -->
            <div class="form-group input-group">
                <div class="input-group-prepend">
                    <span class="input-group-text"> <span class="icon iconfont icon-youxiang"></span></span>
                </div>
                <asp:TextBox ID="TextBox4" runat="server" type="email" CssClass="form-control inline-block" placeholder="邮箱"></asp:TextBox>
            </div> <!-- form-group// -->
            
            <div class="form-group input-group">
                <div class="input-group-prepend">
                    <span class="input-group-text"><span class="icon iconfont icon-mima"></span></span>
                </div>
                <asp:TextBox ID="TextBox5" runat="server" placeholder="输入密码" TextMode="Password" CssClass="form-control"></asp:TextBox>
            </div> <!-- form-group// -->
            <div class="form-group input-group">
                <div class="input-group-prepend">
                    <span class="input-group-text"><span class="icon iconfont icon-mima1"></span> </span>
                </div>
                <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control" placeholder="重复密码"></asp:TextBox>
            </div> <!-- form-group// --> 
              <div class="form-group">
                  <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-primary btn-block" OnClick="LinkButton1_Click">注册</asp:LinkButton>                
            </div> <!-- form-group// -->     

        </article> 
    </div>  
</asp:Panel>
</asp:Content>

