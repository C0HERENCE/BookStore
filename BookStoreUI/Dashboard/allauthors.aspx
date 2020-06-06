<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/SB_Master.Master" AutoEventWireup="true" CodeBehind="allauthors.aspx.cs" Inherits="Dashboard.allauthors" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
作者和出版社管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="row">
        <div class="col-xl-3 col-md-6 mb-4">
            <div class="card border-left-primary shadow h-100 py-2">
            <div class="card-body">
                <div class="row no-gutters align-items-center">
                <div class="col mr-2">
                    <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">作者</div>
                    <div class="h5 mb-0 font-weight-bold text-gray-800">
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>
                <div class="col-auto">
                    <i class="fas fa-calendar fa-2x text-gray-300"></i>
                </div>
                </div>
            </div>
            </div>
        </div>
        <div class="col-xl-3 col-md-6 mb-4">
            <div class="card border-left-info shadow h-100 py-2">
            <div class="card-body">
                <div class="row no-gutters align-items-center">
                <div class="col mr-2">
                    <div class="text-xs font-weight-bold text-info text-uppercase mb-1">出版社</div>
                    <div class="h5 mb-0 font-weight-bold text-gray-800">
                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>
                <div class="col-auto">
                    <i class="fas fa-calendar fa-2x text-gray-300"></i>
                </div>
                </div>
            </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-xl-6 col-md-6 mb-4">
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary">新增作者</h6>
                </div>
                <div class="card-body">
                    <asp:TextBox ID="TextBox1" runat="server" autocomplete="off"></asp:TextBox>
                    <p />
                    <asp:TextBox ID="TextBox2" runat="server" autocomplete="off"></asp:TextBox>
                    <p />
                    <asp:Button ID="Button1" runat="server" Text="添加" OnClick="Button1_Click"/>
                </div>
            </div>
        </div>
        <div class="col-xl-6 col-md-6 mb-4">
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary">新增出版社</h6>
                </div>
                <div class="card-body">
                    <asp:TextBox ID="TextBox3" runat="server" autocomplete="off"></asp:TextBox>
                    <p />
                    <asp:Button ID="Button2" runat="server" Text="添加" OnClick="Button2_Click" />
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <div class="card shadow mb-4">
            <!-- Card Header - Accordion -->
                <a href="#collapseauthor" class="d-block card-header py-3" data-toggle="collapse" role="button" aria-expanded="true" aria-controls="collapseauthor">
                    <h6 class="m-0 font-weight-bold text-primary">作者管理</h6>
                </a>
            <!-- Card Content - Collapse -->
                <div class="collapse" id="collapseauthor">
                    <div class="card-body">
                        <table id="authortable" class="table table-bordered dataTable" width="100%" cellspacing="0" role="grid" aria-describedby="dataTable_info" style="width: 100%;">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>姓名</th>
                                    <th>简介</th>
                                </tr>
                            </thead>
                            <tfoot>
                                <tr>
                                    <th>ID</th>
                                    <th>姓名</th>
                                    <th>简介</th>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <div class="card shadow mb-4">
            <!-- Card Header - Accordion -->
                <a href="#collapspublisher" class="d-block card-header py-3" data-toggle="collapse" role="button" aria-expanded="true" aria-controls="collapspublisher">
                    <h6 class="m-0 font-weight-bold text-primary">出版社管理</h6>
                </a>
            <!-- Card Content - Collapse -->
                <div class="collapse" id="collapspublisher">
                    <div class="card-body">
                        <table id="publishertable" class="table table-bordered dataTable" width="100%" cellspacing="0" role="grid" aria-describedby="dataTable_info" style="width: 100%;">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>名称</th>
                                </tr>
                            </thead>
                            <tfoot>
                                <tr>
                                    <th>ID</th>
                                    <th>名称</th>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
    <script src="vendor/datatables/datatables.js"></script>
    <script type="text/javascript">
        $('[href="allauthors.aspx"]').addClass('active').parent().parent().collapse('show').parent().addClass('active')
        $(document).ready(function () {
            $('#authortable').DataTable({
                "ajax": {
                    url: "/Dashboard/api/getallauthor.ashx",
                    dataSrc:'',
                },
                "columns": [
                                { data: "id" },
                                { data: "name" },
                                { data: "intro" },
                            ],
            });

            $('#publishertable').DataTable({
                "ajax": {
                    url:"/Dashboard/api/getallpublisher.ashx",
                    dataSrc:'',
                },
                "columns": [
                                { data: "id" },
                                { data: "name" },
                            ],
            });
        });
    </script>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="StylePlaceHolder" runat="server">
    <link rel="stylesheet" type="text/css" href="vendor/datatables/datatables.css"/>
</asp:Content>
