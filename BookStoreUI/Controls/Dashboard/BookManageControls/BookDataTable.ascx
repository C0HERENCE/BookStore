<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BookDataTable.ascx.cs" Inherits="BookStoreUI.Controls.Dashboard.BookManage.BookDataTable" %>
<table id="allbooktable" lay-filter="lay_booktable"></table>

 
<script type="text/html" id="toolbarTpl">
  <a class="layui-btn layui-btn-xs layui-btn-primary" lay-event="detail">详情</a>
  <a class="layui-btn layui-btn-xs layui-btn-warm" lay-event="edit">修改</a>
</script>

<script type="text/html" id="delTpl">
  {{#  if(d.del == 0){ }}
    <a class="layui-btn layui-btn-xs" lay-event="del">销售中</a>
  {{#  } else { }}
    <a class="layui-btn layui-btn-xs layui-btn-danger" lay-event="del">已停售</a>
  {{#  } }}
</script>

<script type="text/html" id="toolbarTopTpl">
  <div class="layui-btn-container">
    <a class="layui-btn layui-btn-sm" lay-event="batchDel">批量停售</a>
    <a class="layui-btn layui-btn-sm" lay-event="batchEnable">批量开售</a>
  </div>
</script>