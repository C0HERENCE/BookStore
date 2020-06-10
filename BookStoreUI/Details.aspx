<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Details.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="BookStoreUI.Details" %>

<asp:Content ID="Content2" ContentPlaceHolderID="DetailContent" runat="server">
    <div id="product-image" class="col-sm-4 col-md-4">
        <asp:Image ID="imgCover" runat="server" Style="width: 100%;" ImageUrl="//cdn.shopify.com/s/files/1/1836/0759/products/11_dcb7a2bd-aee9-442f-b24f-2f14129fb5b3_1024x1024.jpg?v=1494838391" />
    </div>
    <div id="product-info" class="col-sm-8 col-md-8">
        <div class="row">
            <asp:Label ID="txtTitle" runat="server" Text="Golddax Product Example"></asp:Label>
            <p />
            <asp:Label ID="txtAuthor" runat="server" Text="Author: Christian Dior"></asp:Label>
            <p />
            <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
            <span class="fa fa-star checked"></span>
            <span class="fa fa-star checked"></span>
            <span class="fa fa-star checked"></span>
            <span class="fa fa-star"></span>
            <span class="fa fa-star"></span>
            <asp:Label ID="Label1" runat="server" Text="(2 reviews)"></asp:Label>
            <asp:Label ID="txtPrice" runat="server" Text="$200.00"></asp:Label>
            <p />
            <asp:Label ID="txtSummary" runat="server" Text="Our new HPB12 / A12 battery is rated at 2000mAh and designed to power up Black and Decker / FireStorm line of 12V tools allowing users to run multiple devices off the same battery pack. The HPB12 is compatible with the following Black and Decker power tool models"></asp:Label>
            <p />
            <input type="number" value="50" min="0" max="100" step="10" />
            <asp:Button ID="Button1" runat="server" Text="Add To Cart" />
        </div>
    </div>
</asp:Content>
