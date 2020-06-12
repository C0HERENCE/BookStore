<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Category.master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="BookStoreUI.Category" %>

<%@ Register Src="~/Controls/CategoryBookRow.ascx" TagPrefix="uc1" TagName="CategoryBookRow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CatagoryDetail" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:ListView ID="list" runat="server" OnPreRender="list_PreRender">
                <ItemTemplate>
                    <uc1:CategoryBookRow runat="server" ID="CategoryBookRow"
                        BookID='<%#Bind("id")%>'
                        Title='<%#Bind("title") %>'
                        ImageUrl='<%#Bind("image") %>'
                        OriginPrice='<%#Bind("origin_price") %>'
                        Publisher='<%#Bind("publisher") %>'
                        Author='<%#Bind("author") %>'
                        Price='<%#Bind("price") %>'
                        Stars='<%#Bind("stars") %>'
                        Summary='<%# Bind("summary") %>' />
                </ItemTemplate>
            </asp:ListView>
            <div style="width: 100%; text-align: center;">
                <asp:DataPager ID="pager" runat="server" PagedControlID="list" OnPreRender="pager_PreRender" PageSize="6">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ButtonCssClass="btn btn-outline-primary" />
                        <asp:NumericPagerField ButtonCount="6" ButtonType="Button" NextPreviousButtonCssClass="btn btn-outline-primary" NumericButtonCssClass="btn btn-outline-primary" />
                        <asp:NextPreviousPagerField ButtonCssClass="btn btn-outline-primary" ButtonType="Button" ShowLastPageButton="True" ShowPreviousPageButton="False" />
                    </Fields>
                </asp:DataPager>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function bindShadow() {
            $('.bookdetailrow').mouseover(function (e) {
                $(e.target).parents('.bookdetailrow').addClass('shadow').removeClass('shadow-sm');
            })
            $('.bookdetailrow').mouseout(function (e) {
                $(e.target).parents('.bookdetailrow').removeClass('shadow').addClass('shadow-sm');
            })
        }
        $('document').ready()
        {
            bindShadow();
        }
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
            bindShadow();
        });
    </script>
</asp:Content>
