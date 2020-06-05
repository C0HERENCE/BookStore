<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/SB_Master.Master" AutoEventWireup="true" CodeBehind="bookadd.aspx.cs" Inherits="Dashboard.bookadd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    新增商品
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="form-row">
        <div class="col-md-4 mb-3">
            <label for="validationTooltip01">图书标题</label>
            <asp:TextBox runat="server" class="form-control" ID="validationTooltip01" placeholder="爱丽丝漫游仙境" value="" required=""></asp:TextBox>
            <div class="valid-tooltip">
                Looks good!
            </div>
        </div>
        <div class="col-md-4 mb-3">
            <label for="validationTooltip02">原作标题</label>
            <asp:TextBox runat="server" class="form-control" ID="validationTooltip02" placeholder="Alice in Wonderland" value="" required=""></asp:TextBox>
            <div class="valid-tooltip">
                Looks good!
            </div>
        </div>
        <div class="col-md-4 mb-3">
            <label for="validationTooltip02">子标题</label>
            <asp:TextBox runat="server" class="form-control" ID="validationTooltip03" placeholder="None" value="" required=""></asp:TextBox>
            <div class="valid-tooltip">
                Looks good!
            </div>
        </div>
    </div>
    <div class="form-row">
        <div class="col-md-3 mb-3">
            <label for="validationTooltip02">封面</label>
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
            <label for="validationTooltip01">分类</label>
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
            </asp:DropDownList>
            <div class="valid-tooltip">
                Looks good!
            </div>
        </div>
        <div class="col-md-2 mb-3">
            <label for="validationTooltip01">&nbsp;</label>
            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control">
            </asp:DropDownList>
            <div class="valid-tooltip">
                Looks good!
            </div>
        </div>
    </div>

    <div class="form-row">
        <div class="col-md-2 mb-3">
            <label for="validationTooltip01">选择或新增一个作者</label>
            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#gridSystemModal">
                马化腾
            </button>
            <div class="valid-tooltip">
                Looks good!
            </div>
        </div>
        <div class="col-md-3 mb-3 offset-2">
            <label for="validationTooltip01">选择或新增一个出版社</label>
            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#selectpublisher">
                温州医科大学出版社
            </button>
            <div class="valid-tooltip">
                Looks good!
            </div>
        </div>
    </div>

    <div class="form-row">
        <div class="col-md-3 mb-3">
            <label for="validationTooltip01">ISBN</label>
            <asp:TextBox ID="TextBox4" runat="server" name="isbn" placeholder="请输入ISBN" autocomplete="off" CssClass="form-control"></asp:TextBox>
            <div class="valid-tooltip">
                Looks good!
            </div>
        </div>
        <div class="col-md-3 mb-3">
            <label for="validationTooltip02">出版日期</label>
            <asp:Calendar ID="Calendar1" runat="server" Visible="false"></asp:Calendar>
            <asp:TextBox ID="TextBox9" runat="server" name="pubdate" autocomplete="off" placeholder="yyyy-MM" CssClass="form-control"></asp:TextBox>
            <div class="valid-tooltip">
                Looks good!
            </div>
        </div>
        <div class="col-md-3 mb-3">
            <label for="validationTooltip02">页数</label>
            <asp:TextBox ID="TextBox5" runat="server" name="pages" placeholder="请输入页数" autocomplete="off" CssClass="form-control"></asp:TextBox>
            <div class="valid-tooltip">
                Looks good!
            </div>
        </div>
        <div class="col-md-3 mb-3">
            <label for="validationTooltip02">定价</label>
            <asp:TextBox ID="TextBox6" runat="server" name="price" placeholder="￥" autocomplete="off" CssClass="form-control"></asp:TextBox>
            <div class="valid-tooltip">
                Looks good!
            </div>
        </div>
    </div>
    <div class="form-row">
        <div class="col-md-6 mb-3">
            <label for="validationTooltip02">图书详情</label>
            <asp:TextBox ID="TextBox7" runat="server" name="summary" placeholder="请输入内容" CssClass="form-control" TextMode="MultiLine" Height="250"></asp:TextBox>
        </div>
        <div class="col-md-6 mb-3">
            <label for="validationTooltip02">目录信息</label>
            <asp:TextBox ID="TextBox8" runat="server" name="catalog" placeholder="请输入内容" CssClass="form-control" TextMode="MultiLine" Height="250"></asp:TextBox>
        </div>
    </div>
    <div class="form-row">
        <div class="col-md-2 mb-3">
            <asp:Button ID="Button3" runat="server" Text="提交" CssClass="btn btn-primary" Style="width: 100%" />
        </div>
        <div class="col-md-2 mb-3">
            <asp:Button ID="Button4" runat="server" Text="重置" CssClass="btn btn-primary" Style="width: 100%" />
        </div>
    </div>
    <div id="gridSystemModal" class="modal fade show" tabindex="-1" role="dialog" aria-labelledby="gridModalLabel"">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="gridModalLabel">选择一个作者</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-12">

                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">关闭</button>
                    <button type="button" class="btn btn-success" data-dismiss="modal">添加新作者</button>
                    <button type="button" class="btn btn-primary">确定</button>
                </div>
            </div>
        </div>
    </div>
    <div id="selectpublisher" class="modal fade show" tabindex="-1" role="dialog" aria-labelledby="gridModalLabel"">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="gridModalLabel">选择一个出版社</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-12">
                            <table id="authortable" class="table table-bordered dataTable" width="100%" cellspacing="0" role="grid" aria-describedby="dataTable_info" style="width: 100%;">
                                <thead>
                                    <tr>
                                        <th>ID</th>
                                        <th>姓名</th>
                                    </tr>
                                </thead>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">关闭</button>
                    <button type="button" class="btn btn-success" data-dismiss="modal">添加新出版社</button>
                    <button type="button" class="btn btn-primary">确定</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <script src="vendor/datatables/jquery.dataTables.min.js"></script>
    <script src="vendor/datatables/dataTables.bootstrap4.min.js"></script>
    <script>
        $(document).ready(function () {
            $('#authortable').DataTable({
                "ajax": {
                    url: "/Dashboard/api/getallauthor.ashx",
                    dataSrc: '',
                },
                "columns": [
                    { data: "id" },
                    { data: "name" },
                ],
            });

            $('#publishertable').DataTable({
                "ajax": {
                    url: "/Dashboard/api/getallpublisher.ashx",
                    dataSrc: '',
                },
                "columns": [
                    { data: "id" },
                    { data: "name" },
                ],
            });
        });
    </script>
</asp:Content>
