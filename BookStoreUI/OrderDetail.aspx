<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Main.Master" AutoEventWireup="true" CodeBehind="OrderDetail.aspx.cs" Inherits="BookStoreUI.OrderDetail" %>

<%@ Register Src="~/Controls/OrderBookRow.ascx" TagPrefix="uc1" TagName="OrderBookRow" %>
<%@ Register Src="~/Controls/AddressAddModal.ascx" TagPrefix="uc1" TagName="AddressAddModal" %>
<%@ Register Src="~/Controls/AddressRow.ascx" TagPrefix="uc1" TagName="AddressRow" %>
<%@ Register Src="~/Controls/Modal.ascx" TagPrefix="uc1" TagName="Modal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StyleContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row small text-muted">
            <div class="col-2">
                订单编号:
                <asp:Label ID="txtOrderID" runat="server" Text="100001"></asp:Label>
            </div>
            <div class="col-2">
                用户编号:
                <asp:Label ID="txtUserID" runat="server" Text="100001"></asp:Label>
            </div>
            <div class="col-3">
                创建时间:
                <asp:Label ID="txtDateTime" runat="server" Text="100001"></asp:Label>
            </div>
            <div class="col-3">
                订单状态:
                <asp:Label ID="txtStatus" runat="server" Text="100001"></asp:Label>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12 p-1 bg-white rounded shadow-sm mb-5">
                <div class="table-responsive">
                    <table class="table">
                        <thead>
                            <tr>
                                <th scope="col" class="border-0 bg-light">
                                    <div class="p-2 px-3">名称</div>
                                </th>
                                <th scope="col" class="border-0 bg-light">
                                    <div class="py-2">单价</div>
                                </th>
                                <th scope="col" class="border-0 bg-light">
                                    <div class="py-2">数量</div>
                                </th>
                                <th scope="col" class="border-0 bg-light">
                                    <div class="py-2">合计</div>
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder ID="orderBookContent" runat="server"></asp:PlaceHolder>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>

        <div class="row">
            <uc1:AddressRow runat="server" ID="AddressRowManage" />
        </div>

        <div class="row py-5 p-4 bg-white rounded shadow-sm">
            <div class="col-lg-6">
                <div class="bg-light rounded-pill px-4 py-3 text-uppercase font-weight-bold">优惠码</div>
                <div class="p-4">
                    <p class="font-italic mb-4">没有使用优惠码</p>

                </div>
                <div class="bg-light rounded-pill px-4 py-3 text-uppercase font-weight-bold">订单备注</div>
                <div class="p-4">
                    <p class="font-italic mb-4"></p>
                    <asp:TextBox ID="txtComment" runat="server" class="form-control" cols="30" Rows="2" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="bg-light rounded-pill px-4 py-3 text-uppercase font-weight-bold">订单总览 </div>
                <div class="p-4">
                    <p class="font-italic mb-4"></p>
                    <ul class="list-unstyled mb-4">
                        <li class="d-flex justify-content-between py-3 border-bottom"><strong class="text-muted">商品总价 </strong><strong>
                            <asp:Label ID="txtOrderPrice" runat="server" Text="0.00"></asp:Label>元</strong></li>
                        <li class="d-flex justify-content-between py-3 border-bottom"><strong class="text-muted">邮费</strong><strong>
                            <asp:Label ID="txtExtraPrice" runat="server" Text="0.00"></asp:Label>元</strong></li>
                        <li class="d-flex justify-content-between py-3 border-bottom"><strong class="text-muted">优惠</strong><strong>
                            -<asp:Label ID="txtOffPrice" runat="server" Text="0.00"></asp:Label>元</strong></li>
                        <li class="d-flex justify-content-between py-3 border-bottom"><strong class="text-muted">需要付款</strong>
                            <h5 class="font-weight-bold">
                                <asp:Label ID="txtTotalPrice" runat="server" Text="0.00">元</asp:Label>
                            </h5>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
