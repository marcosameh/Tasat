<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LocalizedFileUploadField.ascx.cs" Inherits="DynamicData.Admin.Controls.Localized.LocalizedFileUploadField" %>
<table id="LocalizedField">
    <tr>
        <td style="width: 75px;">
            <asp:Label ID="lblFieldName" runat="server"></asp:Label>:
        </td>
        <td>
            <asp:FileUpload runat="server" ID="uplFileUploadField" />
            <asp:HyperLink ID="lnkFieldView" Visible="true" runat="server"></asp:HyperLink>
            <asp:RequiredFieldValidator ID="rfvRequired" runat="server" ControlToValidate="uplFileUploadField"
                Display="Dynamic" ErrorMessage="#FieldLanguage#, #FieldName# is required." Enabled="False"
                EnableClientScript="true" CssClass="DDValidator"></asp:RequiredFieldValidator>
        </td>
    </tr>
</table>
