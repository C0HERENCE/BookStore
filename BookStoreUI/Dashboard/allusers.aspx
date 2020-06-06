<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/SB_Master.Master" AutoEventWireup="true" CodeBehind="allusers.aspx.cs" Inherits="Dashboard.allusers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    用户管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="row">
        <div class="col-12">
            <asp:GridView ID="GridView1" runat="server" style="width:100px;height:300px;" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <table id="ss">

            </table>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
    <script src="vendor/datatables/jquery.dataTables.js"></script>
    <script src="vendor/datatables/dataTables.bootstrap4.js"></script>
    <script>
            $('[href="allusers.aspx"]').addClass('active').parent().parent().collapse('show').parent().addClass('active')
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="StylePlaceHolder" runat="server">
    
</asp:Content>
