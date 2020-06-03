<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BookRow.ascx.cs" Inherits="BookStoreUI.Controls.BookRow" %>
<%@ Register Src="~/Controls/Element/BookRowElement.ascx" TagPrefix="uc1" TagName="BookRowElement" %>
<uc1:BookRowElement runat="server" ID="BookRowElement7" />
<div class="row bookrow">
        <div class="d-flex align-items-center" style="width:100%">
            <span class="iconfont icon" :class="rowData.icon"></span>
            <div class="p-2">
                <h1 class="text-left">{{rowData.title}}</h1>
                <p class="text-right">{{rowData.secondtitle}}</p>
            </div>
            <div class="p-2 flex-grow-1" style="text-align:right">
                <a href="specials.html#/" class="btn btn-link">查看更多>></a>
            </div>
        </div>
        <div class="coverInfo">
            <ul>
                <li class="itemInCovers">
                    <uc1:BookRowElement runat="server" id="BookRowElement" />
                </li>
                <li class="itemInCovers">
                    <uc1:BookRowElement runat="server" id="BookRowElement1" />
                </li>
                <li class="itemInCovers">
                    <uc1:BookRowElement runat="server" id="BookRowElement2" />
                </li>
                <li class="itemInCovers">
                    <uc1:BookRowElement runat="server" id="BookRowElement3" />
                </li>
                <li class="itemInCovers">
                    <uc1:BookRowElement runat="server" id="BookRowElement4" />
                </li>
                <li class="itemInCovers">
                    <uc1:BookRowElement runat="server" id="BookRowElement5" />
                </li>
            </ul>
        </div>
</div>