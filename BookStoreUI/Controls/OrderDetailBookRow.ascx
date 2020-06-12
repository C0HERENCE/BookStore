<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrderDetailBookRow.ascx.cs" Inherits="BookStoreUI.Controls.OrderDetailBookRow" %>
<div class="row m-2">
        <div class="col">
            <div class="card card-2">
                <div class="card-body">
                    <div class="media">
                        <div class="media-body my-auto text-right">
                            <div class="row my-auto flex-column flex-md-row">
                                <div class="col my-auto">
                                    <asp:PlaceHolder runat="server" ID="holder" OnPreRender="holder_PreRender">

                                    </asp:PlaceHolder>
                                    <asp:Label runat="server" ID="txtEx" Visible="false" Text="等3本书" CssClass="small"></asp:Label>

                                </div>
                                <div class="col my-auto"> <small>订单号 : 
                                    <asp:Label ID="txtID" runat="server" Text="Label" OnPreRender="txtID_PreRender"></asp:Label>
                                                          </small></div>
                                <div class="col my-auto"> <small>下单时间 : 
                                    <asp:Label ID="txtTime" runat="server" Text="Label" OnPreRender="txtTime_PreRender"></asp:Label>
                                                          </small></div>
                                <div class="col my-auto">
                                    <h6 class="mb-0">
                                        <asp:Label ID="txtTotal" runat="server" Text="Label" OnPreRender="txtTotal_PreRender"></asp:Label>
                                        元</h6>
                                </div>
                            </div>
                        </div>
                    </div>
                    <hr class="my-3 ">
                    <div class="row">
                        <div class="col-md-3 mb-3">
                            <small>
                                <span>
                                    <i class=" ml-2 fa fa-refresh" aria-hidden="true">
                                        <asp:HyperLink ID="linkDetail" runat="server" CssClass="ml-2 fa fa-refresh" OnPreRender="linkDetail_PreRender">查看详情</asp:HyperLink>
                                    </i>
                                </span>
                            </small>
                        </div>
                        <div class="col mt-auto">
                            <div class="progress my-auto">
                                <asp:Panel ID="progress" runat="server" cssclass="progress-bar progress-bar rounded" OnPreRender="progress_PreRender">
                                </asp:Panel>
                            </div>
                            <div class="media row justify-content-between ">
                                <div class="col-auto text-right">
                                    <span>
                                        <small class="text-right mr-sm-2">用户下单</small> 
                                        <i class="fa fa-circle active"></i> 
                                    </span>
                                </div>
                                <div class="flex-col"> <span> <small class="text-right mr-sm-2">管理员确认</small><i class="fa fa-circle active"></i></span></div>
                                <div class="flex-col"> <span> <small class="text-right mr-sm-2">运输中</small><i class="fa fa-circle active"></i></span></div>
                                <div class="col-auto flex-col-auto"><small class="text-right mr-sm-2">已签收</small><span> <i class="fa fa-circle"></i></span></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>