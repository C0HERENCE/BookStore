<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/SB_Master.Master" AutoEventWireup="true" CodeBehind="allbooks.aspx.cs" Inherits="Dashboard.allbooks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
图书管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="row">
        <div class="col-xl-3 col-md-6 mb-4">
            <div class="card border-left-success shadow h-100 py-2">
            <div class="card-body">
                <div class="row no-gutters align-items-center">
                <div class="col mr-2">
                    <div class="text-xs font-weight-bold text-success text-uppercase mb-1">图书总数</div>
                    <div class="h5 mb-0 font-weight-bold text-gray-800">
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>
                <div class="col-auto">
                    <i class="fas fa-dollar-sign fa-2x text-gray-300"></i>
                </div>
                </div>
            </div>
            </div>
        </div>
        <div class="col-xl-3 col-md-6 mb-4">
            <a href="bookadd.aspx" class="btn btn-primary btn-icon-split m-2">
                    <span class="icon text-white-50">
                      <i class="fas fa-check"></i>
                    </span>
                    <span class="text">去新增图书</span>
            </a>
            <br />
            <a href="bookstock.aspx" class="btn btn-success btn-icon-split m-2">
                    <span class="icon text-white-50">
                      <i class="fas fa-flag"></i>
                    </span>
                    <span class="text">去商品管理</span>
            </a>
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary">图书数据表</h6>
                </div>
                <div class="card-body">
                    <table id="allbooksdata" class="table table-bordered dataTable" width="100%" cellspacing="0" role="grid" aria-describedby="dataTable_info" style="width: 100%;">
                        <thead>
                            <tr>
                                <th>详情</th>
                                <th>ID</th>
                                <th>名称</th>
                                <th>ISBN</th>
                                <th>分类</th>
                                <th>作者</th>
                                <th>出版社</th>
                            </tr>
                        </thead>
                        <tfoot>
                            <tr>
                                <th>详情</th>
                                <th>ID</th>
                                <th>名称</th>
                                <th>ISBN</th>
                                <th>分类</th>
                                <th>作者</th>
                                <th>出版社</th>
                            </tr>
                        </tfoot>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
    <script src="vendor/datatables/datatables.js"></script>
    <script type="text/javascript">
        $('[href="allbooks.aspx"]').addClass('active').parent().parent().collapse('show').parent().addClass('active')
        /* Formatting function for row details - modify as you need */
        function format(d) {
            // `d` is the original data object for the row
            return '<table cellpadding="5" cellspacing="0" border="0" style="padding-left:50px;">' +
                '<tr>' +
                '<td>原标题:</td>' +
                '<td colspan="2">' + d.origintitle + '</td>' +
                '<td>子标题:</td>' +
                '<td colspan="1">' + (typeof (d.subtitile) == "undefined" ?"(无)":d.subtitile) + '</td>' +
                '<td>出版日期:</td>' +
                '<td colspan="1">' + d.pubdate + '</td>' +
                '</tr>' +
                '<tr>' +
                '<td>封面:</td>' +
                '<td colspan="2"><img src="/public/images/cover/' + d.image + '" style="width:100px;height:140px"></img></td>' +
                '<td>页码:</td>' +
                '<td colspan="1">' + d.pages + '</td>' +
                '<td>定价:</td>' +
                '<td colspan="1">' + d.price + '</td>' +
                '</tr>' +
                '<tr>' +
                '<td>图书详情:</td>' +
                '<td colspan="6">' + d.summary + '</td>' +
                '</tr>' +
                '<tr>' +
                '<td>作者详情:</td>' +
                '<td colspan="6">' + (typeof (d.author_intro) == "undefined" ? "(无)" : d.author_intro) + '</td>' +
                '</tr>' +
                '<tr>' +
                '<td>目录:</td>' +
                '<td colspan="6">' + (typeof (d.catalog) == "undefined" ? "(无)" : d.catalog) + '</td>' +
                '</tr>' +
                '</table>';
        }

        $(document).ready(function () {
            var table = $('#allbooksdata').DataTable({
                "ajax": {
                    url:"/Dashboard/api/getallbook.ashx",
                    dataSrc:'',
                },
                "columns": [
                    {
                        orderable: false,
                        className: 'details-control',
                        data: null,
                        defaultContent: ''
                    },
                    { data: "id" },
                    { data: "title" },
                    { data: "isbn" },
                    { data: "category" },
                    { data: "author" },
                    { data: "publisher" },
                ],
                language: {
                    processing: "正在获取数据，请稍后...",
                    search: "搜索",
                    lengthMenu: "显示 _MENU_ 条",
                    info: "当前显示的第是 _START_ 到 _END_ 行数据,共 _TOTAL_ 行数据",
                    infoEmpty: "记录数为0",
                    infoFiltered: "((全部记录数 _MAX_ 条))",
                    infoPostFix: "",
                    loadingRecords: "系统处理中,请稍等...",
                    zeroRecords: "没有您要搜索的内容",
                    emptyTable: "没有数据",
                    paginate: {
                        first: "第一页",
                        previous: "上一页",
                        next: "下一页",
                        last: "最后一页"
                    },
                    aria: {
                        sortAscending: "以升序排列此列",
                        sortDescending: "以降序排列此列"
                    }
                },
            });
            // Add event listener for opening and closing details
            $('#allbooksdata tbody').on('click', 'td.details-control', function () {
                var tr = $(this).closest('tr');
                var row = table.row(tr);
                if (row.child.isShown()) {
                    row.child.hide();
                    tr.removeClass('shown');
                }
                else {
                    row.child(format(row.data())).show();
                    tr.addClass('shown');
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="StylePlaceHolder" runat="server">
    <link rel="stylesheet" type="text/css" href="vendor/datatables/datatables.css"/>
    <style type="text/css">
        td.details-control {
            background: url('resources/details_open.png') no-repeat center center;
            cursor: pointer;
        }
        tr.shown td.details-control {
            background: url('resources/details_close.png') no-repeat center center;
        }
    </style>
</asp:Content>