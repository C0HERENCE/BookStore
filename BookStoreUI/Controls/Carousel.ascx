<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Carousel.ascx.cs" Inherits="BookStoreUI.Controls.Carousel" %>
<div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
    <ol class="carousel-indicators">
        <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
        <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
        <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
    </ol>
    <div class="carousel-inner">
        <div class="carousel-item active">
            <asp:Image ID="Image1" runat="server" CssClass="d-block w-100" ImageUrl="~/Public/Images/1.jpg"/>
        </div>
        <div class="carousel-item">
            <asp:Image ID="Image2" runat="server" CssClass="d-block w-100" ImageUrl="~/Public/Images/2.jpg"/>
        </div>
        <div class="carousel-item">
            <asp:Image ID="Image3" runat="server" CssClass="d-block w-100" ImageUrl="~/Public/Images/3.jpg"/>
        </div>
    </div>
    <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
        <span class="sr-only">Previous</span>
    </a>
    <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
        <span class="carousel-control-next-icon" aria-hidden="true"></span>
        <span class="sr-only">Next</span>
    </a>
</div>