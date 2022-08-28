<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LocalizedField.ascx.cs" Inherits="DynamicData.Admin.Controls.Localized.LocalizedField" %>
<div class="row">
    <div class="col-md-2">
        <asp:Label ID="lblFieldName" runat="server"></asp:Label>:
    </div>
    <div class="col-md-10">
        <asp:TextBox ID="txtFieldEdit" CssClass="form-control input-sm" runat="server"></asp:TextBox>
        <asp:Label ID="lblFieldView" runat="server"></asp:Label>

        <asp:RequiredFieldValidator ID="rfvRequired" runat="server" ControlToValidate="txtFieldEdit"
            Display="None" ErrorMessage="#FieldLanguage# #FieldName# is required." Enabled="false"
            ></asp:RequiredFieldValidator>

        <asp:RegularExpressionValidator ID="revMaxLength" ControlToValidate="txtFieldEdit"
            runat="server" ValidationExpression="^[\s\S]{0,#MaxLength#}$" Display="None"
            ErrorMessage="#FieldLanguage# #FieldName# max length is {#MaxLength#}." Enabled="false"
             />
    </div>
    <span style="padding-left: 220px;">
        <asp:Label ID="lblFieldHint" runat="server"></asp:Label>
    </span>
</div>
<br />
