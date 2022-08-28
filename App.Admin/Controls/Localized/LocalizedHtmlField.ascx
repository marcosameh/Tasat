<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LocalizedHtmlField.ascx.cs" Inherits="DynamicData.Admin.Controls.Localized.LocalizedHtmlField" %>
<div class="row">
    <div class="col-md-2">
        <asp:Label ID="lblFieldName" runat="server"></asp:Label>:
    </div>
    <div class="col-md-10">
        <asp:TextBox TextMode="MultiLine" CssClass="summernoteEditor form-control" runat="server" ID="txtHtmlField"></asp:TextBox>
        <asp:Label ID="lblFieldView" runat="server"></asp:Label>
        <asp:RequiredFieldValidator ID="rfvRequired" runat="server" ControlToValidate="txtHtmlField"
            Display="None" ErrorMessage="#FieldLanguage#, #FieldName# is required." Enabled="False"
            EnableClientScript="true" ></asp:RequiredFieldValidator>
        <asp:CustomValidator ID="cvMaxLength" runat="server" ControlToValidate="txtHtmlField"
            Display="Dynamic" ErrorMessage="#FieldLanguage#, #FieldName# max length is {#MaxLength#}."
            Enabled="False" EnableClientScript="true" OnServerValidate="cvMaxLength_ServerValidate"
            ></asp:CustomValidator>
    </div>
</div>
<br />
