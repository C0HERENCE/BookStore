<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/SB_Master.Master" AutoEventWireup="true" CodeBehind="bookstock.aspx.cs" Inherits="Dashboard.bookstock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    商品库存、售价和状态管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="row">
        <div class="col-xl-3 col-md-6 mb-4">
            <div class="card border-left-primary shadow h-100 py-2">
            <div class="card-body">
                <div class="row no-gutters align-items-center">
                <div class="col mr-2">
                    <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">正在销售的图书</div>
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
    </div>
    <div class="row">
        <div class="col-12">
            <table id="booktable" class="table table-bordered dataTable nowrap" style="width:100%">
                <thead>
                    <tr>
                        <th></th>
                        <th>ID</th>
                        <th>书名</th>
                        <th>ISBN</th>
                        <th>作者</th>
                        <th>类别</th>
                        <th>出版社</th>
                        <th>售价</th>
                        <th>状态</th>
                        <th>库存</th>
                    </tr>
                </thead>
                <tfoot>
                    <tr>
                        <th></th>
                        <th>ID</th>
                        <th>书名</th>
                        <th>ISBN</th>
                        <th>作者</th>
                        <th>类别</th>
                        <th>出版社</th>
                        <th>售价</th>
                        <th>状态</th>
                        <th>库存</th>
                    </tr>
                </tfoot>
            </table>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
    <script src="vendor/datatables/datatables.js"></script>
    <script src="vendor/datatables/Editor-1.9.3/js/dataTables.editor.js"></script>
    <script>

        $('[href="bookstock.aspx"]').addClass('active').parent().parent().collapse('show').parent().addClass('active')
        $(document).ready(function () {  
            var table = $('#booktable').DataTable({
                ajax: {
                    url: "/Dashboard/api/getallsells.ashx",
                    dataSrc: '',
                },
                dom: 'frBtip',
                buttons: [
                    {
                        text: '全选',
                        action: function () {
                            table.rows().select();
                        }
                    },
                    {
                        text: '全不选',
                        action: function () {
                            table.rows().deselect();
                        }
                    },
                    {
                        text: '立即开售',
                        action: function () {
                            var data = table.rows({ selected: true }).data();
                            var list = [];
                            for (var i = 0; i < data.count(); i++) {
                                list.push(data[i].id);
                            }
                            $.ajax({
                                url: '/dashboard/api/togglebookonsale.ashx',
                                data: {
                                    id: list,
                                    onsale: 1
                                },
                                success() {
                                    console.log('success')
                                },
                                error() {
                                    console.log('fail')
                                },
                                complete() {
                                    table.ajax.reload(null, false);
                                    location.href = "bookstock.aspx";
                                }
                            });
                        }
                    },
                    {
                        text: '立即停售',
                        action: function () {
                            var data = table.rows({ selected: true }).data();
                            var list = [];
                            for (var i = 0; i < data.count(); i++) {
                                list.push(data[i].id);
                            }
                            $.ajax({
                                url: '/dashboard/api/togglebookonsale.ashx',
                                data: {
                                    id: list,
                                    onsale: 0
                                },
                                success() {
                                    console.log('success')
                                },
                                error() {
                                    console.log('fail')
                                },
                                complete() {
                                    table.ajax.reload(null, false);
                                    location.href = "bookstock.aspx";
                                }
                            });
                        }
                    },
                    'excel',
                    'pdf',
                    'print',
                ],
                select: {
                    style:'multi+shift'
                },
                columns: [
                    {
                        orderable: false,
                        className: 'select-checkbox',
                        data: null,
                        defaultContent:''
                    },
                    { data: "id" },
                    { data: "title" },
                    { data: "isbn" },
                    { data: "author" },
                    { data: "category" },
                    { data: "publisher" },
                    { data: "price" },
                    {
                        data: "onsale",
                        render: function (data) {
                            if (data==0) {
                                return '<span class="text-danger">已下架</span>';
                            }
                            else {
                                return '<span class="text-success">销售中</span>';
                            }
                        }
                    },
                    {
                        data: "stock",
                        render: function (data) {
                            return '<span class="text-danger">' + data + '</span>';
                        }
                    },
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
            $('#booktable').on('click', 'tbody td', function () {
                table.cell(this).edit();
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="StylePlaceHolder" runat="server">
    <link rel="stylesheet" type="text/css" href="vendor/datatables/datatables.css"/>
    <style>
        .cell-edit-class{
            width:3rem;
        }
    </style>
</asp:Content>