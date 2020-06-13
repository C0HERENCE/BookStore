<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/SB_Master.Master" AutoEventWireup="true" CodeBehind="userdetail.aspx.cs" Inherits="Dashboard.userdetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    用户详情
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="row my-4">
        <div class="col-4">
            <div class="form-row">
                <div class="col">
                    <label>用户ID</label>
                    <asp:TextBox runat="server" ID="txtuserid" AutoComplete="off" CssClass="form-control" placeholder="请输入用户编号"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="col">
                    <asp:Button runat="server" ID="btnCheck" CssClass="btn btn-primary my-3" OnClick="txtuserid_TextChanged" Text="查看"/>
                </div>
            </div>
        </div>
    </div>
    <div class="row my-4">
        <div class="col-8 col-sm-12">
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary">用户资料</h6>
                </div>

                <div class="card-body">
                    <div class="tab-pane active show" id="home">
                        <div class="form-row">
                            <div class="form-group col-md-4">
                                <label for="first_name">昵称: </label>
                                <asp:Label ID="txtNickName" runat="server"></asp:Label>
                            </div>
                            <div class="form-group col-md-5">
                                <label for="first_name">手机号: </label>
                                <asp:Label ID="txtTel" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-4">
                                <label for="first_name">注册时间: </label>
                                <asp:Label ID="TextRegDate" runat="server"></asp:Label>
                            </div>
                            <div class="form-group col-md-5">
                                <label for="first_name">注册邮箱: </label>
                                <asp:Label ID="txtMail" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-4">
                                <label for="first_name">性别: </label>
                                <asp:Label ID="txtGender" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-3">
                                <label for="first_name">余额: </label>
                                <asp:Label ID="txtBalance" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
    <script>
        $('[href="userdetail.aspx"]').addClass('active').parent().parent().collapse('show').parent().addClass('active')
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="StylePlaceHolder" runat="server">
</asp:Content>
