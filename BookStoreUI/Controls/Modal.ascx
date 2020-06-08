<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Modal.ascx.cs" Inherits="BookStoreUI.Controls.Modal" %>

<div class="modal fade" id="msgModal" tabindex="-1" role="dialog" aria-labelledby="msgModal" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title">提示</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                    
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-primary" data-dismiss="modal">确定</button>
            </div>
        </div>
    </div>
</div>
<script>
    var showModal = function (text) {
        $('#msgModal .modal-body').text(text);
        $('#msgModal').modal('show');
    }
</script>