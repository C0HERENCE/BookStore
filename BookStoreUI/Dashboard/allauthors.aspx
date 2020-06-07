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
                    <div class="form-row">
                        <div class="col-md-12 mb-3">
                            <label for="validationTooltip01">作者名</label><p />
                            <asp:TextBox ID="TextBox1" runat="server" autocomplete="off" class="form-control" placeholder="请输入作者名"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" style="font-size:80%;color:crimson" CssClass="p-2" ControlToValidate="TextBox1" ErrorMessage="作者名为必填项" ValidationGroup="author"></asp:RequiredFieldValidator>
                            <p />
                            <label for="validationTooltip01">详情介绍</label><p />
                            <asp:TextBox ID="TextBox2" runat="server" autocomplete="off" TextMode="MultiLine" class="form-control" Height="200px" placeholder="请输入作者详情"></asp:TextBox>
                            <p />
                            <asp:Button ID="Button1" runat="server" Text="添加" OnClick="Button1_Click" CssClass="btn btn-primary" ValidationGroup="author"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-xl-6 col-md-6 mb-4">
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary">新增出版社</h6>
                </div>
                <div class="card-body">
                    <asp:TextBox ID="TextBox3" runat="server" autocomplete="off" class="form-control" placeholder="请输入出版社名"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" style="font-size:80%;color:crimson" CssClass="p-2" ControlToValidate="TextBox3" ErrorMessage="出版社名称为必填项" ValidationGroup="press"></asp:RequiredFieldValidator>
                    <p />
                    <asp:Button ID="Button2" runat="server" Text="添加" OnClick="Button2_Click" CssClass="btn btn-primary" ValidationGroup="press" />
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
                <div class="collapse show" id="collapseauthor">
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
                <div class="collapse show" id="collapspublisher">
                    <div class="card-body">
                        <table id="publishertable" class="table table-bordered dataTable" cellspacing="0" role="grid" aria-describedby="dataTable_info" style="width: 100%;">
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
