function logLoutConfirm(id) {
    layui.use('layer', function () {
        var $ = layui.jquery, layer = layui.layer;
        layer.open({
            type: 1
            , title: false //不显示标题栏
            , closeBtn: false
            , area: '300px;'
            , shade: 0.8
            , id: 'LAY_layuipro' //设定一个id，防止重复弹出
            , btn: ['确定', '取消']
            , btnAlign: 'c'
            , moveType: 1 //拖拽模式，0或者1
            , content: '<div style="padding: 50px; line-height: 22px; background-color: #393D49; color: #fff; font-weight: 300;">确认要退出后台管理系统?</div>'
            , success: function (layero) {
                var btn = layero.find('.layui-layer-btn').find('.layui-layer-btn0');
                btn.on("click", function () {
                    $('#' + id).click();
                });
            }
        });
    });
    return false;
}

$("#allbooktable").ready()
{
    InitializeBookTable();
}
$("#addbookform").ready()
{
    InitializeAddBook();
}
Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
    InitializeBookTable();
    InitializeAddBook();
});

function InitializeBookTable() {
    layui.use('table', function () {
        var table = layui.table;
        var currPage = 1;
        table.render({
            elem: '#allbooktable'
            , id: 'lay_table'
            , toolbar: '#toolbarTopTpl' //开启头部工具栏，并为其绑定左侧模板
            , defaultToolbar: ['filter', 'exports', 'print', { //自定义头部工具栏右侧图标。如无需自定义，去除该参数即可
                title: '提示'
                , layEvent: 'LAYTABLE_TIPS'
                , icon: 'layui-icon-tips'
            }]
            , height: 'full-130'
            , cellMinWidth: 40
            , url: '/public/api/GetAllBooks.ashx' //数据接口
            , page: true
            , limit: 15
            , limits: [15, 30, 60, 100]
            , cols: [[
                { type: 'checkbox' }
                , { field: 'id', title: 'ID', sort: true }
                , { field: 'name', title: '书名' }
                , { field: 'author', title: '作者', sort: true }
                , { field: 'price', title: '原价', sort: true }
                , { field: 'press', title: '出版社' }
                , { field: 'ISBN', title: 'ISBN', sort: true }
                , { field: 'category', title: '分类', sort: true }
                , { field: 'price new', title: '售价' }
                , { field: 'desc', title: '简介', sort: true }
                , { field: 'details', title: '详情介绍', minWidth: 100 }
                , { field: 'stock', title: '库存', sort: true }
                , { field: 'del', title: '状态', sort: true, templet: '#delTpl' }
                , { fixed: 'right', width: 165, align: 'center', toolbar: '#toolbarTpl', templet: '#toolbarTpl' }
            ]]
            , done: function (res, curr, count) {
                currPage = curr;
            }
        });
        // 顶栏
        table.on('toolbar(lay_booktable)', function (obj) {
            var checkStatus = table.checkStatus(obj.config.id);
            switch (obj.event) {
                case 'batchDel':
                    var data = checkStatus.data;
                    var bookid = [];
                    data.forEach(function (rowdata) {
                        bookid.push(rowdata.id);
                    })
                    batchdelBook(bookid, 1);
                    break;
                case 'batchEnable':
                    var data = checkStatus.data;
                    var bookid = [];
                    data.forEach(function (rowdata) {
                        bookid.push(rowdata.id);
                    })
                    batchdelBook(bookid, 0);
                    break;
                case 'getCheckLength':
                    var data = checkStatus.data;
                    layer.msg('选中了：' + data.length + ' 个');
                    break;
                case 'isAll':
                    layer.msg(checkStatus.isAll ? '全选' : '未全选');
                    break;
                    return false;
            };
        });
        // 侧栏
        table.on('tool(lay_booktable)', function (row) {
            var rowdata = row.data
            var layEvent = row.event;
            switch (layEvent) {
                case 'detail':
                    layer.msg('查看操作');
                    break;
                case 'del':
                    layer.confirm('确定要' + (rowdata.del == 1 ? '开售“' : '停售“') + rowdata.name + '”吗？', function (index) {
                        layer.close(index);
                        delBook(rowdata, rowdata.del == 1 ? 0 : 1);
                    });
                    break;
                case 'edit':
                    layer.msg('编辑操作');
                    break;
            }
        });

        function delBook(rowdata, newdel) {
            var loading;
            $.ajax({
                url: '/public/api/delbook.ashx',
                data: {
                    bookid: rowdata.id,
                    delnew: newdel
                },
                beforeSend: function () {
                    loading = layer.load(2, { shade: [0.8, '#393D49'] });
                },
                success: function () {
                    if (newdel == 0) {
                        layer.msg('开售成功');
                    }
                    else {
                        layer.msg('停售成功');
                    }
                    table.reload('lay_table', {
                        page: {
                            curr: currPage
                        }
                    }, 'data');
                },
                error: function () {
                    layer.msg('操作失败');
                },
                complete: function () {
                    layer.close(loading);
                }
            });
        }

        function batchdelBook(bookid, newdel) {
            var loading;
            $.ajax({
                url: '/public/api/batcheditbook.ashx',
                data: {
                    type:'del',
                    bookid: bookid,
                    delnew: newdel
                },
                beforeSend: function () {
                    loading = layer.load(2, { shade: [0.8, '#393D49']});
                },
                success: function () {
                    if (newdel == 0) {
                        layer.msg('开售成功');
                    }
                    else {
                        layer.msg('停售成功');
                    }
                    table.reload('lay_table', {
                        page: {
                            curr: currPage
                        }
                    }, 'data');
                },
                error: function () {
                    layer.msg('操作失败');
                },
                complete: function () {
                    layer.close(loading);
                }
            });
        }
    });
}

function InitializeAddBook() {
    layui.use('form', function () {
        var form = layui.form;

        form.on('submit(btnsubmit)', function (data) {
            layer.msg(JSON.stringify(data.field));
            return false;
        });
        $('#selectrole0').ready(getcategory('#selectrole0', 0));
        form.on('select(selectrole0)', function (data) {
            console.log(data.value);
            if (data.value != "-1") {
                $('#selectrole1').ready(getcategory('#selectrole1', data.value));
            }
            else {
                $('#selectrole1').empty();
                form.render('select');
            }
        }); 
        form.on('checkbox(cborigin)', function (data) {
            console.log(data.elem.checked);
            if (data.elem.checked) $('#txtorigin').css('display', 'block'); else $('#txtorigin').css('display', 'none');
        });
        form.on('checkbox(cbsub)', function (data) {
            if (data.elem.checked) $('#txtsub').css('display', 'block'); else $('#txtsub').css('display', 'none');
        });  
        form.render();
        function getcategory(domid, role) {
            $(domid).ready(
                $.ajax({
                    url: '/public/api/GetCategory.ashx',
                    data: { role: role },
                    success(data) {
                        if (data.length > 0) {
                            $(domid).empty(); $(domid).append("<option value='-1'>" + '请选择' + "</option>");
                            for (var i = 0; i < data.length; i++) {
                                var item = data[i];
                                $(domid).append("<option value=" + item.id + ">" + item.name + "</option>");
                            }
                        }
                        form.render('select');
                    },
                    error() {
                        $(domid).empty();
                        form.render('select');
                    }
                }));
        }
    });
    layui.use('laydate', function () {
        var laydate = layui.laydate;
        laydate.render({
            elem: '#test3'
            , type: 'month'
        });
    });
    layui.use('upload', function () {
        var $ = layui.jquery
            , upload = layui.upload;
        var uploadInst = upload.render({
            elem: '#test1'
            , url: 'https://httpbin.org/post' //改成您自己的上传接口
            , before: function (obj) {
                //预读本地文件示例，不支持ie8
                obj.preview(function (index, file, result) {
                    $('#demo1').attr('src', result); //图片链接（base64）
                });
            }
            , done: function (res) {
                //如果上传失败
                if (res.code > 0) {
                    return layer.msg('上传失败');
                }
                //上传成功
            }
            , error: function () {
                //演示失败状态，并实现重传
                var demoText = $('#demoText');
                demoText.html('<span style="color: #FF5722;">上传失败</span> <a class="layui-btn layui-btn-xs demo-reload">重试</a>');
                demoText.find('.demo-reload').on('click', function () {
                    uploadInst.upload();
                });
            }
        });
    });
}