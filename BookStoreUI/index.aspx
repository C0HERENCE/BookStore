<%@ Page Title="" Language="C#" MasterPageFile="Masters/Main.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="BookStoreUI.index" %>

<%@ Register Src="Controls/Navbar.ascx" TagPrefix="uc1" TagName="Navbar" %>
<%@ Register Src="Controls/WelcomeHeader.ascx" TagPrefix="uc1" TagName="WelcomeHeader" %>
<%@ Register Src="Controls/WeeklyBook.ascx" TagPrefix="uc1" TagName="WeeklyBook" %>
<%@ Register Src="Controls/Carousel.ascx" TagPrefix="uc1" TagName="Carousel" %>
<%@ Register Src="Controls/TopList.ascx" TagPrefix="uc1" TagName="TopList" %>
<%@ Register Src="Controls/BookRow.ascx" TagPrefix="uc1" TagName="BookRow" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:WelcomeHeader runat="server" ID="WelcomeHeader" />
    <uc1:Navbar runat="server" ID="Navbar" />
    <div class="container mt-0">
        <uc1:Carousel runat="server" ID="Carousel" />
        <uc1:WeeklyBook runat="server" ID="WeeklyBook" />
        <div class="row">
            <div class="col-sm-12 col-xl-3">
                <uc1:TopList runat="server" ID="TopList" NameTefst="D" />
            </div>
            <div class="col-sm-12 col-xl-9">
                <uc1:BookRow runat="server" ID="LatestBooksRow" />
                <uc1:BookRow runat="server" ID="BestSellersRow" />
                <uc1:BookRow runat="server" ID="TopRatedBooksRow" />
            </div>
        </div>

    </div>
</asp:Content>
