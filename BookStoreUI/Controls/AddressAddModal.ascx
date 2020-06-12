<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddressAddModal.ascx.cs" Inherits="BookStoreUI.Controls.AddressAddModal" %>
<%@ Register Src="~/Controls/Modal.ascx" TagPrefix="uc1" TagName="Modal" %>
<asp:Label ID="txtAddressID" runat="server" Text="0"></asp:Label>
<div class="modal-dialog modal-dialog-centered modal-dialog-scrollable modal fade" id="addressAddModal" tabindex="-1" role="dialog" aria-labelledby="addressAddModal" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title">
                    <asp:Label ID="txtTitle" runat="server" Text="新增收货地址"></asp:Label>
                </h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                <div class="form-group">
                    <label>收货人</label>
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>联系电话</label>
                    <asp:TextBox ID="txtTel" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>详细地址</label>
                    <asp:TextBox ID="txtAdd" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">取消</button>
                <asp:Button CssClass="btn btn-danger" Text="删除" runat="server" ID="Delete" OnClick="Delete_Click" />
                <asp:Button CssClass="btn btn-primary" Text="设为默认收货地址" runat="server" ID="Default" OnClick="Default_Click" />
                <asp:Button CssClass="btn btn-primary" Text="确认" runat="server" ID="Modify" OnClick="Modify_Click" />
                <asp:Button CssClass="btn btn-primary" Text="确认" runat="server" ID="Add" OnClick="Add_Click" />
            </div>
        </div>
    </div>
</div>

<uc1:Modal runat="server" ID="Modal" />
<script>
    var showAddress = function () {
        $('#addressAddModal').modal('show');
    }
</script>
