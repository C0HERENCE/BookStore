<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Main.Master" AutoEventWireup="true" CodeBehind="PlaceOrder.aspx.cs" Inherits="BookStoreUI.PlaceOrder" %>

<%@ Register Src="~/Controls/OrderBookRow.ascx" TagPrefix="uc1" TagName="OrderBookRow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StyleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
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
                                    <div class="py-2">价格</div>
                                </th>
                                <th scope="col" class="border-0 bg-light">
                                    <div class="py-2">数量</div>
                                </th>
                                <th scope="col" class="border-0 bg-light">
                                    <div class="py-2">操作</div>
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <uc1:OrderBookRow runat="server" ID="OrderBookRow" />
                            <asp:ListView ID="list" runat="server" OnPreRender="list_PreRender">
                                <ItemTemplate>
                                    <uc1:OrderBookRow runat="server" ID="OrderBookRow" BookID='<%#Bind("id") %>' />
                                </ItemTemplate>
                            </asp:ListView>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>

        <div class="row py-5 p-4 bg-white rounded shadow-sm">
            <div class="col-lg-6">
                <div class="bg-light rounded-pill px-4 py-3 text-uppercase font-weight-bold">优惠码</div>
                <div class="p-4">
                    <p class="font-italic mb-4">如果你要使用优惠码，请填写在下方</p>
                    <div class="input-group mb-4 border rounded-pill p-2">
                        <input type="text" placeholder="填写优惠码" aria-describedby="button-addon3" class="form-control border-0">
                        <div class="input-group-append border-0">
                            <button id="button-addon3" type="button" class="btn btn-danger px-4 rounded-pill"><i class="fa fa-gift mr-2"></i>使用</button>
                        </div>
                    </div>
                </div>
                <div class="bg-light rounded-pill px-4 py-3 text-uppercase font-weight-bold">订单备注</div>
                <div class="p-4">
                    <p class="font-italic mb-4">如果你有备注的信息，可以写在这里</p>
                    <textarea name="" cols="30" rows="2" class="form-control"></textarea>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="bg-light rounded-pill px-4 py-3 text-uppercase font-weight-bold">订单总览 </div>
                <div class="p-4">
                    <p class="font-italic mb-4">邮费基于你的收获地址</p>
                    <ul class="list-unstyled mb-4">
                        <li class="d-flex justify-content-between py-3 border-bottom"><strong class="text-muted">订单总价 </strong><strong>
                            <asp:Label ID="txtOrderPrice" runat="server" Text="0.00"></asp:Label>元</strong></li>
                        <li class="d-flex justify-content-between py-3 border-bottom"><strong class="text-muted">邮费</strong><strong>
                            <asp:Label ID="txtExtraPrice" runat="server" Text="0.00"></asp:Label>元</strong></li>
                        <li class="d-flex justify-content-between py-3 border-bottom"><strong class="text-muted">优惠</strong><strong>
                            <asp:Label ID="txtOffPrice" runat="server" Text="0.00"></asp:Label>元</strong></li>
                        <li class="d-flex justify-content-between py-3 border-bottom"><strong class="text-muted">总价</strong>
                            <h5 class="font-weight-bold">
                                <asp:Label ID="txtTotalPrice" runat="server" Text="0.00">元</asp:Label>
                            </h5>
                        </li>
                    </ul>
                    <asp:Button ID="btnCheck" runat="server" CssClass="btn btn-success rounded-pill py-2 btn-block" Text="去结算" />
                </div>
            </div>
        </div>

    </div>
    <script src="Public/JS/bootstrap-input-spinner.js"></script>
    <script>
        $("input[type='number']").inputSpinner({
            buttonsClass: "btn-outline-primary",
            groupClass: "text-primary"
        });
    </script>
</asp:Content>
