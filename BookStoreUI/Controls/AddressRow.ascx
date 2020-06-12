<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddressRow.ascx.cs" Inherits="BookStoreUI.Controls.AddressRow" %>
<asp:LinkButton ID="linkaddress" runat="server" CssClass="list-group-item list-group-item-action" OnClick="linkaddress_Click">
    <div class="d-flex w-100 justify-content-between">
        <h5 class="mb-1">收货人:
            <asp:Label ID="txtName" runat="server" Text="星海城"></asp:Label>
        </h5>
        <small>编号:
            <asp:Label ID="txtNO" runat="server" Text="XingHaiCC123"></asp:Label>
            <br />
            <asp:Label ID="txtIsDefault" CssClass="text-warning" runat="server" Text=""></asp:Label>
        </small>
    </div>
    <p class="mb-1">
        详细地址:
        <asp:Label ID="txtAdd" runat="server" Text="日本，北海道，京都半道120号，10F1004室"></asp:Label>
    </p>
    <small>手机号:
        <asp:Label ID="txtTel" runat="server" Text="130418304"></asp:Label>
    </small>
</asp:LinkButton>
