<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Main.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="BookStoreUI.Profile" %>

<%@ Register Src="~/Controls/AddressAddModal.ascx" TagPrefix="uc1" TagName="AddressAddModal" %>
<%@ Register Src="~/Controls/Modal.ascx" TagPrefix="uc1" TagName="Modal" %>


<asp:Content ID="Content1" ContentPlaceHolderID="StyleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row">
            <div class="col-sm-10">
                <h1>
                    <asp:Label ID="txtUserName" runat="server" Text="Label"></asp:Label>
                </h1>
            </div>
            <div class="col-sm-2">
                <a href="#" class="pull-right">
                    <asp:Image ID="imgAvatar" runat="server" CssClass="img-circle img-responsive" ImageUrl="/public/images/user/admin.jpg" Width="130" />
                </a>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-3">
                <ul class="list-group">
                    <li class="list-group-item text-muted">个人资料</li>
                    <li class="list-group-item"><span class="pull-left"><strong>注册时间：</strong></span>
                        <asp:Label ID="txtRegDate" runat="server" Text="399"></asp:Label>
                    </li>
                    <li class="list-group-item"><span class="pull-left"><strong>上次登录：</strong></span>
                        <asp:Label ID="txtLatestDate" runat="server" Text="Label"></asp:Label>
                    </li>
                    <li class="list-group-item"><span class="pull-left"><strong>注册邮箱：</strong></span>
                        <asp:Label ID="txtMail" runat="server" Text="Label"></asp:Label>
                    </li>

                </ul>
            </div>

            <div class="col-sm-9">

                <h1>个人资料</h1>
                <hr />
                <div class="tab-pane active show" id="home">
                    <div class="form-row">
                        <div class="form-group col-md-4">
                            <label for="first_name">昵称: </label>
                            <asp:TextBox ID="txtNickName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-5">
                            <label for="first_name">手机号: </label>
                            <asp:TextBox ID="txtTel" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-4">
                            <label for="first_name">性别: </label>
                            <asp:RadioButtonList ID="btnGender" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="1">男</asp:ListItem>
                                <asp:ListItem Value="0">女</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-3">
                            <label for="first_name">余额: </label>
                            <asp:TextBox ID="txtBalance" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group form-row">
                        <div class="col-xs-12">
                            <asp:Button id="btnModify" runat="server" CssClass="btn btn-primary" OnClick="btnModify_Click" Text="修改"/>
                            <asp:Button id="btnReset" runat="server" CssClass="btn btn-secondary" OnClick="btnReset_Click" Text="重置"/>
                        </div>
                    </div>
                </div>

                
                <h1>修改密码</h1>
                <hr />
                <div class="tab-pane" id="settings">
                    <div>
                        <div class="form-row">
                            <div class="form-group col-xs-6">
                                <label for="password">原密码</label>
                                <asp:TextBox ID="txtOriginPwd" runat="server" TextMode="Password" CssClass="form-control" placeholder="输入原密码"></asp:TextBox>
                            </div>
                            <div class="form-group col-xs-6">
                                <label for="password2">新密码 </label>
                                <asp:TextBox ID="txtNewPwd" runat="server" TextMode="Password" CssClass="form-control"  placeholder="输入新密码"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-xs-12">
                                <asp:Button ID="btnPwd" runat="server" Text="修改" CssClass="btn btn-primary" OnClick="btnPwd_Click" />
                            </div>
                        </div>
                    </div>
                </div>

                <h1>收货地址管理</h1>
                <hr />
                <div class="tab-pane" id="address">
                    <div class="form-row">
                        <div class="form-group col-xs-6">
                               <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="新增收货地址" CssClass="btn btn-primary" />
                        </div>
                        <div class="form-group col-xs-6">
                               当前共有
                            <asp:Label ID="txtAddressNum" runat="server" Text="1"></asp:Label>
                            个地址，最多可以保存5个收货地址
                        </div>
                    </div>
                    <div class="list-group">
                        <asp:PlaceHolder ID="addresscontent" runat="server"></asp:PlaceHolder>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <uc1:AddressAddModal runat="server" ID="AddressAddModal" />
    <uc1:Modal runat="server" ID="Modal" />
</asp:Content>
