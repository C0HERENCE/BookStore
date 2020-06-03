<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopList.ascx.cs" Inherits="BookStoreUI.Controls.TopList" %>
<%@ Register Src="~/Controls/Element/TopListElement.ascx" TagPrefix="uc1" TagName="TopListElement" %>

<div class="top">
    <h2 style="margin-top:1.5rem">
    <span class="iconfont icon-paixing"></span>畅销排行</h2>
    <asp:Panel ID="Panel1" runat="server" CssClass="accordion"></asp:Panel>
</div>