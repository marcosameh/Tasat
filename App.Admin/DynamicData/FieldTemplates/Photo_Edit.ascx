<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Photo_Edit.ascx.cs" Inherits="DynamicData.Admin.DynamicData.FieldTemplates.Photo_EditField" %>
<div class="row">
    <div runat="server" id="imageContainer" class="col-sm-2">
        <asp:HyperLink ID="HyperLink1" CssClass="photo" runat="server">
            <asp:Image ID="Image1" CssClass="img-responsive" runat="server" />
        </asp:HyperLink>
    </div>
    <div class="col-sm-10">
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <span runat="server" id="lblHintIcon" class="glyphicon glyphicon-info-sign"></span>
        <asp:Label runat="server" ID="lblHint" Visible="false"></asp:Label>
        <br />
        <label>Maximum upload size is 10MB</label>

        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" EnableClientScript="true"
            ControlToValidate="FileUpload1" Display="None" Enabled="false" />

        <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" EnableClientScript="true"
            ControlToValidate="FileUpload1" Display="None" Enabled="false" />

        <asp:DynamicValidator runat="server" ID="DynamicValidator1" ControlToValidate="FileUpload1"
            Display="None" EnableClientScript="true" />
    </div>
    <p class="bg-danger text-danger photo-warning">Photos are too big</p>
    <input type="hidden" class="max-photos-size" id="hfMaxPhotosSize" runat="server" />
    <script>
        $('document').ready(function () {
            $('.photo-warning').hide();
            $('input:file').bind('change', function () {
                var size = 0;
                $('input:file').each(function () {
                    if (this.files.length > 0)
                        size += this.files[0].size;
                });
                if (size/1024/1024 > parseInt($('.max-photos-size').first().val())) {
                    $('.photo-warning').show();
                    $('.btn.btn-success').addClass('disabled');
                } else {
                    $('.photo-warning').hide();
                    $('.btn.btn-success').removeClass('disabled');
                }
            });
        });
    </script>
</div>

