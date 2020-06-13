<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Main.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="BookStoreUI.Cart" %>

<%@ Register Src="~/Controls/Modal.ascx" TagPrefix="uc1" TagName="Modal" %>


<asp:Content ID="Content1" ContentPlaceHolderID="StyleContent" runat="server">
    <style>
        p {
            font-size: 14px;
            margin-bottom: 7px
        }

        .small {
            letter-spacing: 0.5px !important
        }

        hr {
            background-color: rgba(248, 248, 248, 0.667)
        }

        .change-color {
            color: #007bff !important
        }

        .books {
            list-style: none;
        }

            .books:hover img {
                opacity: 0.4;
            }

        .card-2 {
            box-shadow: 1px 1px 3px 0px rgb(112, 115, 139)
        }

        .fa-circle.active {
            font-size: 8px;
            color: #007bff
        }

        .fa-circle {
            font-size: 8px;
            color: #aaa
        }

        .rounded {
            border-radius: 2.25rem !important
        }

        .progress-bar {
            background-color: #007bff !important
        }

        .progress {
            height: 5px !important;
            margin-bottom: 0
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">

        <nav aria-label="breadcrumb" class="bg-light">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="#">首页</a></li>
                <li class="breadcrumb-item"><a href="#">经济</a></li>
                <li class="breadcrumb-item active" aria-current="page">经济学人</li>
            </ol>
        </nav>

        <div class="card card-1">
            <div class="card-header bg-white">
                <div class="media flex-sm-row flex-column-reverse justify-content-between ">
                    <div class="col my-auto">
                        <h4 class="mb-0"><span class="change-color">
                            <asp:Label ID="txtUserName" runat="server" Text="ccwisp2"></asp:Label>
                        </span>的购物车</h4>
                    </div>
                    <div class="col-auto text-center my-auto pl-0 pt-sm-4">
                        <p class="mb-4 pt-0 Glasses">CC 书店</p>
                    </div>
                </div>
            </div>
            <div class="card-body">
                <div class="row justify-content-between mb-3">
                    <div class="col-auto">
                        <h6 class="color-1 mb-0 change-color">购物车</h6>
                    </div>
                    <div class="col-auto ">
                        <small>用户编号 : 
                            <asp:Label ID="txtUserID" runat="server" Text="2"></asp:Label>
                        </small>
                    </div>
                </div>

                <asp:ListView ID="list" runat="server" OnPreRender="list_PreRender" OnItemCommand="list_ItemCommand">
                    <ItemTemplate>
                        <div class="row" runat="server">
                            <div class="col-1 align-middle form-check pt-4">
                                <asp:CheckBox ID="btnSelect" runat="server" AutoPostBack="true"
                                    OnCheckedChanged="btnSelect_CheckedChanged"
                                    bookid='<%#((BookStoreMisc.BookOrderModel)Container.DataItem).book.id%>'
                                    />
                            </div>
                            <div class="p-2 col-4">
                                <asp:Image CssClass="img-thumbnail shadow-sm" runat="server" ID="imgCover" Width="60" Height="70" ImageUrl='<%#("/public/images/cover/"+((BookStoreMisc.BookOrderModel)Container.DataItem).book.image)%>' />
                                <div class="ml-3 d-inline-block align-middle">
                                    <h5 class="mb-0">
                                        <asp:HyperLink ID="linkDetail" runat="server" CssClass="text-dark d-inline-block"
                                            Text='<%#((BookStoreMisc.BookOrderModel)Container.DataItem).book.title%>'
                                            NavigateUrl='<%#("/details.aspx?book="+((BookStoreMisc.BookOrderModel)(Container.DataItem)).book.id.ToString())%>'></asp:HyperLink>
                                    </h5>
                                    <span class="text-muted font-weight-normal font-italic">分类: 
        <asp:Label ID="txtCategory" runat="server" Text='<%#((BookStoreMisc.BookOrderModel)Container.DataItem).book.category%>'></asp:Label>
                                    </span>
                                </div>
                            </div>
                            <div class="align-middle col-3">
                                <strong>
                                    <asp:Label ID="txtPrice" runat="server" Text='<%#((BookStoreMisc.BookOrderModel)Container.DataItem).book.price%>'></asp:Label>
                                    元</strong>
                            </div>
                            <div class="align-middle col-2">
                                <asp:TextBox ID="txtNum" runat="server"
                                    Text='<%#((BookStoreMisc.BookOrderModel)Container.DataItem).quantity%>'
                                    CssClass="form-control"
                                    Style="width: 50px"
                                    autocomplete="off"
                                    AutoPostBack="true"
                                    OnTextChanged="txtNum_TextChanged"
                                    bookid='<%#((BookStoreMisc.BookOrderModel)Container.DataItem).book.id%>'>
                                </asp:TextBox>
                            </div>
                            <div class="align-middle col-2">
                                <asp:Button ID="btnDelete" runat="server" CommandName="btnDelete" CommandArgument='<%#(((BookStoreMisc.BookOrderModel)Container.DataItem).book.id.ToString())%>' CssClass="btn btn-danger rounded-pill" Text="删除" />
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:ListView>

                <div style="width: 100%; text-align: center;">
                    <asp:DataPager ID="pager" runat="server" PagedControlID="list" PageSize="6">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ButtonCssClass="btn btn-outline-primary" />
                            <asp:NumericPagerField ButtonCount="6" ButtonType="Button" NextPreviousButtonCssClass="btn btn-outline-primary" NumericButtonCssClass="btn btn-outline-primary" />
                            <asp:NextPreviousPagerField ButtonCssClass="btn btn-outline-primary" ButtonType="Button" ShowLastPageButton="True" ShowPreviousPageButton="False" />
                        </Fields>
                    </asp:DataPager>
                </div>
                <div class="row">
                    <div class="col-lg-6 offset-6">
                        <div class="bg-light rounded-pill px-4 py-3 text-uppercase font-weight-bold text-right">商品总价
                            <strong><asp:Label ID="txtOrderPrice" runat="server" Text="0.00"></asp:Label>元</strong>
                            <asp:Button ID="btnPlaceOrder" runat="server" CssClass="btn btn-success rounded-pill py-2 mx-4" Text="立即下单" OnClick="btnPlaceOrder_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <uc1:Modal runat="server" ID="Modal" />
</asp:Content>
