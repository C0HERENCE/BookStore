<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Category.master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="BookStoreUI.Category" %>

<%@ Register Src="~/Controls/CategoryBookRow.ascx" TagPrefix="uc1" TagName="CategoryBookRow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CatagoryDetail" runat="server">
    <asp:Label ID="txtCateTitle" runat="server" Text="Label"></asp:Label>
    <asp:PlaceHolder runat="server" ID="contentholder"></asp:PlaceHolder>

    <div id="demo">
        <div class="data-container"></div>
        <div class="pagination"></div>
    </div>
    <script type="text/javascript" src="Public/JS/pagination.js"> </script>
    <script type="text/javascript">
        $('#demo').pagination({
            dataSource: [1, 2, 3, 4, 5, 6, 7, ... , 195],
            callback: function (data, pagination) {
                // template method of yourself
                var html = template(data);
                dataContainer.html(html);
            }
        })
    </script>
</asp:Content>
