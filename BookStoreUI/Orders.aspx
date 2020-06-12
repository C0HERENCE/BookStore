<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Main.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="BookStoreUI.Orders" %>

<%@ Register Src="~/Controls/OrderDetailBookRow.ascx" TagPrefix="uc1" TagName="OrderDetailBookRow" %>

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
                opacity:0.4;
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
                        </span>的订单</h4>
                    </div>
                    <div class="col-auto text-center my-auto pl-0 pt-sm-4">
                        <p class="mb-4 pt-0 Glasses">CC 书店</p>
                    </div>
                </div>
            </div>
            <div class="card-body">
                <div class="row justify-content-between mb-3">
                    <div class="col-auto">
                        <h6 class="color-1 mb-0 change-color">所有订单</h6>
                    </div>
                    <div class="col-auto ">
                        <small>用户编号 : 
                            <asp:Label ID="txtUserID" runat="server" Text="2"></asp:Label>
                        </small>
                    </div>
                </div>

                <asp:ListView ID="list" runat="server" OnPreRender="list_PreRender">
                    <ItemTemplate>
                        <uc1:OrderDetailBookRow runat="server" ID="OrderDetailBookRow"
                            OrderInThisControl='<%#((BookStoreMisc.OrderModel)Container.DataItem)%>'/>
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

            </div>
        </div>
    </div>
    <script>
        $('document').ready(function () {
            $('[data-toggle="tooltip"]').tooltip();
        });
    </script>
</asp:Content>
