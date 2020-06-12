<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Main.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="BookStoreUI.Profile" %>

<%@ Register Src="~/Controls/AddressAddModal.ascx" TagPrefix="uc1" TagName="AddressAddModal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StyleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="container">
    <div class="row">
        <div class="col-sm-10">
            <h1>用户名</h1></div>
        <div class="col-sm-2">
            <a href="/users" class="pull-right"><img title="profile image" class="img-circle img-responsive" src="https://bootdey.com/img/Content/avatar/avatar1.png"></a>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-3">
            <ul class="list-group">
                <li class="list-group-item text-muted">个人资料</li>
                <li class="list-group-item"><span class="pull-left"><strong>注册时间：</strong></span> 2.13.2014</li>
                <li class="list-group-item"><span class="pull-left"><strong>上次登录：</strong></span> 昨天</li>
                <li class="list-group-item"><span class="pull-left"><strong>注册邮箱：</strong></span> 749976734@qq.com</li>

            </ul>
        </div>

        <div class="col-sm-9">

                <div class="tab-pane active show" id="home">
                        <div class="form-group">
                            <div class="col-xs-6">
                                <label for="first_name">
                                    <h4>First name</h4></label>
                                <input type="text" class="form-control" name="first_name" id="first_name" placeholder="first name" title="enter your first name if any.">
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-6">
                                <label for="last_name">
                                    <h4>Last name</h4></label>
                                <input type="text" class="form-control" name="last_name" id="last_name" placeholder="last name" title="enter your last name if any.">
                            </div>
                        </div>
                        <div class="form-group">

                            <div class="col-xs-6">
                                <label for="phone">
                                    <h4>Phone</h4></label>
                                <input type="text" class="form-control" name="phone" id="phone" placeholder="enter phone" title="enter your phone number if any.">
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-6">
                                <label for="mobile">
                                    <h4>Mobile</h4></label>
                                <input type="text" class="form-control" name="mobile" id="mobile" placeholder="enter mobile number" title="enter your mobile number if any.">
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-6">
                                <label for="email">
                                    <h4>Email</h4></label>
                                <input type="email" class="form-control" name="email" id="email" placeholder="you@email.com" title="enter your email.">
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-6">
                                <label for="email">
                                    <h4>Location</h4></label>
                                <input type="email" class="form-control" id="location" placeholder="somewhere" title="enter a location">
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <br>
                                <button class="btn btn-lg btn-success" type="submit"><i class="glyphicon glyphicon-ok-sign"></i> Save</button>
                                <button class="btn btn-lg" type="reset"><i class="glyphicon glyphicon-repeat"></i> Reset</button>
                            </div>
                        </div>
                </div>
                <div class="tab-pane" id="settings">

                    <hr>
                    <div class="form" action="##" method="post" id="registrationForm">
                        <div class="form-group">

                            <div class="col-xs-6">
                                <label for="password">
                                    <h4>原密码</h4></label>
                                <input type="password" class="form-control" name="password" id="password" placeholder="输入原密码" title="enter your password.">
                            </div>
                        </div>
                        <div class="form-group">

                            <div class="col-xs-6">
                                <label for="password2">
                                    <h4>新密码</h4></label>
                                <input type="password" class="form-control" name="password2" id="password2" placeholder="输入新密码" title="enter your password2.">
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <br>
                                <button class="btn btn-primary"><i class="glyphicon glyphicon-ok-sign"></i> 修改</button>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="tab-pane" id="address">
                    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="新增收货地址" CssClass="btn btn-primary"/>
                    <div class="list-group">
                        <asp:PlaceHolder ID="addresscontent" runat="server"></asp:PlaceHolder>
                    </div>
                    <uc1:AddressAddModal runat="server" id="AddressAddModal" />
                </div>

        </div>
    </div>

</div>
</asp:Content>
