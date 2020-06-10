<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Navbar.ascx.cs" Inherits="BookStoreUI.Controls.Navbar" %>
<nav class="navbar sticky-top navbar-expand-md navbar-light bg-light">
    <div class="container">
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>

        <a class="navbar-brand" href="/index.aspx">CC 书店</a>
        <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav mr-auto mt-2 mt-lg-0">

                <asp:PlaceHolder ID="content" runat="server"></asp:PlaceHolder>
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" id="dropdown08" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">更多分类</a>
                    <div class="dropdown-menu" aria-labelledby="dropdown08">
                        <asp:PlaceHolder ID="content2" runat="server"></asp:PlaceHolder>
                    </div>
                </li>
            </ul>

            <div class="form-inline float-right">
                <input class="form-control" type="text" placeholder="全站搜索" aria-label="Search">
            </div>

        </div>
    </div>
</nav>
