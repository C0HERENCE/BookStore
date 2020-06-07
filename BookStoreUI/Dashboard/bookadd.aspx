<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/SB_Master.Master" AutoEventWireup="true" CodeBehind="bookadd.aspx.cs" Inherits="Dashboard.bookadd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    新增图书
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <div class="form-row">
        <div class="col-md-4 mb-3">
            <label for="validationTooltip01">标题*</label>
            <asp:TextBox ID="txttitle" runat="server" class="form-control" placeholder="请输入图书标题" value="" autocomplete="off"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="图书标题为必填项" style="font-size:80%;color:crimson" CssClass="p-2" ControlToValidate="txttitle" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-4 mb-3">
            <label for="validationTooltip02">原标题</label>
            <asp:TextBox runat="server" class="form-control" ID="txtorigin" placeholder="请输入原标题" value="" autocomplete="off"></asp:TextBox>
        </div>
        <div class="col-md-4 mb-3">
            <label for="validationTooltip02">副标题</label>
            <asp:TextBox runat="server" class="form-control" ID="txtsub" placeholder="请输入副标题" value=""  autocomplete="off"></asp:TextBox>
        </div>
    </div>
    <div class="form-row">
        <div class="col-md-3 mb-3">
            <label for="validationTooltip02">封面*</label>
            <div class="input-group mb-3">
                <div class="custom-file">
                    <input type="file" class="custom-file-input" id="inputGroupFile02">
                    <label class="custom-file-label" for="inputGroupFile02">选择封面图</label>
                </div>
            </div>
        </div>
    </div>
    <div class="form-row">
        <div class="col-md-2 mb-3">
            <label for="validationTooltip01">分类*</label>
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <div class="col-md-2 mb-3">
            <label for="validationTooltip01">&nbsp;</label>
            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control" >
            </asp:DropDownList>
        </div>
    </div>
    <div class="form-row">
        <div class="col-md-4 mb-3">
            <label for="validationTooltip01">作者*</label><p />
            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#selectauthormodal" id="selectauthor">
                选择或新增一个作者
            </button>
            <asp:TextBox ID="txtauthorid" name="authorid" runat="server" style="display:none"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="作者为必选项" style="font-size:80%;color:crimson" CssClass="p-2" ControlToValidate="txtauthorid" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-4 mb-3">
            <label for="validationTooltip01">出版社*</label><p />
            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#selectpublishermodal" id="selectpublisher">
                选择或新增一个出版社
            </button>
            <asp:TextBox ID="txtpublisherid" name="publisherid" runat="server" style="display:none"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="出版社为必选项" style="font-size:80%;color:crimson" CssClass="p-2" ControlToValidate="txtpublisherid" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="form-row">
        <div class="col-md-3 mb-3">
            <label for="validationTooltip01">ISBN*</label>
            <asp:TextBox ID="txtisbn" runat="server" name="isbn" placeholder="请输入ISBN" autocomplete="off" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="ISBN为必填项" style="font-size:80%;color:crimson" CssClass="p-2" ControlToValidate="txtisbn" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-3 mb-3">
            <label for="validationTooltip02">出版日期</label>
            <asp:Calendar ID="Calendar1" runat="server" Visible="false"></asp:Calendar>
            <asp:TextBox ID="txtpubdate" runat="server" name="pubdate" autocomplete="off" placeholder="yyyy-MM" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-3 mb-3">
            <label for="validationTooltip02">页数</label>
            <asp:TextBox ID="txtpages" runat="server" name="pages" placeholder="请输入页数" autocomplete="off" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-3 mb-3">
            <label for="validationTooltip02">定价</label>
            <asp:TextBox ID="txtprice" runat="server" name="price" placeholder="￥" autocomplete="off" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="form-row">
        <div class="col-md-6 mb-3">
            <label for="validationTooltip02">详情*</label>
            <asp:TextBox ID="txtsummary" runat="server" name="summary" placeholder="请输入图书详情" CssClass="form-control" TextMode="MultiLine" Height="250" autocomplete="off"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="图书详情为必填项" style="font-size:80%;color:crimson" CssClass="p-2" ControlToValidate="txtsummary" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-6 mb-3">
            <label for="validationTooltip02">目录信息</label>
            <asp:TextBox ID="txtcatalog" runat="server" name="catalog" placeholder="请输入内容" CssClass="form-control" TextMode="MultiLine" Height="250" autocomplete="off"></asp:TextBox>
        </div>
    </div>
    <div class="form-row">
        <div class="col-md-2 mb-3">
            <asp:Button ID="Button3" runat="server" Text="提交" CssClass="btn btn-primary" Style="width: 100%" OnClick="Button3_Click" />
        </div>
        <div class="col-md-2 mb-3">
            <asp:Button ID="Button4" runat="server" Text="重置" CausesValidation="false" CssClass="btn btn-primary" Style="width: 100%" OnClick="Button4_Click" />
        </div> 
    </div>
    <div id="selectauthormodal" class="modal fade show" tabindex="-1" role="dialog" aria-labelledby="gridModalLabel"">
        <div class="modal-dialog  modal-lg" role="document" style="width:50%">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="gridModalLabel1">选择一个作者</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-12">
                            <table id="authortable" class="table table-bordered dataTable" width="100%" cellspacing="0" role="grid" aria-describedby="dataTable_info" style="width: 100%;">
                                <thead>
                                    <tr>
                                        <th>ID</th>
                                        <th>名称</th>
                                    </tr>
                                </thead>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">关闭</button>
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">添加新作者</button>
                    <button type="button" class="btn btn-success" id="authorbtn" data-dismiss="modal">确定</button>
                </div>
            </div>
        </div>
    </div>
    <div id="selectpublishermodal" class="modal fade show" tabindex="-1" role="dialog" aria-labelledby="gridModalLabel"">
        <div class="modal-dialog  modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="gridModalLabel2">选择一个出版社</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-12">
                            <table id="publishertable" class="table table-bordered dataTable" width="100%" cellspacing="0" role="grid" aria-describedby="dataTable_info" style="width: 100%;">
                                <thead>
                                    <tr>
                                        <th>ID</th>
                                        <th>名称</th>
                                    </tr>
                                </thead>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">关闭</button>
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">添加新出版社</button>
                    <button type="button" class="btn btn-success" id="publisherbtn" data-dismiss="modal">确定</button>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="addsuccessmodal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">提示</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    添加成功
                </div>
                <div class="modal-footer">
                    <asp:Button ID="Button1" class="btn btn-secondary" runat="server" Text="管理该商品" OnClick="Button1_Click"/>
                    <button type="button" class="btn btn-success" data-dismiss="modal">确认</button>
                </div>
            </div>
        </div>
    </div>
    <script>
        var showModal = function (text) {
            $('#addsuccessmodal .modal-body').text(text);
            $('#addsuccessmodal').modal('show');
            return false;
        }
        $('#addsuccessmodal').on('hidden.bs.modal', function (e) {
            location.href='bookadd.aspx';
        })
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
    <script src="vendor/datatables/datatables.js"></script>
    <script>
        $('[href="bookadd.aspx"]').addClass('active').parent().parent().collapse('show').parent().addClass('active')
        $(document).ready(function () {
            var authortable = $('#authortable').DataTable({
                select: {
                    style: 'single'
                },
                "pageLength": 5,
                "lengthMenu": [5, 10, 30, 50],
                "ajax": {
                    url: "/Dashboard/api/getallauthor.ashx",
                    dataSrc: '',
                },
                "columns": [
                    { data: "id" },
                    {
                        data: "name",
                        render: function (data, type) {
                            return '<p class="text-secondary">' + data + '</p>';
                        }
                    }
                ],
            });
            $('#authorbtn').click(function () {
                var sb;
                sb = authortable.rows({ selected: true }).data();
                if (sb.count() == 1) {
                    console.log(sb[0].id);
                    $('#selectauthor').text(sb[0].name);
                    $('#' + '<%=txtauthorid.ClientID%>').val(sb[0].id);
                }
                else
                    console.log('no');
            });
            var publishertable = $('#publishertable').DataTable({
                select: {
                    style: 'single'
                },
                "pageLength": 5,
                "lengthMenu": [5, 10, 30, 50],
                "ajax": {
                    url: "/Dashboard/api/getallpublisher.ashx",
                    dataSrc: '',
                },
                "columns": [
                    { data: "id" },
                    {
                        data: "name",
                        render: function (data, type) {
                            return '<p class="text-secondary">' + data + '</p>';
                        }
                    }
                ],
            });
            $('#publisherbtn').click(function () {
                var sb;
                sb = publishertable.rows({ selected: true }).data();
                if (sb.count() == 1) {
                    console.log(sb[0].id);
                    $('#selectpublisher').text(sb[0].name);
                    $('#' + '<%=txtpublisherid.ClientID%>').val(sb[0].id);
                }
                else
                    console.log('no');
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="StylePlaceHolder" runat="server">
    <link rel="stylesheet" type="text/css" href="vendor/datatables/datatables.css"/>
    <style type="text/css">
        table .selected {
            background-color: aquamarine;
        }

        table tbody tr {
            cursor: pointer;
        }
    </style>
</asp:Content>