<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BookInsert.ascx.cs" Inherits="BookStoreUI.Controls.Dashboard.BookManageControls.BookInsert" %>
<div id="addbookform" class="layui-form layui-form-pane" action="" lay-filter="test1" style="margin-top: 30px">

    <fieldset class="layui-elem-field layui-field-title" style="margin-top: 20px;">
        <legend>添加图书</legend>
    </fieldset>
    <%--书名--%>
    <div class="layui-form-item">
        <label class="layui-form-label">书名</label>
        <div class="layui-input-inline" style="min-width: 300px">
            <input type="text" name="title" placeholder="请输入标题" autocomplete="off" class="layui-input">
        </div>
        <div class="layui-input-inline">
            <input type="checkbox" title="原名" lay-skin="primary" id="cborigin" lay-filter="cborigin">
        </div>
        <div class="layui-input-inline">
            <input type="checkbox" title="子标题" lay-skin="primary" lay-filter="cbsub">
        </div>
    </div>
    <%--原名--%>
    <div class="layui-form-item">
        <div id="txtorigin" style="display:none">
            <label class="layui-form-label">原名</label>
            <div class="layui-input-inline" style="min-width: 300px">
                <input type="text" name="origintitle" placeholder="请输入原名" autocomplete="off" class="layui-input">
            </div>

        </div>
        <div id="txtsub" style="display:none">
            <label class="layui-form-label">子标题</label>
            <div class="layui-input-inline" style="min-width: 300px">
                <input type="text" name="subtitle" placeholder="请输入子标题" autocomplete="off" class="layui-input">
            </div>
        </div>
    </div>
    <%--分类--%>
    <div class="layui-form-item pane">
        <label class="layui-form-label">分类</label>
        <div class="layui-input-inline">
            <select id="selectrole0" lay-filter="selectrole0" lay-search></select>
        </div>
        <div class="layui-input-inline">
            <select id="selectrole1" name="categoryid" lay-filter="selectrole1" lay-search></select>
        </div>
    </div>
    <%--出版社--%>
    <div class="layui-form-item pane">
        <label class="layui-form-label">出版社</label>
        <div class="layui-input-inline">
            <input type="text" id="txtpublisher" name="publisherid" placeholder="查询出版社" autocomplete="off" class="layui-input">
                <div style="display:none;:absolute;top:35px;width:100%;z-index:999;" class="layui-anim layui-anim-upbit layui-transfer-box">
                    <ul class="layui-transfer-data">
                        <li>ffff</li>
                        <li>ffff</li>
                        <li>ffff</li>
                        <li>ffff</li>
                        <li>ffff</li>
                    </ul>
                </div>
        </div>
        <label class="layui-form-label">作者</label>
        <div class="layui-input-inline">
            <input type="text" id="autocomplete-author" name="authorid" placeholder="查询作者" autocomplete="off" class="layui-input">
        </div>
    </div>
    <%--基本信息--%>
    <div class="layui-form-item pane">
        <label class="layui-form-label">ISBN</label>
        <div class="layui-input-inline">
            <input type="text" name="isbn" placeholder="请输入ISBN" autocomplete="off" class="layui-input">
        </div>
        <label class="layui-form-label">出版日期</label>
        <div class="layui-input-inline">
            <input type="text" name="pubdate" class="layui-input" id="test3" autocomplete="off" placeholder="yyyy-MM">
        </div>
        <label class="layui-form-label">页数</label>
        <div class="layui-input-inline" style="width: 100px;">
            <input type="text" name="pages" placeholder="请输入页数" autocomplete="off" class="layui-input">
        </div>
        <label class="layui-form-label">定价</label>
        <div class="layui-input-inline" style="width: 100px;">
            <input type="text" name="price" placeholder="￥" autocomplete="off" class="layui-input">
        </div>
    </div>
    <%--封面--%>
    <div class="layui-form-item pane">
        <label class="layui-form-label">封面图</label>
        <div class="layui-input-block">
            <div class="layui-upload">
                <button type="button" class="layui-btn" id="test1">上传图片</button>
                <div class="layui-upload-list">
                    <img style="width: 92px; height: 92px; margin: 0 10px 10px 0;" id="demo1">
                    <p id="demoText"></p>
                </div>
            </div>
        </div>
    </div>

    <%--详细信息--%>
    <div class="layui-form-item layui-form-text">
        <label class="layui-form-label">详细信息</label>
        <div class="layui-input-block">
            <textarea name="summary" placeholder="请输入内容" class="layui-textarea"></textarea>
        </div>
    </div>
    <%--目录--%>
    <div class="layui-form-item layui-form-text"">
        <label class="layui-form-label">目录</label>
        <div class="layui-input-block">
            <textarea name="catalog" placeholder="请输入内容" class="layui-textarea"></textarea>
        </div>
    </div>
    <div class="layui-form-item">
        <label class="layui-form-label">立即开售</label>
        <div class="layui-input-block">
            <input type="checkbox" name="onsale" lay-skin="switch">
        </div>
    </div>
    <div class="layui-form-item">
        <div class="layui-input-block">
            <button class="layui-btn" lay-submit lay-filter="btnsubmit">立即提交</button>
            <button type="reset" class="layui-btn layui-btn-primary">重置</button>
        </div>
    </div>
</div>
