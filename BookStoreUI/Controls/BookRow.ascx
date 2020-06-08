<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BookRow.ascx.cs" Inherits="BookStoreUI.Controls.BookRow" %>
<%@ Register Src="~/Controls/Element/BookRowElement.ascx" TagPrefix="uc1" TagName="BookRowElement" %>
<div class="row bookrow">
        <div class="d-flex align-items-center" style="width:100%">
            <span class="iconfont icon" :class="rowData.icon"></span>
            <div class="p-2">
                <h1 class="text-left">
                    <asp:Label ID="txtName" runat="server" Text="txtName"></asp:Label>
                </h1>
                <p class="text-right">
                    <asp:Label ID="txtSubName" runat="server" Text="txtSubName"></asp:Label>
                </p>
            </div>
            <div class="p-2 flex-grow-1" style="text-align:right">
                <a href="#" class="btn btn-link">查看更多>></a>
            </div>
        </div>
        <div class="coverInfo">
            <ul>
                <asp:PlaceHolder runat="server" ID="booksContent"/>
            </ul>
        </div>
</div>