<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Details.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="BookStoreUI.Details" %>

<%@ Register Src="~/Controls/Modal.ascx" TagPrefix="uc1" TagName="Modal" %>


<asp:Content ID="Content2" ContentPlaceHolderID="DetailContent" runat="server">
    <div class="row">
        <div id="product-image" class="col-sm-4 col-md-4">
            <asp:Image ID="imgCover" runat="server" Style="width: 100%;" CssClass="img-thumbnail" ImageUrl="//cdn.shopify.com/s/files/1/1836/0759/products/11_dcb7a2bd-aee9-442f-b24f-2f14129fb5b3_1024x1024.jpg?v=1494838391" />
        </div>
        <div id="product-info" class="col-sm-8 col-md-8">
            <h3>
                <asp:Label ID="txtTitle" runat="server" Text="Golddax Product Example"></asp:Label>
            </h3>
            <h4>
                <asp:Label ID="txtOriginTitle" runat="server" Text="Golddax Product Example"></asp:Label>
            </h4>
            <p />
            <asp:Label ID="txtAuthor" runat="server" Text="Author: Christian Dior"></asp:Label>
            <p />
            <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
            <span class="fa fa-star checked"></span>
            <span class="fa fa-star checked"></span>
            <span class="fa fa-star checked"></span>
            <span class="fa fa-star"></span>
            <span class="fa fa-star"></span>
            <asp:Label ID="txtStars" runat="server" Text="(2 reviews)"></asp:Label>
            <asp:Label ID="txtPrice" runat="server" Text="$200.00" CssClass="text-danger" Font-Size="X-Large"></asp:Label>
            <p />
            <asp:Label ID="txtSummary" runat="server" 
                CssClass="text-muted text-truncate small"
                Style="display: -webkit-box; display: -moz-box; white-space: pre-wrap; -webkit-box-orient: vertical; -webkit-line-clamp: 4;" 
                Text="Our new HPB12 / A12 battery is rated at 2000mAh and designed to power up Black and Decker / FireStorm line of 12V tools allowing users to run multiple devices off the same battery pack. The HPB12 is compatible with the following Black and Decker power tool models"></asp:Label>
            <p />
            <div class="row">
                <div class="d-inline-block col-lg-2 col-sm-6 small text-danger" style="line-height:2.6;text-align:center;">
                    <asp:Label ID="txtStock" runat="server"></asp:Label>
                </div>
                <div class="col-lg-4 col-sm-6">
                    <asp:TextBox ID="txtNum" runat="server" type="number" value="1" min="1" max="100" step="1"></asp:TextBox>
                </div>
                <div class="col-lg-3 col-sm-6">
                    <asp:Button ID="btnCart" runat="server" Text="加入购物车" CssClass="btn btn-outline-primary" style="width:100%" />
                </div>
                <div class="col-lg-3 col-sm-6">
                    <asp:Button ID="btnBuy" runat="server" Text="立即购买" CssClass="btn btn-primary" style="width:100%" OnClick="btnBuy_Click"/>
                </div>
            </div>
        </div>
    </div>
    <div class="row p-3">
        <table class="table table-bordered table-sm">
            <tbody>
                <tr>
                    <th scope="row" class="bg-light" style="width: 200px">产品名称</th>
                    <td>
                        <asp:Label ID="tdTitle" runat="server" Text="Golddax Product Example"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th scope="row" class="bg-light" style="width: 200px">作者</th>
                    <td>
                        <asp:Label ID="tdAuthor" runat="server" Text="Golddax Product Example"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th scope="row" class="bg-light" style="width: 200px">页数</th>
                    <td>
                        <asp:Label ID="tdPages" runat="server" Text="Golddax Product Example"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th scope="row" class="bg-light" style="width: 200px">定价</th>
                    <td>
                        <asp:Label ID="tdPrice" runat="server" Text="Golddax Product Example"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th scope="row" class="bg-light" style="width: 200px">ISBN</th>
                    <td>
                        <asp:Label ID="tdISBN" runat="server" Text="Golddax Product Example"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th scope="row" class="bg-light" style="width: 200px">出版社</th>
                    <td>
                        <asp:Label ID="tdPublisher" runat="server" Text="Golddax Product Example"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th scope="row" class="bg-light" style="width: 200px">出版日期</th>
                    <td>
                        <asp:Label ID="tdPubdate" runat="server" Text="Golddax Product Example"></asp:Label>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>

    <div class="row m-0">
        <div class="col-md-12">
            <div class="list-group list-group-horizontal-sm" id="list-tab" role="tablist">
                <a class="list-group-item list-group-item-action active text-center p-1" data-toggle="list" href="#list-1" role="tab">介绍</a>
                <a class="list-group-item list-group-item-action text-center p-1" data-toggle="list" href="#list-2" role="tab">目录</a>
                <a class="list-group-item list-group-item-action disabled text-center p-1" data-toggle="list" href="#list-3" role="tab">评价</a>
            </div>
        </div>
        <div class="col-12">
            <div class="tab-content" id="nav-tabContent">
                <div class="tab-pane fade text-muted show active" id="list-1" role="tabpanel" aria-labelledby="list-settings-list">
                    <asp:Label ID="tabSummary" runat="server" Text="Golddax Product Example"></asp:Label>
                </div>
                <div class="tab-pane fade text-muted" id="list-2" role="tabpanel" aria-labelledby="list-profile-list">
                    <asp:Label ID="tabCatalog" runat="server" Text="Golddax Product Example"></asp:Label>
                </div>
                <div class="tab-pane fade text-muted" id="list-3" role="tabpanel" aria-labelledby="list-messages-list">
                    暂无
                </div>
            </div>
        </div>
    </div> 
    <uc1:Modal runat="server" ID="Modal" />
    <script src="Public/JS/bootstrap-input-spinner.js"></script>
    <script>
        $('#' + '<%=txtNum.ClientID%>').inputSpinner({
            buttonsClass: "btn-outline-primary",
            groupClass: "text-primary"
        });
    </script>
</asp:Content>
