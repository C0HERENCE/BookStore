<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrderBookRow.ascx.cs" Inherits="BookStoreUI.Controls.OrderBookRow" %>
<tr>
    <th scope="row">
        <div class="p-2">
            <asp:Image ID="imgCover" runat="server" CssClass="img-fluid rounded shadow-sm" Style="width: 70" />
            <div class="ml-3 d-inline-block align-middle">
                <h5 class="mb-0">
                    <asp:LinkButton ID="linkDetail" runat="server" CssClass="text-dark d-inline-block"></asp:LinkButton>
                </h5>
                <span class="text-muted font-weight-normal font-italic">分类:
                    <asp:Label ID="txtCategory" runat="server" Text=""></asp:Label>
                </span>
            </div>
        </div>
    </th>
    <td class="align-middle"><strong>
        <asp:Label ID="txtPrice" runat="server" Text=""></asp:Label>元</strong></td>
    <td class="align-middle" style="width:180px">
        <asp:TextBox ID="TextBox1" runat="server" value="1" type="number" min="1" max="99" OnTextChanged="TextBox1_TextChanged" AutoPostBack="true"></asp:TextBox>
    </td>
    <td class="align-middle">
        <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-danger rounded-pill"  Text="删除"/>
    </td>
</tr>