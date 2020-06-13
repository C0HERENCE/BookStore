<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CartBookRow.ascx.cs" Inherits="BookStoreUI.Controls.CartBookRow" %>
<div class="row">
    <div class="p-2 col-5">
        <asp:Image CssClass="img-fluid rounded shadow-sm" runat="server" ID="imgCover" Width="70" OnPreRender="imgCover_PreRender"/>
        <div class="ml-3 d-inline-block align-middle">
        <h5 class="mb-0">
            <asp:HyperLink id="linkDetail" runat="server" CssClass="text-dark d-inline-block" OnPreRender="linkDetail_PreRender"></asp:HyperLink>
        </h5>
            <span class="text-muted font-weight-normal font-italic">分类: 
                <asp:Label ID="txtCategory" runat="server" Text="计算机" OnPreRender="txtCategory_PreRender"></asp:Label>
            </span>
        </div>
    </div>
    <div class="align-middle col-3"><strong>
            <asp:Label ID="txtPrice" runat="server" Text="1300.00" OnPreRender="txtPrice_PreRender"></asp:Label>
        元</strong></div>
    <div class="align-middle col-2">
        <asp:TextBox ID="txtNum" runat="server" value="1" type="number" min="1" max="99" AutoPostBack="true" OnTextChanged="txtNum_TextChanged" OnPreRender="txtNum_PreRender"></asp:TextBox>
    </div>
    <div class="align-middle col-2">
        <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" CommandName="btnDelete" OnCommand="btnDelete_Command" CssClass="btn btn-danger rounded-pill" Text="删除" OnPreRender="btnDelete_PreRender"/>
    </div>
</div>