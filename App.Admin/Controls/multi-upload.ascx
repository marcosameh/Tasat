<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="multi-upload.ascx.cs" Inherits="DynamicData.Admin.Controls.multi_upload" %>

<div runat="server" id="divSavedPhotos" class="content-wrapper" visible="False">
    <asp:HiddenField ClientIDMode="Static" ID="hdnJsonDeletedPhotos" runat="server" />
    <div class="row form-group">
        <div class="panel panel-primary col-sm-12">
            <div class="panel-body" style="width: 100%; overflow-x: scroll; overflow-y: hidden">
                <asp:ListView runat="server" ID="lvPhotos" ItemType="DynamicData.Admin.Infrastructure.MultiUploadEntities.EntityPhoto"
                    SelectMethod="lvPhotos_GetData">
                    <ItemTemplate>
                        <div id="<%# Item.PhotoId %>" style="height: 100px; display: inline-block; position:relative;">
                            <img runat="server" alt="" src="<%# Item.PhotoPath %>" style="height: 100px;" />
                            <a style="position:absolute;bottom:5px;right:5px;" href="javascript:;" onclick="DeletePropertyPhoto(<%# Item.PhotoId %>)">
                                <i class="fa fa-trash" style="font-size:30px;color:whitesmoke;text-shadow:2px 2px 4px #000000;"></i></a>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>
    </div>
</div>


<div id="divDropZone" class="dropzone">
    <asp:HiddenField ClientIDMode="Static" ID="hdnJsonParam" runat="server" />
    <asp:HiddenField ClientIDMode="Static" ID="hdnPhotoNamesArray" runat="server" />
    <div class="dz-default dz-message"><span>Drop files here to upload</span></div>
</div>
<div>
    <span style="padding-left: 40px;">
        <asp:Label ID="lblFieldHint" runat="server"></asp:Label>
    </span>
</div>